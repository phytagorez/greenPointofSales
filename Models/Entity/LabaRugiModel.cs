using System;

namespace greenPointofSales.Models.Entity
{
    public class LabaRugiModel
    {
        private int _bulan;
        private int _tahun;

        public int Bulan
        {
            get { return _bulan; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Bulan tidak valid! Harap masukkan angka 1 (Januari) hingga 12 (Desember).");
                }
                _bulan = value;
            }
        }

        public int Tahun
        {
            get { return _tahun; }
            set
            {
                int tahunSekarang = DateTime.Now.Year;
                if (value < 2000 || value > tahunSekarang)
                {
                    throw new ArgumentException($"Tahun tidak valid! Harap masukkan tahun antara 2000 hingga {tahunSekarang}.");
                }
                _tahun = value;
            }
        }

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