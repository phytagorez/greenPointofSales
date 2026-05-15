using greenPointofSales.Models;
using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class ProdukController
    {
        private readonly ProdukContext _context = new ProdukContext();

        // Mengambil semua produk untuk tabel manajemen produk
        public DataTable DapatkanSemuaProduk()
        {
            return _context.AmbilSemuaProduk();
        }

        // Mengambil daftar kategori untuk ComboBox (dipanggil oleh FormKatalog)
        public DataTable DapatkanKategori()
        {
            return _context.AmbilKategori();
        }

        // Menambah produk baru
        public void TambahProduk(ProdukModel produk)
        {
            if (produk == null) throw new ArgumentNullException(nameof(produk));
            _context.TambahProduk(produk);
        }

        // Mengubah status aktif/nonaktif produk
        public void UbahStatusAktif(int idProduk, bool statusBaru)
        {
            _context.UpdateStatusProduk(idProduk, statusBaru);
        }

        // Mengambil data untuk Card Katalog (dipanggil oleh FormKatalog)
        public DataTable DapatkanKatalogProduk(int idKategoriFilter = 0)
        {
            return _context.AmbilKatalog(idKategoriFilter);
        }

        // Mengupdate stok, baik tambah maupun kurangi/busuk (dipanggil oleh FormKatalog)
        public void UpdateStok(int idProduk, int jumlahPerubahan)
        {
            _context.UpdateStok(idProduk, jumlahPerubahan);
        }
    }
}