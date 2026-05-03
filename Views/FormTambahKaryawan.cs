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
            MuatDataKaryawan();
        }

        private void MuatDataKaryawan()
        {
            try
            {
                dgvKaryawan.DataSource = null;
                dgvKaryawan.DataSource = _controller.DapatkanSemuaKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Pilih Role terlebih dahulu!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var pengguna = new PenggunaModel
                {
                    Username = txtUserBaru.Text,
                    Password = txtPassBaru.Text,
                    NamaLengkap = txtNamaLengkap.Text,
                    Role = cmbRole.SelectedItem?.ToString() ?? string.Empty
                };

                _controller.TambahKaryawan(pengguna);
                MessageBox.Show($"Akun {pengguna.Role} berhasil didaftarkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                MuatDataKaryawan();
                BersihkanInputan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            cmbRole.SelectedIndex = -1;
        }
    }
}