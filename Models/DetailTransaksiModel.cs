using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Models
{
    public interface INotaItem
    {
        decimal HitungSubtotal();
    }

    public abstract class EntitasDetail : INotaItem
    {
        private int _idProduk;
        private int _jumlah;
        private decimal _hargaSatuan;

        // Constructor di Abstract Class untuk memaksa validasi awal
        protected EntitasDetail(int idProduk, string namaProduk, int jumlah, decimal hargaSatuan)
        {
            this.IdProduk = idProduk;
            this.NamaProduk = namaProduk;
            this.Jumlah = jumlah;
            this.HargaSatuan = hargaSatuan;
        }

        public int IdProduk
        {
            get { return _idProduk; }
            set
            {
                if (value <= 0) throw new ArgumentException("ID Produk harus valid.");
                _idProduk = value;
            }
        }

        public string NamaProduk { get; set; } = string.Empty;

        public virtual int Jumlah
        {
            get { return _jumlah; }
            set
            {
                if (value <= 0) throw new ArgumentException("Jumlah minimal 1.");
                _jumlah = value;
            }
        }

        public virtual decimal HargaSatuan
        {
            get { return _hargaSatuan; }
            set
            {
                if (value < 0) throw new ArgumentException("Harga tidak boleh negatif.");
                _hargaSatuan = value;
            }
        }

        public decimal HitungSubtotal()
        {
            return this.Jumlah * this.HargaSatuan;
        }
    }

    public class DetailTransaksiModel : EntitasDetail
    {
        // Menggunakan keyword 'base' untuk melempar parameter ke EntitasDetail
        public DetailTransaksiModel(int idProduk, string namaProduk, int jumlah, decimal hargaSatuan)
            : base(idProduk, namaProduk, jumlah, hargaSatuan) { }
    }
}
