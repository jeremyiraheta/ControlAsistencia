namespace WSControl
{
    partial class ListadoPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoPermisos));
            this.c_tblPermisos = new System.Windows.Forms.DataGridView();
            this.HoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewImageColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_btnCrear = new System.Windows.Forms.Button();
            this.c_btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // c_tblPermisos
            // 
            this.c_tblPermisos.AllowUserToAddRows = false;
            this.c_tblPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_tblPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Estado,
            this.Tipo,
            this.Descripcion,
            this.HoraInicial,
            this.HoraFinal});
            this.c_tblPermisos.Location = new System.Drawing.Point(12, 60);
            this.c_tblPermisos.Name = "c_tblPermisos";
            this.c_tblPermisos.ReadOnly = true;
            this.c_tblPermisos.RowTemplate.Height = 24;
            this.c_tblPermisos.Size = new System.Drawing.Size(948, 387);
            this.c_tblPermisos.TabIndex = 0;
            // 
            // HoraFinal
            // 
            this.HoraFinal.Frozen = true;
            this.HoraFinal.HeaderText = "Hora Final";
            this.HoraFinal.Name = "HoraFinal";
            this.HoraFinal.ReadOnly = true;
            // 
            // HoraInicial
            // 
            this.HoraInicial.Frozen = true;
            this.HoraInicial.HeaderText = "Hora Inicial";
            this.HoraInicial.Name = "HoraInicial";
            this.HoraInicial.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.Frozen = true;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 400;
            // 
            // Tipo
            // 
            this.Tipo.Frozen = true;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.Frozen = true;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.Frozen = true;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // c_btnCrear
            // 
            this.c_btnCrear.Location = new System.Drawing.Point(12, 16);
            this.c_btnCrear.Name = "c_btnCrear";
            this.c_btnCrear.Size = new System.Drawing.Size(92, 38);
            this.c_btnCrear.TabIndex = 1;
            this.c_btnCrear.Text = "Crear";
            this.c_btnCrear.UseVisualStyleBackColor = true;
            this.c_btnCrear.Click += new System.EventHandler(this.c_btnCrear_Click);
            // 
            // c_btnSalir
            // 
            this.c_btnSalir.Location = new System.Drawing.Point(868, 16);
            this.c_btnSalir.Name = "c_btnSalir";
            this.c_btnSalir.Size = new System.Drawing.Size(92, 38);
            this.c_btnSalir.TabIndex = 2;
            this.c_btnSalir.Text = "Salir";
            this.c_btnSalir.UseVisualStyleBackColor = true;
            this.c_btnSalir.Click += new System.EventHandler(this.c_btnSalir_Click);
            // 
            // ListadoPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 459);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_btnCrear);
            this.Controls.Add(this.c_tblPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ListadoPermisos";
            this.Text = "Listado de Permisos";
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView c_tblPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewImageColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFinal;
        private System.Windows.Forms.Button c_btnCrear;
        private System.Windows.Forms.Button c_btnSalir;
    }
}