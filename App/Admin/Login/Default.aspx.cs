using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz.modelos;

public partial class Forms_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtuser.Text;
        string pass = txtpass.Text;
        Usuario emp = Datos.Login(user, pass);
        if (emp != null && emp.estado == 'A' && emp.admin)
        {            
            Session["user"] = emp;
            Response.Redirect("..");
        }else if(emp != null)
        {
            msg.Text = "Su usuario no tiene acceso!";
        }else if(emp == null)
        {
            msg.Text = "No hay conexion a los datos";
        }
        else
        {
            msg.Text = "Usuario o password incorrecto!";
        }
    }
}