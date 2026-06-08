using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views.Owner;
using System;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormDashboard : Form
    {
        public FormDashboard()
        {
            InitializeComponent();

            string nama = SesiPenggunaModel.PenggunaAktif?.Username ?? "idk";
            string role = SesiPenggunaModel.PenggunaAktif?.Role ?? "Unknown";

            this.Text = $"Dashboard Owner | Selamat Datang, {nama} ({role})";

            CekPeringatanStokToko();
        }

        private void CekPeringatanStokToko()
        {
            try
            {
                greenPointofSales.Controllers.ProdukController produkCtrl = new();
                int totalKritis = produkCtrl.AmbilTotalStokKritis(5);
                if (totalKritis > 0)
                {
                    UIHelper.Peringatan($"Pemberitahuan Sistem:\nSaat ini terdapat {totalKritis} jenis produk dengan stok kritis (<= 5 Ikat/Kg). Mohon segera periksa menu Katalog atau Manajemen Produk!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal mengecek stok kritis: " + ex.Message);
            }
        }

        private void btnMenuKaryawan_Click(object sender, EventArgs e)
        {
            new FormManajemenKaryawan().ShowDialog();
        }

        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            new FormProduk().ShowDialog();
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
        private void btnMenuKatalog_Click(object sender, EventArgs e)
        {
            new FormManajemenProduk().ShowDialog();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan frm = new FormLaporan();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Show();
        }
    }
}