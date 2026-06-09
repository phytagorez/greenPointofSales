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

        

       
    }
}