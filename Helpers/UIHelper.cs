using greenPointofSales.Models.Entity;
using greenPointofSales.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Helpers
{
    public static class UIHelper
    {
        //reminder
        public static void Peringatan(string pesan)
        {
            MessageBox.Show(pesan, "Input Tidak Valid",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //succses
        public static void Sukses(string pesan)
        {
            MessageBox.Show(pesan, "Berhasil",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //error
        public static void Error(string pesan)
        {
            MessageBox.Show(pesan, "Kesalahan Sistem",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //confirm
        public static bool Konfirmasi(string pesan)
        {
            DialogResult dr = MessageBox.Show(pesan, "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr == DialogResult.Yes;
        }

        public static void PindahKe(Form formBaru)
        {
            formBaru.Show();

            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                Form formAktif = Application.OpenForms[i];

                if (formAktif != null
                    && formAktif.Name != "FormLogin"
                    && formAktif.Name != formBaru.Name)
                {
                    formAktif.Close();
                }
            }
        }

        public static void TampilkanWelcomeMessage(string role, string namaLengkap)
        {
            string pesan = "";
            string judul = "";

            if (role == "Owner")
            {
                judul = "🏢 Selamat Datang Owner";
                pesan = $"Halo, {namaLengkap}!\n\nAnda login sebagai Owner.\nSelamat bekerja!";
            }
            else if (role == "Kasir")
            {
                judul = "👋 Selamat Datang Kasir";
                pesan = $"Halo, {namaLengkap}!\n\nAnda login sebagai Kasir.\nSiap melayani pelanggan? 🚀";
            }

            MessageBox.Show(pesan, judul, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void AlihkanDashboard(string role, Form formLogin)
        {
            if (role == "Owner")
            {
                new FormDashboard().Show();
                formLogin.Hide();
            }
            else if (role == "Kasir")
            {
                new FormTransaksi().Show();
                formLogin.Hide();
            }
        }

        public static void KeluarAplikasi()
        {
            if (Konfirmasi("Apakah kamu yakin ingin keluar dari aplikasi?"))
            {
                Application.Exit();
            }
        }
        public static void LogoutAplikasi()
        {
            string nama = SesiPenggunaModel.PenggunaAktif?.Username ?? "Pengguna";
            string role = SesiPenggunaModel.PenggunaAktif?.Role ?? "Sistem";

            if (Konfirmasi($"Apakah kamu yakin ingin logout dari akun {role} ({nama})?"))
            {
                SesiPenggunaModel.Logout();

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    Form formAktif = Application.OpenForms[i];

                    if (formAktif != null && formAktif.Name != "FormLogin")
                    {
                        formAktif.Close();
                    }
                }

                Application.OpenForms["FormLogin"]?.Show();
            }
        }
        public static void IkatNavigasiMenu(Control induk)
        {
            foreach (Control ctrl in induk.Controls)
            {
                if (ctrl is Button btn)
                {
                    switch (btn.Name)
                    {
                        case "btnMenuDashboard":
                            btn.Click += (s, e) => PindahKe(new greenPointofSales.Views.FormDashboard());
                            break;
                        case "btnMenuKaryawan":
                            btn.Click += (s, e) => PindahKe(new greenPointofSales.FormManajemenKaryawan());
                            break;
                        case "btnMenuProduk":
                            btn.Click += (s, e) => PindahKe(new greenPointofSales.Views.FormProduk());
                            break;
                        case "btnMenuKatalog":
                            btn.Click += (s, e) => PindahKe(new greenPointofSales.Views.FormManajemenProduk());
                            break;
                        case "btnLaporan":
                            btn.Click += (s, e) => PindahKe(new greenPointofSales.Views.Owner.FormLaporan());
                            break;
                        case "btnLogout":
                            btn.Click += (s, e) => LogoutAplikasi();
                            break;
                    }
                }
                if (ctrl.HasChildren)
                {
                    IkatNavigasiMenu(ctrl);
                }
            }
        }
        public static string FormatRupiah(decimal nominal)
        {
            return nominal.ToString("C0", new System.Globalization.CultureInfo("id-ID"));
        }
    }
}
