using greenPointofSales.Models;
using greenPointofSales.Views;
using Npgsql;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormLogin : Form
    {
        private string connString = "Host=localhost;Username=postgres;Password=23;Database=greenPOS"; 
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtUsername.Text) || string.IsNullOrWhiteSpace(this.txtPassword.Text))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(this.connString))
                {
                    conn.Open();
                    string sql = "SELECT role FROM pengguna WHERE username = @username AND password = @password AND is_active = true";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", this.txtUsername.Text);
                        cmd.Parameters.AddWithValue("@password", this.txtPassword.Text);

                        var result = cmd.ExecuteScalar();


                        if (result != null)
                        {
                            string role = result.ToString();

                            SesiPengguna.UsernameAktif = this.txtUsername.Text;
                            SesiPengguna.RoleAktif = role;

                            MessageBox.Show($"Login Berhasil! Selamat datang, {role}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (role == "Owner")
                            {
                                // 1. Buat instance dari form dashboard
                                FormDashboardOwner dashboardOwner = new FormDashboardOwner();

                                // 2. Tampilkan dashboard
                                dashboardOwner.Show();

                                // 3. Sembunyikan form login ini
                                this.Hide();
                            }
                            else if (role == "Kasir")
                            {
                                // Nanti kita buat FormKasirDashboard
                                MessageBox.Show("Dashboard Kasir belum dibuat.", "Info");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username/Password salah, atau akun dinonaktifkan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi Database Error:\n" + ex.Message, "Sistem Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
