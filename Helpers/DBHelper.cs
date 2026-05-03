using Npgsql;

namespace greenPointofSales.Helpers
{
    public static class DBHelper
    {
        private const string ConnString = "Host=localhost;Username=postgres;Password=23;Database=greenPOS";

        public static NpgsqlConnection BukaKoneksi()
        {
            var conn = new NpgsqlConnection(ConnString);
            conn.Open();
            return conn;
        }
    }
}
