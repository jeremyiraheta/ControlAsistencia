<%@ WebHandler Language="C#" Class="Logout" %>

using System;
using System.Web;

public class Logout : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {
    
    public void ProcessRequest (HttpContext context) {
        context.Session.Clear();
        context.Response.Redirect("/Login");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}