using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;
using System.Data;

namespace greenPointofSales.Models
{
    public class PenggunaContext
    {
        // 1. Validasi Login
        public string? ValidasiLogin(string username, string password)
        {
            string query = "SELECT role FROM pengguna WHERE username = @u AND password = @p AND is_active = true";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("u", username.Trim()),
                new NpgsqlParameter("p", password)
            };

            object? result = DBHelper.EksekusiScalar(query, parameters);
            return result?.ToString();
        }

        // 2. Simpan Karyawan Baru
        public void SimpanKaryawan(PenggunaModel pengguna)
        {
            string query = "CALL sp_tambah_karyawan(@p_u, @p_p, @p_n, @p_hp, @p_tgl, @p_jk, @p_eml)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_u", pengguna.Username),
                new NpgsqlParameter("p_p", pengguna.Password),
                new NpgsqlParameter("p_n", pengguna.NamaLengkap),
                new NpgsqlParameter("p_hp", pengguna.NoHp),
                new NpgsqlParameter("p_tgl", pengguna.TglLahir),
                new NpgsqlParameter("p_jk", pengguna.JenisKelamin),
                new NpgsqlParameter("p_eml", pengguna.Email)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        // 3. Ambil Semua Data Karyawan (Untuk DataGridView)
        public DataTable AmbilSemuaKaryawan()
        {
            string query = @"
                SELECT username, nama_lengkap, jenis_kelamin, no_hp, email, tgl_lahir, tgl_mulai_kerja, is_active 
                FROM pengguna 
                WHERE role = 'Kasir' 
                ORDER BY tgl_mulai_kerja DESC";

            return DBHelper.EksekusiQuery(query);
        }

        // 4. Aktifkan/Nonaktifkan Karyawan
        public void UpdateStatus(string username, bool statusBaru)
        {
            string query = "UPDATE pengguna SET is_active = @status WHERE username = @u";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("status", statusBaru),
                new NpgsqlParameter("u", username.Trim())
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }
    }
}