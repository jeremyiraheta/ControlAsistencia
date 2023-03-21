using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;
using System.Globalization;

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
                if(subscrito((Cliente)Session["cliente"]))                
                    Response.Redirect("/Admin");
                else
                {
                    Session["usuario"] = null;
                    msg.Text = "Usted ya no esta subscripto! <a href=\"/Opciones\">Click aqui si desea renovar</a>";
                }
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            msg.Text = "Estamos en mantenimiento, intente mas tarde!";
        }        
        
    }
    private bool subscrito(Cliente cli)
    {
        DateTime fechafin = DateTime.ParseExact(cli.fecha_fin_servicio, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
        fechafin = fechafin.AddDays(1);
        if(fechafin.CompareTo(DateTime.Now) == 1)
        {
            bool resub = cli.plan > 0;
            cli.fecha_fin_servicio = fechafin.AddDays(31).ToString("o");
            Datos.updateCliente(cli);
            return resub;
        }
        else
        {
            return true;
        }
    }
}