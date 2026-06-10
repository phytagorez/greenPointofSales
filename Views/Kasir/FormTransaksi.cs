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
        #region Fields

        // Data
        private TransaksiModel? _transaksiAktif;
        private DataTable _dtProdukSemua = new DataTable();

        // Metadata caches
        private Dictionary<int, string> _satuanProduk = new Dictionary<int, string>();
        private Dictionary<int, decimal> _stokProduk = new Dictionary<int, decimal>();

        // Services & Controllers
        private readonly TransaksiService _transaksiService = new TransaksiService();
        private readonly KatalogService _katalogService = new KatalogService();
        private readonly ProdukController _produkController = new ProdukController();

        // UI State
        private int _idKategoriAktif = 0;

        #endregion

        #region Constructor & Initialization

        public FormTransaksi()
        {
            InitializeComponent();
            InitializeAwalTransaksi();
        }

        private void InitializeAwalTransaksi()
        {
            // Validasi UI components
            ValidasiUIComponents();

            // Generate nomor invoice baru (via Service)
            string noInvoice = _transaksiService.GenerateNoInvoice();

            // Buat transaksi baru
            int idKasir = SesiPenggunaModel.PenggunaAktif?.IdPengguna ?? 1;
            _transaksiAktif = new TransaksiModel(noInvoice, idKasir);

            // Setup metode pembayaran
            SetupMetodePembayaran();

            // Setup nama kasir
            SetupNamaKasir();

            // Load katalog
            MuatKatalogProduk();

            // Update display
            HitungTotalBawah();

            // Hook search
            tbSearchTrans.TextChanged += tbSearchTrans_TextChanged;
        }

        private void ValidasiUIComponents()
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

                MessageBox.Show($"UI Components belum sinkron:\n\n{rincianNull}",
                    "Desainer UI Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #endregion

        #region Product Catalog Loading

        private void MuatKatalogProduk(DataTable? dtOverride = null)
        {
            flpKatalog.Controls.Clear();

            // Load dari database (atau gunakan override)
            if (dtOverride == null)
            {
                _dtProdukSemua = _katalogService.MuatSemuaProduk();
            }

            DataTable dtProduk = dtOverride ?? _dtProdukSemua;

            // Extract metadata (unit & stok) via Service
            _katalogService.ExtractProductMetadata(dtProduk, out _satuanProduk, out _stokProduk);

            // Render cards
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
                Text = _katalogService.FormatHarga(harga, satuan),
                Dock = DockStyle.Top,
                Height = 25,
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.ForestGreen
            };

            Label lblStok = new Label
            {
                Text = _katalogService.FormatStok(stok, satuan),
                Dock = DockStyle.Bottom,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = _katalogService.IsStokKritis(stok) ? Color.Red : Color.Gray
            };

            card.Controls.Add(lblHarga);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblStok);

            // Click handler: add to cart
            EventHandler klikCard = (s, e) => BtnTambahKeKeranjang_Click(id, nama, harga, stok);
            card.Click += klikCard;
            lblNama.Click += klikCard;
            lblHarga.Click += klikCard;
            lblStok.Click += klikCard;

            flpKatalog.Controls.Add(card);
        }

        #endregion

        #region Shopping Cart Management

        /// <summary>
        /// Button handler: tambah ke keranjang
        /// Delegates validation to Service
        /// </summary>
        private void BtnTambahKeKeranjang_Click(int idProduk, string nama, decimal harga, decimal stok)
        {
            // Validate via Service
            string? error = _transaksiService.ValidasiDanTambahItem(
                _transaksiAktif!,
                idProduk,
                nama,
                harga,
                stok,
                _satuanProduk);

            if (error != null)
            {
                UIHelper.Peringatan(error);
                return;
            }

            // Update UI
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

        private void RenderItemKeranjang(DetailTransaksiModel item)
        {
            string satuan = _transaksiService.GetSatuan(item.IdProduk, _satuanProduk);
            decimal takaran = _transaksiService.GetTakaran(satuan);

            Panel cardBarang = new Panel
            {
                Width = flpKeranjang.Width - 25,
                Height = 65,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(245, 245, 245),
                Margin = new Padding(4)
            };

            Label lblNama = new Label
            {
                Text = item.NamaProduk,
                Location = new Point(8, 8),
                Width = 150,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Label lblSub = new Label
            {
                Text = $"Rp {item.HitungSubtotal():N0}",
                Location = new Point(8, 34),
                Width = 120,
                ForeColor = Color.Navy
            };

            Button btnMin = new Button
            {
                Text = "-",
                Location = new Point(cardBarang.Width - 135, 15),
                Width = 30,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            string teksQty = "";
            string satuanLower = satuan.ToLower();
            if (satuanLower == "pcs" || satuanLower == "ikat")
            {
                teksQty = item.Jumlah.ToString("0") + " " + satuan;
            }
            
            else 
            {
                teksQty = item.Jumlah.ToString("0.##") + " " + satuan;
            }

            Label lblQty = new Label
            {
                Text = teksQty,
                Location = new Point(cardBarang.Width - 100, 20),
                Width = 55,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            Button btnPlus = new Button
            {
                Text = "+",
                Location = new Point(cardBarang.Width - 40, 15),
                Width = 30,
                Height = 30,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Click handlers
            btnMin.Click += (s, e) =>
            {
                BtnQuantityMinus_Click(item, takaran, lblQty);
            };

            btnPlus.Click += (s, e) =>
            {
                BtnQuantityPlus_Click(item, takaran, lblQty);
            };

            cardBarang.Controls.Add(lblNama);
            cardBarang.Controls.Add(lblSub);
            cardBarang.Controls.Add(btnMin);
            cardBarang.Controls.Add(lblQty);
            cardBarang.Controls.Add(btnPlus);

            flpKeranjang.Controls.Add(cardBarang);
        }

        private void BtnQuantityMinus_Click(DetailTransaksiModel item, decimal takaran, Label lblQty)
        {
            string? error = _transaksiService.UpdateQuantityItem(
                _transaksiAktif!,
                item,
                -takaran,
                _stokProduk.ContainsKey(item.IdProduk) ? _stokProduk[item.IdProduk] : 0,
                _satuanProduk);

            if (error != null)
            {
                UIHelper.Peringatan(error);
            }

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        private void BtnQuantityPlus_Click(DetailTransaksiModel item, decimal takaran, Label lblQty)
        {
            decimal stokMaks = _stokProduk.ContainsKey(item.IdProduk) ? _stokProduk[item.IdProduk] : 0m;

            string? error = _transaksiService.UpdateQuantityItem(
                _transaksiAktif!,
                item,
                takaran,
                stokMaks,
                _satuanProduk);

            if (error != null)
            {
                UIHelper.Peringatan(error);
                return;
            }

            RenderUlangKeranjang();
            HitungTotalBawah();
        }

        #endregion

        #region Payment Calculation

        private void HitungTotalBawah()
        {
            lblTotalHarga.Text = $"Rp {_transaksiAktif?.TotalHarga:N0}";
            HitungKembalianManual();
        }

        private void cmbMetodeBayar_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isTunai = cmbMetodeBayar.Text == "Tunai";
            pnlTunai.Visible = isTunai;

            if (!isTunai)
            {
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
            if (cmbMetodeBayar.Text == "Non-Tunai / QRIS")
                return;

            // Parse input via Service
            string? parseError = _transaksiService.ParseAndValidateNominal(txtUangBayar.Text, out decimal uangMasuk);

            if (parseError != null)
            {
                lblKembalian.Text = "Kembalian: Rp 0";
                lblKembalian.ForeColor = Color.Black;
                return;
            }

            // Calculate via Service
            decimal kembalian = _transaksiService.HitungKembalian(uangMasuk, _transaksiAktif!.TotalHarga);

            if (kembalian >= 0)
            {
                lblKembalian.Text = $"Kembalian: Rp {kembalian:N0}";
                lblKembalian.ForeColor = Color.Black;
            }
            else
            {
                lblKembalian.Text = "Uang Pembayaran Kurang!";
                lblKembalian.ForeColor = Color.Red;
            }
        }

        #endregion

        #region Checkout

        /// <summary>
        /// Button Bayar click handler
        /// Delegates all validation & business logic to Service
        /// </summary>
        private void btnBayar_Click(object sender, EventArgs e)
        {
            // Validate keranjang
            string? validateError = _transaksiService.ValidasiSebelumCheckout(_transaksiAktif);
            if (validateError != null)
            {
                UIHelper.Peringatan(validateError);
                return;
            }

            _transaksiAktif.MetodePembayaran = cmbMetodeBayar.Text;

            if (cmbMetodeBayar.Text == "Tunai")
            {
                // Parse nominal
                string? parseError = _transaksiService.ParseAndValidateNominal(txtUangBayar.Text, out decimal nominalBayar);
                if (parseError != null)
                {
                    UIHelper.Peringatan(parseError);
                    return;
                }

                // Validate pembayaran
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
                // Non-tunai: set total bayar = total harga (tanpa kembalian)
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
                // Execute checkout via Service
                bool sukses = _transaksiService.ExecuteCheckout(_transaksiAktif!);

                if (sukses)
                {
                    UIHelper.Sukses("✓ Transaksi Berhasil Diproses & Stok Berhasil Diperbarui!");

                    // Reset UI untuk transaksi baru
                    InitializeAwalTransaksi();
                    RenderUlangKeranjang();
                    txtUangBayar.Clear();
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error("Gagal menyimpan transaksi:\n" + ex.Message);
            }
        }

        #endregion

        #region Search & Filter

        private void tbSearchTrans_TextChanged(object? sender, EventArgs e)
        {
            string keyword = tbSearchTrans.Text.Trim();

            // Search via Service
            DataTable dtFiltered = _katalogService.CariProdukByNama(_dtProdukSemua, keyword);

            MuatKatalogProduk(dtFiltered);

            // Show empty message
            if (dtFiltered.Rows.Count == 0 && !string.IsNullOrEmpty(keyword))
            {
                Label lblKosong = new Label
                {
                    Text = $"Produk \"{keyword}\" tidak ditemukan.",
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

            // Filter via Service
            _dtProdukSemua = _katalogService.FilterByKategori(idKategori);
            MuatKatalogProduk(_dtProdukSemua);
        }

        #endregion

        #region Category Filter Buttons

        private void btnKAll_Click(object sender, EventArgs e) => FilterKategori(0);
        private void btnKSay_Click(object sender, EventArgs e) => FilterKategori(1);
        private void btnKBua_Click(object sender, EventArgs e) => FilterKategori(2);
        private void btnKBmb_Click(object sender, EventArgs e) => FilterKategori(3);

        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            string nama = SesiPenggunaModel.PenggunaAktif?.Username ?? "Pengguna";
            string role = SesiPenggunaModel.PenggunaAktif?.Role ?? "Sistem";

            bool yakinKeluar = UIHelper.Konfirmasi($"Apakah kamu yakin ingin logout dari akun {role} ({nama})?");

            if (yakinKeluar)
            {
                SesiPenggunaModel.Logout();

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

        private void flpKatalog_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}