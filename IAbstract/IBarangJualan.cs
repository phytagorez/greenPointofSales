using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public interface IBarangJualan
    {
        string TampilkanDetail();
        void KurangiStok(decimal jumlah);
    }
}
