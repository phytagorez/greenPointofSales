using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class DashboardControllercs
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
    }
}
