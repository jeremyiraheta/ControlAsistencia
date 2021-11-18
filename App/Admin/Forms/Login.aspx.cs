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
            Session["user"] = emp;
            Response.Redirect("..");
        }
        else
        {
            msg.Text = "Usuario o password incorrecto!";
        }
    }
}