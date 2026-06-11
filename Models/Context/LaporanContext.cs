using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;
using System.Data;

namespace greenPointofSales.Models.Context
{
    public class LaporanContext
    {
        public DataTable AmbilLaporanPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            string query = @"
                SELECT 
                    no_invoice AS ""No Invoice"", 
                    tgl_transaksi AS ""Tanggal"", 
                    nama_kasir AS ""Kasir"",
                    nama_produk AS ""Produk"", 
                    nama_kategori AS ""Kategori"", 
                    subtotal AS ""Subtotal"",
                    metode_pembayaran AS ""Metode""
                FROM vw_laporan_penjualan
                WHERE tgl_transaksi::date BETWEEN @dari AND @sampai";

            if (metodeBayar == "Tunai")
            {
                query += " AND LOWER(metode_pembayaran) = 'tunai'";
            }
            else if (metodeBayar == "Non-Tunai")
            {
                query += " AND (LOWER(metode_pembayaran) != 'tunai')";
            }

            query += " ORDER BY tgl_transaksi DESC";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("dari", dari.Date),
                new NpgsqlParameter("sampai", sampai.Date)
            };

            return DBHelper.EksekusiQuery(query, parameters);
        }

        public LabaRugiModel AmbilLabaRugi(int bulan, int tahun)
        {
            string query = @"SELECT total_pendapatan, total_hpp, total_rugi_busuk 
                             FROM vw_laporan_laba_rugi 
                             WHERE bulan = @bulan AND tahun = @tahun";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("bulan", bulan),
                new NpgsqlParameter("tahun", tahun)
            };

            DataTable dt = DBHelper.EksekusiQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return new LabaRugiModel(bulan, tahun, 0, 0, 0);

            DataRow row = dt.Rows[0];
            return new LabaRugiModel(
                bulan,
                tahun,
                Convert.ToDecimal(row["total_pendapatan"]),
                Convert.ToDecimal(row["total_hpp"]),
                Convert.ToDecimal(row["total_rugi_busuk"])
            );
        }

        public int AmbilTotalProdukKurangLaku()
        {
            string query = "SELECT COUNT(*) FROM vw_produk_kurang_laku;";
            DataTable dt = DBHelper.EksekusiQuery(query, null);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
    }
}