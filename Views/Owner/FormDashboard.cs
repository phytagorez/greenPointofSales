using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views.Owner;
using System;
using System.Data;
using System.Drawing;
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

            UIHelper.IkatNavigasiMenu(this);

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
                ProdukController produkCtrl = new();
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

        private void TampilkanGrafikTahunan()
        {
            try
            {
                DataTable dtGrafik = Controller.DapatkanGrafikTahunan();
                panelChartDashboard.Controls.Clear();

                Chart chartTahunan = new Chart
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                ChartArea areaUtama = new ChartArea("MainArea")
                {
                    AxisX = { Title = "Tahun", IsLabelAutoFit = true, MajorGrid = { LineColor = Color.FromArgb(240, 240, 240) } },
                    AxisY = { Title = "Total Omzet", MajorGrid = { LineColor = Color.FromArgb(240, 240, 240) }, LabelStyle = { Format = "Rp #,##0" } }
                };
                chartTahunan.ChartAreas.Add(areaUtama);

                Series seriesBatang = new Series("Penjualan")
                {
                    ChartType = SeriesChartType.Column,
                    ChartArea = "MainArea",
                    Color = Color.DodgerBlue,
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    IsValueShownAsLabel = true,
                    LabelFormat = "Rp #,##0"
                };

                foreach (DataRow row in dtGrafik.Rows)
                {
                    string tahun = row["tahun"].ToString();
                    decimal total = Convert.ToDecimal(row["total_penjualan"]);
                    seriesBatang.Points.AddXY(tahun, total);
                }

                chartTahunan.Series.Add(seriesBatang);
                panelChartDashboard.Controls.Add(chartTahunan);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Gagal memuat grafik tahunan: " + ex.Message);
            }
        }
    }
}