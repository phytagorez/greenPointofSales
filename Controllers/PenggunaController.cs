using greenPointofSales.Helpers;
using greenPointofSales.Models;
using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class PenggunaController
    {
        private readonly PenggunaContext _context = new PenggunaContext();
        private readonly SesiPenggunaContext _sesiContext = new SesiPenggunaContext();

        public string? ProsesLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username dan Password tidak boleh kosong.");
            }

            // KUNCI UTAMA: Pastikan id_pengguna, role, dan nama_lengkap ikut di-SELECT!
            string query = "SELECT id_pengguna, role, nama_lengkap FROM pengguna WHERE username=@u AND password=@p AND is_active=true";

            Npgsql.NpgsqlParameter[] parameters = {
        new Npgsql.NpgsqlParameter("u", username.Trim()),
        new Npgsql.NpgsqlParameter("p", password)
    };

            // Eksekusi ke database
            DataTable dtUser = DBHelper.EksekusiQuery(query, parameters);

            // Jika data tidak ditemukan
            if (dtUser.Rows.Count == 0)
            {
                return null;
            }

            // Pemetaan ke model (Eror kemarin terjadi karena id_pengguna di bawah ini dicari tapi di SELECT atas ga ada)
            var pengguna = new PenggunaModel
            {
                IdPengguna = Convert.ToInt32(dtUser.Rows[0]["id_pengguna"]),
                Username = username.Trim(),
                Role = dtUser.Rows[0]["role"].ToString() ?? "",
                NamaLengkap = dtUser.Rows[0]["nama_lengkap"].ToString() ?? ""
            };

            // Daftarkan ke sesi aktif
            SesiPenggunaModel.Login(pengguna);

            return pengguna.Role;
        }

        public void TambahKaryawan(PenggunaModel pengguna)
        {
            if (pengguna == null)
            {
                throw new ArgumentNullException(nameof(pengguna), "Objek data karyawan kosong.");
            }
            else
            {
                _context.SimpanKaryawan(pengguna);
            }
        }

        public DataTable DapatkanSemuaKaryawan()
        {
            DataTable data = _context.AmbilSemuaKaryawan();

            if (data != null)
            {
                return data;
            }
            else
            {
                return new DataTable();
            }
        }

        public void UbahStatusAktif(string username, bool statusBaru)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username tidak boleh kosong.");
            }
            else
            {
                _context.UpdateStatus(username, statusBaru);
            }
        }
        public void UbahDataKaryawan(PenggunaModel pengguna)
        {
            if (pengguna == null)
            {
                throw new ArgumentNullException(nameof(pengguna));
            }
            _context.UpdateDataKaryawan(pengguna);
        }
        public DataTable CariKaryawan(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return DapatkanSemuaKaryawan();

            return _context.CariKaryawan(keyword);
        }
    }
}