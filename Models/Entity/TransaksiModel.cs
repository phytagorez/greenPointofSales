using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Models.Entity
{
    public class TransaksiModel
    {
        private string _noInvoice = string.Empty;
        private int _idPengguna;
        private decimal _totalBayar;
        private string _metodePembayaran = "Tunai";

        public List<DetailTransaksiModel> Items { get; private set; }

        public DateTime TglTransaksi { get; set; }

        public string MetodePembayaran
        {
            get { return _metodePembayaran; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Metode pembayaran harus ditentukan.");
                _metodePembayaran = value;
            }
        }

        public TransaksiModel(string noInvoice, int idPengguna)
        {
            this.NoInvoice = noInvoice;
            this.IdPengguna = idPengguna;
            this.Items = new List<DetailTransaksiModel>();
            this.TglTransaksi = DateTime.Now;
        }

        public string NoInvoice
        {
            get { return _noInvoice; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Nomor Invoice wajib diisi.");
                _noInvoice = value;
            }
        }

        public int IdPengguna
        {
            get { return _idPengguna; }
            set
            {
                if (value <= 0) throw new ArgumentException("ID Kasir (Pengguna) tidak valid.");
                _idPengguna = value;
            }
        }

        public decimal TotalHarga
        {
            get
            {
                return Items.Sum(item => item.HitungSubtotal());
            }
        }

        public decimal TotalBayar
        {
            get { return _totalBayar; }
            set
            {
                if (value < TotalHarga)
                {
                    throw new ArgumentException("Uang pembayaran tidak mencukupi total belanja.");
                }
                _totalBayar = value;
            }
        }

        public decimal HitungKembalian()
        {
            return this.TotalBayar - this.TotalHarga;
        }

        public void TambahItem(DetailTransaksiModel itemBaru)
        {
            if (itemBaru == null) throw new ArgumentNullException(nameof(itemBaru));

            var itemAda = Items.FirstOrDefault(x => x.IdProduk == itemBaru.IdProduk);

            if (itemAda != null)
            {
                itemAda.Jumlah += itemBaru.Jumlah;
            }
            else
            {
                Items.Add(itemBaru);
            }
        }
    }
}
