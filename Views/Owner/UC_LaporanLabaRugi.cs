using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.IAbstract;
using greenPointofSales.Models.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

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

                lblPendapatan.Text = data.TotalPendapatan.ToString("C0");
                lblHPP.Text = data.TotalHPP.ToString("C0");
                lblRugiBusuk.Text = data.TotalRugiBusuk.ToString("C0");
                lblLabaBersih.Text = data.LabaBersih.ToString("C0");

                lblLabaBersih.ForeColor = data.LabaBersih < 0 ? Color.Red : Color.DarkGreen;
            }
            catch (Exception ex)
            {
                UIHelper.Error("Error saat memproses laporan: " + ex.Message);
            }
        }

        public void ExportKeCSV()
        {
            UIHelper.Peringatan("Fitur cetak CSV untuk ringkasan Laba Rugi belum tersedia.");
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            FilterData(DateTime.MinValue, DateTime.MaxValue, string.Empty);
        }

        private void btnLapPenjualan_Click(object sender, EventArgs e)
        {
            OnNavigasi?.Invoke(new UC_LaporanPenjualan());
        }
    }
}