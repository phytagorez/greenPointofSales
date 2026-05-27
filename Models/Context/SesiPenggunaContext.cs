using greenPointofSales.Helpers;
using Npgsql;

namespace greenPointofSales.Models.Context
{
    public class SesiPenggunaContext
    {
        public string? ValidasiLogin(string username, string password)
        {
            string query = "SELECT role FROM pengguna WHERE username = @u AND password = @p AND is_active = true";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("u", username.Trim()),
                new NpgsqlParameter("p", password)
            };

            object? result = DBHelper.EksekusiScalar(query, parameters);
            return result?.ToString();
        }
    }
}