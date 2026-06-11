using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public abstract class EntitasProduk : IBarangJualan
    {
        private string _namaProduk = string.Empty;
        private string _kodeProduk = string.Empty;
        public int IdKategori { get; set; }

        public virtual string NamaProduk
        {
            get => _namaProduk;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nama Produk tidak boleh kosong.");
                _namaProduk = value;
            }
        }

        public virtual string KodeProduk
        {
            get => _kodeProduk;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Kode Produk tidak boleh kosong.");
                _kodeProduk = value;
            }
        }

        public abstract string TampilkanDetail();
        public abstract void KurangiStok(decimal jumlah);
    }
}
