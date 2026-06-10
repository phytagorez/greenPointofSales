using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views.Owner;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace greenPointofSales.Views
{
    public partial class FormDashboard : Form
    {
        private readonly DashboardControllers Controller = new();
        public FormDashboard()
        {
            InitializeComponent();

            string nama = SesiPenggunaModel.PenggunaAktif?.Username ?? "idk";
            string role = SesiPenggunaModel.PenggunaAktif?.Role ?? "Unknown";

            this.Text = $"Dashboard Owner | Selamat Datang, {nama} ({role})";

            CekPeringatanStokToko();
            TampilkanWidget();
            TampilkanGrafikTahunan();
        }
        private void TampilkanWidget()
        {
            try
            {
                try { lblTTrans.Text = Controller.DapatkanTotalTransaksi(); }
                catch (Exception ex) { UIHelper.Error("Error TotalTransaksi: " + ex.Message); }

                try { lblJTrans.Text = Controller.DapatkanJumlahTransaksi(); }
                catch (Exception ex) { UIHelper.Error("Error JumlahTransaksi: " + ex.Message); }

                try { lblTKary.Text = Controller.DapatkanTotalKaryawan(); }
                catch (Exception ex) { UIHelper.Error("Error TotalKaryawan: " + ex.Message); }

                try { lblTProdukBsk.Text = Controller.DapatkanTotalProdukBusuk(); }
                catch (Exception ex) { UIHelper.Error("Error ProdukBusuk: " + ex.Message); }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal memuat widget: " + ex.Message);
            }
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
            UIHelper.PindahKe(new FormManajemenKaryawan());
        }

        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormProduk());
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

        private void TampilkanGrafikTahunan()
        {
            try
            {
                // Ambil data dari controller
                DataTable dtGrafik = _dashboardController.DapatkanGrafikTahunan();

                // Bersihkan panelChartDashboard terlebih dahulu
                panelChartDashboard.Controls.Clear();

                // Instansiasi Chart Baru secara Programmatic
                Chart chartTahunan = new Chart
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                // Pengaturan Area Grafik
                ChartArea areaUtama = new ChartArea("MainArea")
                {
                    AxisX = { Title = "Tahun", IsLabelAutoFit = true, MajorGrid = { LineColor = Color.FromArgb(240, 240, 240) } },
                    AxisY = { Title = "Total Omzet", MajorGrid = { LineColor = Color.FromArgb(240, 240, 240) }, LabelStyle = { Format = "Rp #,##0" } }
                };
                chartTahunan.ChartAreas.Add(areaUtama);

                // Buat Series Batang (Column)
                Series seriesBatang = new Series("Penjualan")
                {
                    ChartType = SeriesChartType.Column,
                    ChartArea = "MainArea",
                    Color = Color.DodgerBlue, // Warna batang bedakan dengan laporan biar variatif
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    IsValueShownAsLabel = true, // Otomatis munculin angka di atas batang
                    LabelFormat = "Rp #,##0"    // Format Rupiah angka di atas batang
                };

                // Looping data dari DB ke Chart
                foreach (DataRow row in dtGrafik.Rows)
                {
                    string tahun = row["tahun"].ToString();
                    decimal total = Convert.ToDecimal(row["total_penjualan"]);

                    seriesBatang.Points.AddXY(tahun, total);
                }

                // Masukkan series data ke chart, lalu tempel chart ke panel dashboard
                chartTahunan.Series.Add(seriesBatang);
                panelChartDashboard.Controls.Add(chartTahunan);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal memuat grafik tahunan: " + ex.Message);
            }
        }

        private void btnMenuKatalog_Click(object sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormManajemenProduk());
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            UIHelper.PindahKe(new FormLaporan());
        }
    }
}