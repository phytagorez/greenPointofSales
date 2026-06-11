using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using greenPointofSales.Services;
using greenPointofSales.Views.Kasir;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormTransaksi : Form
    {
        private TransaksiModel? _transaksiAktif;
        private DataTable _dtProdukSemua = new DataTable();

        private Dictionary<int, string> _satuanProduk = new Dictionary<int, string>();
        private Dictionary<int, decimal> _stokProduk = new Dictionary<int, decimal>();

        private readonly TransaksiService _transaksiService = new TransaksiService();
        private readonly KatalogService _katalogService = new KatalogService();
        private readonly ProdukController _produkController = new ProdukController();

        private int _idKategoriAktif = 0;

        public FormTransaksi()
        {
            InitializeComponent();
            InitializeAwalTransaksi();
        }

        private void InitializeAwalTransaksi()
        {
            UIHelper.IkatNavigasiMenu(this);
            ResetTransaksiBaru();
            MuatDataKatalogMaster();
        }

        private void ResetTransaksiBaru()
        {
            string invoice = _transaksiService.GenerateNoInvoice();
            int idUser = SesiPenggunaModel.PenggunaAktif?.IdPengguna ?? 1;

            _transaksiAktif = new TransaksiModel(invoice, idUser);

            lblTotalHarga.Text = UIHelper.FormatRupiah(0);
            txtUangBayar.Clear();
            lblKembalian.Text = UIHelper.FormatRupiah(0);
            cmbMetodeBayar.SelectedIndex = 0;

            flpKeranjang.Controls.Clear();
        }

        private void MuatDataKatalogMaster()
        {
            try
            {
                _dtProdukSemua = _katalogService.MuatSemuaProduk(0);
                _katalogService.ExtractProductMetadata(_dtProdukSemua, out _satuanProduk, out _stokProduk);
                MuatKatalogProduk(_dtProdukSemua);
            }
            catch (Exception ex)
            {
                UIHelper.Error("Gagal memuat katalog: " + ex.Message);
            }
        }

        private void MuatKatalogProduk(DataTable dt)
        {
            flpKatalog.Controls.Clear();
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id_produk"]);
                string nama = row["nama_produk"].ToString() ?? "";
                decimal harga = Convert.ToDecimal(row["harga_jual"]);
                decimal stok = Convert.ToDecimal(row["stok"]);
                string satuan = _satuanProduk.ContainsKey(id) ? _satuanProduk[id] : "Pcs";

                Panel card = BuatCardProduk(id, nama, harga, stok, satuan);
                flpKatalog.Controls.Add(card);
            }
        }

        private Panel BuatCardProduk(int id, string nama, decimal harga, decimal stok, string satuan)
        {
            Panel panel = new Panel
            {
                Size = new Size(135, 145),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(6)
            };

            Label lblNama = new Label
            {
                Text = nama,
                Dock = DockStyle.Top,
                Height = 45,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblHarga = new Label
            {
                Text = $"{UIHelper.FormatRupiah(harga)}/{satuan}",
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.ForestGreen
            };

            Label lblStok = new Label
            {
                Text = $"Stok: {stok} {satuan}",
                Dock = DockStyle.Bottom,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = _katalogService.IsStokKritis(stok) ? Color.Red : Color.Gray
            };

            EventHandler klikCard = (s, e) => ActionTambahKeKeranjang(id, nama, harga, satuan);
            panel.Click += klikCard;
            lblNama.Click += klikCard;
            lblHarga.Click += klikCard;
            lblStok.Click += klikCard;

            panel.Controls.Add(lblHarga);
            panel.Controls.Add(lblNama);
            panel.Controls.Add(lblStok);

            return panel;
        }

        private void ActionTambahKeKeranjang(int id, string nama, decimal harga, string satuan)
        {
            if (_transaksiAktif == null) return;

            decimal qtyInput = _transaksiService.GetTakaran(satuan);

            string? errorMsg = _transaksiService.ValidasiDanTambahItem(_transaksiAktif, id, nama, qtyInput, harga);
            if (errorMsg != null)
            {
                UIHelper.Peringatan(errorMsg);
                return;
            }

            RenderUlangKeranjang();
        }

        private void RenderUlangKeranjang()
        {
            if (_transaksiAktif == null) return;

            flpKeranjang.Controls.Clear();
            foreach (var item in _transaksiAktif.Items)
            {
                Panel cardBarang = new Panel
                {
                    Width = flpKeranjang.Width - 25,
                    Height = 65,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(245, 245, 245),
                    Margin = new Padding(4)
                };

                Label lblNamaItem = new Label
                {
                    Text = item.NamaProduk,
                    Location = new Point(8, 8),
                    Width = 150,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                Label lblSub = new Label
                {
                    Text = UIHelper.FormatRupiah(item.HitungSubtotal()),
                    Location = new Point(8, 34),
                    Width = 120,
                    ForeColor = Color.Navy
                };

                Label lblQty = new Label
                {
                    Text = $"{item.Jumlah} {_satuanProduk[item.IdProduk]}",
                    Location = new Point(cardBarang.Width - 100, 20),
                    Width = 55,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                };

                cardBarang.Controls.Add(lblNamaItem);
                cardBarang.Controls.Add(lblSub);
                cardBarang.Controls.Add(lblQty);
                flpKeranjang.Controls.Add(cardBarang);
            }

            lblTotalHarga.Text = UIHelper.FormatRupiah(_transaksiAktif.TotalHarga);
            HitungKembalianKasir();
        }

        private void HitungKembalianKasir()
        {
            if (_transaksiAktif == null) return;

            if (string.IsNullOrWhiteSpace(txtUangBayar.Text))
            {
                lblKembalian.Text = "Kembalian: " + UIHelper.FormatRupiah(0);
                return;
            }

            if (decimal.TryParse(txtUangBayar.Text, out decimal bayar))
            {
                if (bayar >= _transaksiAktif.TotalHarga)
                {
                    decimal kembalian = bayar - _transaksiAktif.TotalHarga;
                    lblKembalian.Text = "Kembalian: " + UIHelper.FormatRupiah(kembalian);
                    lblKembalian.ForeColor = Color.Black;
                }
                else
                {
                    lblKembalian.Text = "Uang Pembayaran Kurang!";
                    lblKembalian.ForeColor = Color.Red;
                }
            }
        }

        private void txtUangBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalianKasir();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (_transaksiAktif == null || _transaksiAktif.Items.Count == 0)
            {
                UIHelper.Peringatan("Keranjang belanja masih kosong!");
                return;
            }

            _transaksiAktif.MetodePembayaran = cmbMetodeBayar.Text;

            if (_transaksiAktif.MetodePembayaran == "Non-Tunai" || _transaksiAktif.MetodePembayaran == "Non-Tunai / QRIS")
            {
                using FormQRIS frmQris = new FormQRIS(_transaksiAktif.TotalHarga);
                if (frmQris.ShowDialog() != DialogResult.OK)
                {
                    UIHelper.Peringatan("Pembayaran QRIS dibatalkan.");
                    return;
                }
                _transaksiAktif.TotalBayar = _transaksiAktif.TotalHarga;
            }
            else
            {
                if (!decimal.TryParse(txtUangBayar.Text, out decimal bayar) || bayar < _transaksiAktif.TotalHarga)
                {
                    UIHelper.Peringatan("Uang tunai yang diinput tidak mencukupi!");
                    return;
                }
                _transaksiAktif.TotalBayar = bayar;
            }

            try
            {
                bool sukses = _transaksiService.ExecuteCheckout(_transaksiAktif);
                if (sukses)
                {
                    UIHelper.Sukses("✓ Transaksi Berhasil Diproses & Stok Berhasil Diperbarui!");
                    ResetTransaksiBaru();
                    MuatDataKatalogMaster();
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error(ex.Message);
            }
        }

        private void tbSearchTrans_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbSearchTrans.Text.Trim();
            DataTable dtFiltered = _katalogService.CariProdukByNama(_dtProdukSemua, keyword);
            MuatKatalogProduk(dtFiltered);
        }

        private void FilterKategori(int idKategori)
        {
            _dtProdukSemua = _katalogService.FilterByKategori(idKategori);
            MuatKatalogProduk(_dtProdukSemua);
        }

        private void btnKAll_Click(object sender, EventArgs e) => FilterKategori(0);
        private void btnKSay_Click(object sender, EventArgs e) => FilterKategori(1);
        private void btnKBua_Click(object sender, EventArgs e) => FilterKategori(2);
        private void btnKBmb_Click(object sender, EventArgs e) => FilterKategori(3);

        private void cmbMetodeBayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTunai = cmbMetodeBayar.Text == "Tunai";
            pnlTunai.Visible = isTunai;
            if (!isTunai)
            {
                txtUangBayar.Clear();
                lblKembalian.Text = "Kembalian: " + UIHelper.FormatRupiah(0);
            }
        }
    }
}