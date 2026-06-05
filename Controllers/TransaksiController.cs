using greenPointofSales.Services;
using greenPointofSales.Models.Entity;

namespace greenPointofSales.Controllers
{
    public class TransaksiController
    {
        private readonly TransaksiService _service = new TransaksiService();

        public bool ProsesCheckout(TransaksiModel trx)
        {
            return _service.ExecuteCheckout(trx);
        }
    }
}