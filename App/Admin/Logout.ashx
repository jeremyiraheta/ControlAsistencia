<%@ WebHandler Language="C#" Class="Logout" %>

using System;
using System.Web;
using Interfaz.modelos;

public class Logout : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        string urlname = null;
        try
        {            
            Cliente c = (Cliente)context.Session["cliente"];
            urlname = c.urlnom;
        }
        catch (Exception)
        {
        }
        context.Session.Clear();
        if (urlname == null)
            context.Response.Redirect("/Login");
        else
            context.Response.Redirect("/Login/" + urlname);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}