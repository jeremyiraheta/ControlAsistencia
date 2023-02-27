<%@ WebHandler Language="C#" Class="Reporte" %>

using System;
using System.Web;
using System.Threading.Tasks;
using Interfaz;
using Interfaz.modelos;

public class Reporte : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        int m = 0;
        int y = 0;
        int t = 0;
        byte[] bytes;
        try
        {
            Cliente c = (Cliente)context.Session["cliente"];
            codcli = c.codcli;
            m = int.Parse(context.Session["m"].ToString());
            y = int.Parse(context.Session["y"].ToString());
            t = int.Parse(context.Session["t"].ToString());
            if (t == 0)
                bytes = Task.Run(() => Datos.reporteHoras(codcli,m,y)).Result;
            else
                bytes = Task.Run(() => Datos.reportePermisos(codcli, m, y)).Result;
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
        context.Response.AddHeader("Content-Disposition", "inline; name=\"ReporteHoras\"; filename=\"ReporteHoras.pdf\"");
        context.Response.BinaryWrite(bytes);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}