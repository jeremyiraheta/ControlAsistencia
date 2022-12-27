namespace WSControl
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
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
            this.c_maintab = new System.Windows.Forms.TabControl();
            this.c_thist = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.c_lstHist = new System.Windows.Forms.ListBox();
            this.c_tperm = new System.Windows.Forms.TabPage();
            this.c_lstMeses = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).BeginInit();
            this.c_maintab.SuspendLayout();
            this.c_thist.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.c_tperm.SuspendLayout();
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
            this.c_tblPermisos.Location = new System.Drawing.Point(3, 35);
            this.c_tblPermisos.Margin = new System.Windows.Forms.Padding(2);
            this.c_tblPermisos.MultiSelect = false;
            this.c_tblPermisos.Name = "c_tblPermisos";
            this.c_tblPermisos.ReadOnly = true;
            this.c_tblPermisos.RowTemplate.Height = 24;
            this.c_tblPermisos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.c_tblPermisos.Size = new System.Drawing.Size(798, 314);
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
            this.Descripcion.Width = 300;
            // 
            // HoraInicial
            // 
            this.HoraInicial.Frozen = true;
            this.HoraInicial.HeaderText = "Hora Inicial";
            this.HoraInicial.Name = "HoraInicial";
            this.HoraInicial.ReadOnly = true;
            // 
            // HoraFinal
            // 
            this.HoraFinal.Frozen = true;
            this.HoraFinal.HeaderText = "Hora Final";
            this.HoraFinal.Name = "HoraFinal";
            this.HoraFinal.ReadOnly = true;
            // 
            // c_btnSalir
            // 
            this.c_btnSalir.Location = new System.Drawing.Point(744, -1);
            this.c_btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.c_btnSalir.Name = "c_btnSalir";
            this.c_btnSalir.Size = new System.Drawing.Size(69, 31);
            this.c_btnSalir.TabIndex = 2;
            this.c_btnSalir.Text = "Salir";
            this.c_btnSalir.UseVisualStyleBackColor = true;
            this.c_btnSalir.Click += new System.EventHandler(this.c_btnSalir_Click);
            // 
            // c_btnElim
            // 
            this.c_btnElim.Enabled = false;
            this.c_btnElim.Location = new System.Drawing.Point(75, 0);
            this.c_btnElim.Margin = new System.Windows.Forms.Padding(2);
            this.c_btnElim.Name = "c_btnElim";
            this.c_btnElim.Size = new System.Drawing.Size(69, 31);
            this.c_btnElim.TabIndex = 3;
            this.c_btnElim.Text = "Eliminar";
            this.c_ttpStatus.SetToolTip(this.c_btnElim, "Solo se pueden eliminar permisos en espera");
            this.c_btnElim.UseVisualStyleBackColor = true;
            this.c_btnElim.Click += new System.EventHandler(this.c_btnElim_Click);
            // 
            // c_btnCrear
            // 
            this.c_btnCrear.Location = new System.Drawing.Point(2, 0);
            this.c_btnCrear.Margin = new System.Windows.Forms.Padding(2);
            this.c_btnCrear.Name = "c_btnCrear";
            this.c_btnCrear.Size = new System.Drawing.Size(69, 31);
            this.c_btnCrear.TabIndex = 1;
            this.c_btnCrear.Text = "Crear";
            this.c_ttpStatus.SetToolTip(this.c_btnCrear, "Crear un nuevo permiso");
            this.c_btnCrear.UseVisualStyleBackColor = true;
            this.c_btnCrear.Click += new System.EventHandler(this.c_btnCrear_Click);
            // 
            // c_maintab
            // 
            this.c_maintab.Controls.Add(this.c_thist);
            this.c_maintab.Controls.Add(this.c_tperm);
            this.c_maintab.Location = new System.Drawing.Point(3, 12);
            this.c_maintab.Name = "c_maintab";
            this.c_maintab.SelectedIndex = 0;
            this.c_maintab.Size = new System.Drawing.Size(814, 385);
            this.c_maintab.TabIndex = 4;
            // 
            // c_thist
            // 
            this.c_thist.Controls.Add(this.tableLayoutPanel1);
            this.c_thist.Location = new System.Drawing.Point(4, 22);
            this.c_thist.Name = "c_thist";
            this.c_thist.Padding = new System.Windows.Forms.Padding(3);
            this.c_thist.Size = new System.Drawing.Size(806, 359);
            this.c_thist.TabIndex = 1;
            this.c_thist.Text = "Historial";
            this.c_thist.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 583F));
            this.tableLayoutPanel1.Controls.Add(this.c_lstMeses, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.c_lstHist, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 347);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // c_lstHist
            // 
            this.c_lstHist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_lstHist.FormattingEnabled = true;
            this.c_lstHist.Location = new System.Drawing.Point(220, 3);
            this.c_lstHist.Name = "c_lstHist";
            this.c_lstHist.Size = new System.Drawing.Size(577, 341);
            this.c_lstHist.TabIndex = 1;
            // 
            // c_tperm
            // 
            this.c_tperm.Controls.Add(this.c_btnCrear);
            this.c_tperm.Controls.Add(this.c_btnElim);
            this.c_tperm.Controls.Add(this.c_tblPermisos);
            this.c_tperm.Location = new System.Drawing.Point(4, 22);
            this.c_tperm.Name = "c_tperm";
            this.c_tperm.Padding = new System.Windows.Forms.Padding(3);
            this.c_tperm.Size = new System.Drawing.Size(806, 359);
            this.c_tperm.TabIndex = 0;
            this.c_tperm.Text = "Permisos";
            this.c_tperm.UseVisualStyleBackColor = true;
            // 
            // c_lstMeses
            // 
            this.c_lstMeses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c_lstMeses.FormattingEnabled = true;
            this.c_lstMeses.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.c_lstMeses.Location = new System.Drawing.Point(3, 3);
            this.c_lstMeses.Name = "c_lstMeses";
            this.c_lstMeses.Size = new System.Drawing.Size(211, 341);
            this.c_lstMeses.TabIndex = 2;
            this.c_lstMeses.SelectedIndexChanged += new System.EventHandler(this.c_lstMeses_SelectedIndexChanged);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 409);
            this.Controls.Add(this.c_btnSalir);
            this.Controls.Add(this.c_maintab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.Text = "Shuseki - Control de Asistencia Remota";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListadoPermisos_FormClosing);
            this.Load += new System.EventHandler(this.ListadoPermisos_Load);
            this.VisibleChanged += new System.EventHandler(this.ListadoPermisos_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.c_tblPermisos)).EndInit();
            this.c_maintab.ResumeLayout(false);
            this.c_thist.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.c_tperm.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl c_maintab;
        private System.Windows.Forms.TabPage c_thist;
        private System.Windows.Forms.TabPage c_tperm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox c_lstHist;
        private System.Windows.Forms.ListBox c_lstMeses;
    }
}