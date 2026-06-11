using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using System;
using System.Data;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormProduk : Form
    {
        private readonly ProdukController _controller = new();

        public FormProduk()
        {
            InitializeComponent();
            UIHelper.IkatNavigasiMenu(this);

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

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = tbSearchBar.Text.Trim();

                if (!string.IsNullOrEmpty(keyword))
                {
                    DataTable dtHasilCari = _controller.CariProdukNama(keyword);
                    dgvProduk.DataSource = dtHasilCari;
                }
                else
                {
                    dgvProduk.DataSource = _controller.DapatkanSemuaProduk();
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error($"Gagal mencari produk: {ex.Message}");
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbKategori.SelectedIndex == -1 || cmbSatuan.SelectedIndex == -1)
            {
                UIHelper.Peringatan("Pastikan Kategori dan Satuan sudah dipilih!");
                return;
            }

            if (decimal.TryParse(txtStok.Text.Replace(',', '.'), out decimal nilaiStok))
            {
                try
                {
                    var produkBaru = new ProdukModel
                    {
                        NamaProduk = txtNamaProduk.Text.Trim(),
                        IdKategori = Convert.ToInt32(cmbKategori.SelectedValue),
                        HargaBeli = Convert.ToDecimal(txtHargaBeli.Text),
                        HargaJual = Convert.ToDecimal(txtHargaJual.Text),
                        Stok = nilaiStok,
                        Satuan = cmbSatuan.SelectedItem?.ToString() ?? "Pcs"
                    };

                    produkBaru.GenerateKodeOtomatis();
                    _controller.TambahProduk(produkBaru);

                    UIHelper.Sukses("Produk baru berhasil disimpan!");

                    MuatDataProduk();
                    BersihkanForm();
                }
                catch (Exception ex)
                {
                    UIHelper.Error(ex.Message);
                }
            }
            else
            {
                UIHelper.Peringatan("Format stok tidak valid. Gunakan angka (contoh: 4,5 atau 4.5).");
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
            cmbSatuan.SelectedIndex = -1;
            txtNamaProduk.Focus();
        }
    }
}