using greenPointofSales.Helpers;
using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Controllers
{
    public class TransaksiController
    {
        private readonly TransaksiContext _trxContext = new TransaksiContext();
        private readonly ProdukContext _produkContext = new ProdukContext();

        public string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"INV-{tgl}-";

            // Mengambil urutan berikutnya
            int jumlahInvoiceHariIni = _trxContext.GetCountInvoice(prefix);
            int urutanNext = jumlahInvoiceHariIni + 1;

            // Format D3 memastikan hasil seperti 001, 002, dst.
            return prefix + urutanNext.ToString("D3");
        }

        public void ProsesSimpanTransaksi(TransaksiModel transaksi)
        {
            // 1. Validasi Objek Utama
            if (transaksi == null)
            {
                throw new ArgumentNullException(nameof(transaksi), "Data transaksi tidak ditemukan.");
            }

            // 2. Validasi Keranjang Belanja (Sangat penting untuk UI)
            if (transaksi.Items == null || transaksi.Items.Count == 0)
            {
                throw new InvalidOperationException("Gagal menyimpan: Keranjang belanja masih kosong.");
            }

            // 3. Simpan Header Transaksi dan ambil ID-nya
            int idTrx = _trxContext.InsertHeader(transaksi);

            if (idTrx > 0)
            {
                // 4. Proses setiap item dalam keranjang
                foreach (var item in transaksi.Items)
                {
                    // Simpan detail transaksi
                    _trxContext.InsertDetail(idTrx, item);

                    // Update stok produk (dikali -1 karena barang keluar/berkurang)
                    int jumlahKeluar = item.Jumlah * -1;
                    _produkContext.UpdateStok(item.IdProduk, jumlahKeluar);
                }
            }
            else
            {
                throw new Exception("Gagal membuat header transaksi di database.");
            }
        }
    }
}