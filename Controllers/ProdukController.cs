using greenPointofSales.Helpers;
using greenPointofSales.Models;
using Npgsql;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    //composition
    public class ProdukController
    {
        public DataTable DapatkanSemuaProduk()
        {
            using var conn = DBHelper.BukaKoneksi();
            using var adapter = new NpgsqlDataAdapter("SELECT * FROM vw_daftar_produk", conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public DataTable DapatkanKategori()
        {
            using var conn = DBHelper.BukaKoneksi();
            using var adapter = new NpgsqlDataAdapter("SELECT id_kategori, nama_kategori FROM kategori", conn);

            var dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void TambahProduk(ProdukModel produk)
        {
            if (produk == null)
            {
                throw new ArgumentNullException(nameof(produk));
            }

            using var conn = DBHelper.BukaKoneksi();
            using var cmd = new NpgsqlCommand(
                "CALL sp_tambah_produk(@p_kode, @p_nama, @p_id_kat, @p_harga_beli, @p_harga_jual, @p_stok)", conn);

            cmd.Parameters.AddWithValue("p_kode", produk.KodeProduk);
            cmd.Parameters.AddWithValue("p_nama", produk.NamaProduk);
            cmd.Parameters.AddWithValue("p_id_kat", produk.IdKategori);
            cmd.Parameters.AddWithValue("p_harga_beli", produk.HargaBeli);
            cmd.Parameters.AddWithValue("p_harga_jual", produk.HargaJual);
            cmd.Parameters.AddWithValue("p_stok", produk.Stok);

            cmd.ExecuteNonQuery();
        }
        //busuk == 0, not return in kasir
        public void TandaiProdukBusuk(int idProduk)
        {
            using var conn = DBHelper.BukaKoneksi();
            using var cmd = new NpgsqlCommand("CALL sp_set_produk_busuk(@p_id)", conn);
            cmd.Parameters.AddWithValue("p_id", idProduk);
            cmd.ExecuteNonQuery();
        }
    }
}