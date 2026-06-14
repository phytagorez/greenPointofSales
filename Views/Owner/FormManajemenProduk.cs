using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using greenPointofSales.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormManajemenProduk : Form
    {
        private readonly ProdukController _controller = new ProdukController();
        private List<ProductCardData> _currentProducts = new List<ProductCardData>();
        private Button? btnKategoriAktif = null;

        private static class UIConstants
        {
            public static class StokAman
            {
                public static readonly Color LineColor = Color.FromArgb(29, 158, 117);
                public static readonly Color BgColor = Color.White;
                public static readonly Color HoverBgColor = Color.FromArgb(225, 245, 254);
                public static readonly Color StokLabelColor = Color.FromArgb(15, 110, 86);
            }

            public static class StokRendah
            {
                public static readonly Color LineColor = Color.FromArgb(226, 75, 74);
                public static readonly Color BgColor = Color.FromArgb(252, 235, 235);
                public static readonly Color HoverBgColor = Color.FromArgb(245, 194, 177);
                public static readonly Color StokLabelColor = Color.Red;
            }

            public static class ButtonColors
            {
                public static readonly Color UpdateNormal = Color.FromArgb(40, 167, 69);
                public static readonly Color UpdateHover = Color.FromArgb(33, 136, 56);
                public static readonly Color UpdateActive = Color.FromArgb(25, 105, 43);

                public static readonly Color BusukNormal = Color.FromArgb(220, 53, 69);
                public static readonly Color BusukHover = Color.FromArgb(189, 33, 48);
                public static readonly Color BusukActive = Color.FromArgb(158, 22, 32);
            }

            public static readonly Font FontProdukName = new Font("Segoe UI", 10, FontStyle.Bold);
            public static readonly Font FontHarga = new Font("Segoe UI", 11, FontStyle.Bold);
            public static readonly Font FontStok = new Font("Segoe UI", 9, FontStyle.Bold);
            public static readonly Font FontKategori = new Font("Segoe UI", 8, FontStyle.Italic);
            public static readonly Font FontButton = new Font("Segoe UI", 9, FontStyle.Bold);

            public static readonly Color TextPrimary = Color.FromArgb(40, 40, 40);
            public static readonly Color TextSecondary = Color.DimGray;
            public static readonly Color TextHarga = Color.DarkGreen;
        }

        public FormManajemenProduk()
        {
            InitializeComponent();
            UIHelper.IkatNavigasiMenu(this);
            flpKatalog.AutoScroll = true;
            flpKatalog.WrapContents = true;
            flpKatalog.FlowDirection = FlowDirection.LeftToRight;
            MuatFilterKategori();
            TampilkanKatalog(0);
        }

        private class ProductCardData
        {
            public int IdProduk { get; set; }
            public string NamaProduk { get; set; } = string.Empty;
            public decimal HargaJual { get; set; }
            public int Stok { get; set; }
            public string NamaKategori { get; set; } = string.Empty;
        }

        private void MuatFilterKategori()
        {
            try
            {
                DataTable dtKategori = _controller.DapatkanKategori();

                if (dtKategori == null || dtKategori.Rows.Count == 0)
                {
                    UIHelper.Peringatan("Database kategori kosong atau tidak terhubung.");
                    return;
                }
                btnKAll.Tag = 0;
                InisialisasiEventTombol(btnKAll);
                SetTombolAktif(btnKAll);

                foreach (DataRow row in dtKategori.Rows)
                {
                    int idKategori = Convert.ToInt32(row["id_kategori"]);
                    string namaKategori = row["nama_kategori"]?.ToString() ?? "";

                    if (namaKategori.ToLower().Contains("sayur"))
                    {
                        btnKSay.Tag = idKategori;
                        InisialisasiEventTombol(btnKSay);
                    }
                    else if (namaKategori.ToLower().Contains("buah"))
                    {
                        btnKBua.Tag = idKategori;
                        InisialisasiEventTombol(btnKBua);
                    }
                    else if (namaKategori.ToLower().Contains("bumbu"))
                    {
                        btnKBmb.Tag = idKategori;
                        InisialisasiEventTombol(btnKBmb);
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error($"Error saat inisialisasi tombol kategori:\n{ex.Message}");
            }
        }

        private void InisialisasiEventTombol(Button btn)
        {
            btn.Click -= TombolKategori_Click;
            btn.Click += TombolKategori_Click;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        private void TombolKategori_Click(object? sender, EventArgs e)
        {
            if (sender is Button btnTerpilih)
            {
                SetTombolAktif(btnTerpilih);
                int idTerpilih = Convert.ToInt32(btnTerpilih.Tag ?? 0);
                TampilkanKatalog(idTerpilih);
            }
        }

        private void SetTombolAktif(Button btnBaru)
        {
            if (btnKategoriAktif != null)
            {
                btnKategoriAktif.BackColor = Color.FromArgb(163, 177, 138);
                btnKategoriAktif.ForeColor = Color.White;
            }
            btnBaru.BackColor = Color.FromArgb(114, 140, 107);
            btnBaru.ForeColor = Color.White;
            btnKategoriAktif = btnBaru;
        }

        private void TampilkanKatalog(int idKategori)
        {
            try
            {
                flpKatalog.Controls.Clear();
                _currentProducts.Clear();

                DataTable dtProduk = _controller.DapatkanKatalogProduk(idKategori);

                if (dtProduk == null || dtProduk.Rows.Count == 0)
                {
                    Label lblKosong = new Label
                    {
                        Text = "📦 Tidak ada produk tersedia",
                        Font = new Font("Segoe UI", 12, FontStyle.Italic),
                        ForeColor = Color.Gray,
                        AutoSize = true,
                        Top = 20,
                        Left = 20
                    };
                    flpKatalog.Controls.Add(lblKosong);
                    return;
                }

                string[] requiredColumns = { "id_produk", "nama_produk", "harga_jual", "stok", "nama_kategori" };
                foreach (string col in requiredColumns)
                {
                    if (!dtProduk.Columns.Contains(col))
                    {
                        UIHelper.Error($"Kolom '{col}' tidak ditemukan dalam database.");
                        return;
                    }
                }

                foreach (DataRow row in dtProduk.Rows)
                {
                    try
                    {
                        var product = new ProductCardData
                        {
                            IdProduk = Convert.ToInt32(row["id_produk"] ?? 0),
                            NamaProduk = row["nama_produk"]?.ToString() ?? "Unnamed",
                            HargaJual = Convert.ToDecimal(row["harga_jual"] ?? 0),
                            Stok = Convert.ToInt32(row["stok"] ?? 0),
                            NamaKategori = row["nama_kategori"]?.ToString() ?? "Uncategorized"
                        };

                        _currentProducts.Add(product);
                        CreateProductCard(product);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing row: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                UIHelper.Error($"Error saat tampil katalog:\n{ex.Message}");
            }
        }

        private void CreateProductCard(ProductCardData product)
        {
            bool isStokAman = product.Stok > 5;
            Color lineColor = isStokAman ? UIConstants.StokAman.LineColor : UIConstants.StokRendah.LineColor;
            Color bgColor = isStokAman ? UIConstants.StokAman.BgColor : UIConstants.StokRendah.BgColor;
            Color hoverBgColor = isStokAman ? UIConstants.StokAman.HoverBgColor : UIConstants.StokRendah.HoverBgColor;
            Color stokLabelColor = isStokAman ? UIConstants.StokAman.StokLabelColor : UIConstants.StokRendah.StokLabelColor;

            Panel card = new Panel
            {
                Width = 260,
                Height = 295,
                BackColor = bgColor,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = product.IdProduk
            };

            Panel line = new Panel { Height = 6, Dock = DockStyle.Top, BackColor = lineColor };

            Label lblNama = new Label
            {
                Text = product.NamaProduk,
                Font = UIConstants.FontProdukName,
                Top = 12,
                Left = 12,
                Width = 236,
                Height = 40,
                AutoSize = false,
                AutoEllipsis = true,
                ForeColor = UIConstants.TextPrimary
            };

            Label lblHarga = new Label
            {
                Text = UIHelper.FormatRupiah(product.HargaJual),
                Font = UIConstants.FontHarga,
                Top = 55,
                Left = 12,
                Width = 236,
                ForeColor = UIConstants.TextHarga,
                AutoSize = false,
                AutoEllipsis = true
            };

            string stokText = product.Stok < 5 ? $"⚠ Stok: {product.Stok} (RENDAH!)" : $"✓ Stok: {product.Stok}";
            Label lblStok = new Label
            {
                Text = stokText,
                Font = UIConstants.FontStok,
                Top = 85,
                Left = 12,
                Width = 236,
                ForeColor = stokLabelColor,
                AutoSize = false,
                AutoEllipsis = true
            };

            Label lblKategori = new Label
            {
                Text = $"📂 {product.NamaKategori}",
                Font = UIConstants.FontKategori,
                Top = 105,
                Left = 12,
                Width = 236,
                ForeColor = UIConstants.TextSecondary,
                AutoEllipsis = true,
                AutoSize = false
            };

            Panel divider = new Panel { Height = 1, BackColor = Color.FromArgb(200, 200, 200), Top = 130, Left = 12, Width = 236 };

            Button btnUpdate = new Button
            {
                Text = "➕ UPDATE",
                Font = UIConstants.FontButton,
                Size = new Size(108, 42),
                Location = new Point(12, 145),
                BackColor = UIConstants.ButtonColors.UpdateNormal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Click += (s, e) => HandleUpdateStok(product);

            Button btnBusuk = new Button
            {
                Text = "❌ BUSUK",
                Font = UIConstants.FontButton,
                Size = new Size(108, 42),
                Location = new Point(140, 145),
                BackColor = UIConstants.ButtonColors.BusukNormal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnBusuk.FlatAppearance.BorderSize = 0;
            btnBusuk.Click += (s, e) => HandleBusukStok(product);

            Button btnInfo = new Button
            {
                Text = "ℹ️ DETAIL",
                Font = UIConstants.FontButton,
                Size = new Size(236, 36),
                Location = new Point(12, 200),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.Click += (s, e) => ShowProductDetails(product);

            Button btnCopyId = new Button
            {
                Text = "📋 ID: " + product.IdProduk,
                Font = new Font("Segoe UI", 8),
                Size = new Size(236, 28),
                Location = new Point(12, 246),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCopyId.FlatAppearance.BorderSize = 0;
            btnCopyId.Click += (s, e) => { Clipboard.SetText(product.IdProduk.ToString()); UIHelper.Sukses("ID produk disalin!"); };

            card.Controls.Add(line); card.Controls.Add(lblNama); card.Controls.Add(lblHarga);
            card.Controls.Add(lblStok); card.Controls.Add(lblKategori); card.Controls.Add(divider);
            card.Controls.Add(btnUpdate); card.Controls.Add(btnBusuk); card.Controls.Add(btnInfo); card.Controls.Add(btnCopyId);

            card.MouseEnter += (s, e) => { card.BackColor = hoverBgColor; };
            card.MouseLeave += (s, e) => { card.BackColor = bgColor; };

            flpKatalog.Controls.Add(card);
        }

        private void HandleUpdateStok(ProductCardData product)
        {
            string prompt = $"Masukkan jumlah stok yang ditambahkan:\n\nStok saat ini: {product.Stok} unit\n(Masukkan angka positif)";
            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, $"📥 Update Stok - {product.NamaProduk}", "");

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int jumlah) || jumlah <= 0)
            {
                UIHelper.Error("❌ Input harus berupa angka yang valid dan lebih dari 0!");
                return;
            }

            try
            {
                _controller.UpdateStok(product.IdProduk, jumlah);
                UIHelper.Sukses($"✓ Stok berhasil ditambah {jumlah} unit!");
                RefreshCatalog();
            }
            catch (Exception ex)
            {
                UIHelper.Error($"❌ Error: {ex.Message}");
            }
        }

        private void HandleBusukStok(ProductCardData product)
        {
            string prompt = $"Masukkan jumlah stok yang rusak/busuk:\n\nStok saat ini: {product.Stok} unit\n(Masukkan angka positif, akan dikurangi dari stok)";
            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, $"📤 Kurangi Stok (Rusak/Busuk) - {product.NamaProduk}", "");

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int jumlah) || jumlah <= 0)
            {
                UIHelper.Error("❌ Input harus berupa angka yang valid dan lebih besar dari 0!");
                return;
            }

            if (jumlah > product.Stok)
            {
                UIHelper.Error($"❌ Jumlah tidak boleh melebihi stok ({product.Stok} unit)!");
                return;
            }

            try
            {
                _controller.UpdateStok(product.IdProduk, -jumlah);
                UIHelper.Sukses($"✓ Stok berhasil dikurangi {jumlah} unit (Rusak/Busuk)!");
                RefreshCatalog();
            }
            catch (Exception ex)
            {
                UIHelper.Error($"❌ Error: {ex.Message}");
            }
        }

        private void ShowProductDetails(ProductCardData product)
        {
            string message = $"📦 DETAIL PRODUK\n\n" +
                           $"{'━'.ToString().PadRight(35, '━')}\n" +
                           $"Nama Produk  : {product.NamaProduk}\n" +
                           $"Harga Jual   : {UIHelper.FormatRupiah(product.HargaJual)}\n" +
                           $"Stok         : {product.Stok} unit\n" +
                           $"Kategori     : {product.NamaKategori}\n" +
                           $"ID Produk    : {product.IdProduk}\n" +
                           $"{'━'.ToString().PadRight(35, '━')}\n";

            MessageBox.Show(message, "📋 Informasi Produk", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshCatalog()
        {
            int selectedCategory = btnKategoriAktif?.Tag != null ? Convert.ToInt32(btnKategoriAktif.Tag) : 0;
            TampilkanKatalog(selectedCategory);
        }
    }
}