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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!(Session.Count > 0 && Session["usuario"] != null))
            Response.Redirect("/Login");
        else
        {
            usuario = (Usuario)Session["usuario"];
            titulo = (string)ViewState["titulo"];
        }
    }
}
