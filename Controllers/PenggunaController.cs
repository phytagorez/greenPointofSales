using greenPointofSales.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace greenPointofSales.Controllers
{
    public class PenggunaController
    {
        private string connString = "Host=localhost;Username=postgres;Password=23;Database=greenPOS";

        // Fungsi Tambah Data
        public void TambahKaryawan(PenggunaModel pengguna)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("CALL sp_tambah_karyawan(@u, @p, @n, @r)", conn))
                {
                    cmd.Parameters.AddWithValue("u", pengguna.Username);
                    cmd.Parameters.AddWithValue("p", pengguna.Password);
                    cmd.Parameters.AddWithValue("n", pengguna.NamaLengkap);
                    cmd.Parameters.AddWithValue("r", pengguna.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Fungsi Ambil Data untuk DataGridView
        public DataTable DapatkanSemuaKaryawan()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                string sql = "SELECT username, nama_lengkap, role, is_active FROM pengguna";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        // Tambahkan fungsi baru ini di dalam class PenggunaController
        public void UbahStatusAktifKaryawan(string username, bool statusAktif)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                string sql = "UPDATE pengguna SET is_active = @status WHERE username = @u";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // PENGAMANAN 1: Tegaskan tipe datanya ke NpgsqlDbType agar PostgreSQL tidak bingung
                    cmd.Parameters.AddWithValue("status", NpgsqlTypes.NpgsqlDbType.Boolean, statusAktif);
                    cmd.Parameters.AddWithValue("u", NpgsqlTypes.NpgsqlDbType.Varchar, username.Trim()); // Tambah .Trim() untuk hapus spasi nyasar

                    // PENGAMANAN 2: Cek apakah ada baris yang berhasil diubah
                    int barisBerubah = cmd.ExecuteNonQuery();

                    if (barisBerubah == 0)
                    {
                        throw new Exception($"Data dengan username '{username}' tidak ditemukan di database atau gagal di-update!");
                    }
                }
            }
        }
    }
}
