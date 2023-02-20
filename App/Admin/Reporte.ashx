<%@ WebHandler Language="C#" Class="Reporte" %>

using System;
using System.Web;
using Interfaz;

public class Reporte : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        int m = 0;
        int y = 0;
        int t = 0;
        byte[] bytes;
        try
        {
            codcli = int.Parse(context.Request.Params["id"]);
            m = int.Parse(context.Request.Params["m"]);
            y = int.Parse(context.Request.Params["y"]);
            t = int.Parse(context.Request.Params["t"]);
            if (t == 0)
                bytes = Datos.reporteHoras(codcli, m, y).Result;
            else
                bytes = Datos.reportePermisos(codcli, m, y).Result;
            if (bytes == null || bytes.Length == 0)
                throw new Exception("Api devolvio vacio");
        }
        catch (Exception)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("No se pudo consultar el reporte, intente mas tarde");
            return;
        }
        context.Response.ContentType = "application/pdf";
        context.Response.Write(bytes);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}