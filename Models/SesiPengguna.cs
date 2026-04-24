using System;

namespace greenPointofSales.Models
{
    public static class SesiPengguna
    {
        public static string UsernameAktif { get; set; }
        public static string RoleAktif { get; set; }
        public static void Logout()
        {
            UsernameAktif = null;
            RoleAktif = null;
        }
    }
}