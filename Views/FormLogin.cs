using greenPointofSales.Helpers;
using greenPointofSales.Models;
using greenPointofSales.Views;
using Npgsql;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string? role = AmbilRoleDariDb(username, password);

                if (role == null)
                {
                    MessageBox.Show("Username/Password salah, atau akun dinonaktifkan.", "Gagal",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //assosciation
                SesiPengguna.Login(new PenggunaModel { Username = username, Role = role });

                BukaDashboard(role);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Database Error:\n" + ex.Message, "Sistem Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //return role jika valid, null jika tidak (scalar)
        private string? AmbilRoleDariDb(string username, string password)
        {
            string query = "SELECT role FROM pengguna WHERE username=@u AND password=@p AND is_active=true";
            NpgsqlParameter[] parameters = {
        new NpgsqlParameter("u", username),
        new NpgsqlParameter("p", password)
    };
            return DBHelper.EksekusiScalar(query, parameters)?.ToString();
        }

        private void BukaDashboard(string role)
        {
            switch (role)
            {
                case "Owner":
                    new FormDashboardOwner().Show();
                    this.Hide();
                    break;
                case "Kasir":
                    MessageBox.Show("Dashboard Kasir belum dibuat.", "Info");
                    break;
            }
        }
    }
}