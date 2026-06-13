using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public abstract class AkunDasar : IPengguna //interface
    {
        private string _username = string.Empty;
        private string _role = string.Empty;

        public virtual string Username
        {
            get { return _username; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Username tidak boleh kosong.");
                _username = value;
            }
        }

        public virtual string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Role tidak boleh kosong.");
                _role = value;
            }
        }

        public abstract string TampilkanInfo();
    }
}
