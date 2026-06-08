using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views.Owner;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Pastikan package NuGet ini terpasang

namespace greenPointofSales.Views
{
    public partial class UC_LaporanPenjualan : UserControl
    {
        private readonly LaporanController _controller = new LaporanController();
        public event Action<UserControl>? OnNavigasi;
        public UC_LaporanPenjualan()
        {
            InitializeComponent();
            cmbMetodeBayar.SelectedIndex = 0;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                string metode = cmbMetodeBayar.Text;
                if (metode == "All") metode = "Semua";

                DataTable dtLaporan = _controller.DapatkanLaporanPenjualan(dtpDari.Value, dtpSampai.Value, metode);
                dgvPenjualan.DataSource = dtLaporan;

                DataTable dtWidget = _controller.DapatkanWidgetPenjualan(dtpDari.Value, dtpSampai.Value, metode);
                if (dtWidget.Rows.Count > 0)
                {
                    decimal totalPenjualan = Convert.ToDecimal(dtWidget.Rows[0]["total_penjualan"]);
                    int totalTransaksi = Convert.ToInt32(dtWidget.Rows[0]["total_transaksi"]);

                    lblTotalPenjualan.Text = "Rp " + totalPenjualan.ToString("N0");
                    lblTotalTransaksi.Text = totalTransaksi.ToString("N0") + " Transaksi";
                }

                DataTable dtGrafik = _controller.DapatkanGrafikPenjualan(dtpDari.Value, dtpSampai.Value, metode);

                panelChart.Controls.Clear();

                Chart chartBatangMurni = new Chart
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.White
                };

                ChartArea areaUtama = new ChartArea("MainArea")
                {
                    AxisX = { IsLabelAutoFit = true, MajorGrid = { LineColor = Color.FromArgb(245, 245, 245) } },
                    AxisY = { MajorGrid = { LineColor = Color.FromArgb(245, 245, 245) } }
                };
                chartBatangMurni.ChartAreas.Add(areaUtama);

                Series seriesBatang = new Series("Omzet Penjualan")
                {
                    ChartType = SeriesChartType.Column,
                    ChartArea = "MainArea",
                    Color = Color.MediumSeaGreen,
                    Font = new Font("Arial", 8, FontStyle.Regular),
                    IsValueShownAsLabel = true,
                    LabelFormat = "Rp #,##0"
                };

                panelChart.Controls.Add(chartBatangMurni);

                foreach (DataRow row in dtGrafik.Rows)
                {
                    try
                    {
                        object tglObj = row["tanggal"];
                        DateTime tgl;

                        // Type checking untuk menangani berbagai format date
                        if (tglObj is DateTime)
                        {
                            tgl = (DateTime)tglObj;
                        }
                        else if (tglObj is DateOnly)
                        {
                            // Convert DateOnly ke DateTime dengan TimeOnly.MinValue (00:00:00)
                            DateOnly dateOnly = (DateOnly)tglObj;
                            tgl = dateOnly.ToDateTime(TimeOnly.MinValue);
                        }
                        else if (tglObj is string)
                        {
                            tgl = DateTime.Parse((string)tglObj);
                        }
                        else
                        {
                            // Fallback: coba convert langsung
                            tgl = Convert.ToDateTime(tglObj);
                        }

                        decimal total = Convert.ToDecimal(row["total"]);
                        seriesBatang.Points.AddXY(tgl.ToString("dd/MM"), total);
                    }
                    catch (Exception rowEx)
                    {
                        UIHelper.Error($"Baris chart gagal diproses: {rowEx.Message}. Melanjutkan dengan data lainnya...");
                        continue; // Skip baris ini, lanjut ke baris berikutnya
                    }
                }

                chartBatangMurni.Series.Add(seriesBatang);

                // KUNCI UTAMA: Bersihkan dan masukkan grafik di akhir proses agar panel TIDAK BLANK/NGILANG
                panelChart.Controls.Clear();
                panelChart.Controls.Add(chartBatangMurni);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Sistem gagal memproses filter & grafik: " + ex.Message);
            }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dgvPenjualan.DataSource is DataTable dt)
            {
                using SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportHelper.ExportDataTableToCSV(dt, sfd.FileName);
                        UIHelper.Sukses("Laporan berhasil di-export ke CSV!");
                    }
                    catch (Exception ex)
                    {
                        UIHelper.Error("Gagal export CSV: " + ex.Message);
                    }
                }
            }
        }
        private void btnLapLabaRugi_Click(object sender, EventArgs e)
        {
            OnNavigasi?.Invoke(new UC_LaporanLabaRugi());
        }
        private void btnMenuKaryawan_Click(object sender, EventArgs e)
        {
            new FormManajemenKaryawan().ShowDialog();
        }

        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            new FormProduk().ShowDialog();
        }
        private void btnMenuKatlog_Click(object sender, EventArgs e)
        {
            new FormManajemenProduk().ShowDialog();
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
    }
}