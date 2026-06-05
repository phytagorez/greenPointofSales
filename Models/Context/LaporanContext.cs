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
            // Query ke DataGridView sekarang MURNI tembak ke VIEW baru, super bersih!
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

        public DataTable AmbilWidgetPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            // Widget tembak langsung ke tabel asal agar total duit & nota selalu akurat 100%
            string query = @"
                SELECT 
                    COALESCE(SUM(total_harga), 0) AS total_penjualan,
                    COUNT(id_transaksi) AS total_transaksi
                FROM transaksi
                WHERE tgl_transaksi::date BETWEEN @dari AND @sampai";

            if (metodeBayar == "Tunai")
            {
                query += " AND LOWER(metode_pembayaran) = 'tunai'";
            }
            else if (metodeBayar == "Non-Tunai")
            {
                query += " AND (LOWER(metode_pembayaran) != 'tunai' OR metode_pembayaran IS NULL)";
            }

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("dari", dari.Date),
                new NpgsqlParameter("sampai", sampai.Date)
            };

            return DBHelper.EksekusiQuery(query, parameters);
        }

        public DataTable AmbilGrafikPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            // Grafik tembak ke tabel asal agar tiang diagramnya tidak error
            string query = @"
                SELECT 
                    tgl_transaksi::date AS tanggal,
                    SUM(total_harga) AS total
                FROM transaksi
                WHERE tgl_transaksi::date BETWEEN @dari AND @sampai";

            if (metodeBayar == "Tunai")
            {
                query += " AND LOWER(metode_pembayaran) = 'tunai'";
            }
            else if (metodeBayar == "Non-Tunai")
            {
                query += " AND (LOWER(metode_pembayaran) != 'tunai' OR metode_pembayaran IS NULL)";
            }

            query += " GROUP BY tgl_transaksi::date ORDER BY tanggal ASC";

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

            // Jika data tidak ditemukan untuk bulan tersebut, kembalikan nilai 0 (default)
            if (dt.Rows.Count == 0)
                return new LabaRugiModel(bulan, tahun, 0, 0, 0);

            // Mapping dari DataTable ke Model LabaRugi
            DataRow row = dt.Rows[0];
            return new LabaRugiModel(
                bulan,
                tahun,
                Convert.ToDecimal(row["total_pendapatan"]),
                Convert.ToDecimal(row["total_hpp"]),
                Convert.ToDecimal(row["total_rugi_busuk"])
            );
        }
    }
}