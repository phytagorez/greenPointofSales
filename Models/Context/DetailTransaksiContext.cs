using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;

namespace greenPointofSales.Models.Context
{
    public class DetailTransaksiContext
    {
        public void InsertDetail(int idTrx, DetailTransaksiModel item)
        {
            string query = "INSERT INTO detail_transaksi (id_transaksi, id_produk, jumlah, harga_satuan, subtotal) VALUES (@idT, @idP, @qty, @harga, @sub)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("idT", idTrx),
                new NpgsqlParameter("idP", item.IdProduk),
                new NpgsqlParameter("qty", item.Jumlah),
                new NpgsqlParameter("harga", item.HargaSatuan),
                new NpgsqlParameter("sub", item.HitungSubtotal())
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }
    }
}