using System;

namespace greenPointofSales.Models
{
    public class ProdukModel
    {
        private int idKategori;
        private string kodeProduk;
        private string namaProduk;
        private decimal hargaBeli;
        private decimal hargaJual;
        private int stok;

        // --- PROPERTIES DENGAN VALIDASI KETAT ---

        public int IdKategori
        {
            get => this.idKategori;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Pilihan Kategori tidak valid! Pastikan Anda sudah memilih kategori di ComboBox.");

                this.idKategori = value;
            }
        }

        public string KodeProduk
        {
            get => this.kodeProduk;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Kode Produk tidak boleh kosong.");
                this.kodeProduk = value;
            }
        }

        public string NamaProduk
        {
            get => this.namaProduk;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nama Produk tidak boleh kosong.");
                this.namaProduk = value;
            }
        }

        public decimal HargaBeli
        {
            get => this.hargaBeli;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Harga Beli tidak mungkin minus!");
                this.hargaBeli = value;
            }
        }

        public decimal HargaJual
        {
            get => this.hargaJual;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Harga Jual tidak boleh minus!");
                if (value < this.hargaBeli)
                    throw new ArgumentException("Peringatan: Harga Jual lebih rendah dari Harga Beli (Rugi)!");
                this.hargaJual = value;
            }
        }

        // STOK DIKUNCI (PRIVATE SET) - Hanya bisa diubah oleh Behavior di bawah
        public int Stok
        {
            get => this.stok;
            private set
            {
                if (value < 0) throw new ArgumentException("Stok tidak bisa di bawah nol.");
                this.stok = value;
            }
        }

        // Properti khusus untuk menandai jika stok habis karena busuk
        public bool IsBusuk { get; private set; }


        // ========================================================
        // BEHAVIOR (PERILAKU OBJEK) - INI YANG BIKIN PPBO BANGET
        // ========================================================

        // 1. Menambah stok saat awal daftar atau kulakan
        // Ganti nama method-nya jadi ini biar sinkron dengan Form
        public void TambahStokAwal(int jumlah)
        {
            if (jumlah < 0) throw new Exception("Stok awal tidak boleh negatif!");
            this.Stok = jumlah;
        }

        // 2. Mengurangi stok karena sayur/buah busuk
        public void SusutkanBarangBusuk(int jumlahBusuk)
        {
            if (jumlahBusuk > this.Stok)
                throw new Exception("Jumlah barang busuk melebihi total stok yang ada!");

            this.Stok -= jumlahBusuk;

            // Logika otomatis: Kalau stok habis karena busuk semua
            if (this.Stok == 0)
            {
                this.IsBusuk = true;
            }
        }

        // 3. Generate Kode Otomatis kalau kasir malas ngetik
        public void GenerateKodeOtomatis()
        {
            if (string.IsNullOrEmpty(this.NamaProduk) || this.NamaProduk.Length < 3)
                throw new Exception("Isi Nama Produk minimal 3 huruf dulu sebelum membuat kode otomatis.");

            string singkatan = this.NamaProduk.Substring(0, 3).ToUpper();
            string randomAngka = new Random().Next(100, 999).ToString();

            // Contoh hasil: PRD-1-SAY-452
            this.KodeProduk = $"PRD-{this.IdKategori}-{singkatan}-{randomAngka}";
        }
    }
}