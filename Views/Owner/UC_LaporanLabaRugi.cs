using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace greenPointofSales.Views.Owner
{
    public partial class UC_LaporanLabaRugi : UserControl
    {
        private readonly LaporanController _controller = new LaporanController();
        public event Action<UserControl>? OnNavigasi;
        public UC_LaporanLabaRugi()
        {
            InitializeComponent();
            // Setup default tahun ke tahun sekarang
            txtTahun.Text = DateTime.Now.Year.ToString();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            try
            {
                int bulan = cbBulan.SelectedIndex + 1; // Index 0 jadi Januari
                int tahun = int.Parse(txtTahun.Text);

                // Panggil logic dari controller
                LabaRugiModel data = _controller.DapatkanLabaRugi(bulan, tahun);

                // Update UI
                lblPendapatan.Text = data.TotalPendapatan.ToString("C0");
                lblHPP.Text = data.TotalHPP.ToString("C0");
                lblRugiBusuk.Text = data.TotalRugiBusuk.ToString("C0");
                lblLabaBersih.Text = data.LabaBersih.ToString("C0");

                // Beri warna merah kalau rugi, hijau kalau untung
                lblLabaBersih.ForeColor = data.LabaBersih < 0 ? Color.Red : Color.DarkGreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memproses laporan: " + ex.Message);
            }
        }
        private void btnLapPenjualan_Click(object? sender, EventArgs e)
        {
            OnNavigasi?.Invoke(new UC_LaporanPenjualan());
        }
        private void btnMenuDashboard_Click(object? sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormDashboard());
        }
        private void btnMenuKaryawan_Click(object? sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormManajemenKaryawan());
        }
        private void btnMenuProduk_Click(object? sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormProduk());
        }
        private void btnMenuKatalog_Click(object? sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormManajemenProduk());
        }
        private void btnLogout_Click(object? sender, EventArgs e)
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
    }
}