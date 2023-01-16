<%@ WebHandler Language="C#" Class="ajaxDepartamentos" %>

using System;
using System.Web;
using System.Linq;
using Interfaz;

public class ajaxDepartamentos : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        var action = context.Request.QueryString["action"];
        if (action == null) context.Response.Redirect("../Departamentos.aspx");
        string id = context.Request.QueryString["coddpto"];
        string id2 = context.Request.QueryString["codcli"];
        var resp = "";
        switch(action.ToLower())
        {
            case "delete":
                try
                {
                    Datos.deleteDepartamento(Convert.ToInt32(id), Convert.ToInt32(id2));
                }
                catch (Exception)
                {
                }
                context.Response.Redirect("../Departamentos.aspx");
                break;
            case "select":
                try
                {
                    int coddpto = Convert.ToInt32(id);
                    var emp = Datos.listEmpleados( Convert.ToInt32(id2));
                    foreach (var item in emp.Where(v => v.coddpto == coddpto))
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