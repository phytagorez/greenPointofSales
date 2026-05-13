namespace greenPointofSales
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            pbUsername = new PictureBox();
            pbPassword = new PictureBox();
            lblUsername = new Label();
            lblPassword = new Label();
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
            txtUsername.Font = new Font("Poppins", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(479, 323);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Username";
            txtUsername.Size = new Size(360, 35);
            txtUsername.TabIndex = 2;
            txtUsername.MouseEnter += txtUsername_MouseEnter_1;
            txtUsername.MouseLeave += txtUsername_MouseLeave_1;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.None;
            txtPassword.BackColor = Color.Beige;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.CharacterCasing = CharacterCasing.Upper;
            txtPassword.Cursor = Cursors.Hand;
            txtPassword.Font = new Font("Poppins", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(479, 390);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PlaceholderText = "Password";
            txtPassword.Size = new Size(360, 35);
            txtPassword.TabIndex = 3;
            txtPassword.MouseEnter += txtPassword_MouseEnter_1;
            txtPassword.MouseLeave += txtPassword_MouseLeave_1;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(22, 97, 14);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Georgia", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(490, 479);
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
            // FormLogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackgroundImage = Properties.Resources.Login_on;
            ClientSize = new Size(1280, 720);
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
    }
}
