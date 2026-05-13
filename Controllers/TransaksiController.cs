using greenPointofSales.Helpers;
using greenPointofSales.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Controllers
{
    public class TransaksiController
    {
        // Behavior: Membuat nomor invoice otomatis berdasarkan tanggal hari ini
        public string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd"); // Format: 20231027
            string prefix = $"INV-{tgl}-";

            // Mencari jumlah transaksi yang sudah ada hari ini
            string query = "SELECT COUNT(*) FROM transaksi WHERE no_invoice LIKE @p";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("p", prefix + "%") };

            object result = DBHelper.EksekusiScalar(query, parameters) ?? 0;
            int urutanNext = Convert.ToInt32(result) + 1;

            // Mengembalikan format: INV-20231027-001
            return prefix + urutanNext.ToString("D3");
        }

        // Method Utama: Menyimpan seluruh objek TransaksiModel
        public void ProsesSimpanTransaksi(TransaksiModel transaksi)
        {
            if (transaksi == null) throw new ArgumentNullException(nameof(transaksi));
            if (transaksi.Items.Count == 0) throw new InvalidOperationException("Tidak ada item di keranjang belanja.");

            try
            {
                // 1. Simpan Header Transaksi dan ambil ID Auto-Increment-nya
                int idTransaksiBaru = SimpanHeader(transaksi);

                // 2. Simpan semua Detail dan Update Stok Produk
                foreach (var detail in transaksi.Items)
                {
                    SimpanDetail(idTransaksiBaru, detail);
                    PotongStokProduk(detail.IdProduk, detail.Jumlah);
                }
            }
            catch (Exception ex)
            {
                // Error dilempar ke UI agar bisa ditampilkan oleh UIHelper.Error
                throw new Exception("Gagal memproses transaksi: " + ex.Message);
            }
        }

        private int SimpanHeader(TransaksiModel trx)
        {
            string query = @"INSERT INTO transaksi (id_pengguna, no_invoice, total_harga, total_bayar, kembalian) 
                             VALUES (@idp, @inv, @total, @bayar, @kembali) RETURNING id_transaksi";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("idp", trx.IdPengguna),
                new NpgsqlParameter("inv", trx.NoInvoice),
                new NpgsqlParameter("total", trx.TotalHarga),
                new NpgsqlParameter("bayar", trx.TotalBayar),
                new NpgsqlParameter("kembali", trx.HitungKembalian())
            };

            return Convert.ToInt32(DBHelper.EksekusiScalar(query, parameters));
        }

        private void SimpanDetail(int idTrx, DetailTransaksiModel item)
        {
            string query = @"INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah, harga_satuan, subtotal) 
                             VALUES (@idT, @idP, @qty, @harga, @sub)";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("idT", idTrx),
                new NpgsqlParameter("idP", item.IdProduk),
                new NpgsqlParameter("qty", item.Jumlah),
                new NpgsqlParameter("harga", item.HargaSatuan),
                new NpgsqlParameter("sub", item.HitungSubtotal())
            };

            DBHelper.EksekusiNonQuery(query, parameters);
        }

        private void PotongStokProduk(int idProduk, int jumlahBeli)
        {
            // Menggunakan fungsi GREATEST agar stok tidak minus di bawah 0 jika ada kesalahan hitung
            string query = "UPDATE produk SET stok = GREATEST(stok - @qty, 0) WHERE id_produk = @id";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("qty", jumlahBeli),
                new NpgsqlParameter("id", idProduk)
            };

            DBHelper.EksekusiNonQuery(query, parameters);
        }
    }
}