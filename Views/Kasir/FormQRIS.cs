using System;
using System.Windows.Forms;

namespace greenPointofSales.Views.Kasir
{
    public partial class FormQRIS : Form
    {
        private decimal _totalTagihan;

        // Constructor kustom menerima total nominal belanja
        public FormQRIS(decimal total)
        {
            InitializeComponent();
            _totalTagihan = total;

            // Atur properties form agar nampak premium & di tengah layar secara paksa
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FormQRIS_Load(object sender, EventArgs e)
        {
            // Tampilkan total belanja pada label di dalam Form QRIS
            lblTotalQRIS.Text = $"TOTAL TAGIHAN: Rp {_totalTagihan:N0}";

            // Hubungkan tombol ke system dialog result agar menutup otomatis saat diklik
            btnSelesaiBayar.DialogResult = DialogResult.OK;
            btnBatalQRIS.DialogResult = DialogResult.Cancel;
        }
    }
}