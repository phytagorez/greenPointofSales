using greenPointofSales.Controllers;
using greenPointofSales.Models;
using greenPointofSales.Helpers;
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

            SetupDataGridView();
            
            MuatKategori();
            MuatDataProduk();
        }

        private void SetupDataGridView()
        {
            dgvProduk.ReadOnly = true;
            dgvProduk.AllowUserToAddRows = false;
            dgvProduk.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                UIHelper.Error("Gagal memuat kategori: " + ex.Message);
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
                UIHelper.Error("Gagal memuat tabel: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaProduk.Text) || cmbKategori.SelectedValue == null)
            {
                UIHelper.Peringatan("Nama produk dan Kategori wajib diisi!");
                return;
            }

            if (!decimal.TryParse(txtHargaBeli.Text.Trim(), out decimal hargaBeli) ||
                !decimal.TryParse(txtHargaJual.Text.Trim(), out decimal hargaJual) ||
                !int.TryParse(txtStok.Text.Trim(), out int stok))
            {
                UIHelper.Peringatan("Harga dan Stok harus berupa angka yang valid!");
                return;
            }

            try
            {
                var produk = new ProdukModel
                {
                    NamaProduk = txtNamaProduk.Text.Trim(),
                    IdKategori = Convert.ToInt32(cmbKategori.SelectedValue),
                    HargaBeli = hargaBeli,
                    HargaJual = hargaJual
                };

                produk.TambahStokAwal(stok);
                produk.GenerateKodeOtomatis();

                _controller.TambahProduk(produk);

                UIHelper.Sukses("Produk berhasil disimpan!");

                MuatDataProduk();
                BersihkanForm();
            }
            catch (ArgumentException ex)
            {
                UIHelper.Peringatan(ex.Message);
            }
            catch (Exception ex)
            {
                UIHelper.Error($"Terjadi kesalahan sistem: {ex.Message}");
            }
        }

        private void btnBusuk_Click(object sender, EventArgs e)
        {
            if (dgvProduk.SelectedRows.Count == 0)
            {
                UIHelper.Peringatan("Pilih produk di tabel dulu!");
                return;
            }

            int id = dgvProduk.SelectedRows[0].Cells["id_produk"].Value as int? ?? 0;
            string nama = dgvProduk.SelectedRows[0].Cells["nama_produk"].Value?.ToString() ?? "Produk";
            bool isNonaktif = Convert.ToBoolean(dgvProduk.SelectedRows[0].Cells["is_nonaktif"].Value ?? false);

            //rollback toggle
            bool statusBaru = !isNonaktif;

            string pesan = statusBaru ? $"Nonaktifkan produk {nama}?" : $"Aktifkan kembali produk {nama}?";

            if (UIHelper.Konfirmasi(pesan))
            {
                try
                {
                    _controller.UbahStatusAktif(id, statusBaru);

                    UIHelper.Sukses("Status produk berhasil diperbarui.");
                    MuatDataProduk();
                }
                catch (Exception ex)
                {
                    UIHelper.Error("Gagal memproses data: " + ex.Message);
                }
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