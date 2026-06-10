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
        //Form Just 1
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

    }
}
