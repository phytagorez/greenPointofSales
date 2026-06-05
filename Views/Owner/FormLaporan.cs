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

            this.Width = 1280;
            this.Height = 720;
            this.StartPosition = FormStartPosition.CenterParent;

            // 1. Setup Panel Container (Ini area yang ganti-ganti)
            pnlContainer.Dock = DockStyle.Fill;
            this.Controls.Add(pnlContainer);

            // 2. Setup Panel Navigasi (Buat tombol di atas)
            Panel pnlNav = new Panel { Height = 50, Dock = DockStyle.Top, BackColor = Color.LightGray };
            this.Controls.Add(pnlNav);

            Button btnPenjualan = new Button { Text = "Laporan Penjualan", Dock = DockStyle.Left };
            btnPenjualan.Click += (s, e) => TampilkanHalaman(new UC_LaporanPenjualan());

            Button btnLabaRugi = new Button { Text = "Laba Rugi", Dock = DockStyle.Left };
            btnLabaRugi.Click += (s, e) => TampilkanHalaman(new UC_LaporanLabaRugi());

            pnlNav.Controls.Add(btnPenjualan);
            pnlNav.Controls.Add(btnLabaRugi);

            // Load default
            TampilkanHalaman(new UC_LaporanPenjualan());
        }

        public void TampilkanHalaman(UserControl ucBaru)
        {
            pnlContainer.Controls.Clear();
            ucBaru.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(ucBaru);
        }
    }
}
