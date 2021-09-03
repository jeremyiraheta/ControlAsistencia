namespace WSControl
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.c_txtUsuario = new System.Windows.Forms.TextBox();
            this.c_txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.c_btnLogin = new System.Windows.Forms.Button();
            this.c_btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(69, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // c_txtUsuario
            // 
            this.c_txtUsuario.Location = new System.Drawing.Point(29, 215);
            this.c_txtUsuario.Name = "c_txtUsuario";
            this.c_txtUsuario.Size = new System.Drawing.Size(282, 22);
            this.c_txtUsuario.TabIndex = 2;
            // 
            // c_txtPass
            // 
            this.c_txtPass.Location = new System.Drawing.Point(29, 275);
            this.c_txtPass.Name = "c_txtPass";
            this.c_txtPass.PasswordChar = '*';
            this.c_txtPass.Size = new System.Drawing.Size(282, 22);
            this.c_txtPass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // c_btnLogin
            // 
            this.c_btnLogin.Location = new System.Drawing.Point(29, 314);
            this.c_btnLogin.Name = "c_btnLogin";
            this.c_btnLogin.Size = new System.Drawing.Size(83, 36);
            this.c_btnLogin.TabIndex = 5;
            this.c_btnLogin.Text = "Login";
            this.c_btnLogin.UseVisualStyleBackColor = true;
            this.c_btnLogin.Click += new System.EventHandler(this.c_btnLogin_Click);
            // 
            // c_btnSalir
            // 
            this.c_btnSalir.Location = new System.Drawing.Point(228, 314);
            this.c_btnSalir.Name = "c_btnSalir";
            this.c_btnSalir.Size = new System.Drawing.Size(83, 36);
            this.c_btnSalir.TabIndex = 6;
            this.c_btnSalir.Text = "Salir";
            this.c_btnSalir.UseVisualStyleBackColor = true;
            this.c_btnSalir.Click += new System.EventHandler(this.c_btnSalir_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 362);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_btnLogin);
            this.Controls.Add(this.c_txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox c_txtUsuario;
        private System.Windows.Forms.TextBox c_txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button c_btnLogin;
        private System.Windows.Forms.Button c_btnSalir;
    }
}