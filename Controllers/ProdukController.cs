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

        public DataTable DapatkanSemuaProduk()
        {
            return _context.AmbilSemuaProduk();
        }

        public DataTable DapatkanKategori()
        {
            return _context.AmbilKategori();
        }

        public void TambahProduk(ProdukModel produk)
        {
            if (produk == null) throw new ArgumentNullException(nameof(produk));
            _context.TambahProduk(produk);
        }

        public void UbahStatusAktif(int idProduk, bool statusBaru)
        {
            _context.UpdateStatusProduk(idProduk, statusBaru);
        }

        public DataTable DapatkanKatalogProduk(int idKategoriFilter = 0)
        {
            return _context.AmbilKatalog(idKategoriFilter);
        }

        public void UpdateStok(int idProduk, decimal jumlahPerubahan)
        {
            _context.UpdateStok(idProduk, jumlahPerubahan);
        }
        public DataTable CariProdukNama(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return DapatkanSemuaProduk();
            return _context.AmbilProdukBerdasarkanNama(keyword);
        }
    }
}