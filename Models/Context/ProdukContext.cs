using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System.Data;

namespace greenPointofSales.Models.Context
{
    public class ProdukContext
    {
        public DataTable AmbilSemuaProduk()
        {
            return DBHelper.EksekusiQuery("SELECT * FROM vw_daftar_produk");
        }

        public DataTable AmbilKategori()
        {
            return DBHelper.EksekusiQuery("SELECT id_kategori, nama_kategori FROM kategori");
        }

        public void TambahProduk(ProdukModel produk)
        {
            string query = "CALL sp_tambah_produk(@p_kode, @p_nama, @p_id_kat, @p_harga_beli, @p_harga_jual, @p_stok)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_kode", produk.KodeProduk),
                new NpgsqlParameter("p_nama", produk.NamaProduk),
                new NpgsqlParameter("p_id_kat", produk.IdKategori),
                new NpgsqlParameter("p_harga_beli", produk.HargaBeli),
                new NpgsqlParameter("p_harga_jual", produk.HargaJual),
                new NpgsqlParameter("p_stok", produk.Stok)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public void UpdateStatusProduk(int idProduk, bool statusBaru)
        {
            string query = "CALL sp_toggle_produk_aktif(@p_id, @p_status)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_id", idProduk),
                new NpgsqlParameter("p_status", statusBaru)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public DataTable AmbilKatalog(int idKategoriFilter)
        {
            string query = @"
                SELECT p.id_produk, p.nama_produk, p.harga_jual, p.stok, k.nama_kategori, p.is_nonaktif
                FROM produk p
                LEFT JOIN kategori k ON p.id_kategori = k.id_kategori
                WHERE (p.id_kategori = @p_id OR @p_id = 0) AND p.is_nonaktif = false
                ORDER BY p.nama_produk";
            NpgsqlParameter[] parameters = {
        new NpgsqlParameter("p_id", idKategoriFilter)
    };

            return DBHelper.EksekusiQuery(query, parameters);
        }

        public void UpdateStok(int idProduk, int jumlahPerubahan)
        {
            string query = "UPDATE produk SET stok = GREATEST(stok + @p_jumlah, 0) WHERE id_produk = @p_id";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_jumlah", jumlahPerubahan),
                new NpgsqlParameter("p_id", idProduk)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }
    }
}