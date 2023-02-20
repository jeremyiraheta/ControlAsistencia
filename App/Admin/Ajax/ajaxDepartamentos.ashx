<%@ WebHandler Language="C#" Class="ajaxDepartamentos" %>

using System;
using System.Web;
using System.Linq;
using Interfaz;
using Interfaz.modelos;

public class ajaxDepartamentos : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        Cliente cliente = (Cliente)context.Session["cliente"];
        var action = context.Request.QueryString["action"];
        if (action == null) context.Response.Redirect("../Departamentos.aspx");
        int id = int.Parse(context.Request.QueryString["coddpto"]);
        int cli = cliente.codcli;        
        var resp = "";
        switch(action.ToLower())
        {
            case "delete":
                try
                {
                    Datos.deleteDepartamento(id, cli);
                }
                catch (Exception)
                {
                }
                context.Response.Redirect("../Departamentos.aspx");
                break;
            case "select":
                try
                {                    
                    var emp = Datos.listEmpleados( cli);
                    foreach (var item in emp.Where(v => v.coddpto == id))
                        resp += String.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>", item.codemp,item.nombres,item.apellidos);
                }
                catch (Exception)
                {
                }
                break;
        }
        context.Response.ContentType = "text/html";
        context.Response.Write(resp);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}