using System;

namespace greenPointofSales.Models
{
    //kontrak
    public interface IPengguna
    {
        string Username { get; set; }
        string Role { get; set; }
        string TampilkanInfo();
    }

    //validasi
    public abstract class AkunDasar : IPengguna
    {
        private string _username = string.Empty;
        private string _role = string.Empty;

        public virtual string Username
        {
            get { return _username; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username tidak boleh kosong.");
                }
                _username = value;
            }
        }

        public virtual string Role
        {
            get { return _role; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Role tidak boleh kosong.");
                }
                _username = value;
            }
        }

        public abstract string TampilkanInfo();
    }

    public class PenggunaModel : AkunDasar
    {
        private string _password = string.Empty;
        private string _namaLengkap = string.Empty;

        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Password tidak boleh kosong.");

                }
                _password = value;
            }
        }

        public string NamaLengkap
        {
            get {return _namaLengkap; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Nama lengkap tidak boleh kosong.");
                }
                _namaLengkap = value;
            }
        }

        public bool IsActive { get; set; } = true;

        public override string TampilkanInfo()
        {
            return $"[{Role}] {NamaLengkap} ({Username})";
        }
    }
}