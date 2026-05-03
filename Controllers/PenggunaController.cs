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

            using var conn = DBHelper.BukaKoneksi();
            using var cmd = new NpgsqlCommand("CALL sp_tambah_karyawan(@u, @p, @n, @r)", conn);

            cmd.Parameters.AddWithValue("u", pengguna.Username);
            cmd.Parameters.AddWithValue("p", pengguna.Password);
            cmd.Parameters.AddWithValue("n", pengguna.NamaLengkap);
            cmd.Parameters.AddWithValue("r", pengguna.Role);

            cmd.ExecuteNonQuery();
        }

        public DataTable DapatkanSemuaKaryawan()
        {
            using var conn = DBHelper.BukaKoneksi();
            using var adapter = new NpgsqlDataAdapter("SELECT username, nama_lengkap, role, is_active FROM pengguna", conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void UbahStatusAktif(string username, bool statusBaru)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username tidak boleh kosong.");
            }

            using var conn = DBHelper.BukaKoneksi();
            using var cmd = new NpgsqlCommand("UPDATE pengguna SET is_active = @status WHERE username = @u", conn);

            cmd.Parameters.AddWithValue("status", NpgsqlDbType.Boolean, statusBaru);
            cmd.Parameters.AddWithValue("u", NpgsqlDbType.Varchar, username.Trim());

            if (cmd.ExecuteNonQuery() == 0)
            {
                throw new Exception($"Username '{username}' tidak ditemukan.");
            }
        }
    }
}