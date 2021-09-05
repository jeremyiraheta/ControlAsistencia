namespace WSControl
{
    partial class Permiso
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
            this.c_tpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c_cmbTipo = new System.Windows.Forms.ComboBox();
            this.c_btnSolicitar = new System.Windows.Forms.Button();
            this.c_btnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.c_txtDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.c_tpHoraInicial = new System.Windows.Forms.DateTimePicker();
            this.c_tpHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.c_btnAdjuntar = new System.Windows.Forms.Button();
            this.c_dlgAdj = new System.Windows.Forms.OpenFileDialog();
            this.c_dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.c_linkDescargar = new System.Windows.Forms.LinkLabel();
            this.c_lfile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // c_tpFecha
            // 
            this.c_tpFecha.CustomFormat = "dd/MM/yyyy";
            this.c_tpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c_tpFecha.Location = new System.Drawing.Point(12, 61);
            this.c_tpFecha.Name = "c_tpFecha";
            this.c_tpFecha.Size = new System.Drawing.Size(200, 22);
            this.c_tpFecha.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fecha del permiso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(215, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tipo";
            // 
            // c_cmbTipo
            // 
            this.c_cmbTipo.FormattingEnabled = true;
            this.c_cmbTipo.Items.AddRange(new object[] {
            "Particular",
            "Oficial",
            "Salud"});
            this.c_cmbTipo.Location = new System.Drawing.Point(218, 61);
            this.c_cmbTipo.Name = "c_cmbTipo";
            this.c_cmbTipo.Size = new System.Drawing.Size(142, 24);
            this.c_cmbTipo.TabIndex = 3;
            // 
            // c_btnSolicitar
            // 
            this.c_btnSolicitar.Location = new System.Drawing.Point(439, 280);
            this.c_btnSolicitar.Name = "c_btnSolicitar";
            this.c_btnSolicitar.Size = new System.Drawing.Size(114, 43);
            this.c_btnSolicitar.TabIndex = 4;
            this.c_btnSolicitar.Text = "Solicitar";
            this.c_btnSolicitar.UseVisualStyleBackColor = true;
            this.c_btnSolicitar.Click += new System.EventHandler(this.c_btnSolicitar_Click);
            // 
            // c_btnSalir
            // 
            this.c_btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.c_btnSalir.Location = new System.Drawing.Point(559, 280);
            this.c_btnSalir.Name = "c_btnSalir";
            this.c_btnSalir.Size = new System.Drawing.Size(115, 43);
            this.c_btnSalir.TabIndex = 5;
            this.c_btnSalir.Text = "Cancelar";
            this.c_btnSalir.UseVisualStyleBackColor = true;
            this.c_btnSalir.Click += new System.EventHandler(this.c_btnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Descripción";
            // 
            // c_txtDescripcion
            // 
            this.c_txtDescripcion.Location = new System.Drawing.Point(15, 111);
            this.c_txtDescripcion.Multiline = true;
            this.c_txtDescripcion.Name = "c_txtDescripcion";
            this.c_txtDescripcion.Size = new System.Drawing.Size(659, 163);
            this.c_txtDescripcion.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hora Inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Hora Final";
            // 
            // c_tpHoraInicial
            // 
            this.c_tpHoraInicial.CustomFormat = "hh:mm tt";
            this.c_tpHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c_tpHoraInicial.Location = new System.Drawing.Point(374, 63);
            this.c_tpHoraInicial.Name = "c_tpHoraInicial";
            this.c_tpHoraInicial.ShowUpDown = true;
            this.c_tpHoraInicial.Size = new System.Drawing.Size(138, 22);
            this.c_tpHoraInicial.TabIndex = 11;
            // 
            // c_tpHoraFinal
            // 
            this.c_tpHoraFinal.CustomFormat = "hh:mm tt";
            this.c_tpHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.c_tpHoraFinal.Location = new System.Drawing.Point(532, 63);
            this.c_tpHoraFinal.Name = "c_tpHoraFinal";
            this.c_tpHoraFinal.ShowUpDown = true;
            this.c_tpHoraFinal.Size = new System.Drawing.Size(142, 22);
            this.c_tpHoraFinal.TabIndex = 12;
            // 
            // c_btnAdjuntar
            // 
            this.c_btnAdjuntar.Location = new System.Drawing.Point(15, 280);
            this.c_btnAdjuntar.Name = "c_btnAdjuntar";
            this.c_btnAdjuntar.Size = new System.Drawing.Size(114, 43);
            this.c_btnAdjuntar.TabIndex = 13;
            this.c_btnAdjuntar.Text = "Adjuntar";
            this.c_btnAdjuntar.UseVisualStyleBackColor = true;
            this.c_btnAdjuntar.Click += new System.EventHandler(this.c_btnAdjuntar_Click);
            // 
            // c_dlgAdj
            // 
            this.c_dlgAdj.Filter = "Comprimido ZIP  (*.zip)|*.zip";
            this.c_dlgAdj.Title = "Subir archivo adjunto";
            // 
            // c_dlgSave
            // 
            this.c_dlgSave.Filter = "Comprimido ZIP  (*.zip)|*.zip";
            this.c_dlgSave.Title = "Descargar el adjunto";
            // 
            // c_linkDescargar
            // 
            this.c_linkDescargar.AutoSize = true;
            this.c_linkDescargar.Location = new System.Drawing.Point(136, 291);
            this.c_linkDescargar.Name = "c_linkDescargar";
            this.c_linkDescargar.Size = new System.Drawing.Size(74, 17);
            this.c_linkDescargar.TabIndex = 14;
            this.c_linkDescargar.TabStop = true;
            this.c_linkDescargar.Text = "Descargar";
            this.c_linkDescargar.Visible = false;
            this.c_linkDescargar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.c_linkDescargar_LinkClicked);
            // 
            // c_lfile
            // 
            this.c_lfile.AutoEllipsis = true;
            this.c_lfile.AutoSize = true;
            this.c_lfile.Location = new System.Drawing.Point(141, 291);
            this.c_lfile.MaximumSize = new System.Drawing.Size(300, 0);
            this.c_lfile.Name = "c_lfile";
            this.c_lfile.Size = new System.Drawing.Size(0, 17);
            this.c_lfile.TabIndex = 15;
            // 
            // Permiso
            // 
            this.AcceptButton = this.c_btnSolicitar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.c_btnSalir;
            this.ClientSize = new System.Drawing.Size(686, 335);
            this.Controls.Add(this.c_lfile);
            this.Controls.Add(this.c_linkDescargar);
            this.Controls.Add(this.c_btnAdjuntar);
            this.Controls.Add(this.c_tpHoraFinal);
            this.Controls.Add(this.c_tpHoraInicial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.c_txtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_btnSolicitar);
            this.Controls.Add(this.c_cmbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.c_tpFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Permiso";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Permisos";
            this.Load += new System.EventHandler(this.Permiso_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker c_tpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox c_cmbTipo;
        private System.Windows.Forms.Button c_btnSolicitar;
        private System.Windows.Forms.Button c_btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox c_txtDescripcion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker c_tpHoraInicial;
        private System.Windows.Forms.DateTimePicker c_tpHoraFinal;
        private System.Windows.Forms.Button c_btnAdjuntar;
        private System.Windows.Forms.OpenFileDialog c_dlgAdj;
        private System.Windows.Forms.SaveFileDialog c_dlgSave;
        private System.Windows.Forms.LinkLabel c_linkDescargar;
        private System.Windows.Forms.Label c_lfile;
    }
}