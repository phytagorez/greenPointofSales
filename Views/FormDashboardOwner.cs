using greenPointofSales.Models;
using System;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormDashboardOwner : Form
    {
        public FormDashboardOwner()
        {
            InitializeComponent();

            string nama = SesiPengguna.PenggunaAktif?.Username ?? "idk";
            string role = SesiPengguna.PenggunaAktif?.Role ?? "Unknown";

            this.Text = $"Dashboard Owner | Selamat Datang, {nama} ({role})";
        }

        private void btnMenuKaryawan_Click(object sender, EventArgs e)
        {
            new FormTambahKaryawan().ShowDialog();
        }

        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            new FormManajemenProduk().ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            SesiPengguna.Logout();
            this.Close();
            Application.OpenForms["FormLogin"]?.Show();
        }

        private void btnMenuKatlog_Click(object sender, EventArgs e)
        {
            new FormKatalog().ShowDialog();
        }

        private void btnMenuDashboard_MouseEnter(object sender, EventArgs e)
        {
            btnMenuDashboard.BackColor = Color.FromArgb(0, 128, 0);
        }
    }
}