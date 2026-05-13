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
            button1 = new Button();
            SuspendLayout();
            // 
            // flpKatalog
            // 
            flpKatalog.Location = new Point(194, 135);
            flpKatalog.Name = "flpKatalog";
            flpKatalog.Size = new Size(1074, 561);
            flpKatalog.TabIndex = 0;
            // 
            // cmbFilterKategori
            // 
            cmbFilterKategori.FormattingEnabled = true;
            cmbFilterKategori.Location = new Point(194, 93);
            cmbFilterKategori.Name = "cmbFilterKategori";
            cmbFilterKategori.Size = new Size(151, 28);
            cmbFilterKategori.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(197, 63);
            label1.Name = "label1";
            label1.Size = new Size(107, 18);
            label1.TabIndex = 2;
            label1.Text = "Filter Kategori: ";
            // 
            // button1
            // 
            button1.Location = new Point(58, 93);
            button1.Name = "button1";
            button1.Size = new Size(114, 29);
            button1.TabIndex = 0;
            button1.Text = "Dashboard";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormKatalog
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackgroundImage = Properties.Resources.Manajemen_Produk_ON;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1280, 720);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(cmbFilterKategori);
            Controls.Add(flpKatalog);
            DoubleBuffered = true;
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
        private Button button1;
    }
}