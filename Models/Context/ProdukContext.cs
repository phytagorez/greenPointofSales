using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using Npgsql;
using System;
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
            string query = "CALL sp_tambah_produk(@p_kode, @p_nama, @p_id_kat, @p_harga_beli, @p_harga_jual, @p_stok, @p_satuan)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("p_kode", produk.KodeProduk),
                new NpgsqlParameter("p_nama", produk.NamaProduk),
                new NpgsqlParameter("p_id_kat", produk.IdKategori),
                new NpgsqlParameter("p_harga_beli", produk.HargaBeli),
                new NpgsqlParameter("p_harga_jual", produk.HargaJual),
                new NpgsqlParameter("p_stok", produk.Stok),
                new NpgsqlParameter("p_satuan", produk.Satuan)
            };
            DBHelper.EksekusiNonQuery(query, parameters);
        }

        public DataTable AmbilProdukBerdasarkanNama(string keyword)
        {
            string query = @"
                SELECT p.id_produk, p.kode_produk, p.nama_produk, k.nama_kategori, 
                p.harga_beli, p.harga_jual, p.stok, p.satuan, p.tanggal_masuk, p.is_nonaktif
                FROM produk p
                LEFT JOIN kategori k ON p.id_kategori = k.id_kategori
                WHERE (p.nama_produk ILIKE @keyword OR p.kode_produk ILIKE @keyword) 
                      AND p.is_nonaktif = false
                ORDER BY p.nama_produk";

            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("keyword", "%" + keyword + "%")
            };
            return DBHelper.EksekusiQuery(query, parameters);
        }

        public int DapatkanJumlahStokKritis(decimal batas)
        {
            string query = "SELECT fn_hitung_stok_kritis(@batas)";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("batas", batas)
            };

            object? result = DBHelper.EksekusiScalar(query, parameters);
            return Convert.ToInt32(result ?? 0);
        }

        public decimal AmbilStokProduk(int idProduk)
        {
            string query = "SELECT stok FROM produk WHERE id_produk = @id";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("id", idProduk)
            };
            return Convert.ToDecimal(DBHelper.EksekusiScalar(query, parameters) ?? 0);
        }
    }
}