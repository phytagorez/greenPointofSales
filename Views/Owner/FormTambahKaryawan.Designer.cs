namespace greenPointofSales
{
    partial class FormTambahKaryawan
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
            txtUserBaru = new TextBox();
            txtPassBaru = new TextBox();
            txtNamaLengkap = new TextBox();
            btnSimpan = new Button();
            dgvKaryawan = new DataGridView();
            label1 = new Label();
            dtpTanggalMulaiKerja = new DateTimePicker();
            dtpTanggalLahir = new DateTimePicker();
            cmbJenisKelamin = new ComboBox();
            txtNoHp = new TextBox();
            txtEmail = new TextBox();
            btnNonaktifkan = new Button();
            pbMenu = new PictureBox();
            label2 = new Label();
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
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // txtUserBaru
            // 
            txtUserBaru.BackColor = Color.White;
            txtUserBaru.BorderStyle = BorderStyle.None;
            txtUserBaru.Font = new Font("Palatino Linotype", 12F);
            txtUserBaru.Location = new Point(239, 234);
            txtUserBaru.Multiline = true;
            txtUserBaru.Name = "txtUserBaru";
            txtUserBaru.Size = new Size(238, 41);
            txtUserBaru.TabIndex = 5;
            // 
            // txtPassBaru
            // 
            txtPassBaru.BackColor = Color.White;
            txtPassBaru.BorderStyle = BorderStyle.None;
            txtPassBaru.Font = new Font("Palatino Linotype", 12F);
            txtPassBaru.Location = new Point(965, 234);
            txtPassBaru.Multiline = true;
            txtPassBaru.Name = "txtPassBaru";
            txtPassBaru.Size = new Size(238, 41);
            txtPassBaru.TabIndex = 6;
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.BackColor = Color.White;
            txtNamaLengkap.BorderStyle = BorderStyle.None;
            txtNamaLengkap.Font = new Font("Palatino Linotype", 12F);
            txtNamaLengkap.Location = new Point(239, 137);
            txtNamaLengkap.Multiline = true;
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(238, 41);
            txtNamaLengkap.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.White;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSimpan.Location = new Point(494, 387);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(100, 35);
            btnSimpan.TabIndex = 8;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.BackgroundColor = Color.FromArgb(148, 172, 137);
            dgvKaryawan.BorderStyle = BorderStyle.None;
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(221, 467);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.RowHeadersWidth = 51;
            dgvKaryawan.Size = new Size(1010, 219);
            dgvKaryawan.TabIndex = 9;
            dgvKaryawan.CellClick += dgvKaryawan_CellClick;
            dgvKaryawan.SelectionChanged += dgvKaryawan_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Palatino Linotype", 12F);
            label1.Location = new Point(974, 338);
            label1.Name = "label1";
            label1.Size = new Size(59, 27);
            label1.TabIndex = 11;
            label1.Text = "Kasir";
            // 
            // dtpTanggalMulaiKerja
            // 
            dtpTanggalMulaiKerja.Font = new Font("Palatino Linotype", 12F);
            dtpTanggalMulaiKerja.Location = new Point(965, 141);
            dtpTanggalMulaiKerja.Name = "dtpTanggalMulaiKerja";
            dtpTanggalMulaiKerja.Size = new Size(239, 34);
            dtpTanggalMulaiKerja.TabIndex = 12;
            // 
            // dtpTanggalLahir
            // 
            dtpTanggalLahir.Font = new Font("Palatino Linotype", 12F);
            dtpTanggalLahir.Location = new Point(602, 141);
            dtpTanggalLahir.Name = "dtpTanggalLahir";
            dtpTanggalLahir.Size = new Size(238, 34);
            dtpTanggalLahir.TabIndex = 13;
            // 
            // cmbJenisKelamin
            // 
            cmbJenisKelamin.FlatStyle = FlatStyle.Flat;
            cmbJenisKelamin.Font = new Font("Palatino Linotype", 12F);
            cmbJenisKelamin.FormattingEnabled = true;
            cmbJenisKelamin.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });
            cmbJenisKelamin.Location = new Point(239, 337);
            cmbJenisKelamin.Name = "cmbJenisKelamin";
            cmbJenisKelamin.Size = new Size(238, 35);
            cmbJenisKelamin.TabIndex = 14;
            // 
            // txtNoHp
            // 
            txtNoHp.BackColor = Color.White;
            txtNoHp.BorderStyle = BorderStyle.None;
            txtNoHp.Font = new Font("Palatino Linotype", 12F);
            txtNoHp.Location = new Point(602, 234);
            txtNoHp.Multiline = true;
            txtNoHp.Name = "txtNoHp";
            txtNoHp.Size = new Size(239, 41);
            txtNoHp.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Palatino Linotype", 12F);
            txtEmail.Location = new Point(602, 331);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(238, 41);
            txtEmail.TabIndex = 16;
            // 
            // btnNonaktifkan
            // 
            btnNonaktifkan.BackColor = Color.White;
            btnNonaktifkan.Cursor = Cursors.Hand;
            btnNonaktifkan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNonaktifkan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNonaktifkan.FlatStyle = FlatStyle.Flat;
            btnNonaktifkan.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNonaktifkan.ForeColor = SystemColors.ControlText;
            btnNonaktifkan.Location = new Point(641, 394);
            btnNonaktifkan.Name = "btnNonaktifkan";
            btnNonaktifkan.Size = new Size(165, 35);
            btnNonaktifkan.TabIndex = 17;
            btnNonaktifkan.Text = " ";
            btnNonaktifkan.UseVisualStyleBackColor = false;
            btnNonaktifkan.Click += btnNonaktifkan_Click;
            // 
            // pbMenu
            // 
            pbMenu.BackColor = Color.Transparent;
            pbMenu.Image = Properties.Resources.list;
            pbMenu.Location = new Point(34, 24);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(26, 26);
            pbMenu.TabIndex = 28;
            pbMenu.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(67, 25);
            label2.Name = "label2";
            label2.Size = new Size(56, 22);
            label2.TabIndex = 27;
            label2.Text = "Menu";
            // 
            // lblLaporan
            // 
            lblLaporan.AutoSize = true;
            lblLaporan.BackColor = Color.Transparent;
            lblLaporan.Font = new Font("Modern No. 20", 12F, FontStyle.Bold);
            lblLaporan.Location = new Point(10, 400);
            lblLaporan.Name = "lblLaporan";
            lblLaporan.Size = new Size(87, 22);
            lblLaporan.TabIndex = 26;
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
            lblPengelolaan.TabIndex = 25;
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
            lblMaster.TabIndex = 24;
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
            btnLaporan.TabIndex = 23;
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
            btnMenuDashboard.TabIndex = 22;
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
            btnMenuKatalog.FlatStyle = FlatStyle.Flat;
            btnMenuKatalog.Font = new Font("Georgia", 10.2F);
            btnMenuKatalog.ForeColor = Color.Black;
            btnMenuKatalog.Image = Properties.Resources.boxes;
            btnMenuKatalog.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuKatalog.Location = new Point(27, 269);
            btnMenuKatalog.Margin = new Padding(4);
            btnMenuKatalog.Name = "btnMenuKatalog";
            btnMenuKatalog.Size = new Size(149, 53);
            btnMenuKatalog.TabIndex = 21;
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
            btnLogout.TabIndex = 20;
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
            btnMenuProduk.FlatStyle = FlatStyle.Flat;
            btnMenuProduk.Font = new Font("Georgia", 10.2F);
            btnMenuProduk.ForeColor = Color.Black;
            btnMenuProduk.Image = Properties.Resources.shopping_cart_add;
            btnMenuProduk.ImageAlign = ContentAlignment.MiddleLeft;
            btnMenuProduk.Location = new Point(27, 174);
            btnMenuProduk.Margin = new Padding(3, 4, 3, 4);
            btnMenuProduk.Name = "btnMenuProduk";
            btnMenuProduk.Size = new Size(149, 48);
            btnMenuProduk.TabIndex = 19;
            btnMenuProduk.Text = "   Produk";
            btnMenuProduk.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuProduk.UseVisualStyleBackColor = false;
            btnMenuProduk.Click += btnMenuProduk_Click;
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
            btnMenuKaryawan.TabIndex = 18;
            btnMenuKaryawan.Text = "   Manajemen     Karyawan";
            btnMenuKaryawan.TextAlign = ContentAlignment.MiddleLeft;
            btnMenuKaryawan.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnMenuKaryawan.UseVisualStyleBackColor = false;
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
            tbSearchBar.Location = new Point(883, 28);
            tbSearchBar.Margin = new Padding(4, 5, 4, 5);
            tbSearchBar.Name = "tbSearchBar";
            tbSearchBar.PlaceholderForeColor = Color.Black;
            tbSearchBar.PlaceholderText = "Search ...";
            tbSearchBar.SelectedText = "";
            tbSearchBar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbSearchBar.Size = new Size(300, 30);
            tbSearchBar.TabIndex = 29;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.White;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(860, 394);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 30;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FormTambahKaryawan
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.MKaryawan_P;
            ClientSize = new Size(1280, 720);
            Controls.Add(btnUpdate);
            Controls.Add(tbSearchBar);
            Controls.Add(pbMenu);
            Controls.Add(label2);
            Controls.Add(lblLaporan);
            Controls.Add(lblPengelolaan);
            Controls.Add(lblMaster);
            Controls.Add(btnLaporan);
            Controls.Add(btnMenuDashboard);
            Controls.Add(btnMenuKatalog);
            Controls.Add(btnLogout);
            Controls.Add(btnMenuProduk);
            Controls.Add(btnMenuKaryawan);
            Controls.Add(btnNonaktifkan);
            Controls.Add(txtEmail);
            Controls.Add(txtNoHp);
            Controls.Add(cmbJenisKelamin);
            Controls.Add(dtpTanggalLahir);
            Controls.Add(dtpTanggalMulaiKerja);
            Controls.Add(label1);
            Controls.Add(dgvKaryawan);
            Controls.Add(btnSimpan);
            Controls.Add(txtNamaLengkap);
            Controls.Add(txtPassBaru);
            Controls.Add(txtUserBaru);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTambahKaryawan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTambahKaryawan";
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUserBaru;
        private TextBox txtPassBaru;
        private TextBox txtNamaLengkap;
        private Button btnSimpan;
        private DataGridView dgvKaryawan;
        private Label label1;
        private DateTimePicker dtpTanggalMulaiKerja;
        private DateTimePicker dtpTanggalLahir;
        private ComboBox cmbJenisKelamin;
        private TextBox txtNoHp;
        private TextBox txtEmail;
        private Button btnNonaktifkan;
        private PictureBox pbMenu;
        private Label label2;
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
        private Button btnUpdate;
    }
}