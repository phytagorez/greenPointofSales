using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public interface IBarangJualan //interface, method tanpa isi
    {
        string TampilkanDetail();
        void KurangiStok(decimal jumlah);
    }
}
