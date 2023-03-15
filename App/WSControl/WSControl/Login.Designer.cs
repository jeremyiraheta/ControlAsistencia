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
            this.pictureBox1.Location = new System.Drawing.Point(52, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // c_txtUsuario
            // 
            this.c_txtUsuario.Location = new System.Drawing.Point(22, 175);
            this.c_txtUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c_txtUsuario.Name = "c_txtUsuario";
            this.c_txtUsuario.Size = new System.Drawing.Size(212, 20);
            this.c_txtUsuario.TabIndex = 2;
            // 
            // c_txtPass
            // 
            this.c_txtPass.Location = new System.Drawing.Point(22, 223);
            this.c_txtPass.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c_txtPass.Name = "c_txtPass";
            this.c_txtPass.PasswordChar = '*';
            this.c_txtPass.Size = new System.Drawing.Size(212, 20);
            this.c_txtPass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 207);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // c_btnLogin
            // 
            this.c_btnLogin.Location = new System.Drawing.Point(22, 255);
            this.c_btnLogin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c_btnLogin.Name = "c_btnLogin";
            this.c_btnLogin.Size = new System.Drawing.Size(62, 29);
            this.c_btnLogin.TabIndex = 5;
            this.c_btnLogin.Text = "Login";
            this.c_btnLogin.UseVisualStyleBackColor = true;
            this.c_btnLogin.Click += new System.EventHandler(this.c_btnLogin_Click);
            // 
            // c_btnSalir
            // 
            this.c_btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_btnSalir.Location = new System.Drawing.Point(171, 255);
            this.c_btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.c_btnSalir.Name = "c_btnSalir";
            this.c_btnSalir.Size = new System.Drawing.Size(62, 29);
            this.c_btnSalir.TabIndex = 6;
            this.c_btnSalir.Text = "Salir";
            this.c_btnSalir.UseVisualStyleBackColor = true;
            this.c_btnSalir.Click += new System.EventHandler(this.c_btnSalir_Click);
            // 
            // Login
            // 
            this.AcceptButton = this.c_btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_btnSalir;
            this.ClientSize = new System.Drawing.Size(266, 294);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_btnLogin);
            this.Controls.Add(this.c_txtPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.c_txtUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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