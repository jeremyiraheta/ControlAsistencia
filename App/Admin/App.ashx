<%@ WebHandler Language="C#" Class="App" %>

using System;
using System.Web;
using System.Threading.Tasks;
using Interfaz;

public class App : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "*/*";
        context.Response.AddHeader("Content-Disposition", "inline; filename=\"setup.exe\"");
        var bytes = Task.Run(() => Datos.downloadInstalador()).Result;
        context.Response.BinaryWrite(bytes);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}