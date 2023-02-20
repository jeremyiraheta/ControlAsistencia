<%@ WebHandler Language="C#" Class="Logos" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Interfaz;
using Interfaz.modelos;

public class Logos : IHttpHandler, System.Web.SessionState.IReadOnlySessionState {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        try
        {
            Cliente c = (Cliente)context.Session["cliente"];
            codcli = c.codcli;
        }
        catch (Exception)
        {
        }
        if (codcli == 0 && context.Request.Params["id"] != null)
            codcli = int.Parse(context.Request.Params["id"]);
        byte[] img= null;
        if(codcli != 0)
            img = Task.Run( () =>  Datos.imgLogo(codcli)).Result;
        context.Response.ContentType = "image/webp";
        if(img == null || img.Length == 0)
        {
            FileStream logo = File.OpenRead(context.Request.PhysicalApplicationPath + "/images/logo.png");
            img = new byte[logo.Length];
            logo.Read(img, 0, img.Length);
        }
        context.Response.OutputStream.Write(img,0,img.Length);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}