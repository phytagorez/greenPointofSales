using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;
using System.Data;

namespace greenPointofSales.Models
{
    public class PenggunaContext
    {
        public void SimpanKaryawan(PenggunaModel pengguna)
        {
            string query = "CALL sp_tambah_karyawan(@p_u, @p_p, @p_n, @p_hp, @p_tgl::date, @p_jk, @p_eml)";
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

        public DataTable AmbilSemuaKaryawan()
        {
            string query = @"
                SELECT username, nama_lengkap, jenis_kelamin, no_hp, email, tgl_lahir, tgl_mulai_kerja, is_active 
                FROM pengguna 
                WHERE role = 'Kasir' 
                ORDER BY tgl_mulai_kerja DESC";
            return DBHelper.EksekusiQuery(query);
        }

        public void UpdateStatus(string username, bool statusBaru)
        {
            string query = "UPDATE pengguna SET is_active = @status WHERE username = @u";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("status", statusBaru),
                new NpgsqlParameter("u", username.Trim())
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public void UpdateDataKaryawan(PenggunaModel pengguna)
        {
            string query = @"
                UPDATE pengguna 
                SET password = CASE WHEN @p_p = '' THEN password ELSE @p_p END, 
                    nama_lengkap = @p_n, no_hp = @p_hp, tgl_lahir = @p_tgl::date, 
                    jenis_kelamin = @p_jk, email = @p_eml 
                WHERE username = @p_u";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_u", pengguna.Username),
                new NpgsqlParameter("p_p", pengguna.Password ?? string.Empty),
                new NpgsqlParameter("p_n", pengguna.NamaLengkap),
                new NpgsqlParameter("p_hp", pengguna.NoHp),
                new NpgsqlParameter("p_tgl", pengguna.TglLahir),
                new NpgsqlParameter("p_jk", pengguna.JenisKelamin),
                new NpgsqlParameter("p_eml", pengguna.Email)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public DataTable CariKaryawan(string keyword)
        {
            string query = @"
                SELECT username, nama_lengkap, jenis_kelamin, no_hp, email, tgl_lahir, tgl_mulai_kerja, is_active 
                FROM pengguna 
                WHERE role = 'Kasir'
                  AND (LOWER(username) LIKE LOWER(@keyword) OR LOWER(nama_lengkap) LIKE LOWER(@keyword) OR
                       LOWER(email) LIKE LOWER(@keyword) OR LOWER(no_hp) LIKE LOWER(@keyword))
                ORDER BY tgl_mulai_kerja DESC";

            NpgsqlParameter[] parameters = { new NpgsqlParameter("keyword", $"%{keyword}%") };
            return DBHelper.EksekusiQuery(query, parameters);
        }

        public DataTable AmbilKaryawanBerdasarkanNama(string keyword)
        {
            string query = @"
                SELECT username, nama_lengkap, jenis_kelamin, no_hp, email, tgl_lahir, tgl_mulai_kerja, is_active
                FROM pengguna
                WHERE role = 'Kasir' AND (nama_lengkap ILIKE @keyword OR username ILIKE @keyword)
                ORDER BY nama_lengkap";

            NpgsqlParameter[] parameters = { new NpgsqlParameter("keyword", "%" + keyword + "%") };
            return DBHelper.EksekusiQuery(query, parameters);
        }
    }
}