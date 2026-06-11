using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Services;
using greenPointofSales.Views;
using System;
using System.Windows.Forms;

namespace greenPointofSales
{
    public partial class FormLogin : Form
    {
        private readonly LoginService _loginService = new LoginService();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            try
            {
                string role = _loginService.ExecuteLogin(username, password);
                string namaLengkap = _loginService.GetNamaLengkap(username);

                UIHelper.TampilkanWelcomeMessage(role, namaLengkap);
                UIHelper.AlihkanDashboard(role, this);
            }
            catch (ArgumentException ex)
            {
                UIHelper.Peringatan(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                UIHelper.Error(ex.Message);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Kesalahan sistem: " + ex.Message);
            }
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            UIHelper.KeluarAplikasi();
        }
    }
}