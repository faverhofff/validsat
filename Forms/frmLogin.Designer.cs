namespace ValidSAT.forms
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ingresarButton2 = new System.Windows.Forms.Button();
            this.salirButton2 = new System.Windows.Forms.Button();
            this.ingresarButton = new System.Windows.Forms.Button();
            this.salirButton = new System.Windows.Forms.Button();
            this.txt_password = new LollipopTextBox();
            this.txt_user = new LollipopTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.claveAnimation = new System.Windows.Forms.Panel();
            this.nombreUsuarioAnimation = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(169)))), ((int)(((byte)(160)))));
            this.panel1.BackgroundImage = global::ValidSAT.Properties.Resources.login_form;
            this.panel1.Controls.Add(this.ingresarButton2);
            this.panel1.Controls.Add(this.salirButton2);
            this.panel1.Controls.Add(this.ingresarButton);
            this.panel1.Controls.Add(this.salirButton);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_user);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.claveAnimation);
            this.panel1.Controls.Add(this.nombreUsuarioAnimation);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(460, 166);
            this.panel1.TabIndex = 1;
            // 
            // ingresarButton2
            // 
            this.ingresarButton2.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
            this.ingresarButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ingresarButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ingresarButton2.FlatAppearance.BorderSize = 0;
            this.ingresarButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingresarButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ingresarButton2.Location = new System.Drawing.Point(257, 120);
            this.ingresarButton2.Name = "ingresarButton2";
            this.ingresarButton2.Size = new System.Drawing.Size(197, 38);
            this.ingresarButton2.TabIndex = 16;
            this.ingresarButton2.TabStop = false;
            this.ingresarButton2.UseVisualStyleBackColor = true;
            this.ingresarButton2.Click += new System.EventHandler(this.ingresarButton2_Click);
            this.ingresarButton2.MouseEnter += new System.EventHandler(this.ingresarButton2_Enter);
            this.ingresarButton2.MouseLeave += new System.EventHandler(this.ingresarButton2_leave);
            // 
            // salirButton2
            // 
            this.salirButton2.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
            this.salirButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.salirButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.salirButton2.FlatAppearance.BorderSize = 0;
            this.salirButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.salirButton2.Location = new System.Drawing.Point(0, 120);
            this.salirButton2.Name = "salirButton2";
            this.salirButton2.Size = new System.Drawing.Size(165, 38);
            this.salirButton2.TabIndex = 15;
            this.salirButton2.TabStop = false;
            this.salirButton2.UseVisualStyleBackColor = true;
            this.salirButton2.Click += new System.EventHandler(this.salirButton2_Click);
            this.salirButton2.MouseEnter += new System.EventHandler(this.salirButton2Enter);
            this.salirButton2.MouseLeave += new System.EventHandler(this.salirButton2_MouseLeave);
            // 
            // ingresarButton
            // 
            this.ingresarButton.BackgroundImage = global::ValidSAT.Properties.Resources.ingresar_off;
            this.ingresarButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ingresarButton.FlatAppearance.BorderSize = 0;
            this.ingresarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ingresarButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ingresarButton.Location = new System.Drawing.Point(257, 120);
            this.ingresarButton.Name = "ingresarButton";
            this.ingresarButton.Size = new System.Drawing.Size(195, 38);
            this.ingresarButton.TabIndex = 3;
            this.ingresarButton.UseVisualStyleBackColor = true;
            this.ingresarButton.Enter += new System.EventHandler(this.ingresarButton2_Enter);
            this.ingresarButton.Leave += new System.EventHandler(this.ingresarButton_Leave);
            this.ingresarButton.MouseEnter += new System.EventHandler(this.ingresarButton2_Enter);
            this.ingresarButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ingresarButton_PreviewKeyDown_1);
            // 
            // salirButton
            // 
            this.salirButton.BackgroundImage = global::ValidSAT.Properties.Resources.salir_off;
            this.salirButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.salirButton.FlatAppearance.BorderSize = 0;
            this.salirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salirButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.salirButton.Location = new System.Drawing.Point(4, 120);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(165, 38);
            this.salirButton.TabIndex = 4;
            this.salirButton.UseVisualStyleBackColor = true;
            this.salirButton.Enter += new System.EventHandler(this.salirButton_Enter);
            this.salirButton.Leave += new System.EventHandler(this.salirButton_Leave);
            this.salirButton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.salirButton_PreviewKeyDown_1);
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(169)))), ((int)(((byte)(160)))));
            this.txt_password.BackgroundColor_RGB = "39, 169, 160";
            this.txt_password.CharacterCasing_LI = System.Windows.Forms.CharacterCasing.Normal;
            this.txt_password.EnabledUnFocusedColor_LI = "#067069";
            this.txt_password.FocusedColor = "#ffffff";
            this.txt_password.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.Font_LI = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_password.FontColor = "#ffffff";
            this.txt_password.IsEnabled = true;
            this.txt_password.Location = new System.Drawing.Point(172, 61);
            this.txt_password.MaxLength = 32767;
            this.txt_password.Multiline = false;
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar_LI = '*';
            this.txt_password.ReadOnly = false;
            this.txt_password.Size = new System.Drawing.Size(158, 24);
            this.txt_password.TabIndex = 2;
            this.txt_password.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_password.UseSystemPasswordChar = false;
            this.txt_password.onKey += new LollipopTextBox.keyEventHandler(this.txt_password_onKey);
            this.txt_password.OnPreviewKeyDown += new LollipopTextBox.PreviewKeyDownEventHandler(this.txt_password_OnPreviewKeyDown);
            // 
            // txt_user
            // 
            this.txt_user.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(169)))), ((int)(((byte)(160)))));
            this.txt_user.BackgroundColor_RGB = "39, 169, 160";
            this.txt_user.CharacterCasing_LI = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_user.EnabledUnFocusedColor_LI = "#067069";
            this.txt_user.FocusedColor = "#ffffff";
            this.txt_user.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.Font_LI = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_user.FontColor = "#ffffff";
            this.txt_user.IsEnabled = true;
            this.txt_user.Location = new System.Drawing.Point(173, 20);
            this.txt_user.MaxLength = 32767;
            this.txt_user.Multiline = false;
            this.txt_user.Name = "txt_user";
            this.txt_user.PasswordChar_LI = '\0';
            this.txt_user.ReadOnly = false;
            this.txt_user.Size = new System.Drawing.Size(158, 24);
            this.txt_user.TabIndex = 1;
            this.txt_user.TabStop = false;
            this.txt_user.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.txt_user.UseSystemPasswordChar = false;
            this.txt_user.onKey += new LollipopTextBox.keyEventHandler(this.txt_user_onKey_1);
            this.txt_user.OnPreviewKeyDown += new LollipopTextBox.PreviewKeyDownEventHandler(this.txt_user_OnPreviewKeyDown);
            this.txt_user.TextChanged += new System.EventHandler(this.txt_user_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(174, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 1);
            this.panel3.TabIndex = 6;
            // 
            // claveAnimation
            // 
            this.claveAnimation.BackColor = System.Drawing.Color.White;
            this.claveAnimation.Location = new System.Drawing.Point(173, 83);
            this.claveAnimation.Name = "claveAnimation";
            this.claveAnimation.Size = new System.Drawing.Size(157, 1);
            this.claveAnimation.TabIndex = 5;
            // 
            // nombreUsuarioAnimation
            // 
            this.nombreUsuarioAnimation.BackColor = System.Drawing.Color.White;
            this.nombreUsuarioAnimation.Location = new System.Drawing.Point(173, 42);
            this.nombreUsuarioAnimation.Name = "nombreUsuarioAnimation";
            this.nombreUsuarioAnimation.Size = new System.Drawing.Size(157, 1);
            this.nombreUsuarioAnimation.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(172, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(156, 1);
            this.panel2.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(458, 166);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLogin_FormClosed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel claveAnimation;
        private System.Windows.Forms.Panel nombreUsuarioAnimation;
        private LollipopTextBox txt_user;
        private LollipopTextBox txt_password;
        private System.Windows.Forms.Button salirButton;
        private System.Windows.Forms.Button ingresarButton;
        private System.Windows.Forms.Button salirButton2;
        private System.Windows.Forms.Button ingresarButton2;
    }
}