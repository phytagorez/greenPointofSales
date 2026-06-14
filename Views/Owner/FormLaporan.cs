using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace greenPointofSales.Views.Owner
{
    public partial class FormLaporan : Form
    {
        public FormLaporan()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.ClientSize = new Size(1280, 720);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1280, 720);
            this.MaximumSize = new Size(1280, 720);
            TampilkanHalaman(new UC_LaporanPenjualan());
        }

        public void TampilkanHalaman(UserControl ucBaru)
        {
            foreach (Control ctrl in pnlContainer.Controls)
            {
                ctrl.Dispose();
            }

            pnlContainer.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            ucBaru.Size = pnlContainer.Size;
            ucBaru.BringToFront();
            pnlContainer.Controls.Add(ucBaru);
            if (ucBaru is UC_LaporanPenjualan ucPenjualan)
            {
                ucPenjualan.OnNavigasi += (uc) => TampilkanHalaman(uc);
            }
            else if (ucBaru is UC_LaporanLabaRugi ucLabaRugi)
            {
                ucLabaRugi.OnNavigasi += (uc) => TampilkanHalaman(uc);
            }
            ucBaru.BringToFront();
            pnlContainer.Refresh();
        }
        private void btnLapPenjualan_Click(object sender, EventArgs e)
        {
            TampilkanHalaman(new UC_LaporanPenjualan());
        }

        private void btnLapLabaRugi_Click(object sender, EventArgs e)
        {
            TampilkanHalaman(new UC_LaporanLabaRugi());
        }
    }
}