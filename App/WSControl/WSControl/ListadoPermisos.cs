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
    public partial class ListadoPermisos : Form
    {
        private static readonly ListadoPermisos singleton = new ListadoPermisos();

        public static ListadoPermisos Instance
        {
            get
            {
                return singleton;
            }
        }

        private ListadoPermisos()
        {
            InitializeComponent();
            this.Text = "Listado de Permisos - " + Login.usuario.nombres + " " + Login.usuario.apellidos + " - " + Login.usuario.departamento;
        }  
        
        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_btnCrear_Click(object sender, EventArgs e)
        {
            new Permiso().ShowDialog(this);
            ListadoPermisos_Load(sender, e);
        }

        private void ListadoPermisos_Load(object sender, EventArgs e)
        {
            API<Permisos[]> api = new API<Permisos[]>();
            Permisos[] permisos = new Permisos[0];
            var task = Task.Run(() => api.get($"permisos/{Login.codemp}"));
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

        private void c_tblPermisos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Permisos p = (Permisos)c_tblPermisos.Rows.SharedRow(e.RowIndex).Tag;
            Permiso frmperm = new Permiso(p.codper,p.fecha,p.tipo,p.horainicial,p.horafinal,p.descripcion, p.estado, p.attch);            
            if(frmperm.ShowDialog(this) == DialogResult.OK)
                ListadoPermisos_Load(sender, null);
        }

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

        private void ListadoPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }        

        private void ListadoPermisos_VisibleChanged(object sender, EventArgs e)
        {
            if(this.Visible)
            {
                ListadoPermisos_Load(sender, null);
            }
        }
    }
}
