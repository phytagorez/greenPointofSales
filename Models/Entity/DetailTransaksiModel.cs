using System;
using greenPointofSales.IAbstract;

namespace greenPointofSales.Models.Entity
{
    public class DetailTransaksiModel : EntitasDetail
    {
        public DetailTransaksiModel(int idProduk, string namaProduk, decimal jumlah, decimal hargaSatuan)
            : base(idProduk, namaProduk, jumlah, hargaSatuan) { }
    }
}