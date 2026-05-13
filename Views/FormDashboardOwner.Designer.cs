namespace greenPointofSales.Views
{
    partial class FormDashboardOwner
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
            btnMenuKaryawan = new Button();
            btnMenuProduk = new Button();
            btnLogout = new Button();
            SuspendLayout();
            // 
            // btnMenuKaryawan
            // 
            btnMenuKaryawan.Location = new Point(77, 41);
            btnMenuKaryawan.Name = "btnMenuKaryawan";
            btnMenuKaryawan.Size = new Size(257, 29);
            btnMenuKaryawan.TabIndex = 0;
            btnMenuKaryawan.Text = "Manajemen Karyawan";
            btnMenuKaryawan.UseVisualStyleBackColor = true;
            btnMenuKaryawan.Click += btnMenuKaryawan_Click;
            // 
            // btnMenuProduk
            // 
            btnMenuProduk.Location = new Point(77, 107);
            btnMenuProduk.Name = "btnMenuProduk";
            btnMenuProduk.Size = new Size(257, 29);
            btnMenuProduk.TabIndex = 1;
            btnMenuProduk.Text = "Manajemen Produk & Stock";
            btnMenuProduk.UseVisualStyleBackColor = true;
            btnMenuProduk.Click += btnMenuProduk_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(12, 409);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // FormDashboardOwner
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogout);
            Controls.Add(btnMenuProduk);
            Controls.Add(btnMenuKaryawan);
            Name = "FormDashboardOwner";
            Text = "FormDashboardOwner";
            ResumeLayout(false);
        }

        #endregion

        private Button btnMenuKaryawan;
        private Button btnMenuProduk;
        private Button btnLogout;
    }
}