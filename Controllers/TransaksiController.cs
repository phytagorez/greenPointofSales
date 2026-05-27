using greenPointofSales.Models.Entity;
using greenPointofSales.Models.Context;
using System;

namespace greenPointofSales.Controllers
{
    public class TransaksiController
    {
        private readonly TransaksiContext _trxContext = new TransaksiContext();
        private readonly DetailTransaksiContext _detailContext = new DetailTransaksiContext();
        private readonly ProdukContext _produkContext = new ProdukContext();

        public string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"INV-{tgl}-";
            int urutanNext = _trxContext.GetCountInvoice(prefix) + 1;
            return prefix + urutanNext.ToString("D3");
        }

        public void ProsesSimpanTransaksi(TransaksiModel transaksi)
        {
            ValidateTransaksi(transaksi);

            int idTrx = _trxContext.InsertHeader(transaksi);

            if (idTrx <= 0)
                throw new Exception("Gagal membuat header transaksi di database.");

            foreach (var item in transaksi.Items)
            {
                decimal jumlahKeluar = item.Jumlah * -1m;
                _produkContext.UpdateStok(item.IdProduk, jumlahKeluar);
            }
        }

        private void ValidateTransaksi(TransaksiModel transaksi)
        {
            if (transaksi == null)
                throw new ArgumentNullException(nameof(transaksi), "Data transaksi tidak ditemukan.");

            if (transaksi.Items == null || transaksi.Items.Count == 0)
                throw new InvalidOperationException("Gagal menyimpan: Keranjang belanja masih kosong.");
        }
    }
}