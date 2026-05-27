using greenPointofSales.Models.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace greenPointofSales.Controllers
{
    public class StokController
    {
        private readonly ProdukContext _context = new ProdukContext();

        public void UpdateStok(int idProduk, decimal jumlahPerubahan)
        {
            _context.UpdateStok(idProduk, jumlahPerubahan);
        }
    }
}
