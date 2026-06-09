using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;

namespace greenPointofSales.Models.Context
{
    public class TransaksiContext
    {
        public int GetCountInvoice(string prefix)
        {
            string query = "SELECT COUNT(*) FROM transaksi WHERE no_invoice LIKE @p";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("p", prefix + "%") };
            return Convert.ToInt32(DBHelper.EksekusiScalar(query, parameters) ?? 0);
        }

        public int InsertHeader(TransaksiModel trx)
        {
            string query = @"INSERT INTO transaksi (no_invoice, id_pengguna, tgl_transaksi, total_harga, total_bayar, kembalian, metode_pembayaran) 
                             VALUES (@inv, @idU, @tgl, @total, @bayar, @kembali, @metode) RETURNING id_transaksi";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("inv", trx.NoInvoice),
                new NpgsqlParameter("idU", trx.IdPengguna),
                new NpgsqlParameter("tgl", trx.TglTransaksi),
                new NpgsqlParameter("total", trx.TotalHarga),
                new NpgsqlParameter("bayar", trx.TotalBayar),
                new NpgsqlParameter("kembali", trx.HitungKembalian()),
                new NpgsqlParameter("metode", trx.MetodePembayaran)
            };

            return Convert.ToInt32(DBHelper.EksekusiScalar(query, parameters));
        }

        public void UpdateStok(int idProduk, decimal qty)
        {
            // PENTING: Karena database kamu sudah punya trigger 'trg_after_insert_detail' untuk memotong stok tabel produk otomatis, 
            // fungsi di bawah ini fokus murni untuk mencatat log aktivitas belanja kasir ke tabel riwayat_stok.

            string queryRiwayat = @"INSERT INTO riwayat_stok (id_produk, perubahan_stok, jenis_transaksi, keterangan) 
                                    VALUES (@idP, @perubahan, 'Penjualan', 'Terjual lewat kasir')";

            NpgsqlParameter[] parametersRiwayat = {
                new NpgsqlParameter("idP", idProduk),
                new NpgsqlParameter("perubahan", -qty) // Minus (-) menandakan barang keluar terjual
            };

            DBHelper.EksekusiNonQuery(queryRiwayat, parametersRiwayat);
        }


    }
}