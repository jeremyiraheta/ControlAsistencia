using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Interfaz;
using Interfaz.modelos;
using System.Globalization;

namespace WSControl
{
    /// <summary>
    /// Ventana que permite gestionar los permisos del empleado logueado
    /// </summary>
    public partial class MainWin : Form
    {
        private static readonly MainWin singleton = new MainWin();

        /// <summary>
        /// La ventana solo tendra una instancia activa, clase singleton
        /// </summary>
        public static MainWin Instance
        {
            get
            {
                return singleton;
            }
        }
        /// <summary>
        /// Inicializa la ventana de permisos
        /// </summary>
        private MainWin()
        {
            InitializeComponent();
            this.Text = "Shuseki - Control de Asistencia Remota - " + Login.usuario.nombres + " " + Login.usuario.apellidos + " - " + Login.usuario.departamento;
        }  
        
        /// <summary>
        /// Evento vinculado al boton crear, permite crear un permiso nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnCrear_Click(object sender, EventArgs e)
        {
            new WPermisos().ShowDialog(this);
            ListadoPermisos_Load(sender, e);
        }
        /// <summary>
        /// Evento disparado cuando se carga la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListadoPermisos_Load(object sender, EventArgs e)
        {
            loadPermit();
            loadHistory(DateTime.Now.Month, DateTime.Now.Year);
            if(c_lstMeses != null)
                c_lstMeses.SelectedIndex = DateTime.Now.Month - 1;
        }   
        /// <summary>
        /// Agrega permisos a la tabla
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int addRow(Permiso p)
        {
            Bitmap img;
            switch (p.estado)
            {
                case 'A':
                    img = Properties.Resources.aprobado;
                    break;
                case 'R':
                    img = Properties.Resources.rechazado;                    
                    break;
                default:
                    img = Properties.Resources.espera;
                    break;
            }
            string tipo;
            switch (p.tipo)
            {
                case 'O':
                    tipo = "Oficial";
                    break;
                case 'S':
                    tipo = "Salud";
                    break;
                default:
                    tipo = "Particular";
                    break;
            }
            return c_tblPermisos.Rows.Add(p.codper,p.fecha, img, tipo, Uri.UnescapeDataString(p.descripcion), p.horainicial.Remove(p.horainicial.LastIndexOf(":")), p.horafinal.Remove(p.horafinal.LastIndexOf(":")));
        }
        /// <summary>
        /// Evento vinculado a la tabla, permite editar un permiso al darle doble click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_tblPermisos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Permiso p = (Permiso)c_tblPermisos.Rows.SharedRow(e.RowIndex).Tag;
            WPermisos frmperm = new WPermisos(p.codper,p.fecha,p.tipo,p.horainicial,p.horafinal,p.descripcion, p.estado, p.attch);            
            if(frmperm.ShowDialog(this) == DialogResult.OK)
                ListadoPermisos_Load(sender, null);
        }
        /// <summary>
        /// Evento vinculado a la tabla, permite seleccionar elementos de la tabla para su eliminacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_tblPermisos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(() => {
                Permiso p = (Permiso)c_tblPermisos.Rows[e.RowIndex].Tag;
                c_btnElim.Enabled = false;
                if (p == null)
                    return;
                if (p.estado == 'E')
                    c_btnElim.Enabled = true;
            }
                ));
        }
        /// <summary>
        /// Evento vinculado a boton eliminar, permite eliminar el permiso seleccionado si esta en estado pendiente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnElim_Click(object sender, EventArgs e)
        {
            if (c_tblPermisos.SelectedRows.Count == 0) return;
            Permiso p = (Permiso)c_tblPermisos.SelectedRows[0].Tag;
            if (p == null) return;
            try
            {
                var result = Datos.deletePermiso(p.codper, p.codcli);
                if (result.affectedRows > 0)
                    MessageBox.Show("Se elimino el permiso", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar permiso", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ListadoPermisos_Load(sender, null);
        }
        /// <summary>
        /// Evento disparado al cerrar ventana, oculta la ventana en lugar de destruir el objecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListadoPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }        
        /// <summary>
        /// Evento disparado al cambiar la visibilidad de la ventana, permite recargar el contenido de la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListadoPermisos_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                ListadoPermisos_Load(sender, null);
            }
        }
        /// <summary>
        /// Carga el historial de registros
        /// </summary>
        private void loadHistory(int m, int year)
        {
            try
            {
                List<Registro> registros = Datos.listRegistrosEmpleado(Login.usuario.codemp, Login.usuario.codcli, m, year);                
                c_table.Rows.Clear();
                foreach (var item in registros)
                {
                    string horaentrada = item.horaentrada;
                    string horasalida = item.horasalida;
                    c_table.Rows.Add(item.fecha, horaentrada, horasalida);                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudieron cargar los registros", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Carga los permisos
        /// </summary>
        private void loadPermit()
        {            
            List<Permiso> permisos = new List<Permiso>();            
            try
            {
                permisos = Datos.listPermisos(Login.usuario.codemp, Login.usuario.codcli);
                if (permisos != null && permisos.Count > 0)
                    permisos = permisos.Where(x => FechaMaximaAntiguedad(x.fecha, 30)).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudieron cargar los permisos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            c_tblPermisos.Rows.Clear();
            foreach (var p in permisos)
                c_tblPermisos.Rows[addRow(p)].Tag = p;
            c_tblPermisos.CurrentCell = null;
        }

        public static string AdjustTimeForTimeZone(string timeString, int timeZoneOffset)
        {
            // Convertir la cadena de tiempo a un objeto DateTime
            DateTime time = DateTime.ParseExact(timeString, "HH:mm:ss", null);

            // Ajustar la hora para la zona horaria especificada
            time = time.AddHours(timeZoneOffset);

            // Formatear la hora ajustada como una cadena en formato HH:mm:ss
            string adjustedTimeString = time.ToString("HH:mm:ss");

            return adjustedTimeString;
        }

        public static bool FechaMaximaAntiguedad(string fechaString, int max)
        {
            DateTime fecha = DateTime.ParseExact(fechaString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            TimeSpan diferencia = DateTime.Now - fecha;
            return (diferencia.TotalDays <= max);
        }

        private void c_lstMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHistory(c_lstMeses.SelectedIndex + 1, DateTime.Now.Year);
        }

        private void c_btnsalirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_btnAbout_Click(object sender, EventArgs e)
        {
            Cliente cli = Datos.getCliente(Login.usuario.codcli);
            MessageBox.Show(this,"Aplicación desarrollada por Shuseki, servicio ofrecido a " + cli.nombre + ", version: " + Application.ProductVersion, "INFO", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
