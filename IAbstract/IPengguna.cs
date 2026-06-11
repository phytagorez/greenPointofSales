using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public interface IPengguna
    {
        string Username { get; set; }
        string Role { get; set; }
        string TampilkanInfo();
    }
}
