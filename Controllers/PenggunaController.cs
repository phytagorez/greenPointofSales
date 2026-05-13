using greenPointofSales.Helpers;
using greenPointofSales.Models;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    //composition
    public class PenggunaController
    {
        public void TambahKaryawan(PenggunaModel pengguna)
        {
            if (pengguna == null)
            {
                throw new ArgumentNullException(nameof(pengguna));
            }

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

            //transaction
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public DataTable DapatkanSemuaKaryawan()
        {
            string query = @"
        SELECT 
            username, 
            nama_lengkap, 
            jenis_kelamin, 
            no_hp, 
            email, 
            tgl_lahir, 
            tgl_mulai_kerja, 
            is_active 
        FROM pengguna
        WHERE role = 'Kasir' 
        ORDER BY tgl_mulai_kerja DESC";

            return DBHelper.EksekusiQuery(query);
        }

        public void UbahStatusAktif(string username, bool statusBaru)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username tidak boleh kosong.");
            }

            string query = "UPDATE pengguna SET is_active = @status WHERE username = @u";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("status", statusBaru),
                new NpgsqlParameter("u", username.Trim())
            };

            if (DBHelper.EksekusiNonQuery(query, parameters) == 0)
            {
                throw new Exception($"Username '{username}' tidak ditemukan.");
            }
        }
    }
}