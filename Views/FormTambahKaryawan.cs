using greenPointofSales.Controllers;
using greenPointofSales.Models;
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
                var pengguna = new PenggunaModel();

                //mapping encap
                pengguna.Username = txtUserBaru.Text.Trim();
                pengguna.Password = txtPassBaru.Text.Trim();
                pengguna.NamaLengkap = txtNamaLengkap.Text.Trim();
                pengguna.NoHp = txtNoHp.Text.Trim();
                pengguna.Email = txtEmail.Text.Trim();
                pengguna.TglLahir = dtpTanggalLahir.Value;
                pengguna.TglMulaiKerja = dtpTanggalMulaiKerja.Value;
                pengguna.JenisKelamin = cmbJenisKelamin.SelectedItem?.ToString() ?? "";

                //fixed
                pengguna.Role = "Kasir";

                //dommit db
                _controller.TambahKaryawan(pengguna);

                MessageBox.Show($"Akun Kasir atas nama '{pengguna.NamaLengkap}' berhasil didaftarkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatDataKaryawan();
                BersihkanInputan();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Peringatan Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string userLogin = SesiPengguna.PenggunaAktif?.Username ?? string.Empty;

            //self-deactivation
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
                MessageBox.Show($"Akun berhasil di-{aksi}!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                MuatDataKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal {aksi}: " + ex.Message);
            }
        }

        //update button
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
        }
    }
}