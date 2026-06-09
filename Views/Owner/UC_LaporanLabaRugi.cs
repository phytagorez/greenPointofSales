using System;
using System.Drawing;
using System.Windows.Forms;
using greenPointofSales.Controllers;
using greenPointofSales.Models.Entity;

namespace greenPointofSales.Views.Owner
{
    public partial class UC_LaporanLabaRugi : UserControl
    {
        private readonly LaporanController _controller = new LaporanController();

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

        private void lblHPP_Click(object sender, EventArgs e)
        {

        }
    }
}