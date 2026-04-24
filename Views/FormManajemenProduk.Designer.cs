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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            btnBusuk = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProduk).BeginInit();
            SuspendLayout();
            // 
            // txtNamaProduk
            // 
            txtNamaProduk.Location = new Point(40, 49);
            txtNamaProduk.Name = "txtNamaProduk";
            txtNamaProduk.Size = new Size(125, 27);
            txtNamaProduk.TabIndex = 0;
            // 
            // txtHargaJual
            // 
            txtHargaJual.Location = new Point(40, 181);
            txtHargaJual.Name = "txtHargaJual";
            txtHargaJual.Size = new Size(125, 27);
            txtHargaJual.TabIndex = 1;
            // 
            // txtHargaBeli
            // 
            txtHargaBeli.Location = new Point(40, 128);
            txtHargaBeli.Name = "txtHargaBeli";
            txtHargaBeli.Size = new Size(125, 27);
            txtHargaBeli.TabIndex = 3;
            // 
            // txtStok
            // 
            txtStok.Location = new Point(40, 245);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(125, 27);
            txtStok.TabIndex = 4;
            // 
            // cmbKategori
            // 
            cmbKategori.FormattingEnabled = true;
            cmbKategori.Location = new Point(40, 308);
            cmbKategori.Name = "cmbKategori";
            cmbKategori.Size = new Size(151, 28);
            cmbKategori.TabIndex = 5;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(12, 342);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 6;
            btnSimpan.Text = "Save";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvProduk
            // 
            dgvProduk.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProduk.Location = new Point(197, 12);
            dgvProduk.Name = "dgvProduk";
            dgvProduk.RowHeadersWidth = 51;
            dgvProduk.Size = new Size(591, 426);
            dgvProduk.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 26);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 8;
            label1.Text = "Nama Produk: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 94);
            label2.Name = "label2";
            label2.Size = new Size(86, 20);
            label2.TabIndex = 9;
            label2.Text = "Harga Beli: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 158);
            label3.Name = "label3";
            label3.Size = new Size(82, 20);
            label3.TabIndex = 10;
            label3.Text = "Harga Jual:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 222);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 11;
            label4.Text = "Stock:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 285);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 13;
            label6.Text = "Kategori:";
            // 
            // btnBusuk
            // 
            btnBusuk.Location = new Point(97, 377);
            btnBusuk.Name = "btnBusuk";
            btnBusuk.Size = new Size(94, 29);
            btnBusuk.TabIndex = 14;
            btnBusuk.Text = "Mark";
            btnBusuk.UseVisualStyleBackColor = true;
            btnBusuk.Click += btnBusuk_Click;
            // 
            // FormManajemenProduk
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBusuk);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProduk);
            Controls.Add(btnSimpan);
            Controls.Add(cmbKategori);
            Controls.Add(txtStok);
            Controls.Add(txtHargaBeli);
            Controls.Add(txtHargaJual);
            Controls.Add(txtNamaProduk);
            Name = "FormManajemenProduk";
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Button btnBusuk;
    }
}