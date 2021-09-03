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


namespace WSControl
{
    public partial class ListadoPermisos : Form
    {
        
        public ListadoPermisos()
        {
            InitializeComponent();
            
        }
        
        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_btnCrear_Click(object sender, EventArgs e)
        {
            new Permisos().ShowDialog(this);
        }
    }
}
