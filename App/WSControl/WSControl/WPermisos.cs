using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaz;
using Interfaz.modelos;

namespace WSControl
{
    /// <summary>
    /// Ventana que permite crear o editar permisos
    /// </summary>
    public partial class WPermisos : Form
    {
        private int codper = 0;
        private string file;
        /// <summary>
        /// Inicializa ventana de permisos vacia
        /// </summary>
        public WPermisos()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Inicializa la ventana de permisos con valores para editar
        /// </summary>
        /// <param name="codper">codigo de permido</param>
        /// <param name="fecha">fecha</param>
        /// <param name="tipo">tipo</param>
        /// <param name="horainicial">hora inicial</param>
        /// <param name="horafinal">hora final</param>
        /// <param name="descripcion">descripcion</param>
        /// <param name="estado">estado</param>
        /// <param name="attch">si tiene archivo adjunto</param>
        public WPermisos(int codper, string fecha, char tipo, string horainicial, string horafinal, string descripcion, char estado, bool attch)
        {
            InitializeComponent();
            this.codper = codper;
            CultureInfo provider = CultureInfo.InvariantCulture;
            c_tpFecha.Value = DateTime.ParseExact(fecha, "dd/MM/yyyy", provider);
            switch (tipo)
            {
                case 'O':
                    c_cmbTipo.SelectedIndex = 1;
                    break;
                case 'S':
                    c_cmbTipo.SelectedIndex = 2;
                    break;
                default:
                    c_cmbTipo.SelectedIndex = 0;
                    break;
            }
            c_btnSolicitar.Enabled = false;
            c_btnAdjuntar.Enabled = false;
            switch (estado)
            {
                case 'E':
                    c_btnAdjuntar.Enabled = true;
                    c_btnSolicitar.Enabled = true;
                    this.Text = "Permisos - Espera";
                    break;
                case 'R':
                    this.Text = "Permisos - Rechazado";
                    break;
                case 'A':
                    this.Text = "Permisos - Aprobado";
                    break;
                default:
                    break;
            }
            c_cmbTipo.Refresh();
            c_tpHoraInicial.Value = DateTime.Parse(horainicial);
            c_tpHoraFinal.Value = DateTime.Parse(horafinal);
            c_txtDescripcion.Text = Uri.UnescapeDataString(descripcion);
            if (attch)
                c_linkDescargar.Visible = true;
        }
        /// <summary>
        /// Evento vinculado al boton salir, permite cerrar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento disparado al cargar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Permiso_Load(object sender, EventArgs e)
        {
            if (c_cmbTipo.SelectedIndex == -1)
                c_cmbTipo.SelectedIndex = 0;
        }
        /// <summary>
        /// Evento vinculado al boton solicitar, permite enviar a la api los datos del permiso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnSolicitar_Click(object sender, EventArgs e)
        {
            try
            {
                Permiso permiso = new Permiso();
                permiso.codemp = Login.usuario.codemp;
                permiso.codcli = Login.usuario.codcli;
                if (c_txtDescripcion.Text.Trim().Length < 10)
                {
                    MessageBox.Show(this, "Debe justificar su permiso!, almenos 10 caracteres", "Descripcion no valida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                permiso.descripcion = Uri.EscapeDataString(c_txtDescripcion.Text);
                permiso.fecha = c_tpFecha.Value.ToString("dd-MM-yyyy");
                permiso.horainicial = c_tpHoraInicial.Value.ToString("HH:mm");
                permiso.horafinal = c_tpHoraFinal.Value.ToString("HH:mm");
                permiso.estado = 'E';
                if (c_cmbTipo.SelectedIndex == 0)
                    permiso.tipo = 'P';
                else if (c_cmbTipo.SelectedIndex == 1)
                    permiso.tipo = 'O';
                else if (c_cmbTipo.SelectedIndex == 2)
                    permiso.tipo = 'S';
                if (codper == 0)
                {
                    Datos.Result result = Datos.insertPermiso(permiso);
                    codper = result.insertId;
                }
                else
                {
                    Datos.Result result = Datos.updatePermiso(codper, permiso);
                    if (result == null || result.affectedRows == 0)
                        throw new Exception();
                }
                if (c_dlgAdj.FileNames.Length > 0)
                {
                    var result = Datos.uploadPermisoAdjunto(codper, Login.usuario.codcli, c_dlgAdj.FileName);
                    if (!result.status)
                        MessageBox.Show(this, result.message, "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Ocurrio un error interno y la accion no pudo ejecutarse", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento vinculado al boton de adjuntar, permite adjuntar archivo zip al permiso
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnAdjuntar_Click(object sender, EventArgs e)
        {
            if (c_dlgAdj.ShowDialog(this) == DialogResult.OK)
            {
                file = c_dlgAdj.FileName;
                FileInfo fi = new FileInfo(file);
                if (ToSize(fi.Length, SizeUnits.MB) > 20)
                    MessageBox.Show(this, "El archivo no debe exceder los 20MB!!!", "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (fi.Extension.ToLower() == ".zip")
                    {
                        c_lfile.Text = "Adjunto: " + fi.Name;
                        c_linkDescargar.Visible = false;
                    }
                    else
                        MessageBox.Show(this, "El formato no es valido!!!", "Adjuntar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Evento vinculado al link descarga, permite descargar archivo adjunto si existe uno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void c_linkDescargar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {            
            if (c_dlgSave.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes;
                try
                {
                    bytes = await Datos.downloadPermisoAdjunto(codper, Login.usuario.codcli);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Ocurrio un error al intentar descargar el archivo...", "Descargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BinaryWriter writer = new BinaryWriter(c_dlgSave.OpenFile());
                writer.Write(bytes);
                writer.Flush();
                writer.Close();
                System.Diagnostics.Process.Start("explorer.exe", c_dlgSave.FileName);
            }
        }
        public enum SizeUnits
        {
            Byte, KB, MB, GB, TB, PB, EB, ZB, YB
        }
        /// <summary>
        /// Convierte bites a un valor en base a su unidad
        /// </summary>
        /// <param name="value">valor en bites</param>
        /// <param name="unit">unidad a la que se dea convertir</param>
        /// <returns></returns>
        public double ToSize(Int64 value, SizeUnits unit)
        {
            return (value / (double)Math.Pow(1024, (Int64)unit));
        }        
    }
}
