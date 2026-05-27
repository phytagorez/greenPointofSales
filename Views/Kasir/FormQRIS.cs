using System;
using System.Windows.Forms;

namespace greenPointofSales.Views.Kasir
{
    public partial class FormQRIS : Form
    {
        private decimal _totalTagihan;

        public FormQRIS(decimal total)
        {
            InitializeComponent();
            _totalTagihan = total;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void FormQRIS_Load(object sender, EventArgs e)
        {
            lblTotalQRIS.Text = $"TOTAL TAGIHAN: Rp {_totalTagihan:N0}";

            btnSelesaiBayar.DialogResult = DialogResult.OK;
            btnBatalQRIS.DialogResult = DialogResult.Cancel;
        }
    }
}