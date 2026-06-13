using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.IAbstract;
using greenPointofSales.Models.Entity;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace greenPointofSales.Views.Owner
{
    public partial class UC_LaporanLabaRugi : UserControl, ILaporan
    {
        private readonly LaporanController _controller = new LaporanController();
        public event Action<UserControl>? OnNavigasi;

        public UC_LaporanLabaRugi()
        {
            InitializeComponent();
            UIHelper.IkatNavigasiMenu(this);
            MuatDataDefault();
        }

        public void MuatDataDefault()
        {
            cbBulan.SelectedIndex = DateTime.Now.Month - 1;
            txtTahun.Text = DateTime.Now.Year.ToString();
            FilterData(DateTime.MinValue, DateTime.MaxValue, string.Empty);
        }

        public void FilterData(DateTime dari, DateTime sampai, string opsiTambahan)
        {
            try
            {
                int bulan = cbBulan.SelectedIndex + 1;
                if (!int.TryParse(txtTahun.Text, out int tahun))
                {
                    UIHelper.Peringatan("Tahun harus diisi dengan angka yang valid!");
                    return;
                }

                LabaRugiModel data = _controller.DapatkanLabaRugi(bulan, tahun);

                lblHPP.Text = UIHelper.FormatRupiah(data.TotalHPP);
                lblRugiBusuk.Text = UIHelper.FormatRupiah(data.TotalRugiBusuk);
                lblLabaBersih.Text = UIHelper.FormatRupiah(data.LabaBersih);
                lblLabaBersih.ForeColor = data.LabaBersih < 0 ? Color.Red : Color.DarkGreen;

                if (data.LabaBersih >= 0)
                {
                    lblStatus.Text = "PROFIT";
                    lblStatus.ForeColor = Color.MediumSeaGreen;
                }
                else
                {
                    lblStatus.Text = "TIDAK PROFIT (RUGI)";
                    lblStatus.ForeColor = Color.Crimson;
                }

                DataTable dtSemuaLaporan = _controller.DapatkanSemuaLabaRugi();
                dgvLaporan.DataSource = dtSemuaLaporan;

                if (dgvLaporan.Columns.Count > 0)
                {
                    dgvLaporan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvLaporan.ReadOnly = true;
                    dgvLaporan.AllowUserToAddRows = false;
                }

                RenderChart(data);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Error saat memproses laporan: " + ex.Message);
            }
        }

        private void RenderChart(LabaRugiModel data)
        {
            panelChart.Controls.Clear();

            if (data.TotalPendapatan == 0 && data.TotalRugiBusuk == 0)
            {
                Label lblKosong = new Label
                {
                    Text = "Tidak ada data untuk grafik di bulan ini.",
                    AutoSize = true,
                    ForeColor = Color.Gray,
                    Location = new Point(10, 10)
                };
                panelChart.Controls.Add(lblKosong);
                return;
            }

            Chart chartPie = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            ChartArea area = new ChartArea("MainArea");
            chartPie.ChartAreas.Add(area);

            Series seriesPie = new Series("Perbandingan")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                LabelFormat = "C0",
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            seriesPie.Points.AddXY("Pendapatan", data.TotalPendapatan);
            seriesPie.Points[0].Color = Color.MediumSeaGreen;

            seriesPie.Points.AddXY("Rugi Busuk", data.TotalRugiBusuk);
            seriesPie.Points[1].Color = Color.Crimson;

            chartPie.Series.Add(seriesPie);

            Legend legend = new Legend("LegendUtama")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center
            };
            chartPie.Legends.Add(legend);

            panelChart.Controls.Add(chartPie);
        }

        public void ExportKeCSV()
        {
            if (dgvLaporan.DataSource is DataTable dt)
            {
                using SaveFileDialog sfd = new SaveFileDialog { Filter = "CSV Files (*.csv)|*.csv" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportHelper.ExportDataTableToCSV(dt, sfd.FileName);
                        UIHelper.Sukses("Laporan Laba Rugi berhasil di-export ke CSV!");
                    }
                    catch (Exception ex)
                    {
                        UIHelper.Error("Gagal export CSV: " + ex.Message);
                    }
                }
            }
            else
            {
                UIHelper.Peringatan("Tidak ada data untuk di-export.");
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            FilterData(DateTime.MinValue, DateTime.MaxValue, string.Empty);
        }

        private void btnLapPenjualan_Click(object sender, EventArgs e)
        {
            OnNavigasi?.Invoke(new UC_LaporanPenjualan());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportKeCSV();
        }
    }
}