using greenPointofSales.Controllers;
using greenPointofSales.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace greenPointofSales.Views
{
    public partial class FormKatalog : Form
    {
        private readonly ProdukController _controller = new ProdukController();
        private List<ProductCardData> _currentProducts = new List<ProductCardData>();

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

        public FormKatalog()
        {
            InitializeComponent();
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
                cmbFilterKategori.SelectedIndexChanged -= cmbFilterKategori_SelectedIndexChanged;
                cmbFilterKategori.DataSource = null;

                DataTable dtKategori = _controller.DapatkanKategori();

                if (dtKategori == null || dtKategori.Rows.Count == 0)
                {
                    MessageBox.Show("Database kategori kosong atau tidak terhubung.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!dtKategori.Columns.Contains("id_kategori") || !dtKategori.Columns.Contains("nama_kategori"))
                {
                    MessageBox.Show("Struktur database tidak sesuai.\nKolom 'id_kategori' atau 'nama_kategori' tidak ditemukan.", "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dtFiltered = new DataTable();
                dtFiltered.Columns.Add("id_kategori", typeof(int));
                dtFiltered.Columns.Add("nama_kategori", typeof(string));

                DataRow rowSemua = dtFiltered.NewRow();
                rowSemua["id_kategori"] = 0;
                rowSemua["nama_kategori"] = "All";
                dtFiltered.Rows.Add(rowSemua);

                foreach (DataRow row in dtKategori.Rows)
                {
                    DataRow newRow = dtFiltered.NewRow();
                    newRow["id_kategori"] = row["id_kategori"];
                    newRow["nama_kategori"] = row["nama_kategori"];
                    dtFiltered.Rows.Add(newRow);
                }

                cmbFilterKategori.DataSource = dtFiltered;
                cmbFilterKategori.DisplayMember = "nama_kategori";
                cmbFilterKategori.ValueMember = "id_kategori";
                cmbFilterKategori.SelectedIndex = 0;

                cmbFilterKategori.SelectedIndexChanged += cmbFilterKategori_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat memuat kategori:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbFilterKategori_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                if (cmbFilterKategori.SelectedValue == null) return;

                int idTerpilih = 0;
                object val = cmbFilterKategori.SelectedValue;

                if (val is int id)
                {
                    idTerpilih = id;
                }
                else if (val is DataRowView drv)
                {
                    idTerpilih = Convert.ToInt32(drv["id_kategori"]);
                }
                else if (val != null && int.TryParse(val.ToString(), out int parsedId))
                {
                    idTerpilih = parsedId;
                }

                TampilkanKatalog(idTerpilih);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat filter kategori:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        MessageBox.Show($"Kolom '{col}' tidak ditemukan dalam database.", "Error Struktur Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error saat tampil katalog:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateProductCard(ProductCardData product)
        {
            bool isStokAman = product.Stok > 5;
            Color lineColor = isStokAman ? UIConstants.StokAman.LineColor : UIConstants.StokRendah.LineColor;
            Color bgColor = isStokAman ? UIConstants.StokAman.BgColor : UIConstants.StokRendah.BgColor;
            Color hoverBgColor = isStokAman ? UIConstants.StokAman.HoverBgColor : UIConstants.StokRendah.HoverBgColor;
            Color stokLabelColor = isStokAman ? UIConstants.StokAman.StokLabelColor : UIConstants.StokRendah.StokLabelColor;

            // CARD CONTAINER - Ukuran diperbesar untuk menampung semua elemen
            Panel card = new Panel
            {
                Width = 260,
                Height = 295,  // Diperbesar dari 160 menjadi 295
                BackColor = bgColor,
                Margin = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = product.IdProduk
            };

            // TOP LINE INDICATOR
            Panel line = new Panel
            {
                Height = 6,
                Dock = DockStyle.Top,
                BackColor = lineColor
            };

            // PRODUCT NAME
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

            // PRICE
            Label lblHarga = new Label
            {
                Text = "Rp " + product.HargaJual.ToString("N0"),
                Font = UIConstants.FontHarga,
                Top = 55,
                Left = 12,
                Width = 236,
                ForeColor = UIConstants.TextHarga,
                AutoSize = false,
                AutoEllipsis = true
            };

            // STOCK STATUS
            string stokText = product.Stok < 5
                ? $"⚠ Stok: {product.Stok} (RENDAH!)"
                : $"✓ Stok: {product.Stok}";

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

            // CATEGORY
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

            // DIVIDER LINE
            Panel divider = new Panel
            {
                Height = 1,
                BackColor = Color.FromArgb(200, 200, 200),
                Top = 130,
                Left = 12,
                Width = 236
            };

            // ============================================
            // UPDATE BUTTON - IMPROVED UI
            // ============================================
            Button btnUpdate = new Button
            {
                Text = "➕ UPDATE",
                Font = UIConstants.FontButton,
                Size = new Size(108, 42),
                Location = new Point(12, 145),
                BackColor = UIConstants.ButtonColors.UpdateNormal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseDownBackColor = UIConstants.ButtonColors.UpdateActive;
            btnUpdate.FlatAppearance.MouseOverBackColor = UIConstants.ButtonColors.UpdateHover;

            btnUpdate.MouseEnter += (s, e) =>
            {
                btnUpdate.BackColor = UIConstants.ButtonColors.UpdateHover;
                btnUpdate.Font = new Font(UIConstants.FontButton.FontFamily, 9, FontStyle.Bold | FontStyle.Underline);
            };

            btnUpdate.MouseLeave += (s, e) =>
            {
                btnUpdate.BackColor = UIConstants.ButtonColors.UpdateNormal;
                btnUpdate.Font = UIConstants.FontButton;
            };

            btnUpdate.MouseDown += (s, e) =>
            {
                btnUpdate.BackColor = UIConstants.ButtonColors.UpdateActive;
            };

            btnUpdate.MouseUp += (s, e) =>
            {
                btnUpdate.BackColor = UIConstants.ButtonColors.UpdateHover;
            };

            btnUpdate.Click += (s, e) =>
            {
                HandleUpdateStok(product);
            };

            // ============================================
            // BUSUK BUTTON - IMPROVED UI
            // ============================================
            Button btnBusuk = new Button
            {
                Text = "❌ BUSUK",
                Font = UIConstants.FontButton,
                Size = new Size(108, 42),
                Location = new Point(140, 145),
                BackColor = UIConstants.ButtonColors.BusukNormal,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnBusuk.FlatAppearance.BorderSize = 0;
            btnBusuk.FlatAppearance.MouseDownBackColor = UIConstants.ButtonColors.BusukActive;
            btnBusuk.FlatAppearance.MouseOverBackColor = UIConstants.ButtonColors.BusukHover;

            btnBusuk.MouseEnter += (s, e) =>
            {
                btnBusuk.BackColor = UIConstants.ButtonColors.BusukHover;
                btnBusuk.Font = new Font(UIConstants.FontButton.FontFamily, 9, FontStyle.Bold | FontStyle.Underline);
            };

            btnBusuk.MouseLeave += (s, e) =>
            {
                btnBusuk.BackColor = UIConstants.ButtonColors.BusukNormal;
                btnBusuk.Font = UIConstants.FontButton;
            };

            btnBusuk.MouseDown += (s, e) =>
            {
                btnBusuk.BackColor = UIConstants.ButtonColors.BusukActive;
            };

            btnBusuk.MouseUp += (s, e) =>
            {
                btnBusuk.BackColor = UIConstants.ButtonColors.BusukHover;
            };

            btnBusuk.Click += (s, e) =>
            {
                HandleBusukStok(product);
            };

            // INFO BUTTON - LIHAT DETAIL
            Button btnInfo = new Button
            {
                Text = "ℹ️ DETAIL",
                Font = UIConstants.FontButton,
                Size = new Size(236, 36),
                Location = new Point(12, 200),
                BackColor = Color.FromArgb(23, 162, 184),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnInfo.FlatAppearance.BorderSize = 0;
            btnInfo.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 129, 147);

            btnInfo.MouseEnter += (s, e) =>
            {
                btnInfo.BackColor = Color.FromArgb(17, 129, 147);
            };

            btnInfo.MouseLeave += (s, e) =>
            {
                btnInfo.BackColor = Color.FromArgb(23, 162, 184);
            };

            btnInfo.Click += (s, e) =>
            {
                ShowProductDetails(product);
            };

            // COPY ID BUTTON - UTILITY
            Button btnCopyId = new Button
            {
                Text = "📋 ID: " + product.IdProduk,
                Font = new Font("Segoe UI", 8),
                Size = new Size(236, 28),
                Location = new Point(12, 246),
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnCopyId.FlatAppearance.BorderSize = 0;
            btnCopyId.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 80, 87);

            btnCopyId.MouseEnter += (s, e) =>
            {
                btnCopyId.BackColor = Color.FromArgb(73, 80, 87);
            };

            btnCopyId.MouseLeave += (s, e) =>
            {
                btnCopyId.BackColor = Color.FromArgb(108, 117, 125);
            };

            btnCopyId.Click += (s, e) =>
            {
                Clipboard.SetText(product.IdProduk.ToString());
                UIHelper.Sukses("ID produk disalin!");
            };

            // ADD CONTROLS TO CARD
            card.Controls.Add(line);
            card.Controls.Add(lblNama);
            card.Controls.Add(lblHarga);
            card.Controls.Add(lblStok);
            card.Controls.Add(lblKategori);
            card.Controls.Add(divider);
            card.Controls.Add(btnUpdate);
            card.Controls.Add(btnBusuk);
            card.Controls.Add(btnInfo);
            card.Controls.Add(btnCopyId);

            // CARD HOVER EFFECTS
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = hoverBgColor;
                card.BorderStyle = BorderStyle.FixedSingle;
            };

            card.MouseLeave += (s, e) =>
            {
                card.BackColor = bgColor;
            };

            flpKatalog.Controls.Add(card);
        }

        /// <summary>
        /// Handle Update Stok Logic
        /// </summary>
        private void HandleUpdateStok(ProductCardData product)
        {
            string title = $"📥 Update Stok - {product.NamaProduk}";
            string prompt = $"Masukkan jumlah stok yang ditambahkan:\n\n" +
                           $"Stok saat ini: {product.Stok} unit\n" +
                           $"(Masukkan angka positif)";

            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "");

            // VALIDASI INPUT
            if (string.IsNullOrWhiteSpace(input))
            {
                return; // User cancel
            }

            if (!int.TryParse(input, out int jumlah))
            {
                UIHelper.Error("❌ Input harus berupa angka yang valid!");
                return;
            }

            if (jumlah <= 0)
            {
                UIHelper.Error("❌ Jumlah harus lebih besar dari 0!");
                return;
            }

            // EXECUTE UPDATE
            try
            {
                _controller.UpdateStok(product.IdProduk, jumlah); // POSITIF (+)
                UIHelper.Sukses($"✓ Stok berhasil ditambah {jumlah} unit!");
                RefreshCatalog();
            }
            catch (Exception ex)
            {
                UIHelper.Error($"❌ Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Handle Busuk Stok Logic
        /// </summary>
        private void HandleBusukStok(ProductCardData product)
        {
            string title = $"📤 Kurangi Stok (Rusak/Busuk) - {product.NamaProduk}";
            string prompt = $"Masukkan jumlah stok yang rusak/busuk:\n\n" +
                           $"Stok saat ini: {product.Stok} unit\n" +
                           $"(Masukkan angka positif, akan dikurangi dari stok)";

            string input = Microsoft.VisualBasic.Interaction.InputBox(prompt, title, "");

            // VALIDASI INPUT
            if (string.IsNullOrWhiteSpace(input))
            {
                return; // User cancel
            }

            if (!int.TryParse(input, out int jumlah))
            {
                UIHelper.Error("❌ Input harus berupa angka yang valid!");
                return;
            }

            if (jumlah <= 0)
            {
                UIHelper.Error("❌ Jumlah harus lebih besar dari 0!");
                return;
            }

            if (jumlah > product.Stok)
            {
                UIHelper.Error($"❌ Jumlah tidak boleh melebihi stok ({product.Stok} unit)!");
                return;
            }

            // EXECUTE UPDATE
            try
            {
                _controller.UpdateStok(product.IdProduk, -jumlah); // NEGATIF (-)
                UIHelper.Sukses($"✓ Stok berhasil dikurangi {jumlah} unit (Rusak/Busuk)!");
                RefreshCatalog();
            }
            catch (Exception ex)
            {
                UIHelper.Error($"❌ Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Show Product Details
        /// </summary>
        private void ShowProductDetails(ProductCardData product)
        {
            string message = $"📦 DETAIL PRODUK\n\n" +
                           $"{'━'.ToString().PadRight(35, '━')}\n" +
                           $"Nama Produk  : {product.NamaProduk}\n" +
                           $"Harga Jual   : Rp {product.HargaJual:N0}\n" +
                           $"Stok         : {product.Stok} unit\n" +
                           $"Kategori     : {product.NamaKategori}\n" +
                           $"ID Produk    : {product.IdProduk}\n" +
                           $"{'━'.ToString().PadRight(35, '━')}\n";

            MessageBox.Show(message, "📋 Informasi Produk", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Refresh Catalog Display
        /// </summary>
        private void RefreshCatalog()
        {
            int selectedCategory = Convert.ToInt32(cmbFilterKategori.SelectedValue ?? 0);
            TampilkanKatalog(selectedCategory);
        }
    }
} 