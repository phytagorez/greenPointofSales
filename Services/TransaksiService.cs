using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using greenPointofSales.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace greenPointofSales.Services
{
    public class TransaksiService
    {
        private readonly TransaksiContext _context;
        private readonly ProdukContext _produkContext;
        private readonly DetailTransaksiContext _detailContext;

        public TransaksiService()
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

        public string? ValidasiDanTambahItem(TransaksiModel transaksi, int idProduk, string namaProduk, decimal jumlah, decimal hargaSatuan)
        {
            if (jumlah <= 0)
            {
                return "Jumlah barang yang dimasukkan harus lebih dari 0!";
            }

            try
            {
                decimal stokTersedia = _produkContext.AmbilStokProduk(idProduk);

                var itemSama = transaksi.Items.FirstOrDefault(x => x.IdProduk == idProduk);
                decimal jumlahDiKeranjang = itemSama?.Jumlah ?? 0;

                if (jumlahDiKeranjang + jumlah > stokTersedia)
                {
                    return $"Stok tidak mencukupi! Sisa stok di toko: {stokTersedia}. Di keranjang Anda sudah ada: {jumlahDiKeranjang}.";
                }

                var detailBaru = new DetailTransaksiModel(idProduk, namaProduk, jumlah, hargaSatuan);
                transaksi.TambahItem(detailBaru);
                return null;
            }
            catch (Exception ex)
            {
                return "Gagal melakukan pengecekan stok produk: " + ex.Message;
            }
        }

        public bool ExecuteCheckout(TransaksiModel transaksi)
        {
            if (transaksi == null || !transaksi.Items.Any())
            {
                throw new InvalidOperationException("Tidak ada barang di dalam keranjang belanja untuk diproses.");
            }

            try
            {
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
                throw new Exception($"Sistem gagal menyimpan data transaksi checkout: {ex.Message}", ex);
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