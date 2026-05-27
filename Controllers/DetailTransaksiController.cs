using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Controllers
{
    public class DetailTransaksiController
    {
        private readonly DetailTransaksiContext _context = new DetailTransaksiContext();

        public void TambahItem(int idTrx, DetailTransaksiModel item)
        {
            _context.InsertDetail(idTrx, item);
        }
    }
}
