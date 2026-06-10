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
        public string DapatkanTotalTransaksi()
        {
            decimal total = _context.AmbilTotalTransaksi();
            return total.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
        }
        public string DapatkanJumlahTransaksi()
        {
            int jumlah = _context.AmbilJumlahTransaksi();
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
