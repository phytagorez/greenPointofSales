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

        public string? AutentikasiLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            else
            {
                string? role = _sesiContext.ValidasiLogin(username, password);
                return role;
            }
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
    }
}