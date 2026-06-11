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
                SELECT p.id_produk, p.nama_produk, p.harga_jual, p.stok, p.satuan, k.nama_kategori, p.is_nonaktif
                FROM produk p
                LEFT JOIN kategori k ON p.id_kategori = k.id_kategori
                WHERE (p.id_kategori = @p_id OR @p_id = 0) AND p.is_nonaktif = false
                ORDER BY p.nama_produk";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("p_id", idKategoriFilter) };
            return DBHelper.EksekusiQuery(query, parameters);
        }

        public void UpdateStok(int idProduk, decimal jumlahPerubahan, string jenisTransaksi = "Penyesuaian Manual", string keterangan = "Update dari sistem")
        {
            using (var conn = DBHelper.BukaKoneksi())
            using (var tx = conn.BeginTransaction())
            {
                try
                {
                    string queryUpdate = "UPDATE produk SET stok = GREATEST(stok + @jumlah, 0) WHERE id_produk = @id";
                    using (var cmd = new NpgsqlCommand(queryUpdate, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("jumlah", jumlahPerubahan);
                        cmd.Parameters.AddWithValue("id", idProduk);
                        cmd.ExecuteNonQuery();
                    }

                    string queryRiwayat = @"INSERT INTO riwayat_stok (id_produk, perubahan_stok, jenis_transaksi, keterangan) 
                                            VALUES (@id, @jumlah, @jenis, @ket)";
                    using (var cmdHist = new NpgsqlCommand(queryRiwayat, conn, tx))
                    {
                        cmdHist.Parameters.AddWithValue("id", idProduk);
                        cmdHist.Parameters.AddWithValue("jumlah", jumlahPerubahan);
                        cmdHist.Parameters.AddWithValue("jenis", jenisTransaksi);
                        cmdHist.Parameters.AddWithValue("ket", keterangan);
                        cmdHist.ExecuteNonQuery();
                    }

                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    throw;
                }
            }
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

            NpgsqlParameter[] parameters = { new NpgsqlParameter("keyword", "%" + keyword + "%") };
            return DBHelper.EksekusiQuery(query, parameters);
        }

        public int DapatkanJumlahStokKritis(decimal batas)
        {
            string query = "SELECT fn_hitung_stok_kritis(@batas)";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("batas", batas) };
            return Convert.ToInt32(DBHelper.EksekusiScalar(query, parameters) ?? 0);
        }

        public decimal AmbilStokProduk(int idProduk)
        {
            string query = "SELECT stok FROM produk WHERE id_produk = @id";
            NpgsqlParameter[] parameters = { new NpgsqlParameter("id", idProduk) };
            return Convert.ToDecimal(DBHelper.EksekusiScalar(query, parameters) ?? 0);
        }
    }
}