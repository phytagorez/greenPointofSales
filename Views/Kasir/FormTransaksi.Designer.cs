namespace greenPointofSales.Views
{
    partial class FormTransaksi
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            splitContainer1 = new SplitContainer();
            flpKatalog = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlCheckout = new Panel();
            pnlTunai = new Panel();
            label2 = new Label();
            lblKembalian = new Label();
            txtUangBayar = new TextBox();
            btnBayar = new Button();
            lblTotalHarga = new Label();
            label1 = new Label();
            cmbMetodeBayar = new ComboBox();
            flpKeranjang = new FlowLayoutPanel();
            tbSearchTrans = new Guna.UI2.WinForms.Guna2TextBox();
            btnKAll = new Button();
            btnKBmb = new Button();
            btnKBua = new Button();
            btnKSay = new Button();
            lblMenu = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            pbMenu = new PictureBox();
            lblNamaKasir = new Label();
            tbNamaKasir = new TextBox();
            btnLogout = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlCheckout.SuspendLayout();
            pnlTunai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.Transparent;
            splitContainer1.Location = new Point(183, 70);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.Controls.Add(flpKatalog);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(1099, 640);
            splitContainer1.SplitterDistance = 792;
            splitContainer1.TabIndex = 0;
            // 
            // flpKatalog
            // 
            flpKatalog.AutoScroll = true;
            flpKatalog.BackColor = Color.White;
            flpKatalog.Location = new Point(0, 3);
            flpKatalog.Name = "flpKatalog";
            flpKatalog.Size = new Size(796, 648);
            flpKatalog.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(pnlCheckout, 0, 1);
            tableLayoutPanel1.Controls.Add(flpKeranjang, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
            tableLayoutPanel1.Size = new Size(303, 648);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlCheckout
            // 
            pnlCheckout.BackColor = Color.FromArgb(148, 172, 137);
            pnlCheckout.Controls.Add(label3);
            pnlCheckout.Controls.Add(pnlTunai);
            pnlCheckout.Controls.Add(lblTotalHarga);
            pnlCheckout.Controls.Add(label1);
            pnlCheckout.Controls.Add(cmbMetodeBayar);
            pnlCheckout.Location = new Point(3, 430);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Size = new Size(297, 215);
            pnlCheckout.TabIndex = 1;
            // 
            // pnlTunai
            // 
            pnlTunai.Controls.Add(label2);
            pnlTunai.Controls.Add(btnBayar);
            pnlTunai.Controls.Add(lblKembalian);
            pnlTunai.Controls.Add(txtUangBayar);
            pnlTunai.Location = new Point(0, 83);
            pnlTunai.Name = "pnlTunai";
            pnlTunai.Size = new Size(297, 133);
            pnlTunai.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 17);
            label2.Name = "label2";
            label2.Size = new Size(111, 22);
            label2.TabIndex = 5;
            label2.Text = "Total Bayar:";
            // 
            // lblKembalian
            // 
            lblKembalian.AutoSize = true;
            lblKembalian.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKembalian.Location = new Point(19, 61);
            lblKembalian.Name = "lblKembalian";
            lblKembalian.Size = new Size(146, 22);
            lblKembalian.TabIndex = 4;
            lblKembalian.Text = "Kembalian: Rp 0";
            // 
            // txtUangBayar
            // 
            txtUangBayar.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUangBayar.Location = new Point(136, 14);
            txtUangBayar.Name = "txtUangBayar";
            txtUangBayar.Size = new Size(125, 29);
            txtUangBayar.TabIndex = 0;
            txtUangBayar.TextChanged += txtUangBayar_TextChanged;
            // 
            // btnBayar
            // 
            btnBayar.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBayar.Location = new Point(96, 98);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(94, 29);
            btnBayar.TabIndex = 5;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // lblTotalHarga
            // 
            lblTotalHarga.AutoSize = true;
            lblTotalHarga.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalHarga.Location = new Point(132, 11);
            lblTotalHarga.Name = "lblTotalHarga";
            lblTotalHarga.Size = new Size(48, 22);
            lblTotalHarga.TabIndex = 2;
            lblTotalHarga.Text = "Rp 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(118, 22);
            label1.TabIndex = 1;
            label1.Text = "Total Harga: ";
            // 
            // cmbMetodeBayar
            // 
            cmbMetodeBayar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodeBayar.FormattingEnabled = true;
            cmbMetodeBayar.Items.AddRange(new object[] { "Tunai", "Non-Tunai" });
            cmbMetodeBayar.Location = new Point(136, 52);
            cmbMetodeBayar.Name = "cmbMetodeBayar";
            cmbMetodeBayar.Size = new Size(151, 26);
            cmbMetodeBayar.TabIndex = 0;
            cmbMetodeBayar.SelectedIndexChanged += cmbMetodeBayar_SelectedIndexChanged;
            // 
            // flpKeranjang
            // 
            flpKeranjang.AutoScroll = true;
            flpKeranjang.BackColor = Color.FromArgb(227, 233, 207);
            flpKeranjang.Location = new Point(3, 3);
            flpKeranjang.Name = "flpKeranjang";
            flpKeranjang.Size = new Size(297, 421);
            flpKeranjang.TabIndex = 0;
            // 
            // tbSearchTrans
            // 
            tbSearchTrans.BackColor = Color.Transparent;
            tbSearchTrans.BorderColor = Color.Transparent;
            tbSearchTrans.BorderRadius = 15;
            tbSearchTrans.CustomizableEdges = customizableEdges5;
            tbSearchTrans.DefaultText = "";
            tbSearchTrans.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbSearchTrans.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbSearchTrans.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbSearchTrans.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbSearchTrans.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbSearchTrans.Font = new Font("Palatino Linotype", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearchTrans.ForeColor = Color.Black;
            tbSearchTrans.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbSearchTrans.IconLeftOffset = new Point(5, 0);
            tbSearchTrans.IconRight = Properties.Resources.search;
            tbSearchTrans.Location = new Point(648, 24);
            tbSearchTrans.Margin = new Padding(2, 3, 2, 3);
            tbSearchTrans.Name = "tbSearchTrans";
            tbSearchTrans.PlaceholderForeColor = Color.Black;
            tbSearchTrans.PlaceholderText = "Cari Produk...";
            tbSearchTrans.SelectedText = "";
            tbSearchTrans.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbSearchTrans.Size = new Size(300, 30);
            tbSearchTrans.TabIndex = 1;
            // 
            // btnKAll
            // 
            btnKAll.BackColor = Color.FromArgb(148, 172, 137);
            btnKAll.FlatStyle = FlatStyle.Flat;
            btnKAll.Font = new Font("Modern No. 20", 10.7999992F);
            btnKAll.ForeColor = Color.Black;
            btnKAll.Location = new Point(29, 86);
            btnKAll.Name = "btnKAll";
            btnKAll.Size = new Size(120, 30);
            btnKAll.TabIndex = 27;
            btnKAll.Text = "All";
            btnKAll.TextAlign = ContentAlignment.TopCenter;
            btnKAll.UseVisualStyleBackColor = false;
            btnKAll.Click += btnKAll_Click;
            // 
            // btnKBmb
            // 
            btnKBmb.BackColor = Color.FromArgb(148, 172, 137);
            btnKBmb.FlatStyle = FlatStyle.Flat;
            btnKBmb.Font = new Font("Modern No. 20", 10.7999992F);
            btnKBmb.ForeColor = Color.Black;
            btnKBmb.Location = new Point(29, 246);
            btnKBmb.Name = "btnKBmb";
            btnKBmb.Size = new Size(120, 30);
            btnKBmb.TabIndex = 26;
            btnKBmb.Text = "Bumbu Dapur";
            btnKBmb.TextAlign = ContentAlignment.TopCenter;
            btnKBmb.UseVisualStyleBackColor = false;
            btnKBmb.Click += btnKBmb_Click;
            // 
            // btnKBua
            // 
            btnKBua.BackColor = Color.FromArgb(148, 172, 137);
            btnKBua.FlatStyle = FlatStyle.Flat;
            btnKBua.Font = new Font("Modern No. 20", 10.7999992F);
            btnKBua.ForeColor = Color.Black;
            btnKBua.Location = new Point(29, 193);
            btnKBua.Name = "btnKBua";
            btnKBua.Size = new Size(120, 30);
            btnKBua.TabIndex = 25;
            btnKBua.Text = "Buah";
            btnKBua.TextAlign = ContentAlignment.TopCenter;
            btnKBua.UseVisualStyleBackColor = false;
            btnKBua.Click += btnKBua_Click;
            // 
            // btnKSay
            // 
            btnKSay.BackColor = Color.FromArgb(148, 172, 137);
            btnKSay.FlatStyle = FlatStyle.Flat;
            btnKSay.Font = new Font("Modern No. 20", 10.7999992F);
            btnKSay.ForeColor = Color.Black;
            btnKSay.Location = new Point(29, 138);
            btnKSay.Name = "btnKSay";
            btnKSay.Size = new Size(120, 30);
            btnKSay.TabIndex = 24;
            btnKSay.Text = "Sayuran";
            btnKSay.TextAlign = ContentAlignment.TopCenter;
            btnKSay.UseVisualStyleBackColor = false;
            btnKSay.Click += btnKSay_Click;
            // 
            // lblMenu
            // 
            lblMenu.AutoSize = true;
            lblMenu.BackColor = Color.Transparent;
            lblMenu.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMenu.Location = new Point(67, 25);
            lblMenu.Name = "lblMenu";
            lblMenu.Size = new Size(80, 22);
            lblMenu.TabIndex = 28;
            lblMenu.Text = "Kategori";
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackgroundImage = Properties.Resources.list;
            guna2PictureBox1.CustomizableEdges = customizableEdges7;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(488, 41);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2PictureBox1.Size = new Size(0, 0);
            guna2PictureBox1.TabIndex = 29;
            guna2PictureBox1.TabStop = false;
            // 
            // pbMenu
            // 
            pbMenu.BackColor = Color.Transparent;
            pbMenu.Image = Properties.Resources.list;
            pbMenu.Location = new Point(34, 24);
            pbMenu.Name = "pbMenu";
            pbMenu.Size = new Size(26, 26);
            pbMenu.TabIndex = 34;
            pbMenu.TabStop = false;
            // 
            // lblNamaKasir
            // 
            lblNamaKasir.AutoSize = true;
            lblNamaKasir.BackColor = Color.Transparent;
            lblNamaKasir.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamaKasir.Location = new Point(989, 27);
            lblNamaKasir.Name = "lblNamaKasir";
            lblNamaKasir.Size = new Size(113, 20);
            lblNamaKasir.TabIndex = 6;
            lblNamaKasir.Text = "Nama Kasir:";
            // 
            // tbNamaKasir
            // 
            tbNamaKasir.BackColor = Color.FromArgb(148, 172, 137);
            tbNamaKasir.BorderStyle = BorderStyle.None;
            tbNamaKasir.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNamaKasir.ForeColor = Color.Black;
            tbNamaKasir.Location = new Point(1101, 27);
            tbNamaKasir.Multiline = true;
            tbNamaKasir.Name = "tbNamaKasir";
            tbNamaKasir.Size = new Size(150, 25);
            tbNamaKasir.TabIndex = 35;
            tbNamaKasir.TextAlign = HorizontalAlignment.Center;
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
            btnLogout.TabIndex = 36;
            btnLogout.Text = "Logout";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Modern No. 20", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 54);
            label3.Name = "label3";
            label3.Size = new Size(115, 22);
            label3.TabIndex = 4;
            label3.Text = "Pembayaran:";
            // 
            // FormTransaksi
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.Transaksi_Kasir;
            ClientSize = new Size(1280, 720);
            Controls.Add(btnLogout);
            Controls.Add(tbNamaKasir);
            Controls.Add(lblNamaKasir);
            Controls.Add(pbMenu);
            Controls.Add(guna2PictureBox1);
            Controls.Add(lblMenu);
            Controls.Add(btnKAll);
            Controls.Add(btnKBmb);
            Controls.Add(btnKBua);
            Controls.Add(btnKSay);
            Controls.Add(tbSearchTrans);
            Controls.Add(splitContainer1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTransaksi";
            Text = "FormTransaksi";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlCheckout.ResumeLayout(false);
            pnlCheckout.PerformLayout();
            pnlTunai.ResumeLayout(false);
            pnlTunai.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMenu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private FlowLayoutPanel flpKatalog;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpKeranjang;
        private Panel pnlCheckout;
        private Label label1;
        private ComboBox cmbMetodeBayar;
        private Label lblTotalHarga;
        private Panel pnlTunai;
        private TextBox txtUangBayar;
        private Label lblKembalian;
        private Button btnBayar;
        private Guna.UI2.WinForms.Guna2TextBox tbSearchTrans;
        private Button btnKAll;
        private Button btnKBmb;
        private Button btnKBua;
        private Button btnKSay;
        private Label lblMenu;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private PictureBox pbMenu;
        private Label label2;
        private Label lblNamaKasir;
        private TextBox tbNamaKasir;
        private Button btnLogout;
        private Label label3;
    }
}