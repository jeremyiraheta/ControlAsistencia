using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Departamentos : System.Web.UI.Page
{
    Usuario usuario; 
    protected void Page_Load(object sender, EventArgs e)
    {
        bool noplan = Session["noplan"] != null;
        if (noplan) Response.Redirect("/Opciones");
        string tabdp = @"<li class='nav-item'>
                              <span style='display:flex;'><a class='nav-link {1}' href=# onclick='selectDpto({2},this)'>{0}</a><a href=/Ajax/ajaxDepartamentos.ashx?action=delete&coddpto={2} class='btn-close btn-close-white' style='{3}' aria-label='Close'></a></span>
                          </li>";
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        var dpts = Datos.listDepartamentos(usuario.codcli);
        var emp = Datos.listEmpleadosDpto(usuario.codcli,dpts.First().coddpto);
        ltabs.Text = String.Format(tabdp, dpts.First().nombre.ToUpper(), "active", dpts.First().coddpto, "display:none;");
        tbldpto.Text = "";        
        foreach (var itm in emp.Where(v => v.coddpto == dpts.First().coddpto))
            tbldpto.Text += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><tr>\n", itm.codemp, itm.nombres, itm.apellidos);
        dpts.RemoveAt(0);
        foreach (var item in dpts)
        {
            var temp = Datos.filter<Datos.Counter>("EMPLEADOS", string.Format("codcli = {0} and coddpto = {1}", item.codcli, item.coddpto), "COUNT(*) count");            
            ltabs.Text += string.Format(tabdp, item.nombre.ToUpper(), "", item.coddpto, (temp[0].count > 0) ? "display:none;" : "");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtdpto.Text.Trim() != "")
            Datos.insertDepartamento(usuario.codcli, txtdpto.Text);
        txtdpto.Text = "";
        Page_Load(null, null);
    }
}