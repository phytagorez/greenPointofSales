using System;

namespace greenPointofSales.Models.Entity
{
    //association
    public static class SesiPengguna
    {
        public static PenggunaModel? PenggunaAktif { get; private set; }

        public static void Login(PenggunaModel pengguna)
        {
            if (pengguna == null)
            {
                throw new ArgumentNullException(nameof(pengguna));
            }
            PenggunaAktif = pengguna;
        }

        public static void Logout()
        {
            PenggunaAktif = null;
        }

        public static bool IsLoggedIn()
        {
            return PenggunaAktif != null;
        }
    }
}