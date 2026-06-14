using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormManajemenKaryawan : Form
    {
        private readonly PenggunaController _controller = new PenggunaController();

        public FormManajemenKaryawan()
        {
            InitializeComponent();

            UIHelper.IkatNavigasiMenu(this);

            dgvKaryawan.ReadOnly = true;
            dgvKaryawan.AllowUserToAddRows = false;
            dgvKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dtpTanggalLahir.Value = DateTime.Now.AddYears(-17);
            dtpTanggalMulaiKerja.Value = DateTime.Now;

            MuatDataKaryawan();
        }

        private void MuatDataKaryawan()
        {
            try
            {
                dgvKaryawan.DataSource = null;
                dgvKaryawan.DataSource = _controller.DapatkanSemuaKaryawan();

                if (dgvKaryawan.Columns.Count > 0)
                {
                    dgvKaryawan.Columns["username"]!.HeaderText = "Username";
                    dgvKaryawan.Columns["nama_lengkap"]!.HeaderText = "Nama Lengkap";
                    dgvKaryawan.Columns["jenis_kelamin"]!.HeaderText = "L/P";
                    dgvKaryawan.Columns["no_hp"]!.HeaderText = "No. Handphone";
                    dgvKaryawan.Columns["email"]!.HeaderText = "Email";

                    dgvKaryawan.Columns["tgl_lahir"]!.HeaderText = "Tgl. Lahir";
                    dgvKaryawan.Columns["tgl_lahir"]!.DefaultCellStyle.Format = "dd MMM yyyy";

                    dgvKaryawan.Columns["tgl_mulai_kerja"]!.HeaderText = "Mulai Kerja";
                    dgvKaryawan.Columns["tgl_mulai_kerja"]!.DefaultCellStyle.Format = "dd MMM yyyy";

                    dgvKaryawan.Columns["is_active"]!.HeaderText = "Status Aktif";

                    dgvKaryawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidasiFormInput()) return;
            try
            {
                var pengguna = new PenggunaModel(
                    txtUserBaru.Text.Trim(),
                    txtPassBaru.Text.Trim(),
                    txtNamaLengkap.Text.Trim(),
                    txtNoHp.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dtpTanggalLahir.Value,
                    dtpTanggalMulaiKerja.Value,
                    cmbJenisKelamin.SelectedItem?.ToString() ?? "",
                    "Kasir"
                );

                _controller.TambahKaryawan(pengguna);

                UIHelper.Sukses(
                   $"✅ Akun Kasir atas nama '{pengguna.NamaLengkap}' berhasil didaftarkan!\n\n" +
                   $"Username: {pengguna.Username}\n" +
                   $"Password: {pengguna.Password}\n\n" +
                   $"📌 Catat kredensial ini untuk login kasir nanti."
                );

                MuatDataKaryawan();
                BersihkanInputan();
            }
            catch (ArgumentException argEx)
            {
                UIHelper.Peringatan($"Validasi data gagal: {argEx.Message}");
            }
            catch (Exception ex)
            {
                TampilkanDetailErrorSistem(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserBaru.Text) || string.IsNullOrWhiteSpace(txtNamaLengkap.Text))
            {
                UIHelper.Peringatan("Silahkan pilih karyawan yang ingin diubah!");
                return;
            }
            try
            {
                var karyawan = new PenggunaModel(
                    txtUserBaru.Text.Trim(),
                    txtPassBaru.Text.Trim(),
                    txtNamaLengkap.Text.Trim(),
                    txtNoHp.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dtpTanggalLahir.Value,
                    dtpTanggalMulaiKerja.Value,
                    cmbJenisKelamin.SelectedItem?.ToString() ?? "Laki-laki",
                    "Kasir"
                );

                _controller.UbahDataKaryawan(karyawan);
                UIHelper.Sukses("Data Karyawan berhasil diperbarui!");

                MuatDataKaryawan();
                BersihkanInputan();
                txtUserBaru.ReadOnly = false;
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private bool ValidasiFormInput()
        {
            if (string.IsNullOrWhiteSpace(txtUserBaru.Text))
            {
                UIHelper.Peringatan("Username tidak boleh kosong!");
                txtUserBaru.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPassBaru.Text))
            {
                UIHelper.Peringatan("Password tidak boleh kosong!");
                txtPassBaru.Focus();
                return false;
            }
            if (cmbJenisKelamin.SelectedItem == null)
            {
                UIHelper.Peringatan("Jenis kelamin harus dipilih!");
                cmbJenisKelamin.Focus();
                return false;
            }
            return true;
        }

        private void TampilkanDetailErrorSistem(Exception ex)
        {
            string errorDetail = $"Sistem Error:\n\nMessage: {ex.Message}\n\nType: {ex.GetType().Name}\n\nStack Trace:\n{ex.StackTrace}";
            UIHelper.Error(errorDetail);
            Console.WriteLine("[ERROR] " + errorDetail);
        }

        private void btnNonaktifkan_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count == 0)
            {
                UIHelper.Peringatan("Pilih baris karyawan di tabel dulu.");
                return;
            }

            string username = dgvKaryawan.SelectedRows[0].Cells["username"]?.Value?.ToString() ?? string.Empty;
            bool statusSaatIni = Convert.ToBoolean(dgvKaryawan.SelectedRows[0].Cells["is_active"]?.Value ?? false);
            string userLogin = SesiPenggunaModel.PenggunaAktif?.Username ?? string.Empty;

            if (username.ToLower() == "ejak")
            {
                UIHelper.Peringatan("Akun utama tidak bisa diubah statusnya!");
                return;
            }
            if (username == userLogin)
            {
                UIHelper.Peringatan("Tidak bisa menonaktifkan akun sendiri!");
                return;
            }

            string aksi = statusSaatIni ? "menonaktifkan" : "mengaktifkan";

            if (!UIHelper.Konfirmasi($"Yakin ingin {aksi} akun '{username}'?")) return;

            try
            {
                _controller.UbahStatusAktif(username, !statusSaatIni);
                UIHelper.Sukses($"✅ Akun berhasil di-{aksi}!");
                MuatDataKaryawan();
            }
            catch (Exception ex)
            {
                UIHelper.Error($"❌ Gagal {aksi}:\n\n{ex.Message}");
            }
        }

        private void dgvKaryawan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count == 0) return;
            bool isActive = Convert.ToBoolean(dgvKaryawan.SelectedRows[0].Cells["is_active"].Value ?? false);
            btnNonaktifkan.Text = isActive ? "Nonaktifkan Akun" : "Aktifkan Akun";
        }

        private void BersihkanInputan()
        {
            txtUserBaru.Clear();
            txtPassBaru.Clear();
            txtNamaLengkap.Clear();
            txtNoHp.Clear();
            txtEmail.Clear();
            cmbJenisKelamin.SelectedIndex = -1;
            dtpTanggalLahir.Value = DateTime.Now.AddYears(-17);
            dtpTanggalMulaiKerja.Value = DateTime.Now;
            txtUserBaru.Focus();
        }

        private void dgvKaryawan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvKaryawan.Rows[e.RowIndex];

            txtUserBaru.Text = row.Cells["username"].Value?.ToString() ?? string.Empty;
            txtUserBaru.ReadOnly = true;
            txtPassBaru.Text = string.Empty;
            txtNamaLengkap.Text = row.Cells["nama_lengkap"].Value?.ToString() ?? string.Empty;
            txtNoHp.Text = row.Cells["no_hp"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = row.Cells["email"].Value?.ToString() ?? string.Empty;
            cmbJenisKelamin.SelectedItem = row.Cells["jenis_kelamin"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["tgl_lahir"].Value?.ToString(), out DateTime tglLahir))
            {
                dtpTanggalLahir.Value = tglLahir;
            }
        }

        private void tbSearchBar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = tbSearchBar.Text.Trim();

                if (!string.IsNullOrEmpty(keyword))
                {
                    dgvKaryawan.DataSource = _controller.CariKaryawan(keyword);
                }
                else
                {
                    MuatDataKaryawan();
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error($"Gagal mencari karyawan: {ex.Message}");
            }
        }
    }
}