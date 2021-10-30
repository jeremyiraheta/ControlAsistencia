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
        private char estado;
        public static Empleado usuario { get; set; }
        /// <summary>
        /// Inicializador de la ventana de login
        /// </summary>
        public Login()
        {
            InitializeComponent();
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
        /// Evento vinculado al boton login, permite verificar si las credenciales son correctas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c_btnLogin_Click(object sender, EventArgs e)
        {
            if(c_txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese usuario!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (c_txtPass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingrese password!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (login(c_txtUsuario.Text, c_txtPass.Text))
            {
                if(estado.ToString().ToUpper() == "A")
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Usuario desactivado!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuario o Password incorrectos!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                         
        }
        /// <summary>
        /// Determina si un usuario es valido
        /// </summary>
        /// <param name="user">Usuario</param>
        /// <param name="pass">Password</param>
        /// <returns>True si es un usuario valido</returns>
        private bool login(string user, string pass)
        {
            API<List< Empleado >> api = new API<List<Empleado>>();
            List<Empleado> valid = null;
            Credenciales c = new Credenciales(user,pass);
            var task = Task.Run(() => api.post("login", c));
            try
            {
                task.Wait();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al accesar datos!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            valid = task.Result;
            if (valid != null && valid.Count > 0)
            {
                codemp = valid[0].codemp;
                estado = valid[0].estado;
                usuario = valid[0];
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Entidad de usuarios
        /// </summary>
        class Credenciales
        {
            public string user { get; set; }
            public string password { get; set; }
            public Credenciales(string user, string pass)
            {
                this.user = user;
                this.password = pass;
            }
            public Credenciales()
            {

            }
        }
        /// <summary>
        /// Entidad de Empleados
        /// </summary>
        public class Empleado
        {
            public int codemp { get; set; }
            public char estado { get; set; }
            public string nombres { get; set; }
            public string apellidos { get; set; }
            public string departamento { get; set; }
            public Empleado()
            {

            }
        }
    }
}
