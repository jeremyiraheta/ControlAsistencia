using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string user = txtuser.Text;
        string pass = txtpass.Text;
        RESTAPI.Usuario emp = RESTAPI.Login(user, pass);
        if (emp != null)
        {            
            fillTable();
            response.Text += "Logeado codigo empleado: " + emp.codemp + ", departamento: " + emp.departamento;
            Session["logged"] = true;
        }
        else
        {
            response.Text = "Usuario no valido";
            Session.Clear();
        }
    }

    private void fillTable()
    {
        
        response.Text = "\n<div><table border=1><tr><th>id</th><th>nombre</th></tr>";
        List<Departamentos> departamentos = RESTAPI.listDepartamentos();
        foreach (var d in departamentos)
        {
            response.Text += string.Format("\n<tr><td>{0}</td><td>{1}</td></tr>", d.coddpto, d.nombre);
        }
        response.Text += "\n</table></div>";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if(txtnombre.Text != "")
        {            
            RESTAPI.insertDepartamento(txtnombre.Text);
            fillTable();
        }
    }
}