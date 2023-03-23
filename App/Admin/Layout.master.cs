using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz.modelos;

public partial class Layout : System.Web.UI.MasterPage
{
    public string titulo;
    public Usuario usuario;
    public string msg;
    public string title;
    public string icon;    
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!(Session.Count > 0 && Session["usuario"] != null))
            Response.Redirect("/Login");
        else
        {
            usuario = (Usuario)Session["usuario"];            
        }        
    }
    /// <summary>
    /// Muestra una alerta dinamica
    /// </summary>
    /// <param name="title">titulo</param>
    /// <param name="msg">mensaje</param>
    /// <param name="level">nivel 0=informacion, 1=alerta, 2=error</param>
    /// <param name="scripter">instancia de scripter</param>
    public void toast(string title, string msg, int level,ClientScriptManager scripter)
    {
        this.msg = msg;
        this.title = title;
        switch (level)
        {
            case 0:
                icon = "info.svg";                
                break;
            case 1:
                icon = "warning.svg";                
                break;
            case 2:
                icon = "error.svg";                
                break;
            default:
                icon = "info.svg";                
                break;
        }
        string script = "window.onload = function() { $('.toast').toast('show') }";
        scripter.RegisterStartupScript(this.GetType(), "Toast", script, true);        
    }
}
