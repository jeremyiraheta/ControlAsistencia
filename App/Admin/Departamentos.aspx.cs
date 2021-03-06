using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Departamentos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewBag.Set("title", "Sistema Administrativo Control Asistencia Remota - Departamentos - DIGESTYC");
        string tabdp = @"<li class='nav-item'>
                              <span style='display:flex;'><a class='nav-link {1}' href=# onclick='selectDpto({2},this)'>{0}</a><a href=/Ajax/ajaxDepartamentos.ashx?action=delete&id={2} class='btn-close btn-close-white' style='{3}' aria-label='Close'></a></span>
                          </li>";                
        var dpts = RESTAPI.listDepartamentos();
        var emp = RESTAPI.listEmpleados();
        ltabs.Text = String.Format(tabdp, dpts.First().nombre.ToUpper(), "active", dpts.First().coddpto,emp.Where(v => v.coddpto == dpts.First().coddpto).Count() > 0  ? "display:none;" : "");
        tbldpto.Text = "";        
        foreach (var itm in emp.Where(v => v.coddpto == dpts.First().coddpto))
            tbldpto.Text += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><tr>\n", itm.codemp, itm.nombres, itm.apellidos);
        dpts.RemoveAt(0);
        foreach (var item in dpts)
            ltabs.Text += String.Format(tabdp, item.nombre.ToUpper(), "", item.coddpto, emp.Where(v => v.coddpto == item.coddpto).Count() > 0 ? "display:none;" : "" );
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtdpto.Text.Trim() != "")
            RESTAPI.insertDepartamento(txtdpto.Text);
        txtdpto.Text = "";
        Page_Load(null, null);
    }
}