using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Models
{
    public class TransaksiModel
    {
        private string _noInvoice = string.Empty;
        private int _idPengguna;
        private decimal _totalBayar;

        // Aggregation: Transaksi "memiliki" daftar DetailTransaksiModel
        public List<DetailTransaksiModel> Items { get; private set; }

        public DateTime TglTransaksi { get; set; }

        // Constructor Wajib: Transaksi tidak boleh tercipta tanpa Invoice dan Kasir
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

        // Properti Read-Only (Hanya getter)
        // Menjumlahkan subtotal dari semua item di List menggunakan LINQ
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

        // Behavior: Hitung Kembalian
        public decimal HitungKembalian()
        {
            return this.TotalBayar - this.TotalHarga;
        }

        // Behavior: Menambah item ke keranjang dengan logika cek duplikat
        public void TambahItem(DetailTransaksiModel itemBaru)
        {
            if (itemBaru == null) throw new ArgumentNullException(nameof(itemBaru));

            // Cari apakah produk yang sama sudah ada di keranjang
            var itemAda = Items.FirstOrDefault(x => x.IdProduk == itemBaru.IdProduk);

            if (itemAda != null)
            {
                // Jika ada, cukup tambahkan jumlahnya saja
                itemAda.Jumlah += itemBaru.Jumlah;
            }
            else
            {
                // Jika belum ada, masukkan sebagai item baru
                Items.Add(itemBaru);
            }
        }
    }
}
