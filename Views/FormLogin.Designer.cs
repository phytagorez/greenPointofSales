namespace greenPointofSales
{
    partial class FormLogin
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
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pbUsername = new PictureBox();
            pbPassword = new PictureBox();
            lblUsername = new Label();
            lblPassword = new Label();
            btnX = new Button();
            ((System.ComponentModel.ISupportInitialize)pbUsername).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            SuspendLayout();
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.None;
            txtUsername.BackColor = Color.Beige;
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Cursor = Cursors.Hand;
            txtUsername.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(479, 323);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(360, 35);
            txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.Beige;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Cursor = Cursors.Hand;
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(479, 390);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(360, 35);
            txtPassword.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(22, 97, 14);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(504, 477);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(300, 45);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // pbUsername
            // 
            pbUsername.BackColor = Color.Transparent;
            pbUsername.Image = Properties.Resources.user;
            pbUsername.Location = new Point(444, 331);
            pbUsername.Name = "pbUsername";
            pbUsername.Size = new Size(20, 20);
            pbUsername.SizeMode = PictureBoxSizeMode.StretchImage;
            pbUsername.TabIndex = 5;
            pbUsername.TabStop = false;
            // 
            // pbPassword
            // 
            pbPassword.BackColor = Color.Transparent;
            pbPassword.Image = Properties.Resources.padlock;
            pbPassword.Location = new Point(444, 397);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(20, 20);
            pbPassword.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPassword.TabIndex = 6;
            pbPassword.TabStop = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.FlatStyle = FlatStyle.Flat;
            lblUsername.Font = new Font("Century Schoolbook", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.Location = new Point(465, 298);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(0, 22);
            lblUsername.TabIndex = 7;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.FlatStyle = FlatStyle.Flat;
            lblPassword.Font = new Font("Century Schoolbook", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.Location = new Point(466, 365);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(0, 22);
            lblPassword.TabIndex = 8;
            // 
            // btnX
            // 
            btnX.BackColor = Color.SandyBrown;
            btnX.FlatStyle = FlatStyle.Popup;
            btnX.Font = new Font("Mongolian Baiti", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnX.ForeColor = Color.Black;
            btnX.Location = new Point(1252, -1);
            btnX.Name = "btnX";
            btnX.Size = new Size(29, 33);
            btnX.TabIndex = 9;
            btnX.Text = "X";
            btnX.UseVisualStyleBackColor = false;
            btnX.Click += btnX_Click;
            // 
            // FormLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.Login_G;
            ClientSize = new Size(1280, 720);
            Controls.Add(btnX);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(pbPassword);
            Controls.Add(pbUsername);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ((System.ComponentModel.ISupportInitialize)pbUsername).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private PictureBox pbUsername;
        private PictureBox pbPassword;
        private Label lblUsername;
        private Label lblPassword;
        private Button btnX;
    }
}
