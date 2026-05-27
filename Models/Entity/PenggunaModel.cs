using System;

namespace greenPointofSales.Models.Entity
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
                _role = value;
            }
        }

        public abstract string TampilkanInfo();
    }

    public class PenggunaModel : AkunDasar
    {
        public int IdPengguna;
        private string _password = string.Empty;
        private string _namaLengkap = string.Empty;
        private string _noHp = string.Empty;
        private DateTime _tglLahir;
        private string _jenisKelamin = string.Empty;
        private string _email = string.Empty;
        private DateTime _tglMulaiKerja;

        public string Password
        {
            get { return _password; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 6)
                {
                    throw new ArgumentException("Password harus minimal 6 karakter!");
                }
                _password = value;
            }
        }

        public string NamaLengkap
        {
            get { return _namaLengkap; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException("Nama lengkap tidak valid. Minimal 3 huruf!");
                }
                _namaLengkap = value;
            }
        }

        public string NoHp
        {
            get { return _noHp; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 10)
                {
                    throw new ArgumentException("Nomor HP tidak valid. Minimal 10 digit!");
                }
                _noHp = value;
            }
        }

        public DateTime TglLahir
        {
            get { return _tglLahir; }
            set
            {
                int umur = DateTime.Now.Year - value.Year;
                if (value.Date > DateTime.Now.AddYears(-umur)) umur--; //validasi kabisat/bulan

                if (umur < 17)
                    throw new ArgumentException("Karyawan tidak boleh di bawah umur (minimal 17 tahun).");

                _tglLahir = value;
            }
        }

        public string JenisKelamin
        {
            get { return _jenisKelamin; }
            set
            {
                if (value != "Laki-laki" && value != "Perempuan")
                {
                    throw new ArgumentException("Jenis kelamin harus dipilih antara 'Laki-laki' atau 'Perempuan'.");
                }
                _jenisKelamin = value;
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email tidak boleh kosong.");
                }
                if (!value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Format email tidak valid.");
                }
                _email = value;
            }
        }

        public DateTime TglMulaiKerja
        {
            get { return _tglMulaiKerja; }
            set
            {
                if (value.Date < DateTime.Today)
                {
                    throw new ArgumentException("Tanggal mulai kerja tidak valid! Tidak boleh memilih tanggal di masa lalu.");
                }
                if (value.Date > DateTime.Today.AddDays(30))
                {
                    throw new ArgumentException("Tanggal mulai kerja terlalu jauh ke depan!");
                }

                _tglMulaiKerja = value;
            }
        }

        public bool IsActive { get; set; } = true;


        public override string TampilkanInfo()
        {
            return $"[{Role}] {NamaLengkap} ({Username})";
        }
    }
}