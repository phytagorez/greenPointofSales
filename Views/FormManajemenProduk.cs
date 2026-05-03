using greenPointofSales.Controllers;
using greenPointofSales.Models;
using System;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    //composition
    public partial class FormManajemenProduk : Form
    {
        private readonly ProdukController _controller = new();

        public FormManajemenProduk()
        {
            InitializeComponent();

            dgvProduk.ReadOnly = true;
            dgvProduk.AllowUserToAddRows = false;
            dgvProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            MuatKategori();
            MuatDataProduk();
        }

        private void MuatKategori()
        {
            try
            {
                cmbKategori.DataSource = _controller.DapatkanKategori();
                cmbKategori.DisplayMember = "nama_kategori";
                cmbKategori.ValueMember = "id_kategori";
                cmbKategori.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat kategori: " + ex.Message, "Error Database",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MuatDataProduk()
        {
            try
            {
                dgvProduk.DataSource = null;
                dgvProduk.DataSource = _controller.DapatkanSemuaProduk();
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
                var produk = new ProdukModel
                {
                    //iterasi harga jual before harga beli
                    HargaBeli = decimal.Parse(txtHargaBeli.Text.Trim()),
                    HargaJual = decimal.Parse(txtHargaJual.Text.Trim()),
                    IdKategori = Convert.ToInt32(cmbKategori.SelectedValue),
                    NamaProduk = txtNamaProduk.Text.Trim()
                };

                //stok & kode unik
                produk.TambahStokAwal(int.Parse(txtStok.Text.Trim()));
                produk.GenerateKodeOtomatis();

                //kirim ke db
                _controller.TambahProduk(produk);

                MessageBox.Show("Produk berhasil disimpan!", "Sukses");
                MuatDataProduk();
                BersihkanForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ada Masalah: " + ex.Message, "Sistem Menolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBusuk_Click(object sender, EventArgs e)
        {
            if (dgvProduk.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih produk di tabel dulu!");
                return;
            }

            //catch from id baru nama
            int id = Convert.ToInt32(dgvProduk.SelectedRows[0].Cells["id_produk"]?.Value ?? 0);
            string nama = dgvProduk.SelectedRows[0].Cells["nama_produk"]?.Value?.ToString() ?? string.Empty;

            //confirm
            if (MessageBox.Show($"Tandai '{nama}' sebagai produk busuk? Stok akan jadi nol.",
                    "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _controller.TandaiProdukBusuk(id);
                MessageBox.Show("Produk berhasil ditandai busuk.");
                MuatDataProduk();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal: " + ex.Message);
            }
        }

        private void BersihkanForm()
        {
            txtNamaProduk.Clear();
            txtHargaBeli.Clear();
            txtHargaJual.Clear();
            txtStok.Clear();
            cmbKategori.SelectedIndex = -1;
            txtNamaProduk.Focus();
        }
    }
}