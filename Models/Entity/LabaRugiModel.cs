using System;

namespace greenPointofSales.Models.Entity
{
    public class LabaRugiModel
    {
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public decimal TotalPendapatan { get; set; } // Uang masuk dari kasir
        public decimal TotalHPP { get; set; }        // Modal barang yang terjual
        public decimal TotalRugiBusuk { get; set; }  // Modal barang yang dibuang karena busuk

        // Encapsulation: Laba Kotor dihitung otomatis (Pendapatan - Modal Terjual)
        public decimal LabaKotor
        {
            get { return TotalPendapatan - TotalHPP; }
        }

        // Encapsulation: Laba Bersih dihitung otomatis (Laba Kotor - Rugi Busuk)
        public decimal LabaBersih
        {
            get { return LabaKotor - TotalRugiBusuk; }
        }

        // Constructor
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