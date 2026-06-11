using System;
using greenPointofSales.Controllers;
using greenPointofSales.Models.Entity;

namespace greenPointofSales.Services
{
    public class LoginService
    {
        private readonly PenggunaController _penggunaController = new PenggunaController();

        public string ExecuteLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Username dan Password tidak boleh kosong!");
            }

            string? role = _penggunaController.ProsesLogin(username, password);

            if (string.IsNullOrEmpty(role))
            {
                throw new UnauthorizedAccessException("Username/Password salah, atau akun dinonaktifkan.");
            }

            return role;
        }

        public string GetNamaLengkap(string username)
        {
            return SesiPenggunaModel.PenggunaAktif?.NamaLengkap ?? username;
        }
    }
}