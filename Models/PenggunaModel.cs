using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Models
{
    public class PenggunaModel
    {
        private string username;
        private string password;
        private string namaLengkap;
        private string role;

        public string Username
        {
            get { return this.username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Username tidak boleh kosong.");
                this.username = value;
            }
        }

        public string Password
        {
            get { return this.password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Password tidak boleh kosong.");
                this.password = value;
            }
        }

        public string NamaLengkap
        {
            get { return this.namaLengkap; }
            set { this.namaLengkap = value; }
        }

        public string Role
        {
            get { return this.role; }
            set { this.role = value; }
        }
    }
}

