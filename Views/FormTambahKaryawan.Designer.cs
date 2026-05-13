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
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            SuspendLayout();
            // 
            // txtUserBaru
            // 
            txtUserBaru.BorderStyle = BorderStyle.None;
            txtUserBaru.Location = new Point(88, 193);
            txtUserBaru.Name = "txtUserBaru";
            txtUserBaru.Size = new Size(164, 20);
            txtUserBaru.TabIndex = 5;
            // 
            // txtPassBaru
            // 
            txtPassBaru.BorderStyle = BorderStyle.None;
            txtPassBaru.Location = new Point(535, 193);
            txtPassBaru.Name = "txtPassBaru";
            txtPassBaru.Size = new Size(169, 20);
            txtPassBaru.TabIndex = 6;
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.BorderStyle = BorderStyle.None;
            txtNamaLengkap.Location = new Point(88, 132);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(164, 20);
            txtNamaLengkap.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.Transparent;
            btnSimpan.Cursor = Cursors.Hand;
            btnSimpan.FlatAppearance.BorderSize = 0;
            btnSimpan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSimpan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSimpan.FlatStyle = FlatStyle.Flat;
            btnSimpan.Location = new Point(266, 302);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 8;
            btnSimpan.UseVisualStyleBackColor = false;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(68, 364);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.RowHeadersWidth = 51;
            dgvKaryawan.Size = new Size(710, 206);
            dgvKaryawan.TabIndex = 9;
            dgvKaryawan.SelectionChanged += dgvKaryawan_SelectionChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(535, 257);
            label1.Name = "label1";
            label1.Size = new Size(49, 26);
            label1.TabIndex = 11;
            label1.Text = "Kasir";
            // 
            // dtpTanggalMulaiKerja
            // 
            dtpTanggalMulaiKerja.Location = new Point(540, 130);
            dtpTanggalMulaiKerja.Name = "dtpTanggalMulaiKerja";
            dtpTanggalMulaiKerja.Size = new Size(164, 27);
            dtpTanggalMulaiKerja.TabIndex = 12;
            // 
            // dtpTanggalLahir
            // 
            dtpTanggalLahir.Location = new Point(313, 132);
            dtpTanggalLahir.Name = "dtpTanggalLahir";
            dtpTanggalLahir.Size = new Size(164, 27);
            dtpTanggalLahir.TabIndex = 13;
            // 
            // cmbJenisKelamin
            // 
            cmbJenisKelamin.FlatStyle = FlatStyle.Flat;
            cmbJenisKelamin.FormattingEnabled = true;
            cmbJenisKelamin.Items.AddRange(new object[] { "Laki-laki", "Perempuan" });
            cmbJenisKelamin.Location = new Point(88, 255);
            cmbJenisKelamin.Name = "cmbJenisKelamin";
            cmbJenisKelamin.Size = new Size(164, 28);
            cmbJenisKelamin.TabIndex = 14;
            // 
            // txtNoHp
            // 
            txtNoHp.BorderStyle = BorderStyle.None;
            txtNoHp.Location = new Point(313, 196);
            txtNoHp.Name = "txtNoHp";
            txtNoHp.Size = new Size(164, 20);
            txtNoHp.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Location = new Point(313, 258);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(164, 20);
            txtEmail.TabIndex = 16;
            // 
            // btnNonaktifkan
            // 
            btnNonaktifkan.BackColor = Color.Black;
            btnNonaktifkan.Cursor = Cursors.Hand;
            btnNonaktifkan.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnNonaktifkan.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnNonaktifkan.FlatStyle = FlatStyle.Flat;
            btnNonaktifkan.ForeColor = Color.Black;
            btnNonaktifkan.Location = new Point(420, 302);
            btnNonaktifkan.Name = "btnNonaktifkan";
            btnNonaktifkan.Size = new Size(164, 29);
            btnNonaktifkan.TabIndex = 17;
            btnNonaktifkan.Text = " ";
            btnNonaktifkan.UseVisualStyleBackColor = false;
            btnNonaktifkan.Click += btnNonaktifkan_Click;
            // 
            // FormTambahKaryawan
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.Dash_On__karyawan;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
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
    }
}