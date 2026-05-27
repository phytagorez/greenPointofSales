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
            splitContainer1 = new SplitContainer();
            flpKatalog = new FlowLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flpKeranjang = new FlowLayoutPanel();
            pnlCheckout = new Panel();
            pnlTunai = new Panel();
            btnBayar = new Button();
            lblTotalHarga = new Label();
            panel1 = new Panel();
            txtUangBayar = new TextBox();
            lblTotalHarga = new Label();
            panel1 = new Panel();
            txtUangBayar = new TextBox();
            lblTotalHarga = new Label();
            panel1 = new Panel();
            txtUangBayar = new TextBox();
            lblKembalian = new Label();
            txtUangBayar = new TextBox();
            lblTotalHarga = new Label();
            label1 = new Label();
            cmbMetodeBayar = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlCheckout.SuspendLayout();
            pnlTunai.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flpKatalog);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer1.Size = new Size(1280, 720);
            splitContainer1.SplitterDistance = 923;
            splitContainer1.TabIndex = 0;
            // 
            // flpKatalog
            // 
            flpKatalog.AutoScroll = true;
            flpKatalog.Dock = DockStyle.Fill;
            flpKatalog.Location = new Point(0, 0);
            flpKatalog.Name = "flpKatalog";
            flpKatalog.Size = new Size(923, 720);
            flpKatalog.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(flpKeranjang, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlCheckout, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            tableLayoutPanel1.Size = new Size(353, 720);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // flpKeranjang
            // 
            flpKeranjang.AutoScroll = true;
            flpKeranjang.Dock = DockStyle.Fill;
            flpKeranjang.Location = new Point(3, 3);
            flpKeranjang.Name = "flpKeranjang";
            flpKeranjang.Size = new Size(347, 414);
            flpKeranjang.TabIndex = 0;
            // 
            // pnlCheckout
            // 
            pnlCheckout.Controls.Add(pnlTunai);
            pnlCheckout.Controls.Add(lblTotalHarga);
            pnlCheckout.Controls.Add(label1);
            pnlCheckout.Controls.Add(cmbMetodeBayar);
            pnlCheckout.Dock = DockStyle.Fill;
            pnlCheckout.Location = new Point(3, 423);
            pnlCheckout.Name = "pnlCheckout";
            pnlCheckout.Size = new Size(347, 294);
            pnlCheckout.TabIndex = 1;
            // 
            // pnlTunai
            // 
            pnlTunai.Controls.Add(btnBayar);
            pnlTunai.Controls.Add(lblKembalian);
            pnlTunai.Controls.Add(txtUangBayar);
            pnlTunai.Location = new Point(3, 112);
            pnlTunai.Name = "pnlTunai";
            pnlTunai.Size = new Size(341, 156);
            pnlTunai.TabIndex = 3;
            // 
            // btnBayar
            // 
            btnBayar.Location = new Point(23, 115);
            btnBayar.Name = "btnBayar";
            btnBayar.Size = new Size(94, 29);
            btnBayar.TabIndex = 5;
            btnBayar.Text = "Bayar";
            btnBayar.UseVisualStyleBackColor = true;
            btnBayar.Click += btnBayar_Click;
            // 
            // lblKembalian
            // 
            lblKembalian.AutoSize = true;
            lblKembalian.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblKembalian.Location = new Point(23, 82);
            lblKembalian.Name = "lblKembalian";
            lblKembalian.Size = new Size(150, 30);
            lblKembalian.TabIndex = 4;
            lblKembalian.Text = "Kembalian: Rp 0";
            // 
            // txtUangBayar
            // 
            txtUangBayar.Location = new Point(23, 21);
            txtUangBayar.Name = "txtUangBayar";
            txtUangBayar.Size = new Size(125, 30);
            txtUangBayar.TabIndex = 0;
            txtUangBayar.TextChanged += txtUangBayar_TextChanged;
            // 
            // lblTotalHarga
            // 
            lblTotalHarga.AutoSize = true;
            lblTotalHarga.Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalHarga.Location = new Point(147, 11);
            lblTotalHarga.Name = "lblTotalHarga";
            lblTotalHarga.Size = new Size(50, 30);
            lblTotalHarga.TabIndex = 2;
            lblTotalHarga.Text = "Rp 0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 11);
            label1.Name = "label1";
            label1.Size = new Size(126, 30);
            label1.TabIndex = 1;
            label1.Text = "Total Harga: ";
            // 
            // cmbMetodeBayar
            // 
            cmbMetodeBayar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodeBayar.FormattingEnabled = true;
            cmbMetodeBayar.Items.AddRange(new object[] { "Tunai", "Non-Tunai" });
            cmbMetodeBayar.Location = new Point(15, 62);
            cmbMetodeBayar.Name = "cmbMetodeBayar";
            cmbMetodeBayar.Size = new Size(151, 34);
            cmbMetodeBayar.TabIndex = 0;
            cmbMetodeBayar.SelectedIndexChanged += cmbMetodeBayar_SelectedIndexChanged;
            // 
            // FormTransaksi
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1280, 720);
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
            ResumeLayout(false);
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
    }
}