using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class DashboardControllers
    {
        private readonly DashboardContext _context = new DashboardContext();
        public DataTable DapatkanDatalabaRugiDashboard()
        {
            return _context.AmbilLabaRugi();
        }
        public int DapatkanJumlahProdukPopuler()
        {
            return _context.AmbilTotalProdukDiatasRataRata();
        }
        public string DapatkanTotalTransaksiHariIni()
        {
            decimal total = _context.AmbilTotalTransaksiHariIni();
            return total.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
        }
        public string DapatkanJumlahTransaksiHariIni()
        {
            int jumlah = _context.AmbilJumlahTransaksiHariIni();
            return jumlah.ToString() + " Transaksi";
        }

        public string DapatkanTotalKaryawan()
        {
            int total = _context.AmbilTotalKaryawan();
            return total.ToString() + " Orang";
        }

        public string DapatkanTotalProdukBusuk()
        {
            int total = _context.AmbilTotalProdukBusuk();
            return total.ToString() + " Produk";
        }
    }
}
