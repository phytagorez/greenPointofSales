namespace greenPointofSales.Views
{
    partial class UC_LaporanPenjualan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            this.Size = new Size(1280, 720);
            this.AutoScaleMode = AutoScaleMode.None;
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            dtpDari = new DateTimePicker();
            dtpSampai = new DateTimePicker();
            cmbMetodeBayar = new ComboBox();
            btnFilter = new Button();
            btnCetak = new Button();
            lblTotalPenjualan = new Label();
            lblTotalTransaksi = new Label();
            dgvPenjualan = new DataGridView();
            panelChart = new Panel();
            panel1 = new Panel();
            pbMenu = new PictureBox();
            label1 = new Label();
            lblLaporan = new Label();
            lblPengelolaan = new Label();
            lblMaster = new Label();
            btnLaporan = new Button();
            btnMenuDashboard = new Button();
            btnMenuKatalog = new Button();
            btnLogout = new Button();
            btnMenuProduk = new Button();
            btnMenuKaryawan = new Button();
            btnLapLabaRugi = new Button();
            btnLapPenjualan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPenjualan).BeginInit();
            panelChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // dtpDari
            // 
            dtpDari.CalendarTitleBackColor = Color.White;
            dtpDari.Font = new Font("Mongolian Baiti", 10.2F);
            dtpDari.Location = new Point(222, 150);
            dtpDari.Name = "dtpDari";
            dtpDari.Size = new Size(250, 27);
            dtpDari.TabIndex = 0;
            // 
            // dtpSampai
            // 
            dtpSampai.CalendarTitleBackColor = Color.White;
            dtpSampai.Font = new Font("Mongolian Baiti", 10.2F);
            dtpSampai.Location = new Point(222, 213);
            dtpSampai.Name = "dtpSampai";
            dtpSampai.Size = new Size(250, 27);
            dtpSampai.TabIndex = 1;
            // 
            // cmbMetodeBayar
            // 
            cmbMetodeBayar.Font = new Font("Mongolian Baiti", 10.2F);
            cmbMetodeBayar.FormattingEnabled = true;
            cmbMetodeBayar.Items.AddRange(new object[] { "All", "Tunai", "Non-Tunai" });
            cmbMetodeBayar.Location = new Point(527, 150);
            cmbMetodeBayar.Name = "cmbMetodeBayar";
            cmbMetodeBayar.Size = new Size(151, 26);
            cmbMetodeBayar.TabIndex = 2;
            // 
            // btnFilter
            // 
            btnFilter.Font = new Font("Mongolian Baiti", 10.2F);
            btnFilter.Location = new Point(549, 209);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnCetak
            // 
            btnCetak.BackColor = Color.FromArgb(227, 233, 207);
            btnCetak.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCetak.Location = new Point(923, 0);
            btnCetak.Name = "btnCetak";
            btnCetak.Size = new Size(117, 40);
            btnCetak.TabIndex = 4;
            btnCetak.Text = "Cetak";
            btnCetak.UseVisualStyleBackColor = false;
            btnCetak.Click += btnCetak_Click;
            // 
            // lblTotalPenjualan
            // 
            lblTotalPenjualan.AutoSize = true;
            lblTotalPenjualan.Location = new Point(288, 316);
            lblTotalPenjualan.Name = "lblTotalPenjualan";
            lblTotalPenjualan.Size = new Size(72, 20);
            lblTotalPenjualan.TabIndex = 5;
            lblTotalPenjualan.Text = "Penjualan";
            // 
            // lblTotalTransaksi
            // 
            lblTotalTransaksi.AutoSize = true;
            lblTotalTransaksi.Location = new Point(566, 316);
            lblTotalTransaksi.Name = "lblTotalTransaksi";
            lblTotalTransaksi.Size = new Size(68, 20);
            lblTotalTransaksi.TabIndex = 6;
            lblTotalTransaksi.Text = "Transaksi";
            // 
            // dgvPenjualan
            // 
            dgvPenjualan.BackgroundColor = Color.FromArgb(148, 172, 137);
            dgvPenjualan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenjualan.Location = new Point(729, 98);
            dgvPenjualan.Name = "dgvPenjualan";
            dgvPenjualan.RowHeadersWidth = 51;
            dgvPenjualan.Size = new Size(519, 273);
            dgvPenjualan.TabIndex = 7;
            // 
            // panelChart
            // 
            panelChart.BackColor = Color.FromArgb(148, 172, 137);
            panelChart.Controls.Add(btnCetak);
            panelChart.Location = new Point(208, 389);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1040, 299);
            panelChart.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(148, 172, 137);
            panel1.Location = new Point(222, 160);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 52);
            panel1.TabIndex = 9;
            // 
            // pbMenu
            // 
            pbMenu.BackColor = Color.Transparent;
            pbMenu.Image = Properties.Resources.list;
            pbMenu.Location = new Point(34, 24);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(26, 26);
            pbMenu.TabIndex = 21;
            pbMenu.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 25);
            label1.Name = "label1";
            label1.Size = new Size(56, 22);
            label1.TabIndex = 20;
            label1.Text = "Menu";
            // 
            // lblLaporan
            // 
            lblLaporan.AutoSize = true;
            lblLaporan.BackColor = Color.Transparent;
            lblLaporan.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblLaporan.Location = new Point(10, 400);
            lblLaporan.Name = "lblLaporan";
            lblLaporan.Size = new Size(87, 22);
            lblLaporan.TabIndex = 19;
            lblLaporan.Text = "Laporan";
            // 
            // lblPengelolaan
            // 
            lblPengelolaan.AutoSize = true;
            lblPengelolaan.BackColor = Color.Transparent;
            lblPengelolaan.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblPengelolaan.Location = new Point(10, 239);
            lblPengelolaan.Name = "lblPengelolaan";
            lblPengelolaan.Size = new Size(120, 22);
            lblPengelolaan.TabIndex = 18;
            lblPengelolaan.Text = "Pengelolaan";
            // 
            // lblMaster
            // 
            lblMaster.AutoSize = true;
            lblMaster.BackColor = Color.Transparent;
            lblMaster.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblMaster.Location = new Point(10, 148);
            lblMaster.Name = "lblMaster";
            lblMaster.Size = new Size(71, 22);
            lblMaster.TabIndex = 17;
            lblMaster.Text = "Master";
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.Transparent;
            btnLaporan.Cursor = Cursors.Hand;
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnLaporan.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Font = new Font("Georgia", 10.2F);
            btnLaporan.ForeColor = Color.Black;
            btnLaporan.Image = Properties.Resources.bar_chart;
            btnLaporan.ImageAlign = ContentAlignment.MiddleLeft;
            btnLaporan.Location = new Point(27, 428);
            btnLaporan.Margin = new Padding(3, 4, 3, 4);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(149, 48);
            btnLaporan.TabIndex = 16;
            btnLaporan.Text = "   Laporan";
            btnLaporan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLaporan.UseVisualStyleBackColor = false;
            // 
            // btnMenuDashboard
            // 
            btnMenuDashboard.BackColor = Color.Transparent;
            btnMenuDashboard.Cursor = Cursors.Hand;
            btnMenuDashboard.FlatAppearance.BorderSize = 0;
            btnMenuDashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuDashboard.FlatStyle = FlatStyle.Flat;
            btnMenuDashboard.Font = new Font("Georgia", 10.2F);
            btnMenuDashboard.ForeColor = Color.Black;
            btnMenuDashboard.Image = Properties.Resources.home;
            btnMenuDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuDashboard.Location = new Point(27, 87);
            btnMenuDashboard.Margin = new Padding(3, 4, 3, 4);
            btnMenuDashboard.Name = "btnMenuDashboard";
            btnMenuDashboard.Size = new Size(149, 48);
            btnMenuDashboard.TabIndex = 15;
            btnMenuDashboard.Text = "   Dashboard";
            btnMenuDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuDashboard.UseVisualStyleBackColor = false;
            // 
            // btnMenuKatalog
            // 
            btnMenuKatalog.BackColor = Color.Transparent;
            btnMenuKatalog.Cursor = Cursors.Hand;
            btnMenuKatalog.FlatAppearance.BorderSize = 0;
            btnMenuKatalog.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuKatalog.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuKatalog.FlatStyle = FlatStyle.Flat;
            btnMenuKatalog.Font = new Font("Georgia", 10.2F);
            btnMenuKatalog.ForeColor = Color.Black;
            btnMenuKatalog.Image = Properties.Resources.boxes;
            btnMenuKatalog.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuKatalog.Location = new Point(27, 269);
            btnMenuKatalog.Margin = new Padding(4);
            btnMenuKatalog.Name = "btnMenuKatalog";
            btnMenuKatalog.Size = new Size(149, 53);
            btnMenuKatalog.TabIndex = 14;
            btnMenuKatalog.Text = "   Manajemen     Produk      ";
            btnMenuKatalog.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKatalog.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuKatalog.UseVisualStyleBackColor = false;
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
            btnLogout.TabIndex = 13;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnMenuProduk
            // 
            btnMenuProduk.BackColor = Color.Transparent;
            btnMenuProduk.Cursor = Cursors.Hand;
            btnMenuProduk.FlatAppearance.BorderSize = 0;
            btnMenuProduk.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuProduk.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuProduk.FlatStyle = FlatStyle.Flat;
            btnMenuProduk.Font = new Font("Georgia", 10.2F);
            btnMenuProduk.ForeColor = Color.Black;
            btnMenuProduk.Image = Properties.Resources.shopping_cart_add;
            btnMenuProduk.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuProduk.Location = new Point(27, 174);
            btnMenuProduk.Margin = new Padding(3, 4, 3, 4);
            btnMenuProduk.Name = "btnMenuProduk";
            btnMenuProduk.Size = new Size(149, 48);
            btnMenuProduk.TabIndex = 12;
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
            btnMenuKaryawan.FlatStyle = FlatStyle.Flat;
            btnMenuKaryawan.Font = new Font("Georgia", 10.2F);
            btnMenuKaryawan.ForeColor = Color.Black;
            btnMenuKaryawan.Image = Properties.Resources.add_user;
            btnMenuKaryawan.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuKaryawan.Location = new Point(27, 329);
            btnMenuKaryawan.Margin = new Padding(3, 4, 3, 4);
            btnMenuKaryawan.Name = "btnMenuKaryawan";
            btnMenuKaryawan.Size = new Size(149, 53);
            btnMenuKaryawan.TabIndex = 11;
            btnMenuKaryawan.Text = "   Manajemen     Karyawan";
            btnMenuKaryawan.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKaryawan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuKaryawan.UseVisualStyleBackColor = false;
            // 
            // btnLapLabaRugi
            // 
            btnLapLabaRugi.BackColor = Color.Transparent;
            btnLapLabaRugi.FlatStyle = FlatStyle.Popup;
            btnLapLabaRugi.Font = new Font("Perpetua Titling MT", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLapLabaRugi.Location = new Point(992, 24);
            btnLapLabaRugi.Name = "btnLapLabaRugi";
            btnLapLabaRugi.Size = new Size(256, 30);
            btnLapLabaRugi.TabIndex = 23;
            btnLapLabaRugi.Text = "LAPORAN LABA RUGI";
            btnLapLabaRugi.UseVisualStyleBackColor = false;
            btnLapLabaRugi.Click += btnLapLabaRugi_Click;
            // 
            // btnLapPenjualan
            // 
            btnLapPenjualan.BackColor = Color.Transparent;
            btnLapPenjualan.FlatStyle = FlatStyle.Popup;
            btnLapPenjualan.Font = new Font("Perpetua Titling MT", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLapPenjualan.Location = new Point(743, 24);
            btnLapPenjualan.Name = "btnLapPenjualan";
            btnLapPenjualan.Size = new Size(250, 30);
            btnLapPenjualan.TabIndex = 22;
            btnLapPenjualan.Text = "Laporan Penjualan";
            btnLapPenjualan.UseVisualStyleBackColor = false;
            // 
            // UC_LaporanPenjualan
            // 
            BackgroundImage = Properties.Resources.Laporan_P_O;
            Controls.Add(lblTotalPenjualan);
            Controls.Add(lblTotalTransaksi);
            Controls.Add(dgvPenjualan);
            Controls.Add(panelChart);
            Controls.Add(dtpDari);
            Controls.Add(dtpSampai);
            Controls.Add(btnFilter);
            Controls.Add(cmbMetodeBayar);
            Controls.Add(btnMenuKaryawan);
            Controls.Add(btnMenuProduk);
            Controls.Add(btnLogout);
            Controls.Add(btnMenuKatalog);
            Controls.Add(btnMenuDashboard);
            Controls.Add(btnLaporan);
            Controls.Add(lblMaster);
            Controls.Add(lblPengelolaan);
            Controls.Add(lblLaporan);
            Controls.Add(label1);
            Controls.Add(pbMenu);
            Controls.Add(btnLapLabaRugi);
            Controls.Add(btnLapPenjualan);
            Controls.Add(panel1);
            Name = "UC_LaporanPenjualan";
            Size = new Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)dgvPenjualan).EndInit();
            panelChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDari;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.DateTimePicker dtpSampai;
        private System.Windows.Forms.ComboBox cmbMetodeBayar;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label lblTotalPenjualan;
        private System.Windows.Forms.Label lblTotalTransaksi;
        private System.Windows.Forms.DataGridView dgvPenjualan;
        private System.Windows.Forms.Panel panelChart;
        private Panel panel1;
        private PictureBox pbMenu;
        private Label label1;
        private Label lblLaporan;
        private Label lblPengelolaan;
        private Label lblMaster;
        private Button btnLaporan;
        private Button btnMenuDashboard;
        private Button btnMenuKatalog;
        private Button btnLogout;
        private Button btnMenuProduk;
        private Button btnMenuKaryawan;
        private Button btnLapLabaRugi;
        private Button btnLapPenjualan;
    }
}