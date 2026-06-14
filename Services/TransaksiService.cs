using greenPointofSales.Helpers;
using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.ConstrainedExecution;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace greenPointofSales.Services
{
    public class TransaksiService
    {
        private readonly TransaksiContext _context;
        private readonly ProdukContext _produkContext;
        private readonly DetailTransaksiContext _detailContext;

        public TransaksiService() //constructure
        {
            _context = new TransaksiContext();
            _produkContext = new ProdukContext();
            _detailContext = new DetailTransaksiContext();
        }

        public string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"INV-{tgl}-";
            int count = _context.GetCountInvoice(prefix);
            return prefix + (count + 1).ToString("D3");
        }

        public string? ValidasiDanTambahItem(
            TransaksiModel transaksi,
            int idProduk,
            string namaProduk,
            decimal harga,
            decimal stokTersedia,
            Dictionary<int, string> unitMapping)
        {
            if (transaksi == null) return "Transaksi tidak valid";

            string satuan = unitMapping.ContainsKey(idProduk) ? unitMapping[idProduk] : "Pcs";
            decimal takaran = satuan.ToLower() == "kg" ? 0.25m : 1m;

            var itemAda = transaksi.Items.FirstOrDefault(x => x.IdProduk == idProduk);

            if (itemAda != null && (itemAda.Jumlah + takaran) > stokTersedia)
                return "Stok barang di toko tidak mencukupi batas pembelian!";

            if (stokTersedia < takaran)
                return "Produk jualan saat ini sedang kosong atau tidak cukup untuk takaran awal!";

            DetailTransaksiModel itemBaru = new DetailTransaksiModel(idProduk, namaProduk, takaran, harga);
            transaksi.TambahItem(itemBaru);

            return null;
        }

        public string? UpdateQuantityItem(
            TransaksiModel transaksi,
            DetailTransaksiModel item,
            decimal deltaQty,
            decimal stokMaks,
            Dictionary<int, string> unitMapping)
        {
            if (transaksi == null || item == null) return "Item atau transaksi tidak valid";

            string satuan = unitMapping.ContainsKey(item.IdProduk) ? unitMapping[item.IdProduk] : "Pcs";
            decimal qtyBaru = item.Jumlah + deltaQty;

            if (qtyBaru <= 0)
            {
                transaksi.Items.Remove(item);
                return null;
            }

            if (qtyBaru > stokMaks) return $"Stok maksimal {stokMaks:0.##} {satuan}";

            item.Jumlah = qtyBaru;
            return null;
        }

        public string? ValidasiPembayaranTunai(decimal uangBayar, decimal totalBelanja)
        {
            if (uangBayar < totalBelanja) return "Uang tunai yang diinput tidak mencukupi!";
            return null;
        }

        public decimal HitungKembalian(decimal uangBayar, decimal totalBelanja)
        {
            return uangBayar - totalBelanja;
        }

        public string? ParseAndValidateNominal(string input, out decimal nominal)
        {
            nominal = 0;
            if (string.IsNullOrWhiteSpace(input)) return "Masukkan nominal uang pembayaran";
            if (!decimal.TryParse(input, out nominal)) return "Format nominal uang tidak valid (gunakan angka)";
            if (nominal <= 0) return "Nominal harus lebih dari 0";
            return null;
        }

        public string? ValidasiSebelumCheckout(TransaksiModel transaksi)
        {
            if (transaksi == null) return "Data transaksi tidak tersedia";
            if (transaksi.Items == null || transaksi.Items.Count == 0) return "Keranjang belanja masih kosong!";
            return null;
        }

        public bool ExecuteCheckout(TransaksiModel transaksi)
        {
            if (transaksi == null || transaksi.Items.Count == 0) return false;

            try
            {
                foreach (var item in transaksi.Items)
                {
                    decimal stokAktual = _produkContext.AmbilStokProduk(item.IdProduk);
                    if (stokAktual < item.Jumlah) throw new Exception($"Stok produk {item.NamaProduk} tidak mencukupi");
                }

                int newIdTransaksi = _context.InsertHeader(transaksi);
                if (newIdTransaksi > 0)
                {
                    foreach (var item in transaksi.Items)
                    {
                        item.IdTransaksi = newIdTransaksi;
                        _detailContext.InsertDetail(newIdTransaksi, item);
                        _context.UpdateStok(item.IdProduk, item.Jumlah);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception($"Gagal menyimpan transaksi: {ex.Message}", ex);
            }
        }

        public string GetSatuan(int idProduk, Dictionary<int, string> unitMapping)
        {
            return unitMapping.ContainsKey(idProduk) ? unitMapping[idProduk] : "Pcs";
        }

        public decimal GetTakaran(string satuan)
        {
            return satuan.ToLower() == "kg" ? 0.25m : 1m;
        }
    }
}