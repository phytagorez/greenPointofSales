using System;

namespace greenPointofSales.Models.Entity
{
    public class LabaRugiModel
    {
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public decimal TotalPendapatan { get; set; } 
        public decimal TotalHPP { get; set; }       
        public decimal TotalRugiBusuk { get; set; }  

        public decimal LabaKotor
        {
            get { return TotalPendapatan - TotalHPP; }
        }

        public decimal LabaBersih
        {
            get { return LabaKotor - TotalRugiBusuk; }
        }

        public LabaRugiModel(int bulan, int tahun, decimal pendapatan, decimal hpp, decimal rugiBusuk)
        {
            Bulan = bulan;
            Tahun = tahun;
            TotalPendapatan = pendapatan;
            TotalHPP = hpp;
            TotalRugiBusuk = rugiBusuk;
        }
    }
}