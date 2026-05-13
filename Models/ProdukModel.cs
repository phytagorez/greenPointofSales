using System;

namespace greenPointofSales.Models
{
    //kontrak
    public interface IBarangJualan
    {
        string TampilkanDetail();
        void KurangiStok(int jumlah);
    }

    //validasi
    public abstract class EntitasProduk : IBarangJualan
    {
        private string _namaProduk = string.Empty;
        private string _kodeProduk = string.Empty;
        public int IdKategori { get; set; }

        public virtual string NamaProduk
        {
            get { return _namaProduk; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nama Produk tidak boleh kosong.");
                }
                _namaProduk = value;
            }
        }

        public virtual string KodeProduk
        {
            get { return _kodeProduk; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Kode Produk tidak boleh kosong.");
                }
                _kodeProduk = value;
            }
        }

        public abstract string TampilkanDetail();
        public abstract void KurangiStok(int jumlah);
    }

    public class ProdukModel : EntitasProduk
    {
        private decimal _hargaBeli;
        private decimal _hargaJual;
        private int _stok;

        public decimal HargaBeli
        {
            get { return _hargaBeli; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Harga Beli tidak boleh negatif.");
                }
                _hargaBeli = value;
            }
        }

        public decimal HargaJual
        {
            get { return _hargaJual; }
            set
            {
                if (value < HargaBeli)
                {
                    throw new ArgumentException("Harga Jual tidak boleh lebih kecil dari Harga Beli.");
                }
                _hargaJual = value;
            }
        }

        public int Stok
        {
            get { return _stok; }
            private set { _stok = value; }
        }

        public bool IsNonaktif { get; set; }

        //stok
        public void TambahStokAwal(int jumlah)
        {
            if (jumlah < 0)
            {
                throw new ArgumentException("Stok awal tidak boleh negatif!");
            }
            Stok += jumlah;
        }

        //stok busuk
        public void SusutkanBarangBusuk(int jumlahBusuk)
        {
            if (jumlahBusuk > Stok)
            {
                throw new InvalidOperationException("Jumlah busuk melebihi stok!");
            }
            Stok -= jumlahBusuk;

            if (Stok == 0)
            {
                IsNonaktif = true; // Sudah diperbarui
            }
        }

        //kode unik
        public void GenerateKodeOtomatis()
        {
            if (string.IsNullOrEmpty(NamaProduk) || NamaProduk.Length < 3)
            {
                throw new InvalidOperationException("Nama Produk minimal 3 huruf.");
            }

            string singkatan = NamaProduk[..3].ToUpper();
            string angka = Random.Shared.Next(100, 999).ToString();

            KodeProduk = $"{singkatan}-{angka}";
        }

        public override string TampilkanDetail()
        {
            return $"[{KodeProduk}] {NamaProduk} - Rp{HargaJual}";
        }

        public override void KurangiStok(int jumlah)
        {
            if (jumlah > Stok)
            {
                throw new InvalidOperationException("Stok tidak mencukupi.");
            }
            Stok -= jumlah;
        }
    }
}