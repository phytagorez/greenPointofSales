using greenPointofSales.Models.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace greenPointofSales.Services
{
    public class KatalogService
    {
        private readonly ProdukContext _produkContext;

        public KatalogService()
        {
            _produkContext = new ProdukContext();
        }

        #region Product Catalog
        public DataTable MuatSemuaProduk(int idKategoriFilter = 0)
        {
            return _produkContext.AmbilKatalog(idKategoriFilter);
        }
        public void ExtractProductMetadata(
            DataTable dtProduk,
            out Dictionary<int, string> unitMapping,
            out Dictionary<int, decimal> stokMapping)
        {
            unitMapping = new Dictionary<int, string>();
            stokMapping = new Dictionary<int, decimal>();

            foreach (DataRow row in dtProduk.Rows)
            {
                int id = Convert.ToInt32(row["id_produk"]);
                string satuan = row["satuan"]?.ToString() ?? "Pcs";
                decimal stok = Convert.ToDecimal(row["stok"]);

                unitMapping[id] = satuan;
                stokMapping[id] = stok;
            }
        }

        #endregion

        #region Search & Filter
        public DataTable CariProdukByNama(DataTable dtSource, string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return dtSource;

            string keywordLower = keyword.Trim().ToLower();
            DataTable dtFiltered = dtSource.Clone();

            foreach (DataRow row in dtSource.Rows)
            {
                string nama = row["nama_produk"]?.ToString()?.ToLower() ?? "";

                if (nama.Contains(keywordLower))
                {
                    dtFiltered.ImportRow(row);
                }
            }

            return dtFiltered;
        }
        public DataTable FilterByKategori(int idKategori)
        {
            return _produkContext.AmbilKatalog(idKategori);
        }

        #endregion

        #region Validation
        public bool IsStokKritis(decimal stok, decimal batas = 5m)
        {
            return stok <= batas;
        }

        #endregion

        #region Formatting
        public string FormatHarga(decimal harga, string satuan)
        {
            return $"Rp {harga:N0}/{satuan}";
        }
        public string FormatStok(decimal stok, string satuan)
        {
            return $"Stok: {stok:0.##} {satuan}";
        }
    }
}