using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Forms_Login : System.Web.UI.Page
{
    public Cliente cliente;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Page.RouteData.Values.ContainsKey("urlnom"))
        {
            string urlnom = Page.RouteData.Values["urlnom"].ToString();
            try
            {
                cliente = Datos.getCliente(urlnom);
            }
            catch (Exception)
            {

                msg.Text = "Estamos en mantenimiento, intente mas tarde!";
            }           
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtuser.Text;
        string pass = txtpass.Text;
        Usuario emp;
        try
        {
            if (cliente == null)
                emp = Datos.Login(user, pass);
            else
                emp = Datos.Login(user, pass, cliente.codcli);
            if (emp != null && emp.activo && emp.admin)
            {
                Session["usuario"] = emp;
                Session["cliente"] = Datos.getCliente(emp.codcli);
                Response.Redirect("/Admin");
            }
            else if (emp != null)
            {
                msg.Text = "Su usuario no tiene acceso!";
            }
            else
            {
                msg.Text = "Usuario o password incorrecto!";
            }
        }
        catch (Exception)
        {

            msg.Text = "Estamos en mantenimiento, intente mas tarde!";
        }

        
    }
}