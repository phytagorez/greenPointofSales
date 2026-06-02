using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views;
using Npgsql;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                UIHelper.Peringatan("Username dan Password tidak boleh kosong!");
                return;
            }

            try
            {
                DataTable dtUser = AmbilDataPenggunaDariDb(username, password);

                if (dtUser.Rows.Count == 0)
                {
                    UIHelper.Error("Username/Password salah, atau akun dinonaktifkan.");
                    return;
                }

                // 1. Ambil data dari baris database
                int idPengguna = Convert.ToInt32(dtUser.Rows[0]["id_pengguna"]);
                string role = dtUser.Rows[0]["role"].ToString();
                string namaLengkap = dtUser.Rows[0]["nama_lengkap"].ToString();

                // 2. Simpan info lengkap ke SesiPengguna (IdPengguna wajib diikutkan)
                SesiPengguna.Login(new PenggunaModel
                {
                    IdPengguna = idPengguna,
                    Username = username,
                    Role = role!,
                    NamaLengkap = namaLengkap!  // ← Simpan nama lengkap juga
                });

                // 🎉 REVISI: Tampilkan welcome message sebelum buka dashboard
                TampilkanWelcomeMessage(role!, namaLengkap!);

                // 3. Buka dashboard setelah welcome message di-close
                BukaDashboard(role!);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Koneksi Database Error:\n" + ex.Message);
            }
        }

        // ===== FUNGSI BARU: Tampilkan welcome message =====
        private void TampilkanWelcomeMessage(string role, string namaLengkap)
        {
            string pesan = "";
            string judul = "";

            if (role == "Owner")
            {
                judul = "🏢 Selamat Datang Owner";
                pesan = $"Halo, {namaLengkap}!\n\n" +
                        "Anda login sebagai Owner.\n" +
                        "Selamat bekerja!";
            }
            else if (role == "Kasir")
            {
                judul = "👋 Selamat Datang Kasir";
                pesan = $"Halo, {namaLengkap}!\n\n" +
                        "Anda login sebagai Kasir.\n" +
                        "Siap melayani pelanggan? 🚀";
            }

            MessageBox.Show(
                pesan,
                judul,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // FUNGSI: Mengambil data pengguna secara utuh dari PostgreSQL
        private DataTable AmbilDataPenggunaDariDb(string username, string password)
        {
            // ===== REVISI: Tambah nama_lengkap ke SELECT =====
            string query = "SELECT id_pengguna, role, nama_lengkap FROM pengguna WHERE username=@u AND password=@p AND is_active=true";
            NpgsqlParameter[] parameters = {
                new NpgsqlParameter("u", username),
                new NpgsqlParameter("p", password)
            };
            return DBHelper.EksekusiQuery(query, parameters);
        }

        // FUNGSI: Mengarahkan layar utama berdasarkan Role hak akses
        private void BukaDashboard(string role)
        {
            switch (role)
            {
                case "Owner":
                    new FormDashboardOwner().Show();
                    this.Hide();
                    break;

                case "Kasir":
                    FormTransaksi frmTrx = new FormTransaksi();
                    frmTrx.Show();
                    this.Hide();
                    break;
            }
        }

        private void txtUsername_MouseEnter(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.FromArgb(148, 172, 137);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtUsername_MouseLeave(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.FromArgb(245, 245, 220);
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromArgb(148, 172, 137);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.FromArgb(245, 245, 220);
        }
    }
}