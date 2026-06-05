using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Data;

namespace greenPointofSales.Controllers
{
    public class LaporanController
    {
        private readonly LaporanContext _context = new LaporanContext();

        public DataTable DapatkanLaporanPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            return _context.AmbilLaporanPenjualan(dari, sampai, metodeBayar);
        }

        public DataTable DapatkanWidgetPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            return _context.AmbilWidgetPenjualan(dari, sampai, metodeBayar);
        }

        public DataTable DapatkanGrafikPenjualan(DateTime dari, DateTime sampai, string metodeBayar)
        {
            return _context.AmbilGrafikPenjualan(dari, sampai, metodeBayar);
        }

        public LabaRugiModel DapatkanLabaRugi(int bulan, int tahun)
        {
            return _context.AmbilLabaRugi(bulan, tahun);
        }
        //public DataTable DapatkanLabaRugiBulanan(int bulan, int tahun)
        //{
        //    return _context.AmbilLabaRugiBulanan(bulan, tahun);
        //}

        //public DataTable DapatkanDetailLabaRugi(int bulan, int tahun)
        //{
        //    return _context.AmbilDetailLabaRugi(bulan, tahun);
        //}
    }
}