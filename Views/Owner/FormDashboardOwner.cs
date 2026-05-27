using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
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
            string nama = SesiPengguna.PenggunaAktif?.Username ?? "Pengguna";
            string role = SesiPengguna.PenggunaAktif?.Role ?? "Sistem";

            bool yakinKeluar = UIHelper.Konfirmasi($"Apakah kamu yakin ingin logout dari akun {role} ({nama})?");

            if (yakinKeluar)
            {
                SesiPengguna.Logout();

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
        private void btnMenuKatlog_Click(object sender, EventArgs e)
        {
            new FormKatalog().ShowDialog();
        }
    }
}