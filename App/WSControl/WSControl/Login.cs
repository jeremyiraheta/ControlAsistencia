using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaz;
using Interfaz.modelos;

namespace WSControl
{
    public partial class Login : Form
    {        
        public static Usuario usuario { get; set; }
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
                if(usuario.activo)
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
            try
            {
                usuario = Datos.Login(user, pass);                
            }
            catch (Exception)
            {
                MessageBox.Show("Error al accesar datos!!!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            return usuario != null && usuario.activo;
        }
        
    }
}
