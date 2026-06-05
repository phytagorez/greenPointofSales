namespace greenPointofSales.Views.Owner
{
    partial class UC_LaporanLabaRugi
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cbBulan = new ComboBox();
            txtTahun = new TextBox();
            btnCari = new Button();
            lblPendapatan = new Label();
            lblHPP = new Label();
            lblLabaBersih = new Label();
            lblRugiBusuk = new Label();
            SuspendLayout();
            // 
            // cbBulan
            // 
            cbBulan.FormattingEnabled = true;
            cbBulan.Items.AddRange(new object[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" });
            cbBulan.Location = new Point(31, 15);
            cbBulan.Name = "cbBulan";
            cbBulan.Size = new Size(151, 28);
            cbBulan.TabIndex = 0;
            // 
            // txtTahun
            // 
            txtTahun.Location = new Point(61, 62);
            txtTahun.Name = "txtTahun";
            txtTahun.Size = new Size(125, 27);
            txtTahun.TabIndex = 1;
            // 
            // btnCari
            // 
            btnCari.Location = new Point(59, 102);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(94, 29);
            btnCari.TabIndex = 2;
            btnCari.Text = "Cari";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += btnCari_Click;
            // 
            // lblPendapatan
            // 
            lblPendapatan.AutoSize = true;
            lblPendapatan.Location = new Point(55, 182);
            lblPendapatan.Name = "lblPendapatan";
            lblPendapatan.Size = new Size(87, 20);
            lblPendapatan.TabIndex = 3;
            lblPendapatan.Text = "Pendapatan";
            // 
            // lblHPP
            // 
            lblHPP.AutoSize = true;
            lblHPP.Location = new Point(161, 174);
            lblHPP.Name = "lblHPP";
            lblHPP.Size = new Size(36, 20);
            lblHPP.TabIndex = 4;
            lblHPP.Text = "HPP";
            // 
            // lblLabaBersih
            // 
            lblLabaBersih.AutoSize = true;
            lblLabaBersih.Location = new Point(103, 275);
            lblLabaBersih.Name = "lblLabaBersih";
            lblLabaBersih.Size = new Size(85, 20);
            lblLabaBersih.TabIndex = 5;
            lblLabaBersih.Text = "Laba Bersih";
            // 
            // lblRugiBusuk
            // 
            lblRugiBusuk.AutoSize = true;
            lblRugiBusuk.Location = new Point(210, 228);
            lblRugiBusuk.Name = "lblRugiBusuk";
            lblRugiBusuk.Size = new Size(81, 20);
            lblRugiBusuk.TabIndex = 6;
            lblRugiBusuk.Text = "Rugi Busuk";
            // 
            // UC_LaporanLabaRugi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblRugiBusuk);
            Controls.Add(lblLabaBersih);
            Controls.Add(lblHPP);
            Controls.Add(lblPendapatan);
            Controls.Add(btnCari);
            Controls.Add(txtTahun);
            Controls.Add(cbBulan);
            Name = "UC_LaporanLabaRugi";
            Size = new Size(373, 369);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbBulan;
        private TextBox txtTahun;
        private Button btnCari;
        private Label lblPendapatan;
        private Label lblHPP;
        private Label lblLabaBersih;
        private Label lblRugiBusuk;
    }
}
