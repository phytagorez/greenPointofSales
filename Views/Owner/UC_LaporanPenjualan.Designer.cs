namespace greenPointofSales.Views
{
    partial class UC_LaporanPenjualan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
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
            ((System.ComponentModel.ISupportInitialize)dgvPenjualan).BeginInit();
            SuspendLayout();
            // 
            // dtpDari
            // 
            dtpDari.Location = new Point(53, 103);
            dtpDari.Name = "dtpDari";
            dtpDari.Size = new Size(250, 27);
            dtpDari.TabIndex = 0;
            // 
            // dtpSampai
            // 
            dtpSampai.Location = new Point(53, 166);
            dtpSampai.Name = "dtpSampai";
            dtpSampai.Size = new Size(250, 27);
            dtpSampai.TabIndex = 1;
            // 
            // cmbMetodeBayar
            // 
            cmbMetodeBayar.FormattingEnabled = true;
            cmbMetodeBayar.Items.AddRange(new object[] { "All", "Tunai", "Non-Tunai" });
            cmbMetodeBayar.Location = new Point(53, 226);
            cmbMetodeBayar.Name = "cmbMetodeBayar";
            cmbMetodeBayar.Size = new Size(151, 28);
            cmbMetodeBayar.TabIndex = 2;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(53, 288);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(94, 29);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnCetak
            // 
            btnCetak.Location = new Point(222, 288);
            btnCetak.Name = "btnCetak";
            btnCetak.Size = new Size(94, 29);
            btnCetak.TabIndex = 4;
            btnCetak.Text = "Cetak";
            btnCetak.UseVisualStyleBackColor = true;
            btnCetak.Click += btnCetak_Click;
            // 
            // lblTotalPenjualan
            // 
            lblTotalPenjualan.AutoSize = true;
            lblTotalPenjualan.Location = new Point(638, 64);
            lblTotalPenjualan.Name = "lblTotalPenjualan";
            lblTotalPenjualan.Size = new Size(72, 20);
            lblTotalPenjualan.TabIndex = 5;
            lblTotalPenjualan.Text = "Penjualan";
            // 
            // lblTotalTransaksi
            // 
            lblTotalTransaksi.AutoSize = true;
            lblTotalTransaksi.Location = new Point(502, 22);
            lblTotalTransaksi.Name = "lblTotalTransaksi";
            lblTotalTransaksi.Size = new Size(68, 20);
            lblTotalTransaksi.TabIndex = 6;
            lblTotalTransaksi.Text = "Transaksi";
            // 
            // dgvPenjualan
            // 
            dgvPenjualan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenjualan.Location = new Point(384, 103);
            dgvPenjualan.Name = "dgvPenjualan";
            dgvPenjualan.RowHeadersWidth = 51;
            dgvPenjualan.Size = new Size(734, 188);
            dgvPenjualan.TabIndex = 7;
            // 
            // panelChart
            // 
            panelChart.Location = new Point(64, 364);
            panelChart.Name = "panelChart";
            panelChart.Size = new Size(1031, 321);
            panelChart.TabIndex = 8;
            // 
            // UC_LaporanPenjualan
            // 
            Controls.Add(panelChart);
            Controls.Add(dgvPenjualan);
            Controls.Add(lblTotalTransaksi);
            Controls.Add(lblTotalPenjualan);
            Controls.Add(btnCetak);
            Controls.Add(btnFilter);
            Controls.Add(cmbMetodeBayar);
            Controls.Add(dtpSampai);
            Controls.Add(dtpDari);
            Name = "UC_LaporanPenjualan";
            Size = new Size(1280, 720);
            ((System.ComponentModel.ISupportInitialize)dgvPenjualan).EndInit();
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
    }
}