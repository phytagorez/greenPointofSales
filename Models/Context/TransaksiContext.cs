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

        public void InsertDetail(DetailTransaksiModel dt)
        {
            string query = @"INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah, harga_satuan, subtotal) 
                             VALUES (@idT, @idP, @qty, @harga, @sub)";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("idT", dt.IdTransaksi),
                new NpgsqlParameter("idP", dt.IdProduk),
                new NpgsqlParameter("qty", dt.Jumlah),
                new NpgsqlParameter("harga", dt.HargaSatuan),
                new NpgsqlParameter("sub", dt.Subtotal)
            };

            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public void UpdateStok(int idProduk, decimal qty)
        {
            // 1. Potong stok
            string queryStok = "UPDATE produk SET stok = stok - @qty WHERE id_produk = @idP";
            NpgsqlParameter[] parametersStok = {
                new NpgsqlParameter("qty", qty),
                new NpgsqlParameter("idP", idProduk)
            };
            DBHelper.EksekusiNonQuery(queryStok, parametersStok);

            // 2. Catat Riwayat
            string queryRiwayat = @"INSERT INTO riwayat_stok (id_produk, perubahan_stok, jenis_transaksi, keterangan) 
                                    VALUES (@idP, @perubahan, 'Penjualan', 'Terjual lewat kasir')";
            NpgsqlParameter[] parametersRiwayat = {
                new NpgsqlParameter("idP", idProduk),
                new NpgsqlParameter("perubahan", -qty)
            };
            DBHelper.EksekusiNonQuery(queryRiwayat, parametersRiwayat);
        }
    }
}