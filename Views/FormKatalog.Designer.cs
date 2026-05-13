namespace greenPointofSales.Views
{
    partial class FormKatalog
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
            flpKatalog = new FlowLayoutPanel();
            cmbFilterKategori = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // flpKatalog
            // 
            flpKatalog.Location = new Point(12, 74);
            flpKatalog.Name = "flpKatalog";
            flpKatalog.Size = new Size(776, 514);
            flpKatalog.TabIndex = 0;
            // 
            // cmbFilterKategori
            // 
            cmbFilterKategori.FormattingEnabled = true;
            cmbFilterKategori.Location = new Point(12, 40);
            cmbFilterKategori.Name = "cmbFilterKategori";
            cmbFilterKategori.Size = new Size(151, 28);
            cmbFilterKategori.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Poppins", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(122, 26);
            label1.TabIndex = 2;
            label1.Text = "Filter Kategori: ";
            // 
            // FormKatalog
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 600);
            Controls.Add(label1);
            Controls.Add(cmbFilterKategori);
            Controls.Add(flpKatalog);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKatalog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormKatalog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flpKatalog;
        private ComboBox cmbFilterKategori;
        private Label label1;
    }
}