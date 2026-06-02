using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Context;
using greenPointofSales.Models.Entity;
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
        private readonly ProdukController _produkController = new ProdukController();
        private readonly TransaksiContext _transaksiContext = new TransaksiContext();

        private Dictionary<int, string> _satuanProduk = new Dictionary<int, string>();
        private Dictionary<int, decimal> _stokProduk = new Dictionary<int, decimal>();
        private DataTable _dtProdukSemua = new DataTable();
        private int _idKategoriAktif = 0;
        public FormTransaksi()
        {
            InitializeComponent();
            InitializeAwalTransaksi();
        }

        private void InitializeAwalTransaksi()
        {
            if (cmbMetodeBayar == null || flpKatalog == null || lblTotalHarga == null ||
                pnlTunai == null || txtUangBayar == null || lblKembalian == null ||
                btnBayar == null || flpKeranjang == null)
            {
                string rincianNull = "";
                if (cmbMetodeBayar == null) rincianNull += "• cmbMetodeBayar\n";
                if (flpKatalog == null) rincianNull += "• flpKatalog\n";
                if (lblTotalHarga == null) rincianNull += "• lblTotalHarga\n";
                if (pnlTunai == null) rincianNull += "• pnlTunai\n";
                if (txtUangBayar == null) rincianNull += "• txtUangBayar\n";
                if (lblKembalian == null) rincianNull += "• lblKembalian\n";
                if (btnBayar == null) rincianNull += "• btnBayar\n";
                if (flpKeranjang == null) rincianNull += "• flpKeranjang\n";

                MessageBox.Show($"Ejak, beberapa nama komponen di desainer UI belum disesuaikan:\n\n{rincianNull}\n👉 Solusi: Buka FormTransaksi [Design], klik komponennya, lalu samakan properti (Name)-nya!",
                    "Desainer UI Belum Sinkron", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string noInvoice = GenerateNoInvoice();
            int idKasir = SesiPengguna.PenggunaAktif != null ? SesiPengguna.PenggunaAktif.IdPengguna : 1;
            _transaksiAktif = new TransaksiModel(noInvoice, idKasir);

            if (cmbMetodeBayar.Items.Count == 0)
            {
                cmbMetodeBayar.Items.Add("Tunai");
                cmbMetodeBayar.Items.Add("Non-Tunai / QRIS");
            }
            cmbMetodeBayar.SelectedIndex = 0;

            var kasir = SesiPengguna.PenggunaAktif;
            if (kasir != null)
            {
                tbNamaKasir.Text = $"{kasir.NamaLengkap}";
            }
            else
            {
                tbNamaKasir.Text = "-";
            }

            MuatKatalogProduk();
            HitungTotalBawah();

            tbSearchTrans.TextChanged += tbSearchTrans_TextChanged;
        }

        private string GenerateNoInvoice()
        {
            string tgl = DateTime.Now.ToString("yyyyMMdd");
            string prefix = $"INV-{tgl}-";
            int count = _transaksiContext.GetCountInvoice(prefix);
            return prefix + (count + 1).ToString("D3");
        }

        private void MuatKatalogProduk(DataTable? dtOverride = null)
        {
            flpKatalog.Controls.Clear();
            _satuanProduk.Clear();
            _stokProduk.Clear();

            if (dtOverride == null)
            {
                _dtProdukSemua = _produkController.DapatkanKatalogProduk();
            }

            DataTable dtProduk = dtOverride ?? _dtProdukSemua;

            foreach (DataRow row in dtProduk.Rows)
            {
                int id = Convert.ToInt32(row["id_produk"]);
                string nama = row["nama_produk"].ToString() ?? "";
                decimal harga = Convert.ToDecimal(row["harga_jual"]);
                decimal stok = Convert.ToDecimal(row["stok"]);
                string satuan = row["satuan"]?.ToString() ?? "Pcs";

                _satuanProduk[id] = satuan;
                _stokProduk[id] = stok;

                Panel card = new Panel
                {
                    Width = 135,
                    Height = 145,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White,
                    Margin = new Padding(6)
                };

                Label lblNama = new Label { Text = nama, Dock = DockStyle.Top, Height = 45, Font = new Font("Segoe UI", 9, FontStyle.Bold), TextAlign = ContentAlignment.MiddleCenter };
                Label lblHarga = new Label { Text = $"Rp {harga:N0}/{satuan}", Dock = DockStyle.Top, Height = 25, TextAlign = ContentAlignment.MiddleCenter, ForeColor = Color.ForestGreen };
                Label lblStok = new Label { Text = $"Stok: {stok:0.##} {satuan}", Dock = DockStyle.Bottom, Height = 20, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 8, FontStyle.Italic), ForeColor = stok <= 5 ? Color.Red : Color.Gray };

                card.Controls.Add(lblHarga);
                card.Controls.Add(lblNama);
                card.Controls.Add(lblStok);

                EventHandler klikCard = (s, e) => TambahKeKeranjang(id, nama, harga, stok);
                card.Click += klikCard;
                lblNama.Click += klikCard;
                lblHarga.Click += klikCard;
                lblStok.Click += klikCard;

                flpKatalog.Controls.Add(card);
            }
        }

        private void TambahKeKeranjang(int id, string nama, decimal harga, decimal stokMaks)
        {
            string satuan = _satuanProduk.ContainsKey(id) ? _satuanProduk[id] : "Pcs";
            decimal takaran = satuan.ToLower() == "kg" ? 0.25m : 1m;

            var itemAda = _transaksiAktif?.Items.Find(x => x.IdProduk == id);

            if (itemAda != null && (itemAda.Jumlah + takaran) > stokMaks)
            {
                UIHelper.Peringatan("Stok barang di toko tidak mencukupi batas pembelian!");
                return;
            }
            if (stokMaks < takaran)
            {
                UIHelper.Peringatan("Produk jualan saat ini sedang kosong atau tidak cukup untuk takaran awal!");
                return;
            }

            DetailTransaksiModel itemBaru = new DetailTransaksiModel(id, nama, takaran, harga);
            _transaksiAktif?.TambahItem(itemBaru);

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        private void RenderUlangKeranjang()
        {
            flpKeranjang.Controls.Clear();

            foreach (var item in _transaksiAktif!.Items)
            {
                string satuan = _satuanProduk.ContainsKey(item.IdProduk) ? _satuanProduk[item.IdProduk] : "Pcs";
                decimal takaran = satuan.ToLower() == "kg" ? 0.25m : 1m;

                Panel cardBarang = new Panel
                {
                    Width = flpKeranjang.Width - 25,
                    Height = 65,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(245, 245, 245),
                    Margin = new Padding(4)
                };

                Label lblNama = new Label { Text = item.NamaProduk, Location = new Point(8, 8), Width = 150, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
                Label lblSub = new Label { Text = $"Rp {item.HitungSubtotal():N0}", Location = new Point(8, 34), Width = 120, ForeColor = Color.Navy };

                Button btnMin = new Button { Text = "-", Location = new Point(cardBarang.Width - 135, 15), Width = 30, Height = 30, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
                Label lblQty = new Label { Text = $"{item.Jumlah:0.##} {satuan}", Location = new Point(cardBarang.Width - 100, 20), Width = 55, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9, FontStyle.Bold) };
                Button btnPlus = new Button { Text = "+", Location = new Point(cardBarang.Width - 40, 15), Width = 30, Height = 30, Font = new Font("Segoe UI", 10, FontStyle.Bold) };

                btnMin.Click += (s, e) =>
                {
                    item.Jumlah -= takaran;
                    if (item.Jumlah <= 0) _transaksiAktif.Items.Remove(item);
                    RenderUlangKeranjang();
                    HitungTotalBawah();
                };

                btnPlus.Click += (s, e) =>
                {
                    decimal stokMaks = _stokProduk.ContainsKey(item.IdProduk) ? _stokProduk[item.IdProduk] : 0m;

                    if (item.Jumlah + takaran > stokMaks)
                    {
                        UIHelper.Peringatan("Stok barang tidak mencukupi!");
                    }
                    else
                    {
                        item.Jumlah += takaran;
                        RenderUlangKeranjang();
                        HitungTotalBawah();
                    }
                };

                cardBarang.Controls.Add(lblNama);
                cardBarang.Controls.Add(lblSub);
                cardBarang.Controls.Add(btnMin);
                cardBarang.Controls.Add(lblQty);
                cardBarang.Controls.Add(btnPlus);

                flpKeranjang.Controls.Add(cardBarang);
            }
        }

        private void HitungTotalBawah()
        {
            lblTotalHarga.Text = $"Rp {_transaksiAktif?.TotalHarga:N0}";
            HitungKembalianManual();
        }

        private void cmbMetodeBayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodeBayar.Text == "Tunai")
            {
                pnlTunai.Visible = true;
            }
            else
            {
                pnlTunai.Visible = false;
                txtUangBayar.Clear();
                lblKembalian.Text = "Kembalian: Rp 0";
            }
        }

        private void txtUangBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalianManual();
        }

        private void HitungKembalianManual()
        {
            if (cmbMetodeBayar.Text == "Non-Tunai / QRIS") return;

            if (decimal.TryParse(txtUangBayar.Text, out decimal uangMasuk))
            {
                decimal totalBelanja = _transaksiAktif!.TotalHarga;
                decimal sisaKembalian = uangMasuk - totalBelanja;

                if (sisaKembalian >= 0)
                {
                    lblKembalian.Text = $"Kembalian: Rp {sisaKembalian:N0}";
                    lblKembalian.ForeColor = Color.Black;
                }
                else
                {
                    lblKembalian.Text = "Uang Pembayaran Kurang!";
                    lblKembalian.ForeColor = Color.Red;
                }
            }
            else
            {
                lblKembalian.Text = "Kembalian: Rp 0";
                lblKembalian.ForeColor = Color.Black;
            }
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (_transaksiAktif == null || _transaksiAktif.Items.Count == 0)
            {
                UIHelper.Peringatan("Keranjang belanja masih kosong!");
                return;
            }

            if (cmbMetodeBayar.Text == "Tunai")
            {
                if (decimal.TryParse(txtUangBayar.Text, out decimal nominalBayar))
                {
                    if (nominalBayar < _transaksiAktif.TotalHarga)
                    {
                        UIHelper.Peringatan("Uang tunai yang diinput tidak mencukupi!");
                        return;
                    }

                    _transaksiAktif.TotalBayar = nominalBayar;
                    EksekusiSimpanPenjualan();
                }
                else
                {
                    UIHelper.Peringatan("Masukkan nominal angka uang pembayaran tunai dengan benar!");
                }
            }
            else
            {
                _transaksiAktif.TotalBayar = _transaksiAktif.TotalHarga;

                using var formQris = new FormQRIS(_transaksiAktif.TotalHarga);

                if (formQris.ShowDialog() == DialogResult.OK)
                {
                    EksekusiSimpanPenjualan();
                }
            }
        }

        private void EksekusiSimpanPenjualan()
        {
            try
            {
                int idTrxBaru = _transaksiContext.InsertHeader(_transaksiAktif!);

                foreach (var item in _transaksiAktif!.Items)
                {
                    decimal jumlahKeluar = item.Jumlah * -1m;
                    _produkController.UpdateStok(item.IdProduk, jumlahKeluar);
                }

                UIHelper.Sukses("✓ Transaksi Berhasil Diproses & Stok Berhasil Diperbarui!");

                InitializeAwalTransaksi();
                RenderUlangKeranjang();
                txtUangBayar.Clear();
            }
            catch (Exception ex)
            {
                UIHelper.Error("Gagal menyimpan transaksi ke database:\n" + ex.Message);
            }
        }
        private void tbSearchTrans_TextChanged(object? sender, EventArgs e)
        {
            string keyword = tbSearchTrans.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                MuatKatalogProduk(_dtProdukSemua);
                return;
            }

            DataTable dtFiltered = _dtProdukSemua.Clone();

            foreach (DataRow row in _dtProdukSemua.Rows)
            {
                string nama = row["nama_produk"]?.ToString()?.ToLower() ?? "";

                if (nama.Contains(keyword))
                {
                    dtFiltered.ImportRow(row);
                }
            }

            MuatKatalogProduk(dtFiltered);

            if (dtFiltered.Rows.Count == 0)
            {
                Label lblKosong = new Label
                {
                    Text = $"Produk \"{tbSearchTrans.Text}\" tidak ditemukan.",
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic),
                    AutoSize = true,
                    Margin = new Padding(10)
                };
                flpKatalog.Controls.Add(lblKosong);
            }
        }
        private void FilterKategori(int idKategori)
        {
            _idKategoriAktif = idKategori;
            tbSearchTrans.Text = "";
            _dtProdukSemua = _produkController.DapatkanKatalogProduk(idKategori);
            MuatKatalogProduk(_dtProdukSemua);
        }
        private void btnKAll_Click(object sender, EventArgs e)
        {
            FilterKategori(0);
        }

        private void btnKSay_Click(object sender, EventArgs e)
        {
            FilterKategori(1);
        }

        private void btnKBua_Click(object sender, EventArgs e)
        {
            FilterKategori(2);
        }

        private void btnKBmb_Click(object sender, EventArgs e)
        {
            FilterKategori(3);
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            string nama = SesiPengguna.PenggunaAktif?.Username ?? "Pengguna";
            string role = SesiPengguna.PenggunaAktif?.Role ?? "Sistem";

            bool yakinKeluar = UIHelper.Konfirmasi($"Apakah kamu yakin ingin logout dari akun {role} ({nama})?");

            if (yakinKeluar)
            {
                SesiPengguna.Logout();

                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    var formAktif = Application.OpenForms[i];

                    if (formAktif != null && formAktif.Name != "FormLogin")
                    {
                        formAktif.Close();
                    }
                }

                Application.OpenForms["FormLogin"]?.Show();
            }
        }
    }
}