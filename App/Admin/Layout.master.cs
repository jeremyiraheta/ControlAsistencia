using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count > 0 && Session["user"] != null)
            ViewBag.Set("name", ((RESTAPI.Usuario)Session["user"]).nombres);
        else
            Response.Redirect("/Login");
    }
}
