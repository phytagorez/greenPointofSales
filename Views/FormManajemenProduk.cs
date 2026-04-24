using System;
using System.Data;
using System.Windows.Forms;
using greenPointofSales.Models;
using greenPointofSales.Controllers;

namespace greenPointofSales.Views
{
    public partial class FormManajemenProduk : Form
    {
        private ProdukController controller;

        public FormManajemenProduk()
        {
            InitializeComponent();
            this.controller = new ProdukController();

            // Setup Tabel biar rapi & PBO (Encapsulation UI)
            this.dgvProduk.ReadOnly = true;
            this.dgvProduk.AllowUserToAddRows = false;
            this.dgvProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Muat data saat pertama kali form terbuka
            this.MuatKategori();
            this.MuatDataProduk();
        }

        private void MuatKategori()
        {
            try
            {
                // Ambil data dari Controller (MVC)
                this.cmbKategori.DataSource = this.controller.DapatkanKategori();
                this.cmbKategori.DisplayMember = "nama_kategori";
                this.cmbKategori.ValueMember = "id_kategori";
                this.cmbKategori.SelectedIndex = -1; // Biar awal-awal kosong
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kategori: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDataProduk()
        {
            try
            {
                this.dgvProduk.DataSource = null;
                this.dgvProduk.DataSource = this.controller.DapatkanSemuaProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat tabel: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                // Diagnosis: Intip dulu apa yang dibaca C# dari TextBox kamu
                // MessageBox.Show($"Beli: {txtHargaBeli.Text}, Jual: {txtHargaJual.Text}"); // Hapus tanda // ini buat ngetes

                ProdukModel produkBaru = new ProdukModel();

                // 1. SET HARGA BELI DULU (Wajib pertama agar HargaJual punya pembanding)
                produkBaru.HargaBeli = decimal.Parse(this.txtHargaBeli.Text.Trim());

                // 2. SET HARGA JUAL (Di sini validasi Model akan otomatis ngecek HargaBeli)
                produkBaru.HargaJual = decimal.Parse(this.txtHargaJual.Text.Trim());

                // 3. Sisanya bebas
                produkBaru.IdKategori = Convert.ToInt32(this.cmbKategori.SelectedValue);
                produkBaru.NamaProduk = this.txtNamaProduk.Text.Trim();
                produkBaru.TambahStokAwal(int.Parse(this.txtStok.Text.Trim()));
                produkBaru.GenerateKodeOtomatis();

                this.controller.TambahProduk(produkBaru);
                MessageBox.Show("Berhasil Simpan!");
                MuatDataProduk();
            }
            catch (Exception ex)
            {
                // Kalau error, dia bakal kasih tahu errornya di mana
                MessageBox.Show("Ada Masalah: " + ex.Message, "Sistem Menolak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBusuk_Click(object sender, EventArgs e)
        {
            if (dgvProduk.SelectedRows.Count > 0)
            {
                // Ambil ID dan Nama dari baris yang dipilih
                int idProduk = Convert.ToInt32(dgvProduk.SelectedRows[0].Cells["id_produk"].Value);
                string namaProduk = dgvProduk.SelectedRows[0].Cells["nama_produk"].Value.ToString();

                DialogResult konfirmasi = MessageBox.Show(
                    $"Apakah yakin ingin menandai '{namaProduk}' sebagai produk busuk? Stok akan otomatis nol dan tidak muncul di kasir.",
                    "Konfirmasi Produk Busuk",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (konfirmasi == DialogResult.Yes)
                {
                    try
                    {
                        this.controller.TandaiProdukBusuk(idProduk);
                        MessageBox.Show("Produk berhasil ditandai busuk.");
                        MuatDataProduk(); // Refresh tabel biar yang busuk hilang (karena View kita filter)
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih produk di tabel dulu, Jak!");
            }
        }

        private void BersihkanForm()
        {
            this.txtNamaProduk.Clear();
            this.txtHargaBeli.Clear();
            this.txtStok.Clear();
            this.txtStok.Clear();
            this.cmbKategori.SelectedIndex = -1;
            this.txtNamaProduk.Focus();
        }
    }
}
