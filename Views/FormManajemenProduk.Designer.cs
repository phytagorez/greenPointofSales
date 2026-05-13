namespace greenPointofSales.Views
{
    partial class FormManajemenProduk
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
            txtNamaProduk = new TextBox();
            txtHargaJual = new TextBox();
            txtHargaBeli = new TextBox();
            txtStok = new TextBox();
            cmbKategori = new ComboBox();
            btnSimpan = new Button();
            dgvProduk = new DataGridView();
            btnBusuk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            SuspendLayout();
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.BackColor = Color.White;
            txtNamaProduk.BorderStyle = BorderStyle.None;
            txtNamaProduk.ForeColor = Color.Black;
            txtNamaProduk.Location = new Point(91, 399);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(163, 20);
            txtNamaProduk.TabIndex = 0;
            // 
            // txtHargaJual
            // 
            txtHargaJual.BackColor = Color.White;
            txtHargaJual.BorderStyle = BorderStyle.None;
            txtHargaJual.ForeColor = Color.Black;
            txtHargaJual.Location = new Point(341, 470);
            txtHargaJual.Name = "txtHargaJual";
            txtHargaJual.Size = new Size(163, 20);
            txtHargaJual.TabIndex = 1;
            // 
            // txtHargaBeli
            // 
            txtHargaBeli.BackColor = Color.White;
            txtHargaBeli.BorderStyle = BorderStyle.None;
            txtHargaBeli.ForeColor = Color.Black;
            txtHargaBeli.Location = new Point(341, 398);
            txtHargaBeli.Name = "txtHargaBeli";
            txtHargaBeli.Size = new Size(163, 20);
            txtHargaBeli.TabIndex = 3;
            // 
            // txtStok
            // 
            txtStok.BackColor = Color.White;
            txtStok.BorderStyle = BorderStyle.None;
            txtStok.ForeColor = Color.Black;
            txtStok.Location = new Point(91, 470);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(163, 20);
            txtStok.TabIndex = 4;
            txtStok.Text = "   ";
            // 
            // cmbKategori
            // 
            cmbKategori.BackColor = Color.White;
            cmbKategori.Cursor = Cursors.Hand;
            cmbKategori.FlatStyle = FlatStyle.Flat;
            cmbKategori.ForeColor = Color.Black;
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(594, 399);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(163, 28);
            cmbKategori.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.ForeColor = Color.Transparent;
            btnSimpan.Location = new Point(505, 531);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 6;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvProduk
            // 
            dgvProduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduk.Location = new Point(67, 107);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.Size = new Size(710, 211);
            dgvProduk.TabIndex = 7;
            // 
            // btnBusuk
            // 
            btnBusuk.BackColor = Color.Transparent;
            btnBusuk.Cursor = Cursors.Hand;
            btnBusuk.FlatAppearance.BorderSize = 0;
            btnBusuk.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnBusuk.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnBusuk.FlatStyle = FlatStyle.Flat;
            btnBusuk.ForeColor = Color.Transparent;
            btnBusuk.Location = new Point(646, 531);
            btnBusuk.Name = "btnBusuk";
            btnBusuk.Size = new Size(94, 29);
            btnBusuk.TabIndex = 14;
            btnBusuk.UseVisualStyleBackColor = false;
            btnBusuk.Click += btnBusuk_Click;
            // 
            // FormManajemenProduk
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.Dash_O_Produk;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
            Controls.Add(btnBusuk);
            Controls.Add(dgvProduk);
            Controls.Add(btnSimpan);
            Controls.Add(cmbKategori);
            Controls.Add(txtStok);
            Controls.Add(txtHargaBeli);
            Controls.Add(txtHargaJual);
            Controls.Add(txtNamaProduk);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormManajemenProduk";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormManajemenProduk";
            ((System.ComponentModel.ISupportInitialize)dgvProduk).EndInit();
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
    }
}