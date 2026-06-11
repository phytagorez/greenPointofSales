using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.IAbstract;
using greenPointofSales.Models.Entity;
using greenPointofSales.Views.Owner;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace greenPointofSales.Views
{
    public partial class UC_LaporanPenjualan : UserControl, ILaporan
    {
        private readonly LaporanController _controller = new LaporanController();
        public event Action<UserControl>? OnNavigasi;

        public UC_LaporanPenjualan()
        {
            InitializeComponent();
            UIHelper.IkatNavigasiMenu(this);
            MuatDataDefault();
        }

        public void MuatDataDefault()
        {
            cmbMetodeBayar.SelectedIndex = 0;
            dtpDari.Value = DateTime.Today;
            dtpSampai.Value = DateTime.Today;
            FilterData(dtpDari.Value, dtpSampai.Value, cmbMetodeBayar.Text);
        }

        public void FilterData(DateTime dari, DateTime sampai, string opsiTambahan)
        {
            try
            {
                if (opsiTambahan == "All") opsiTambahan = "Semua";

                DataTable dtLaporan = _controller.DapatkanLaporanPenjualan(dari, sampai, opsiTambahan);
                dgvPenjualan.DataSource = dtLaporan;

                DataTable dtWidget = _controller.DapatkanWidgetPenjualan(dari, sampai, opsiTambahan);
                if (dtWidget.Rows.Count > 0)
                {
                    decimal totalPenjualan = Convert.ToDecimal(dtWidget.Rows[0]["total_penjualan"]);
                    int totalTransaksi = Convert.ToInt32(dtWidget.Rows[0]["total_transaksi"]);

                    lblTotalPenjualan.Text = "Rp " + totalPenjualan.ToString("N0");
                    lblTotalTransaksi.Text = totalTransaksi.ToString("N0") + " Transaksi";
                }

                DataTable dtGrafik = _controller.DapatkanGrafikPenjualan(dari, sampai, opsiTambahan);
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

                foreach (DataRow row in dtGrafik.Rows)
                {
                    try
                    {
                        object tglObj = row["tanggal"];
                        DateTime tgl;

                        if (tglObj is DateTime time)
                        {
                            tgl = time;
                        }
                        else if (tglObj is DateOnly dateOnly)
                        {
                            tgl = dateOnly.ToDateTime(TimeOnly.MinValue);
                        }
                        else if (tglObj is string str)
                        {
                            tgl = DateTime.Parse(str);
                        }
                        else
                        {
                            tgl = Convert.ToDateTime(tglObj);
                        }

                        decimal total = Convert.ToDecimal(row["total"]);
                        seriesBatang.Points.AddXY(tgl.ToString("dd/MM"), total);
                    }
                    catch (Exception rowEx)
                    {
                        System.Diagnostics.Debug.WriteLine($"Baris chart gagal diproses: {rowEx.Message}");
                        continue;
                    }
                }

                chartBatangMurni.Series.Add(seriesBatang);
                panelChart.Controls.Add(chartBatangMurni);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Sistem gagal memproses filter & grafik: " + ex.Message);
            }
        }

        public void ExportKeCSV()
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            FilterData(dtpDari.Value, dtpSampai.Value, cmbMetodeBayar.Text);
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            ExportKeCSV();
        }

        private void btnLapLabaRugi_Click(object sender, EventArgs e)
        {
            OnNavigasi?.Invoke(new UC_LaporanLabaRugi());
        }
    }
}