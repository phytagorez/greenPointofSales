namespace greenPointofSales.Views.Owner
{
    partial class FormLaporan
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            pnlContainer = new Panel();
            SuspendLayout();
            // 
            // pnlContainer
            // 
            pnlContainer.BackColor = Color.White;
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Size = new Size(1280, 720);
            pnlContainer.TabIndex = 0;
            // 
            // FormLaporan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1280, 720);
            MinimumSize = new Size(1280, 720);
            MaximumSize = new Size(1280, 720);
            Controls.Add(pnlContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLaporan";
            Text = "FormLaporan";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContainer;
    }
}