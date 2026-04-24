using System;
using System.Windows.Forms;
using greenPointofSales.Models;
using greenPointofSales.Controllers;

namespace greenPointofSales
{
    public partial class FormTambahKaryawan : Form
    {
        private PenggunaController controller;

        public FormTambahKaryawan()
        {
            InitializeComponent();
            this.controller = new PenggunaController(); // Inisialisasi Controller

            this.dgvKaryawan.ReadOnly = true; // Kunci semua sel agar tidak bisa diketik/diceklis
            this.dgvKaryawan.AllowUserToAddRows = false; // Hilangkan baris kosong di paling bawah tabel
            this.dgvKaryawan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            this.MuatDataKaryawan();
        }

        private void MuatDataKaryawan()
        {
            try
            {
                // Kosongkan tabel dulu, baru diisi ulang (mencegah UI nge-bug/nyangkut)
                this.dgvKaryawan.DataSource = null;

                this.dgvKaryawan.DataSource = this.controller.DapatkanSemuaKaryawan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data: " + ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            try
            {
                PenggunaModel penggunaBaru = new PenggunaModel();
                penggunaBaru.Username = this.txtUserBaru.Text;
                penggunaBaru.Password = this.txtPassBaru.Text;
                penggunaBaru.NamaLengkap = this.txtNamaLengkap.Text;

                // Pastikan ComboBox Role tidak kosong sebelum disimpan
                if (this.cmbRole.SelectedItem == null)
                {
                    MessageBox.Show("Pilih Role terlebih dahulu (Owner/Kasir)!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                penggunaBaru.Role = this.cmbRole.SelectedItem.ToString();

                this.controller.TambahKaryawan(penggunaBaru);

                MessageBox.Show($"Akun {penggunaBaru.Role} baru berhasil didaftarkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.MuatDataKaryawan(); // Refresh tabel

                this.BersihkanInputan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNonaktifkan_Click(object sender, EventArgs e)
        {
            if (this.dgvKaryawan.SelectedRows.Count > 0)
            {
                string usernamePilihan = this.dgvKaryawan.SelectedRows[0].Cells["username"].Value.ToString();

                // Ambil status saat ini dari tabel
                bool statusSaatIni = Convert.ToBoolean(this.dgvKaryawan.SelectedRows[0].Cells["is_active"].Value);

                // PROTEKSI: Cek apakah yang dipilih adalah akun utama
                if (usernamePilihan.ToLower() == "ejak")
                {
                    MessageBox.Show("Akun utama (Ejak) tidak bisa diubah statusnya demi keamanan sistem!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                // Cegah menonaktifkan akun sendiri (Self-Deactivation)
                // GANTI 'VariabelSesiLoginKamu' dengan cara kamu menyimpan data user yang sedang login saat ini
                string userYangLagiLogin = SesiPengguna.UsernameAktif;

                if (usernamePilihan == userYangLagiLogin)
                {
                    MessageBox.Show("Anda tidak bisa menonaktifkan akun Anda sendiri yang sedang aktif digunakan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tentukan kata-kata dan status baru secara otomatis
                string aksi = statusSaatIni ? "menonaktifkan" : "mengaktifkan";
                bool statusBaru = !statusSaatIni;

                DialogResult dialog = MessageBox.Show($"Yakin ingin {aksi} akun '{usernamePilihan}'?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        // Panggil Controller dengan status yang baru
                        this.controller.UbahStatusAktifKaryawan(usernamePilihan, statusBaru);
                        MessageBox.Show($"Akun berhasil di-{aksi}!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.MuatDataKaryawan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Gagal {aksi}: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan klik baris karyawan di tabel terlebih dahulu.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvKaryawan_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvKaryawan.SelectedRows.Count > 0)
            {
                // Ambil status is_active dari baris yang tersorot
                bool isActive = Convert.ToBoolean(this.dgvKaryawan.SelectedRows[0].Cells["is_active"].Value);

                // Ubah teks tombol secara real-time
                if (isActive)
                {
                    this.btnNonaktifkan.Text = "Nonaktifkan Akun";
                }
                else
                {
                    this.btnNonaktifkan.Text = "Aktifkan Akun";
                }
            }
        }

        private void BersihkanInputan()
        {
            this.txtUserBaru.Clear();
            this.txtPassBaru.Clear();
            this.txtNamaLengkap.Clear();
            this.cmbRole.SelectedIndex = -1;
        }
    }
}