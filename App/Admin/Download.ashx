<%@ WebHandler Language="C#" Class="Download" %>

using System;
using System.Web;
using System.Threading.Tasks;
using Interfaz;
using Interfaz.modelos;

public class Download : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        int codper = 0;
        byte[] data = null;
        try
        {
            Cliente c = (Cliente)context.Session["cliente"];
            codcli = c.codcli;
            Permiso p = (Permiso)context.Session["permiso"];
            codper = p.codper;            
            data = Task.Run(() =>  Datos.downloadPermisoAdjunto(codper, codcli)).Result;
        }
        catch (Exception)
        {
        }
        if(data == null)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("No se pudo descargar, intente mas tarde!");
        }else
        {
            context.Response.ContentType = "application/zip";
            context.Response.AddHeader("Content-Disposition", "filename=\"Permiso_" + codper + ".zip\"");
            context.Response.BinaryWrite(data);
        }

    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}