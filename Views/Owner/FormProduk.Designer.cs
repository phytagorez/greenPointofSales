namespace greenPointofSales.Views
{
    partial class FormProduk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtNamaProduk = new TextBox();
            txtHargaJual = new TextBox();
            txtHargaBeli = new TextBox();
            txtStok = new TextBox();
            cmbKategori = new ComboBox();
            btnSimpan = new Button();
            dgvProduk = new DataGridView();
            btnBusuk = new Button();
            pbMenu = new PictureBox();
            lblMenu = new Label();
            lblLaporan = new Label();
            lblPengelolaan = new Label();
            lblMaster = new Label();
            btnLaporan = new Button();
            btnMenuDashboard = new Button();
            btnMenuKatalog = new Button();
            btnLogout = new Button();
            btnMenuProduk = new Button();
            btnMenuKaryawan = new Button();
            tbSearchBar = new Guna.UI2.WinForms.Guna2TextBox();
            cmbSatuan = new Guna.UI2.WinForms.Guna2ComboBox();
            label1 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            label6 = new Label();
            label5 = new Label();
            panel2 = new Panel();
            label7 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.BackColor = Color.White;
            txtNamaProduk.BorderStyle = BorderStyle.None;
            txtNamaProduk.Font = new Font("Modern No. 20", 12F);
            txtNamaProduk.ForeColor = Color.Black;
            txtNamaProduk.Location = new Point(247, 495);
            txtNamaProduk.Multiline = true;
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(233, 40);
            txtNamaProduk.TabIndex = 0;
            // 
            // txtHargaJual
            // 
            txtHargaJual.BackColor = Color.White;
            txtHargaJual.BorderStyle = BorderStyle.None;
            txtHargaJual.Font = new Font("Modern No. 20", 12F);
            txtHargaJual.ForeColor = Color.Black;
            txtHargaJual.Location = new Point(589, 604);
            txtHargaJual.Multiline = true;
            txtHargaJual.Name = "txtHargaJual";
            txtHargaJual.Size = new Size(233, 40);
            txtHargaJual.TabIndex = 1;
            // 
            // txtHargaBeli
            // 
            txtHargaBeli.BackColor = Color.White;
            txtHargaBeli.BorderStyle = BorderStyle.None;
            txtHargaBeli.Font = new Font("Modern No. 20", 12F);
            txtHargaBeli.ForeColor = Color.Black;
            txtHargaBeli.Location = new Point(589, 495);
            txtHargaBeli.Multiline = true;
            txtHargaBeli.Name = "txtHargaBeli";
            txtHargaBeli.Size = new Size(233, 40);
            txtHargaBeli.TabIndex = 3;
            // 
            // txtStok
            // 
            txtStok.BackColor = Color.White;
            txtStok.BorderStyle = BorderStyle.None;
            txtStok.Font = new Font("Modern No. 20", 12F);
            txtStok.ForeColor = Color.Black;
            txtStok.Location = new Point(247, 604);
            txtStok.Multiline = true;
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(233, 40);
            txtStok.TabIndex = 4;
            txtStok.Text = "   ";
            // 
            // cmbKategori
            // 
            cmbKategori.BackColor = Color.White;
            cmbKategori.Cursor = Cursors.Hand;
            cmbKategori.FlatStyle = FlatStyle.Flat;
            cmbKategori.Font = new Font("Modern No. 20", 12F);
            cmbKategori.ForeColor = Color.Black;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(931, 501);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(233, 30);
            cmbKategori.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(227, 233, 207);
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Popup;
            btnSimpan.Font = new Font("Modern No. 20", 12F);
            btnSimpan.ForeColor = Color.Black;
            btnSimpan.Location = new Point(589, 657);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 6;
            btnSimpan.Text = "Save";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvProduk
            // 
            dgvProduk.BackgroundColor = Color.FromArgb(148, 172, 137);
            dgvProduk.BorderStyle = BorderStyle.None;
            dgvProduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduk.Location = new Point(222, 86);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.Size = new Size(1009, 328);
            dgvProduk.TabIndex = 7;
            dgvProduk.Click += tbSearchBar_TextChanged;
            // 
            // btnBusuk
            // 
            btnBusuk.BackColor = Color.FromArgb(227, 233, 207);
            btnBusuk.Cursor = Cursors.Hand;
            btnBusuk.FlatAppearance.BorderSize = 0;
            btnBusuk.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBusuk.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBusuk.FlatStyle = FlatStyle.Popup;
            btnBusuk.Font = new Font("Modern No. 20", 12F);
            btnBusuk.ForeColor = Color.Black;
            btnBusuk.Location = new Point(728, 657);
            btnBusuk.Name = "btnBusuk";
            btnBusuk.Size = new Size(94, 29);
            btnBusuk.TabIndex = 14;
            btnBusuk.Text = "Mark";
            btnBusuk.UseVisualStyleBackColor = false;
            btnBusuk.Click += btnBusuk_Click;
            // 
            // pbMenu
            // 
            pbMenu.BackColor = Color.Transparent;
            pbMenu.Image = Properties.Resources.list;
            pbMenu.Location = new Point(34, 24);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(26, 26);
            pbMenu.TabIndex = 33;
            pbMenu.TabStop = false;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.BackColor = Color.Transparent;
            lblMenu.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMenu.ForeColor = Color.Black;
            lblMenu.Location = new Point(67, 25);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(56, 22);
            lblMenu.TabIndex = 32;
            lblMenu.Text = "Menu";
            lblMenu.TextChanged += tbSearchBar_TextChanged;
            // 
            // lblLaporan
            // 
            lblLaporan.AutoSize = true;
            lblLaporan.BackColor = Color.Transparent;
            lblLaporan.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblLaporan.ForeColor = Color.Black;
            lblLaporan.Location = new Point(10, 400);
            lblLaporan.Name = "lblLaporan";
            lblLaporan.Size = new Size(87, 22);
            lblLaporan.TabIndex = 31;
            lblLaporan.Text = "Laporan";
            // 
            // lblPengelolaan
            // 
            lblPengelolaan.AutoSize = true;
            lblPengelolaan.BackColor = Color.Transparent;
            lblPengelolaan.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblPengelolaan.ForeColor = Color.Black;
            lblPengelolaan.Location = new Point(10, 239);
            lblPengelolaan.Name = "lblPengelolaan";
            lblPengelolaan.Size = new Size(120, 22);
            lblPengelolaan.TabIndex = 30;
            lblPengelolaan.Text = "Pengelolaan";
            // 
            // lblMaster
            // 
            lblMaster.AutoSize = true;
            lblMaster.BackColor = Color.Transparent;
            lblMaster.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblMaster.ForeColor = Color.Black;
            lblMaster.Location = new Point(10, 148);
            lblMaster.Name = "lblMaster";
            lblMaster.Size = new Size(71, 22);
            lblMaster.TabIndex = 29;
            lblMaster.Text = "Master";
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.Transparent;
            btnLaporan.Cursor = Cursors.Hand;
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnLaporan.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnLaporan.FlatStyle = FlatStyle.Popup;
            btnLaporan.Font = new Font("Georgia", 10.2F);
            btnLaporan.ForeColor = Color.Black;
            btnLaporan.Image = Properties.Resources.bar_chart;
            btnLaporan.ImageAlign = ContentAlignment.MiddleLeft;
            btnLaporan.Location = new Point(27, 428);
            btnLaporan.Margin = new Padding(3, 4, 3, 4);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(149, 48);
            btnLaporan.TabIndex = 28;
            btnLaporan.Text = "   Laporan";
            btnLaporan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLaporan.UseVisualStyleBackColor = false;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnMenuDashboard
            // 
            btnMenuDashboard.BackColor = Color.Transparent;
            btnMenuDashboard.Cursor = Cursors.Hand;
            btnMenuDashboard.FlatAppearance.BorderSize = 0;
            btnMenuDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuDashboard.FlatStyle = FlatStyle.Popup;
            btnMenuDashboard.Font = new Font("Georgia", 10.2F);
            btnMenuDashboard.ForeColor = Color.Black;
            btnMenuDashboard.Image = Properties.Resources.home;
            btnMenuDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuDashboard.Location = new Point(27, 87);
            btnMenuDashboard.Margin = new Padding(3, 4, 3, 4);
            btnMenuDashboard.Name = "btnMenuDashboard";
            btnMenuDashboard.Size = new Size(149, 48);
            btnMenuDashboard.TabIndex = 27;
            btnMenuDashboard.Text = "   Dashboard";
            btnMenuDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuDashboard.UseVisualStyleBackColor = false;
            btnMenuDashboard.Click += btnMenuDashboard_Click;
            // 
            // btnMenuKatalog
            // 
            btnMenuKatalog.BackColor = Color.Transparent;
            btnMenuKatalog.Cursor = Cursors.Hand;
            btnMenuKatalog.FlatAppearance.BorderSize = 0;
            btnMenuKatalog.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuKatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuKatalog.FlatStyle = FlatStyle.Popup;
            btnMenuKatalog.Font = new Font("Georgia", 10.2F);
            btnMenuKatalog.ForeColor = Color.Black;
            btnMenuKatalog.Image = Properties.Resources.boxes;
            btnMenuKatalog.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuKatalog.Location = new Point(27, 269);
            btnMenuKatalog.Margin = new Padding(4);
            btnMenuKatalog.Name = "btnMenuKatalog";
            btnMenuKatalog.Size = new Size(149, 53);
            btnMenuKatalog.TabIndex = 26;
            btnMenuKatalog.Text = "   Manajemen     Produk      ";
            btnMenuKatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKatalog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuKatalog.UseVisualStyleBackColor = false;
            btnMenuKatalog.Click += btnMenuKatalog_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(227, 233, 207);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(215, 235, 200);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 200);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.Black;
            btnLogout.Image = Properties.Resources.log_out;
            btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
            btnLogout.Location = new Point(43, 679);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(90, 36);
            btnLogout.TabIndex = 25;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMenuProduk
            // 
            btnMenuProduk.BackColor = Color.Transparent;
            btnMenuProduk.Cursor = Cursors.Hand;
            btnMenuProduk.FlatAppearance.BorderSize = 0;
            btnMenuProduk.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuProduk.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuProduk.FlatStyle = FlatStyle.Popup;
            btnMenuProduk.Font = new Font("Georgia", 10.2F);
            btnMenuProduk.ForeColor = Color.Black;
            btnMenuProduk.Image = Properties.Resources.shopping_cart_add;
            btnMenuProduk.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuProduk.Location = new Point(27, 174);
            btnMenuProduk.Margin = new Padding(3, 4, 3, 4);
            btnMenuProduk.Name = "btnMenuProduk";
            btnMenuProduk.Size = new Size(149, 48);
            btnMenuProduk.TabIndex = 24;
            btnMenuProduk.Text = "   Produk";
            btnMenuProduk.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuProduk.UseVisualStyleBackColor = false;
            // 
            // btnMenuKaryawan
            // 
            btnMenuKaryawan.BackColor = Color.Transparent;
            btnMenuKaryawan.Cursor = Cursors.Hand;
            btnMenuKaryawan.FlatAppearance.BorderSize = 0;
            btnMenuKaryawan.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuKaryawan.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuKaryawan.FlatStyle = FlatStyle.Popup;
            btnMenuKaryawan.Font = new Font("Georgia", 10.2F);
            btnMenuKaryawan.ForeColor = Color.Black;
            btnMenuKaryawan.Image = Properties.Resources.add_user;
            btnMenuKaryawan.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuKaryawan.Location = new Point(27, 329);
            btnMenuKaryawan.Margin = new Padding(3, 4, 3, 4);
            btnMenuKaryawan.Name = "btnMenuKaryawan";
            btnMenuKaryawan.Size = new Size(149, 53);
            btnMenuKaryawan.TabIndex = 23;
            btnMenuKaryawan.Text = "   Manajemen     Karyawan";
            btnMenuKaryawan.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKaryawan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuKaryawan.UseVisualStyleBackColor = false;
            btnMenuKaryawan.Click += btnMenuKaryawan_Click;
            // 
            // tbSearchBar
            // 
            tbSearchBar.BackColor = Color.Transparent;
            tbSearchBar.BorderColor = Color.Transparent;
            tbSearchBar.BorderRadius = 15;
            tbSearchBar.CustomizableEdges = customizableEdges1;
            tbSearchBar.DefaultText = "";
            tbSearchBar.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbSearchBar.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbSearchBar.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbSearchBar.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbSearchBar.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbSearchBar.Font = new Font("Palatino Linotype", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchBar.ForeColor = Color.Black;
            tbSearchBar.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbSearchBar.IconRight = Properties.Resources.search;
            tbSearchBar.IconRightOffset = new Point(5, 0);
            tbSearchBar.Location = new Point(910, 25);
            tbSearchBar.Margin = new Padding(4, 5, 4, 5);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.PlaceholderForeColor = Color.Black;
            tbSearchBar.PlaceholderText = "Search ...";
            tbSearchBar.SelectedText = "";
            tbSearchBar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbSearchBar.Size = new Size(300, 30);
            tbSearchBar.TabIndex = 34;
            tbSearchBar.TextChanged += tbSearchBar_TextChanged;
            // 
            // cmbSatuan
            // 
            cmbSatuan.BackColor = Color.White;
            cmbSatuan.CustomizableEdges = customizableEdges3;
            cmbSatuan.DrawMode = DrawMode.OwnerDrawFixed;
            cmbSatuan.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSatuan.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbSatuan.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbSatuan.Font = new Font("Modern No. 20", 12F);
            cmbSatuan.ForeColor = Color.Black;
            cmbSatuan.ItemHeight = 30;
            cmbSatuan.Items.AddRange(new object[] { "Ikat", "Kg", "Pcs" });
            cmbSatuan.Location = new Point(931, 604);
            cmbSatuan.Name = "cmbSatuan";
            cmbSatuan.ShadowDecoration.CustomizableEdges = customizableEdges4;
            cmbSatuan.Size = new Size(233, 36);
            cmbSatuan.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            cmbSatuan.TabIndex = 35;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(684, 1);
            label1.Name = "label1";
            label1.Size = new Size(150, 26);
            label1.TabIndex = 36;
            label1.Text = "Satuan Produk";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(148, 172, 137);
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(350, 2);
            label3.Name = "label3";
            label3.Size = new Size(108, 26);
            label3.TabIndex = 37;
            label3.Text = "Harga Beli";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(148, 172, 137);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(247, 463);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 30);
            panel1.TabIndex = 38;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(1, 2);
            label6.Name = "label6";
            label6.Size = new Size(141, 26);
            label6.TabIndex = 39;
            label6.Text = "Nama Produk";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(684, 2);
            label5.Name = "label5";
            label5.Size = new Size(91, 26);
            label5.TabIndex = 38;
            label5.Text = "Kategori";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(148, 172, 137);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(247, 573);
            panel2.Name = "panel2";
            panel2.Size = new Size(917, 30);
            panel2.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(148, 172, 137);
            label7.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(1, 1);
            label7.Name = "label7";
            label7.Size = new Size(130, 26);
            label7.TabIndex = 38;
            label7.Text = "Stok Produk";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(148, 172, 137);
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(350, 2);
            label4.Name = "label4";
            label4.Size = new Size(109, 26);
            label4.TabIndex = 37;
            label4.Text = "Harga Jual";
            // 
            // FormProduk
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            BackgroundImage = Properties.Resources.Produk_O;
            ClientSize = new Size(1280, 720);
            Controls.Add(panel1);
            Controls.Add(cmbSatuan);
            Controls.Add(tbSearchBar);
            Controls.Add(pbMenu);
            Controls.Add(lblMenu);
            Controls.Add(lblLaporan);
            Controls.Add(lblPengelolaan);
            Controls.Add(lblMaster);
            Controls.Add(btnLaporan);
            Controls.Add(btnMenuDashboard);
            Controls.Add(btnMenuKatalog);
            Controls.Add(btnLogout);
            Controls.Add(btnMenuProduk);
            Controls.Add(btnMenuKaryawan);
            Controls.Add(btnBusuk);
            Controls.Add(dgvProduk);
            Controls.Add(btnSimpan);
            Controls.Add(cmbKategori);
            Controls.Add(txtStok);
            Controls.Add(txtHargaBeli);
            Controls.Add(txtHargaJual);
            Controls.Add(txtNamaProduk);
            Controls.Add(panel2);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormProduk";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormManajemenProduk";
            ((System.ComponentModel.ISupportInitialize)dgvProduk).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNamaProduk;
        private TextBox txtHargaJual;
        private TextBox txtHargaBeli;
        private TextBox txtStok;
        private ComboBox cmbKategori;
        private Button btnSimpan;
        private DataGridView dgvProduk;
        private Button btnBusuk;
        private PictureBox pbMenu;
        private Label lblMenu;
        private Label lblLaporan;
        private Label lblPengelolaan;
        private Label lblMaster;
        private Button btnLaporan;
        private Button btnMenuDashboard;
        private Button btnMenuKatalog;
        private Button btnLogout;
        private Button btnMenuProduk;
        private Button btnMenuKaryawan;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchBar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbSatuan;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private Label label6;
        private Label label5;
        private Panel panel2;
        private Label label7;
        private Label label4;
    }
}