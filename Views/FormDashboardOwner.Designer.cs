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
            btnMenuKatlog = new Button();
            SuspendLayout();
            // 
            // btnMenuKaryawan
            // 
            btnMenuKaryawan.BackColor = Color.FromArgb(149, 172, 137);
            btnMenuKaryawan.Cursor = Cursors.Hand;
            btnMenuKaryawan.FlatAppearance.BorderSize = 0;
            btnMenuKaryawan.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuKaryawan.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuKaryawan.FlatStyle = FlatStyle.Flat;
            btnMenuKaryawan.ForeColor = Color.Black;
            btnMenuKaryawan.Location = new Point(36, 156);
            btnMenuKaryawan.Margin = new Padding(3, 4, 3, 4);
            btnMenuKaryawan.Name = "btnMenuKaryawan";
            btnMenuKaryawan.Size = new Size(106, 38);
            btnMenuKaryawan.TabIndex = 0;
            btnMenuKaryawan.Text = "Karyawan";
            btnMenuKaryawan.UseVisualStyleBackColor = false;
            btnMenuKaryawan.Click += btnMenuKaryawan_Click;
            // 
            // btnMenuProduk
            // 
            btnMenuProduk.BackColor = Color.FromArgb(149, 172, 137);
            btnMenuProduk.Cursor = Cursors.Hand;
            btnMenuProduk.FlatAppearance.BorderSize = 0;
            btnMenuProduk.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuProduk.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuProduk.FlatStyle = FlatStyle.Flat;
            btnMenuProduk.ForeColor = Color.Black;
            btnMenuProduk.Location = new Point(36, 97);
            btnMenuProduk.Margin = new Padding(3, 4, 3, 4);
            btnMenuProduk.Name = "btnMenuProduk";
            btnMenuProduk.Size = new Size(106, 38);
            btnMenuProduk.TabIndex = 1;
            btnMenuProduk.Text = "Produk";
            btnMenuProduk.UseVisualStyleBackColor = false;
            btnMenuProduk.Click += btnMenuProduk_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Beige;
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseDownBackColor = Color.FromArgb(215, 235, 200);
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 235, 200);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.Black;
            btnLogout.Location = new Point(36, 562);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(106, 38);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMenuKatlog
            // 
            btnMenuKatlog.BackColor = Color.FromArgb(149, 172, 137);
            btnMenuKatlog.Cursor = Cursors.Hand;
            btnMenuKatlog.FlatAppearance.BorderSize = 0;
            btnMenuKatlog.FlatAppearance.MouseDownBackColor = Color.FromArgb(119, 142, 157);
            btnMenuKatlog.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 192, 157);
            btnMenuKatlog.FlatStyle = FlatStyle.Flat;
            btnMenuKatlog.ForeColor = Color.Black;
            btnMenuKatlog.Location = new Point(36, 202);
            btnMenuKatlog.Margin = new Padding(3, 4, 3, 4);
            btnMenuKatlog.Name = "btnMenuKatlog";
            btnMenuKatlog.Size = new Size(106, 38);
            btnMenuKatlog.TabIndex = 3;
            btnMenuKatlog.Text = "Katalog";
            btnMenuKatlog.UseVisualStyleBackColor = false;
            btnMenuKatlog.Click += btnMenuKatlog_Click;
            // 
            // FormDashboardOwner
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.Dashboard_Ow;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
            Controls.Add(btnMenuKatlog);
            Controls.Add(btnLogout);
            Controls.Add(btnMenuProduk);
            Controls.Add(btnMenuKaryawan);
            DoubleBuffered = true;
            Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormDashboardOwner";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormDashboardOwner";
            ResumeLayout(false);
        }

        #endregion

        private Button btnMenuKaryawan;
        private Button btnMenuProduk;
        private Button btnLogout;
        private Button btnMenuKatlog;
    }
}