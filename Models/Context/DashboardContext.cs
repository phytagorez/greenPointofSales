using greenPointofSales.Helpers;
using Npgsql;
using System;
using System.Data;

namespace greenPointofSales.Models.Context
{
    public class DashboardContext
    {
        public DataTable AmbilLabaRugi()
        {
            string query = "SELECT total_pendapatan, total_hpp, total_rugi_busuk FROM vw_laporan_laba_rugi ORDER BY tahun DESC, bulan DESC LIMIT 1;";
            return DBHelper.EksekusiQuery(query, null);
            
        }

        public int AmbilTotalProdukDiatasRataRata()
        {
            string query = "SELECT COUNT(*) FROM vw_produk_diatas_rata_rata;";
            DataTable dt = DBHelper.EksekusiQuery(query, null);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
        public decimal AmbilTotalTransaksiHariIni()
        {
            string query = @"
                SELECT COALESCE(SUM(total_harga), 0)
                FROM transaksi
                WHERE DATE(tgl_transaksi) = CURRENT_DATE";
            object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToDecimal(result ?? 0);
        }
        public int AmbilJumlahTransaksiHariIni()
        {
            string query = @"
                SELECT COUNT(*)
                FROM transaksi
                WHERE DATE(tgl_transaksi) = CURRENT_DATE";
            object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(result ?? 0);
        }
        public int AmbilTotalKaryawan()
        {
            string query = @"
                SELECT COUNT(*)
                FROM pengguna
                WHERE role = 'Kasir' AND is_active = true";
            object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(result ?? 0);
        }
        public int AmbilTotalProdukBusuk()
        {
            string query = @"
                SELECT COUNT(*)
                FROM produk
                WHERE is_nonaktif = true";
            object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(result ?? 0);
        }
    }
}
