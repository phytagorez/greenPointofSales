using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public abstract class EntitasDetail : INotaItem
    {
        private int _idTransaksi;
        private int _idProduk;
        private string _namaProduk;
        private decimal _jumlah;
        private decimal _hargaSatuan;

        protected EntitasDetail(int idProduk, string namaProduk, decimal jumlah, decimal hargaSatuan)
        {
            this.IdProduk = idProduk;
            this.NamaProduk = namaProduk;
            this.Jumlah = jumlah;
            this.HargaSatuan = hargaSatuan;
        }

        public int IdTransaksi
        {
            get { return _idTransaksi; }
            set
            {
                if (value < 0) throw new ArgumentException("ID Transaksi tidak valid.");
                _idTransaksi = value;
            }
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

        public string NamaProduk
        {
            get { return _namaProduk; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nama Produk tidak boleh kosong.");
                _namaProduk = value;
            }
        }

        public virtual decimal Jumlah
        {
            get { return _jumlah; }
            set
            {
                if (value <= 0) throw new ArgumentException("Jumlah barang harus lebih dari 0.");
                _jumlah = value;
            }
        }

        public virtual decimal HargaSatuan
        {
            get { return _hargaSatuan; }
            set
            {
                if (value < 0) throw new ArgumentException("Harga satuan tidak boleh negatif.");
                _hargaSatuan = value;
            }
        }

        public decimal Subtotal
        {
            get { return HitungSubtotal(); }
        }

        public decimal HitungSubtotal()
        {
            return this.Jumlah * this.HargaSatuan;
        }
    }
}
