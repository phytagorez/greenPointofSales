using greenPointofSales.Helpers;
using Npgsql;
using System.Data;

namespace greenPointofSales.Models.Context
{
    public class SesiPenggunaContext
    {
        public DataTable ValidasiLogin(string username, string password)
        {
            string query = "SELECT id_pengguna, role, nama_lengkap FROM pengguna WHERE username=@u AND password=@p AND is_active=true";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("u", username.Trim()),
                new NpgsqlParameter("p", password)
            };

            return DBHelper.EksekusiQuery(query, parameters);
        }
    }
}