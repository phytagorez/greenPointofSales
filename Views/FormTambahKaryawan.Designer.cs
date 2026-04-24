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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbRole = new ComboBox();
            txtUserBaru = new TextBox();
            txtPassBaru = new TextBox();
            txtNamaLengkap = new TextBox();
            btnSimpan = new Button();
            dgvKaryawan = new DataGridView();
            btnNonaktifkan = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 37);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 0;
            label1.Text = "Username:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 105);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 1;
            label2.Text = "Password: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 272);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 2;
            label3.Text = "Role:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 181);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 3;
            label4.Text = "Nama Lengkap:";
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Owner", "Kasir" });
            cmbRole.Location = new Point(88, 272);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(151, 28);
            cmbRole.TabIndex = 4;
            // 
            // txtUserBaru
            // 
            txtUserBaru.Location = new Point(40, 60);
            txtUserBaru.Name = "txtUserBaru";
            txtUserBaru.Size = new Size(125, 27);
            txtUserBaru.TabIndex = 5;
            // 
            // txtPassBaru
            // 
            txtPassBaru.Location = new Point(40, 132);
            txtPassBaru.Name = "txtPassBaru";
            txtPassBaru.Size = new Size(125, 27);
            txtPassBaru.TabIndex = 6;
            // 
            // txtNamaLengkap
            // 
            txtNamaLengkap.Location = new Point(40, 216);
            txtNamaLengkap.Name = "txtNamaLengkap";
            txtNamaLengkap.Size = new Size(125, 27);
            txtNamaLengkap.TabIndex = 7;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(40, 365);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(94, 29);
            btnSimpan.TabIndex = 8;
            btnSimpan.Text = "Create";
            btnSimpan.UseVisualStyleBackColor = true;
            btnSimpan.Click += btnSimpan_Click;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(276, 37);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.RowHeadersWidth = 51;
            dgvKaryawan.Size = new Size(498, 378);
            dgvKaryawan.TabIndex = 9;
            dgvKaryawan.SelectionChanged += dgvKaryawan_SelectionChanged;
            // 
            // btnNonaktifkan
            // 
            btnNonaktifkan.Location = new Point(145, 365);
            btnNonaktifkan.Name = "btnNonaktifkan";
            btnNonaktifkan.Size = new Size(107, 29);
            btnNonaktifkan.TabIndex = 10;
            btnNonaktifkan.Text = "Nonaktifkan";
            btnNonaktifkan.UseVisualStyleBackColor = true;
            btnNonaktifkan.Click += btnNonaktifkan_Click;
            // 
            // FormTambahKaryawan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnNonaktifkan);
            Controls.Add(dgvKaryawan);
            Controls.Add(btnSimpan);
            Controls.Add(txtNamaLengkap);
            Controls.Add(txtPassBaru);
            Controls.Add(txtUserBaru);
            Controls.Add(cmbRole);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormTambahKaryawan";
            Text = "FormTambahKaryawan";
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbRole;
        private TextBox txtUserBaru;
        private TextBox txtPassBaru;
        private TextBox txtNamaLengkap;
        private Button btnSimpan;
        private DataGridView dgvKaryawan;
        private Button btnNonaktifkan;
    }
}