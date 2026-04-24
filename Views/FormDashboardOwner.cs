using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormDashboardOwner : Form
    {
        public FormDashboardOwner()
        {
            InitializeComponent();
        }
        private void btnMenuKaryawan_Click(object sender, EventArgs e)
        {
            // Panggil form yang sudah kita buat sebelumnya
            FormTambahKaryawan formKaryawan = new FormTambahKaryawan();

            // Gunakan ShowDialog agar form muncul sebagai pop-up yang fokus
            formKaryawan.ShowDialog();
        }

        // Tombol Logout
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Tutup dashboard

            // Tampilkan kembali form login yang tadi disembunyikan
            Application.OpenForms["Form1"].Show();
        }

        private void btnMenuKaryawan_Click_1(object sender, EventArgs e)
        {
            FormTambahKaryawan formKaryawan = new FormTambahKaryawan();
            formKaryawan.ShowDialog();
        }

        private void btnMenuProduk_Click(object sender, EventArgs e)
        {
            FormManajemenProduk formProduk = new FormManajemenProduk();
            formProduk.ShowDialog();
        }
    }
}