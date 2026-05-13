using Npgsql;

namespace greenPointofSales.Helpers
{
    public static class DBHelper
    {
        private const string ConnString = "Host=localhost;Port=7721;Username=postgres;Password=OLAA12;Database=greenPOS;Include Error Detail=true";

        public static NpgsqlConnection BukaKoneksi()
        {
            var conn = new NpgsqlConnection(ConnString);
            conn.Open();
            return conn;
        }
    }
}