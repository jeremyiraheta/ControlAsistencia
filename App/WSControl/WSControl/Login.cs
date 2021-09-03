using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSControl
{
    public partial class Login : Form
    {
        public static int codemp = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void c_btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void c_btnLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
