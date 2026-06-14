namespace greenPointofSales.Views.Kasir
{
    partial class FormQRIS
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
            picQRIS = new PictureBox();
            label1 = new Label();
            lblTotalQRIS = new Label();
            btnSelesaiBayar = new Button();
            btnBatalQRIS = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)picQRIS).BeginInit();
            SuspendLayout();
            // 
            // picQRIS
            // 
            picQRIS.BackgroundImage = Properties.Resources.Qris;
            picQRIS.BackgroundImageLayout = ImageLayout.Zoom;
            picQRIS.Location = new Point(68, 85);
            picQRIS.Name = "picQRIS";
            picQRIS.Size = new Size(404, 564);
            picQRIS.TabIndex = 0;
            picQRIS.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Mongolian Baiti", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 9);
            label1.Name = "label1";
            label1.Size = new Size(202, 30);
            label1.TabIndex = 1;
            label1.Text = "SCAN UNTUK";
            // 
            // lblTotalQRIS
            // 
            lblTotalQRIS.AutoSize = true;
            lblTotalQRIS.Font = new Font("Mongolian Baiti", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalQRIS.Location = new Point(152, 661);
            lblTotalQRIS.Name = "lblTotalQRIS";
            lblTotalQRIS.Size = new Size(102, 21);
            lblTotalQRIS.TabIndex = 2;
            lblTotalQRIS.Text = "Total: Rp 0";
            // 
            // btnSelesaiBayar
            // 
            btnSelesaiBayar.DialogResult = DialogResult.OK;
            btnSelesaiBayar.Font = new Font("Mongolian Baiti", 10.8F);
            btnSelesaiBayar.Location = new Point(106, 695);
            btnSelesaiBayar.Name = "btnSelesaiBayar";
            btnSelesaiBayar.Size = new Size(102, 29);
            btnSelesaiBayar.TabIndex = 3;
            btnSelesaiBayar.Text = "Selesai";
            btnSelesaiBayar.UseVisualStyleBackColor = true;
            // 
            // btnBatalQRIS
            // 
            btnBatalQRIS.DialogResult = DialogResult.Cancel;
            btnBatalQRIS.Font = new Font("Mongolian Baiti", 10.8F);
            btnBatalQRIS.Location = new Point(321, 695);
            btnBatalQRIS.Name = "btnBatalQRIS";
            btnBatalQRIS.Size = new Size(102, 29);
            btnBatalQRIS.TabIndex = 4;
            btnBatalQRIS.Text = "Batal";
            btnBatalQRIS.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Mongolian Baiti", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(86, 45);
            label2.Name = "label2";
            label2.Size = new Size(371, 30);
            label2.TabIndex = 5;
            label2.Text = "LAKUKAN PEMBAYARAN";
            // 
            // FormQRIS
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(227, 233, 207);
            ClientSize = new Size(540, 739);
            Controls.Add(label2);
            Controls.Add(btnBatalQRIS);
            Controls.Add(btnSelesaiBayar);
            Controls.Add(lblTotalQRIS);
            Controls.Add(label1);
            Controls.Add(picQRIS);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "FormQRIS";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormQRIS";
            Load += FormQRIS_Load;
            ((System.ComponentModel.ISupportInitialize)picQRIS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picQRIS;
        private Label label1;
        private Label lblTotalQRIS;
        private Button btnSelesaiBayar;
        private Button btnBatalQRIS;
        private Label label2;
    }
}