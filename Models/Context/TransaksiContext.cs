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
            // SINKRONISASI: total_kembali diganti menjadi kembalian sesuai skema baru kamu
            string query = @"INSERT INTO transaksi (no_invoice, id_pengguna, tgl_transaksi, total_harga, total_bayar, kembalian) 
                             VALUES (@inv, @idU, @tgl, @total, @bayar, @kembali) RETURNING id_transaksi";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("inv", trx.NoInvoice),
                new NpgsqlParameter("idU", trx.IdPengguna),
                new NpgsqlParameter("tgl", trx.TglTransaksi),
                new NpgsqlParameter("total", trx.TotalHarga),
                new NpgsqlParameter("bayar", trx.TotalBayar),
                new NpgsqlParameter("kembali", trx.HitungKembalian())
            };
            return Convert.ToInt32(DBHelper.EksekusiScalar(query, parameters));
        }

        public void InsertDetail(int idTrx, DetailTransaksiModel item)
        {
            string query = "INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah, harga_satuan, subtotal) VALUES (@idT, @idP, @qty, @harga, @sub)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("idT", idTrx),
                new NpgsqlParameter("idP", item.IdProduk),
                new NpgsqlParameter("qty", item.Jumlah),
                new NpgsqlParameter("harga", item.HargaSatuan),
                new NpgsqlParameter("sub", item.HitungSubtotal())
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }
    }
}