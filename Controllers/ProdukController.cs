using System;
using System.Data;
using Npgsql;
using greenPointofSales.Models;

namespace greenPointofSales.Controllers
{
    public class ProdukController
    {
        // Sesuaikan dengan password database-mu
        private string connString = "Host=localhost;Username=postgres;Password=23;Database=greenPOS";

        // ======================================================
        // FUNGSI 1: Ambil data produk untuk DataGridView (Pakai VIEW)
        // ======================================================
        public DataTable DapatkanSemuaProduk()
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                // Memanggil VIEW yang sudah kita perbaiki tadi
                string sql = "SELECT * FROM vw_daftar_produk";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // ======================================================
        // FUNGSI 2: Tambah Produk Baru (Pakai STORED PROCEDURE)
        // ======================================================
        public void TambahProduk(ProdukModel produk)
        {
            using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                // Memanggil Procedure dengan 6 parameter wajib (termasuk p_kode)
                string sql = "CALL sp_tambah_produk(@p_kode, @p_nama, @p_id_kat, @p_harga_beli, @p_harga_jual, @p_stok)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    // Mapping data dari Model ke Parameter SQL
                    cmd.Parameters.AddWithValue("p_kode", produk.KodeProduk);
                    cmd.Parameters.AddWithValue("p_nama", produk.NamaProduk);
                    cmd.Parameters.AddWithValue("p_id_kat", produk.IdKategori);
                    cmd.Parameters.AddWithValue("p_harga_beli", produk.HargaBeli);
                    cmd.Parameters.AddWithValue("p_harga_jual", produk.HargaJual);
                    cmd.Parameters.AddWithValue("p_stok", produk.Stok);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ======================================================
        // FUNGSI 3: Ambil Data Kategori untuk ComboBox
        // ======================================================
        public DataTable DapatkanKategori()
        {
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT id_kategori, nama_kategori FROM kategori", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public void TandaiProdukBusuk(int id)
        {
            using (var conn = new NpgsqlConnection(this.connString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("CALL sp_set_produk_busuk(@p_id)", conn))
                {
                    cmd.Parameters.AddWithValue("p_id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}