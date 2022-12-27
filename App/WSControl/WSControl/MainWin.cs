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
using WSControl.modelos;


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
        /// Evento vinculado al boton salir, permite cerrar la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Evento vinculado al boton crear, permite crear un permiso nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnCrear_Click(object sender, EventArgs e)
        {
            new Permiso().ShowDialog(this);
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
            c_lstMeses.SelectedIndex = DateTime.Now.Month - 1;
        }   
        /// <summary>
        /// Agrega permisos a la tabla
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int addRow(Permisos p)
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
            Permisos p = (Permisos)c_tblPermisos.Rows.SharedRow(e.RowIndex).Tag;
            Permiso frmperm = new Permiso(p.codper,p.fecha,p.tipo,p.horainicial,p.horafinal,p.descripcion, p.estado, p.attch);            
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
                Permisos p = (Permisos)c_tblPermisos.Rows[e.RowIndex].Tag;
                try
                {
                    c_btnElim.Enabled = false;
                }
                catch (Exception)
                {
                }
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
            Permisos p = (Permisos)c_tblPermisos.SelectedRows[0].Tag;
            if (p == null) return;
            API api = new API();
            var task = Task.Run(() => api.delete($"permisos/{p.codper}"));
            try
            {
                task.Wait();
            }
            catch (Exception)
            {
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
                API<Registros[]> api = new API<Registros[]>();
                Registros[] registros;
                var task = Task.Run(() => api.get($"registros/{Login.codemp}/{m}/{year}"));
                task.Wait();
                registros = task.Result;
                c_lstHist.Items.Clear();
                foreach (var item in registros)
                {
                    c_lstHist.Items.Add($"{item.fecha} - Entrada: {item.horaentrada} || Salida: {item.horasalida}");
                }
            }
            catch (Exception)
            {
            }
        }
        
        private void loadPermit()
        {
            API<Permisos[]> api = new API<Permisos[]>();
            Permisos[] permisos = new Permisos[0];
            var task = Task.Run(() => api.get($"permisos/emp/{Login.codemp}"));
            try
            {
                task.Wait();
                permisos = task.Result;
            }
            catch (Exception)
            {
            }
            c_tblPermisos.Rows.Clear();
            foreach (var p in permisos)
                c_tblPermisos.Rows[addRow(p)].Tag = p;
            c_tblPermisos.CurrentCell = null;
        }

        private void c_lstMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadHistory(c_lstMeses.SelectedIndex + 1, DateTime.Now.Year);
        }
    }
}
