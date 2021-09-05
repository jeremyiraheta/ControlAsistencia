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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoPermisos));
            this.c_tblPermisos = new System.Windows.Forms.DataGridView();
            this.CODPER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewImageColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_btnSalir = new System.Windows.Forms.Button();
            this.c_ttpStatus = new System.Windows.Forms.ToolTip(this.components);
            this.c_btnElim = new System.Windows.Forms.Button();
            this.c_btnCrear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // c_tblPermisos
            // 
            this.c_tblPermisos.AllowUserToAddRows = false;
            this.c_tblPermisos.AllowUserToDeleteRows = false;
            this.c_tblPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.c_tblPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CODPER,
            this.Fecha,
            this.Estado,
            this.Tipo,
            this.Descripcion,
            this.HoraInicial,
            this.HoraFinal});
            this.c_tblPermisos.Location = new System.Drawing.Point(12, 60);
            this.c_tblPermisos.MultiSelect = false;
            this.c_tblPermisos.Name = "c_tblPermisos";
            this.c_tblPermisos.ReadOnly = true;
            this.c_tblPermisos.RowTemplate.Height = 24;
            this.c_tblPermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_tblPermisos.Size = new System.Drawing.Size(948, 387);
            this.c_tblPermisos.TabIndex = 0;
            this.c_ttpStatus.SetToolTip(this.c_tblPermisos, "Listado de permisos");
            this.c_tblPermisos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.c_tblPermisos_CellContentDoubleClick);
            this.c_tblPermisos.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.c_tblPermisos_RowEnter);
            // 
            // CODPER
            // 
            this.CODPER.Frozen = true;
            this.CODPER.HeaderText = "Codper";
            this.CODPER.Name = "CODPER";
            this.CODPER.ReadOnly = true;
            this.CODPER.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.Frozen = true;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.Frozen = true;
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.Frozen = true;
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.Frozen = true;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 350;
            // 
            // HoraInicial
            // 
            this.HoraInicial.Frozen = true;
            this.HoraInicial.HeaderText = "Hora Inicial";
            this.HoraInicial.Name = "HoraInicial";
            this.HoraInicial.ReadOnly = true;
            this.HoraInicial.Width = 130;
            // 
            // HoraFinal
            // 
            this.HoraFinal.Frozen = true;
            this.HoraFinal.HeaderText = "Hora Final";
            this.HoraFinal.Name = "HoraFinal";
            this.HoraFinal.ReadOnly = true;
            this.HoraFinal.Width = 130;
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
            // c_btnElim
            // 
            this.c_btnElim.Enabled = false;
            this.c_btnElim.Location = new System.Drawing.Point(110, 16);
            this.c_btnElim.Name = "c_btnElim";
            this.c_btnElim.Size = new System.Drawing.Size(92, 38);
            this.c_btnElim.TabIndex = 3;
            this.c_btnElim.Text = "Eliminar";
            this.c_ttpStatus.SetToolTip(this.c_btnElim, "Solo se pueden eliminar permisos en espera");
            this.c_btnElim.UseVisualStyleBackColor = true;
            this.c_btnElim.Click += new System.EventHandler(this.c_btnElim_Click);
            // 
            // c_btnCrear
            // 
            this.c_btnCrear.Location = new System.Drawing.Point(12, 16);
            this.c_btnCrear.Name = "c_btnCrear";
            this.c_btnCrear.Size = new System.Drawing.Size(92, 38);
            this.c_btnCrear.TabIndex = 1;
            this.c_btnCrear.Text = "Crear";
            this.c_ttpStatus.SetToolTip(this.c_btnCrear, "Crear un nuevo permiso");
            this.c_btnCrear.UseVisualStyleBackColor = true;
            this.c_btnCrear.Click += new System.EventHandler(this.c_btnCrear_Click);
            // 
            // ListadoPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 459);
            this.Controls.Add(this.c_btnElim);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_btnCrear);
            this.Controls.Add(this.c_tblPermisos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ListadoPermisos";
            this.Text = "Listado de Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoPermisos_FormClosing);
            this.Load += new System.EventHandler(this.ListadoPermisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView c_tblPermisos;
        private System.Windows.Forms.Button c_btnCrear;
        private System.Windows.Forms.Button c_btnSalir;
        private System.Windows.Forms.ToolTip c_ttpStatus;
        private System.Windows.Forms.Button c_btnElim;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODPER;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewImageColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraFinal;
    }
}