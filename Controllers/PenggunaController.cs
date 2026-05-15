using greenPointofSales.Models;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class PenggunaController
    {
        private readonly PenggunaContext _context = new PenggunaContext();

        public string? AutentikasiLogin(string username, string password)
        {
            // Validasi: Pastikan input tidak kosong atau cuma spasi
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            else if (string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            else
            {
                // Jika input valid, baru tanya ke database
                string? role = _context.ValidasiLogin(username, password);
                return role;
            }
        }

        public void TambahKaryawan(PenggunaModel pengguna)
        {
            // Cek apakah objek pengguna ada
            if (pengguna == null)
            {
                throw new ArgumentNullException(nameof(pengguna), "Objek data karyawan kosong.");
            }
            else
            {
                // Eksekusi penyimpanan
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
                // Return tabel kosong agar Grid/Tabel di UI tidak error 'Null Reference'
                return new DataTable();
            }
        }

        public void UbahStatusAktif(string username, bool statusBaru)
        {
            // Validasi string menggunakan IsNullOrWhiteSpace agar input " " (spasi) tertolak
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username tidak boleh kosong.");
            }
            else
            {
                _context.UpdateStatus(username, statusBaru);
            }
        }
    }
}