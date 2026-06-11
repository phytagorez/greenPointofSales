using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.IAbstract
{
    public interface ILaporan
    {
        void MuatDataDefault();
        void FilterData(DateTime dari, DateTime sampai, string opsiTambahan);
        void ExportKeCSV();
    }
}
