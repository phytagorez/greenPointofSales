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

        private int _idKategoriAktif = 0;

        public FormTransaksi()
        {
            InitializeComponent();
            InitializeAwalTransaksi();
        }

        private void InitializeAwalTransaksi()
        {
            // REFACTOR: Ikat navigasi menu otomatis
            UIHelper.IkatNavigasiMenu(this);

            string noInvoice = _transaksiService.GenerateNoInvoice();
            int idKasir = SesiPenggunaModel.PenggunaAktif?.IdPengguna ?? 1;
            _transaksiAktif = new TransaksiModel(noInvoice, idKasir);

            SetupMetodePembayaran();
            SetupNamaKasir();
            MuatKatalogProduk();
            HitungTotalBawah();

            tbSearchTrans.TextChanged += tbSearchTrans_TextChanged;
        }

        private void SetupMetodePembayaran()
        {
            if (cmbMetodeBayar.Items.Count == 0)
            {
                cmbMetodeBayar.Items.Add("Tunai");
                cmbMetodeBayar.Items.Add("Non-Tunai");
            }
            cmbMetodeBayar.SelectedIndex = 0;
        }

        private void SetupNamaKasir()
        {
            var kasir = SesiPenggunaModel.PenggunaAktif;
            tbNamaKasir.Text = kasir?.NamaLengkap ?? "-";
        }

        private void MuatKatalogProduk(DataTable? dtOverride = null)
        {
            flpKatalog.Controls.Clear();

            if (dtOverride == null)
            {
                _dtProdukSemua = _katalogService.MuatSemuaProduk();
            }

            DataTable dtProduk = dtOverride ?? _dtProdukSemua;
            _katalogService.ExtractProductMetadata(dtProduk, out _satuanProduk, out _stokProduk);

            foreach (DataRow row in dtProduk.Rows)
            {
                RenderProductCard(row);
            }
        }

        private void RenderProductCard(DataRow row)
        {
            int id = Convert.ToInt32(row["id_produk"]);
            string nama = row["nama_produk"].ToString() ?? "";
            decimal harga = Convert.ToDecimal(row["harga_jual"]);
            decimal stok = Convert.ToDecimal(row["stok"]);
            string satuan = _satuanProduk.ContainsKey(id) ? _satuanProduk[id] : "Pcs";

            Panel card = new Panel
            {
                Width = 135,
                Height = 145,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(6),
                Cursor = Cursors.Hand
            };

            Label lblNama = new Label { Text = nama, Dock = DockStyle.Top, Height = 45, Font = new Font("Segoe UI", 9, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
            Label lblHarga = new Label { Text = $"{UIHelper.FormatRupiah(harga)}/{satuan}", Dock = DockStyle.Top, Height = 25, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.ForestGreen };
            Label lblStok = new Label { Text = $"Stok: {stok:0.##} {satuan}", Dock = DockStyle.Bottom, Height = 20, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8, FontStyle.Italic), ForeColor = _katalogService.IsStokKritis(stok) ? Color.Red : Color.Gray };

            card.Controls.Add(lblHarga);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblStok);

            EventHandler klikCard = (s, e) => BtnTambahKeKeranjang_Click(id, nama, harga, stok);
            card.Click += klikCard;
            lblNama.Click += klikCard;
            lblHarga.Click += klikCard;
            lblStok.Click += klikCard;

            flpKatalog.Controls.Add(card);
        }

        private void BtnTambahKeKeranjang_Click(int idProduk, string nama, decimal harga, decimal stok)
        {
            string? error = _transaksiService.ValidasiDanTambahItem(_transaksiAktif!, idProduk, nama, harga, stok, _satuanProduk);

            if (error != null)
            {
                UIHelper.Peringatan(error);
                return;
            }

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        private void RenderUlangKeranjang()
        {
            flpKeranjang.Controls.Clear();
            foreach (var item in _transaksiAktif!.Items)
            {
                RenderItemKeranjang(item);
            }
        }

        // KEMBALINYA TOMBOL + DAN - UNTUK KERANJANG
        private void RenderItemKeranjang(DetailTransaksiModel item)
        {
            string satuan = _transaksiService.GetSatuan(item.IdProduk, _satuanProduk);
            decimal takaran = _transaksiService.GetTakaran(satuan);

            Panel cardBarang = new Panel { Width = flpKeranjang.Width - 25, Height = 65, BorderStyle = BorderStyle.FixedSingle, BackColor = Color.FromArgb(245, 245, 245), Margin = new Padding(4) };
            Label lblNama = new Label { Text = item.NamaProduk, Location = new Point(8, 8), Width = 150, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
            Label lblSub = new Label { Text = UIHelper.FormatRupiah(item.HitungSubtotal()), Location = new Point(8, 34), Width = 120, ForeColor = Color.Navy };

            Button btnMin = new Button { Text = "-", Location = new Point(cardBarang.Width - 135, 15), Width = 30, Height = 30, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            string teksQty = (satuan.ToLower() == "pcs" || satuan.ToLower() == "ikat") ? item.Jumlah.ToString("0") + " " + satuan : item.Jumlah.ToString("0.##") + " " + satuan;
            Label lblQty = new Label { Text = teksQty, Location = new Point(cardBarang.Width - 100, 20), Width = 55, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold) };

            Button btnPlus = new Button { Text = "+", Location = new Point(cardBarang.Width - 40, 15), Width = 30, Height = 30, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

            btnMin.Click += (s, e) => BtnQuantityMinus_Click(item, takaran, lblQty);
            btnPlus.Click += (s, e) => BtnQuantityPlus_Click(item, takaran, lblQty);

            cardBarang.Controls.Add(lblNama);
            cardBarang.Controls.Add(lblSub);
            cardBarang.Controls.Add(btnMin);
            cardBarang.Controls.Add(lblQty);
            cardBarang.Controls.Add(btnPlus);

            flpKeranjang.Controls.Add(cardBarang);
        }

        private void BtnQuantityMinus_Click(DetailTransaksiModel item, decimal takaran, Label lblQty)
        {
            string? error = _transaksiService.UpdateQuantityItem(_transaksiAktif!, item, -takaran, _stokProduk.ContainsKey(item.IdProduk) ? _stokProduk[item.IdProduk] : 0, _satuanProduk);
            if (error != null) UIHelper.Peringatan(error);

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        private void BtnQuantityPlus_Click(DetailTransaksiModel item, decimal takaran, Label lblQty)
        {
            decimal stokMaks = _stokProduk.ContainsKey(item.IdProduk) ? _stokProduk[item.IdProduk] : 0m;
            string? error = _transaksiService.UpdateQuantityItem(_transaksiAktif!, item, takaran, stokMaks, _satuanProduk);

            if (error != null)
            {
                UIHelper.Peringatan(error);
                return;
            }

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        private void HitungTotalBawah()
        {
            lblTotalHarga.Text = UIHelper.FormatRupiah(_transaksiAktif?.TotalHarga ?? 0);
            HitungKembalianManual();
        }

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

        private void txtUangBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalianManual();
        }

        private void HitungKembalianManual()
        {
            if (cmbMetodeBayar.Text == "Non-Tunai / QRIS") return;

            string? parseError = _transaksiService.ParseAndValidateNominal(txtUangBayar.Text, out decimal uangMasuk);

            if (parseError != null)
            {
                lblKembalian.Text = "Kembalian: " + UIHelper.FormatRupiah(0);
                lblKembalian.ForeColor = Color.Black;
                return;
            }

            decimal kembalian = _transaksiService.HitungKembalian(uangMasuk, _transaksiAktif!.TotalHarga);

            if (kembalian >= 0)
            {
                lblKembalian.Text = "Kembalian: " + UIHelper.FormatRupiah(kembalian);
                lblKembalian.ForeColor = Color.Black;
            }
            else
            {
                lblKembalian.Text = "Uang Pembayaran Kurang!";
                lblKembalian.ForeColor = Color.Red;
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            string? validateError = _transaksiService.ValidasiSebelumCheckout(_transaksiAktif!);
            if (validateError != null)
            {
                UIHelper.Peringatan(validateError);
                return;
            }

            _transaksiAktif!.MetodePembayaran = cmbMetodeBayar.Text;

            if (cmbMetodeBayar.Text == "Tunai")
            {
                string? parseError = _transaksiService.ParseAndValidateNominal(txtUangBayar.Text, out decimal nominalBayar);
                if (parseError != null)
                {
                    UIHelper.Peringatan(parseError);
                    return;
                }

                string? paymentError = _transaksiService.ValidasiPembayaranTunai(nominalBayar, _transaksiAktif.TotalHarga);
                if (paymentError != null)
                {
                    UIHelper.Peringatan(paymentError);
                    return;
                }

                _transaksiAktif.TotalBayar = nominalBayar;
                ExecuteCheckout();
            }
            else
            {
                _transaksiAktif.TotalBayar = _transaksiAktif.TotalHarga;

                using var formQris = new FormQRIS(_transaksiAktif.TotalHarga);
                if (formQris.ShowDialog() == DialogResult.OK)
                {
                    ExecuteCheckout();
                }
            }
        }

        private void ExecuteCheckout()
        {
            try
            {
                bool sukses = _transaksiService.ExecuteCheckout(_transaksiAktif!);
                if (sukses)
                {
                    UIHelper.Sukses("✓ Transaksi Berhasil Diproses & Stok Berhasil Diperbarui!");

                    // Reset UI, keranjang kosong kembali
                    txtUangBayar.Clear();
                    InitializeAwalTransaksi();
                    flpKeranjang.Controls.Clear();
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error("Gagal menyimpan transaksi:\n" + ex.Message);
            }
        }

        private void tbSearchTrans_TextChanged(object? sender, EventArgs e)
        {
            string keyword = tbSearchTrans.Text.Trim();
            DataTable dtFiltered = _katalogService.CariProdukByNama(_dtProdukSemua, keyword);
            MuatKatalogProduk(dtFiltered);

            if (dtFiltered.Rows.Count == 0 && !string.IsNullOrEmpty(keyword))
            {
                Label lblKosong = new Label { Text = $"Produk \"{keyword}\" tidak ditemukan.", ForeColor = Color.Gray, Font = new Font("Segoe UI", 9, FontStyle.Italic), AutoSize = true, Margin = new Padding(10) };
                flpKatalog.Controls.Add(lblKosong);
            }
        }

        private void FilterKategori(int idKategori)
        {
            _idKategoriAktif = idKategori;
            tbSearchTrans.Text = "";
            _dtProdukSemua = _katalogService.FilterByKategori(idKategori);
            MuatKatalogProduk(_dtProdukSemua);
        }

        private void btnKAll_Click(object sender, EventArgs e) => FilterKategori(0);
        private void btnKSay_Click(object sender, EventArgs e) => FilterKategori(1);
        private void btnKBua_Click(object sender, EventArgs e) => FilterKategori(2);
        private void btnKBmb_Click(object sender, EventArgs e) => FilterKategori(3);
    }
}