using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormLogin : Form
    {
        private readonly PenggunaController _penggunaController = new PenggunaController();
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
                string? role = _penggunaController.ProsesLogin(username, password);

                if (string.IsNullOrEmpty(role))
                {
                    UIHelper.Error("Username/Password salah, atau akun dinonaktifkan.");
                    return;
                }

                string namaLengkap = SesiPenggunaModel.PenggunaAktif?.NamaLengkap ?? username;

                TampilkanWelcomeMessage(role, namaLengkap);

                BukaDashboard(role);
            }
            catch (ArgumentException ex)
            {
                UIHelper.Peringatan(ex.Message);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Kesalahan sistem: " + ex.Message);
            }
        }

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

            MessageBox.Show(pesan, judul, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BukaDashboard(string role)
        {
            switch (role)
            {
                case "Owner":
                    new FormDashboard().Show();
                    this.Hide();
                    break;

                case "Kasir":
                    FormTransaksi frmTrx = new FormTransaksi();
                    frmTrx.Show();
                    this.Hide();
                    break;
            }
        }
        private void btnX_Click(object sender, EventArgs e)
        {
            DialogResult konfirmasi = MessageBox.Show(
                "Apakah kamu yakin ingin keluar dari aplikasi?",
                "Konfirmasi Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (konfirmasi == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}