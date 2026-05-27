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
            ((System.ComponentModel.ISupportInitialize)picQRIS).BeginInit();
            SuspendLayout();
            // 
            // picQRIS
            // 
            picQRIS.Location = new Point(57, 62);
            picQRIS.Name = "picQRIS";
            picQRIS.Size = new Size(430, 564);
            picQRIS.TabIndex = 0;
            picQRIS.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(120, 9);
            label1.Name = "label1";
            label1.Size = new Size(309, 50);
            label1.TabIndex = 1;
            label1.Text = "SCAN UNTUK BAYAR";
            // 
            // lblTotalQRIS
            // 
            lblTotalQRIS.AutoSize = true;
            lblTotalQRIS.Font = new Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalQRIS.Location = new Point(200, 629);
            lblTotalQRIS.Name = "lblTotalQRIS";
            lblTotalQRIS.Size = new Size(118, 36);
            lblTotalQRIS.TabIndex = 2;
            lblTotalQRIS.Text = "Total: Rp 0";
            // 
            // btnSelesaiBayar
            // 
            btnSelesaiBayar.DialogResult = DialogResult.OK;
            btnSelesaiBayar.Location = new Point(57, 698);
            btnSelesaiBayar.Name = "btnSelesaiBayar";
            btnSelesaiBayar.Size = new Size(142, 29);
            btnSelesaiBayar.TabIndex = 3;
            btnSelesaiBayar.Text = "Selesai";
            btnSelesaiBayar.UseVisualStyleBackColor = true;
            // 
            // btnBatalQRIS
            // 
            btnBatalQRIS.DialogResult = DialogResult.Cancel;
            btnBatalQRIS.Location = new Point(393, 698);
            btnBatalQRIS.Name = "btnBatalQRIS";
            btnBatalQRIS.Size = new Size(94, 29);
            btnBatalQRIS.TabIndex = 4;
            btnBatalQRIS.Text = "Batal";
            btnBatalQRIS.UseVisualStyleBackColor = true;
            // 
            // FormQRIS
            // 
            AutoScaleDimensions = new SizeF(10F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 739);
            Controls.Add(btnBatalQRIS);
            Controls.Add(btnSelesaiBayar);
            Controls.Add(lblTotalQRIS);
            Controls.Add(label1);
            Controls.Add(picQRIS);
            Font = new Font("Poppins", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
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
    }
}