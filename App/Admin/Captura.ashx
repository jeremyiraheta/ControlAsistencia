<%@ WebHandler Language="C#" Class="Captura" %>

using System;
using System.Web;
using Interfaz;
using Interfaz.modelos;
using System.Threading.Tasks;
using System.IO;

public class Captura : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        int codprod = 0;
        try
        {
            Cliente c = (Cliente)context.Session["cliente"];
            codcli = c.codcli;
            codprod = int.Parse(context.Request.Params["id"]);
            if (codcli == 0 || codprod == 0) throw new Exception();
        }
        catch (Exception)
        {
            context.Response.BinaryWrite(null);
            return;
        }

        byte[] img= null;
        img = Task.Run(() => Datos.imgCaptura(codprod, codcli)).Result;            
        context.Response.ContentType = "image/webp";        
        context.Response.OutputStream.Write(img,0,img.Length);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}