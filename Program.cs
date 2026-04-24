using System;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace greenPointofSales
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Panggil Form1 (Login) sebagai tampilan pertama saat aplikasi dibuka
            Application.Run(new FormLogin());
        }
    }
}