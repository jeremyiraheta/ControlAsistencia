namespace WSControl
{
    partial class ControlService
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlService));
            this.c_systray = new System.Windows.Forms.NotifyIcon(this.components);
            // 
            // c_systray
            // 
            this.c_systray.Icon = ((System.Drawing.Icon)(resources.GetObject("c_systray.Icon")));
            this.c_systray.Text = "Control Asistencia DIGESTYC";
            this.c_systray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.c_systray_MouseClick);
            // 
            // ControlService
            // 
            this.ServiceName = "Control Asistencia DIGESTYC";

        }

        #endregion

        private System.Windows.Forms.NotifyIcon c_systray;
    }
}
