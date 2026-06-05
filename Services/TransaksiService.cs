using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace greenPointofSales.Services
{
    /// <summary>
    /// Service untuk business logic transaksi
    /// Handles: validasi item, stok checking, perhitungan, checkout logic
    /// </summary>
    public class TransaksiService
    {
        private readonly TransaksiContext _context;
        private readonly ProdukContext _produkContext;

        public TransaksiService()
        {
            _context = new TransaksiContext();
            _produkContext = new ProdukContext();
        }

        #region Invoice Generation

        /// <summary>
        /// Generate nomor invoice unique: INV-YYYYMMDD-001
        /// </summary>
        public string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"INV-{tgl}-";
            int count = _context.GetCountInvoice(prefix);
            return prefix + (count + 1).ToString("D3");
        }

        #endregion

        #region Item Management

        /// <summary>
        /// Validasi dan tambah item ke transaksi
        /// Returns: error message jika ada, null jika sukses
        /// </summary>
        public string? ValidasiDanTambahItem(
            TransaksiModel transaksi,
            int idProduk,
            string namaProduk,
            decimal harga,
            decimal stokTersedia,
            Dictionary<int, string> unitMapping)
        {
            if (transaksi == null)
                return "Transaksi tidak valid";

            // Tentukan takaran default berdasarkan satuan
            string satuan = unitMapping.ContainsKey(idProduk) ? unitMapping[idProduk] : "Pcs";
            decimal takaran = satuan.ToLower() == "kg" ? 0.25m : 1m;

            // Check: apakah sudah ada di keranjang?
            var itemAda = transaksi.Items.FirstOrDefault(x => x.IdProduk == idProduk);

            // Check: stok cukup untuk penambahan?
            if (itemAda != null && (itemAda.Jumlah + takaran) > stokTersedia)
                return "Stok barang di toko tidak mencukupi batas pembelian!";

            // Check: stok cukup untuk takaran awal?
            if (stokTersedia < takaran)
                return "Produk jualan saat ini sedang kosong atau tidak cukup untuk takaran awal!";

            // Semua validasi passed, tambah item
            DetailTransaksiModel itemBaru = new DetailTransaksiModel(idProduk, namaProduk, takaran, harga);
            transaksi.TambahItem(itemBaru);

            return null; // Success
        }

        /// <summary>
        /// Update quantity item di keranjang dengan validasi stok
        /// </summary>
        public string? UpdateQuantityItem(
            TransaksiModel transaksi,
            DetailTransaksiModel item,
            decimal deltaQty,
            decimal stokMaks,
            Dictionary<int, string> unitMapping)
        {
            if (transaksi == null || item == null)
                return "Item atau transaksi tidak valid";

            string satuan = unitMapping.ContainsKey(item.IdProduk)
                ? unitMapping[item.IdProduk]
                : "Pcs";

            // Hitung kuantitas baru
            decimal qtyBaru = item.Jumlah + deltaQty;

            // Check: quantity tidak boleh negatif
            if (qtyBaru <= 0)
            {
                transaksi.Items.Remove(item);
                return null; // Item dihapus, bukan error
            }

            // Check: stok cukup?
            if (qtyBaru > stokMaks)
                return $"Stok maksimal {stokMaks:0.##} {satuan}";

            item.Jumlah = qtyBaru;
            return null; // Success
        }

        /// <summary>
        /// Remove item dari keranjang
        /// </summary>
        public void RemoveItemFromCart(TransaksiModel transaksi, DetailTransaksiModel item)
        {
            if (transaksi != null && item != null)
                transaksi.Items.Remove(item);
        }

        #endregion

        #region Payment Validation

        /// <summary>
        /// Validasi pembayaran tunai
        /// Returns: error message jika ada, null jika valid
        /// </summary>
        public string? ValidasiPembayaranTunai(decimal uangBayar, decimal totalBelanja)
        {
            if (uangBayar < totalBelanja)
                return "Uang tunai yang diinput tidak mencukupi!";

            return null; // Valid
        }

        /// <summary>
        /// Hitung kembalian untuk pembayaran tunai
        /// </summary>
        public decimal HitungKembalian(decimal uangBayar, decimal totalBelanja)
        {
            return uangBayar - totalBelanja;
        }

        /// <summary>
        /// Parse input uang dari textbox
        /// Returns: error message jika gagal parse
        /// </summary>
        public string? ParseAndValidateNominal(string input, out decimal nominal)
        {
            nominal = 0;

            if (string.IsNullOrWhiteSpace(input))
                return "Masukkan nominal uang pembayaran";

            if (!decimal.TryParse(input, out nominal))
                return "Format nominal uang tidak valid (gunakan angka)";

            if (nominal <= 0)
                return "Nominal harus lebih dari 0";

            return null; // Valid
        }

        #endregion

        #region Checkout Process

        /// <summary>
        /// Validasi keranjang sebelum checkout
        /// </summary>
        public string? ValidasiSebelumCheckout(TransaksiModel transaksi)
        {
            if (transaksi == null)
                return "Data transaksi tidak tersedia";

            if (transaksi.Items == null || transaksi.Items.Count == 0)
                return "Keranjang belanja masih kosong!";

            return null; // Valid
        }

        /// <summary>
        /// Proses checkout lengkap: simpan transaksi + update stok
        /// </summary>
        public bool ExecuteCheckout(TransaksiModel transaksi)
        {
            if (transaksi == null || transaksi.Items.Count == 0)
                return false;

            try
            {
                // Insert header transaksi
                int newIdTransaksi = _context.InsertHeader(transaksi);

                if (newIdTransaksi > 0)
                {
                    // Insert detail items
                    foreach (var item in transaksi.Items)
                    {
                        item.IdTransaksi = newIdTransaksi;
                        _context.InsertDetail(item);

                        // Update stok produk
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

        #endregion

        #region Helpers

        public string GetSatuan(int idProduk, Dictionary<int, string> unitMapping)
        {
            return unitMapping.ContainsKey(idProduk) ? unitMapping[idProduk] : "Pcs";
        }

        public decimal GetTakaran(string satuan)
        {
            return satuan.ToLower() == "kg" ? 0.25m : 1m;
        }

        #endregion
    }
}