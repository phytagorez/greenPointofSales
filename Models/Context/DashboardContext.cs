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
            return DBHelper.EksekusiQuery(query);
            
        }

        public int AmbilTotalProdukDiatasRataRata()
        {
            string query = "SELECT COUNT(*) FROM vw_produk_diatas_rata_rata;";
            DataTable dt = DBHelper.EksekusiQuery(query);
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }
        public decimal AmbilTotalTransaksi()
        {
            string query = @"
                SELECT COALESCE(SUM(total_harga), 0)
                FROM transaksi";
            //object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToDecimal(DBHelper.EksekusiScalar(query) ?? 0);
        }
        public int AmbilJumlahTransaksi()
        {
            string query = @"
                SELECT COUNT(*)
                FROM transaksi";
            //object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(DBHelper.EksekusiScalar(query) ?? 0);
        }
        public int AmbilTotalKaryawan()
        {
            string query = @"
                SELECT COUNT(*)
                FROM pengguna
                WHERE role = 'Kasir' AND is_active = true";
            //object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(DBHelper.EksekusiScalar(query) ?? 0);
        }
        public int AmbilTotalProdukBusuk()
        {
            string query = @"
                SELECT COUNT(*)
                FROM riwayat_stok
                WHERE jenis_transaksi = 'Barang Busuk'";
            //object? result = DBHelper.EksekusiScalar(query, null);
            return Convert.ToInt32(DBHelper.EksekusiScalar(query) ?? 0);
        }
    }
}
