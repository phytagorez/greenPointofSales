using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormTambahKaryawan : Form
    {
        //composition
        private readonly PenggunaController _controller = new PenggunaController();

        public FormTambahKaryawan()
        {
            InitializeComponent();

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
                MessageBox.Show("Gagal memuat data: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserBaru.Text))
                {
                    MessageBox.Show("Username tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUserBaru.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPassBaru.Text))
                {
                    MessageBox.Show("Password tidak boleh kosong!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassBaru.Focus();
                    return;
                }

                if (cmbJenisKelamin.SelectedItem == null)
                {
                    MessageBox.Show("Jenis Kelamin harus dipilih!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbJenisKelamin.Focus();
                    return;
                }

                var pengguna = new PenggunaModel();

                try
                {
                    pengguna.Username = txtUserBaru.Text.Trim();
                    pengguna.Password = txtPassBaru.Text.Trim();
                    pengguna.NamaLengkap = txtNamaLengkap.Text.Trim();
                    pengguna.NoHp = txtNoHp.Text.Trim();
                    pengguna.Email = txtEmail.Text.Trim();
                    pengguna.TglLahir = dtpTanggalLahir.Value;
                    pengguna.TglMulaiKerja = dtpTanggalMulaiKerja.Value;
                    pengguna.JenisKelamin = cmbJenisKelamin.SelectedItem?.ToString() ?? "";
                    pengguna.Role = "Kasir";
                }
                catch (ArgumentException argEx)
                {
                    MessageBox.Show(
                        $"❌ Validasi data gagal:\n\n{argEx.Message}",
                        "Input Tidak Valid",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                _controller.TambahKaryawan(pengguna);

                MessageBox.Show(
                    $"✅ Akun Kasir atas nama '{pengguna.NamaLengkap}' berhasil didaftarkan!\n\n" +
                    $"Username: {pengguna.Username}\n" +
                    $"Password: {pengguna.Password}\n\n" +
                    $"📌 Catat kredensial ini untuk login kasir nanti.",
                    "Sukses Tambah Karyawan",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                MuatDataKaryawan();
                BersihkanInputan();
            }
            catch (ArgumentException validationEx)
            {
                MessageBox.Show(
                    $"⚠️ Validasi gagal:\n\n{validationEx.Message}",
                    "Peringatan Validasi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            catch (Exception ex)
            {
                string errorDetail = $"❌ Sistem Error:\n\n" +
                    $"Message: {ex.Message}\n\n" +
                    $"Type: {ex.GetType().Name}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}";

                MessageBox.Show(
                    errorDetail,
                    "Error Sistem - Database Problem",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Console.WriteLine("[ERROR] " + errorDetail);
            }
        }

        private void btnNonaktifkan_Click(object sender, EventArgs e)
        {
            if (dgvKaryawan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih baris karyawan di tabel dulu.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string username = dgvKaryawan.SelectedRows[0].Cells["username"]?.Value?.ToString() ?? string.Empty;
            bool statusSaatIni = Convert.ToBoolean(dgvKaryawan.SelectedRows[0].Cells["is_active"]?.Value ?? false);
            string userLogin = SesiPenggunaModel.PenggunaAktif?.Username ?? string.Empty;

            //self-deactivation protection
            if (username.ToLower() == "ejak")
            {
                MessageBox.Show("Akun utama tidak bisa diubah statusnya!", "Akses Ditolak",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (username == userLogin)
            {
                MessageBox.Show("Tidak bisa menonaktifkan akun sendiri!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string aksi = statusSaatIni ? "menonaktifkan" : "mengaktifkan";
            if (MessageBox.Show($"Yakin ingin {aksi} akun '{username}'?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _controller.UbahStatusAktif(username, !statusSaatIni);
                MessageBox.Show($"✅ Akun berhasil di-{aksi}!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatDataKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Gagal {aksi}:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //update button status
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
        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {
            new FormDashboardOwner().ShowDialog();
        }
        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            new FormManajemenProduk().ShowDialog();
        }
        private void btnMenuKatalog_Click(object sender, EventArgs e)
        {
            new FormKatalog().ShowDialog();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            string nama = SesiPenggunaModel.PenggunaAktif?.Username ?? "Pengguna";
            string role = SesiPenggunaModel.PenggunaAktif?.Role ?? "Sistem";

            bool yakinKeluar = UIHelper.Konfirmasi($"Apakah kamu yakin ingin logout dari akun {role} ({nama})?");

            if (yakinKeluar)
            {
                SesiPenggunaModel.Logout();

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    var formAktif = Application.OpenForms[i];

                    if (formAktif != null && formAktif.Name != "FormLogin")
                    {
                        formAktif.Close();
                    }
                }

                Application.OpenForms["FormLogin"]?.Show();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserBaru.Text) || string.IsNullOrWhiteSpace(txtNamaLengkap.Text))
            {
                UIHelper.Peringatan("Silakan pilih karyawan yang ingin diubah terlebih dahulu!");
                return;
            }

            try
            {
                var karyawan = new PenggunaModel
                {
                    Username = txtUserBaru.Text.Trim(),
                    Password = txtPassBaru.Text.Trim(),
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    NoHp = txtNoHp.Text.Trim(),
                    TglLahir = dtpTanggalLahir.Value,
                    JenisKelamin = cmbJenisKelamin.SelectedItem?.ToString() ?? "Laki-laki",
                    Email = txtEmail.Text.Trim()
                };

                _controller.UbahDataKaryawan(karyawan);
                UIHelper.Sukses("Data karyawan berhasil diperbarui!");

                MuatDataKaryawan();
                BersihkanInputan();
                txtUserBaru.ReadOnly = false;
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
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
                MessageBox.Show($"Gagal mencari karyawan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}