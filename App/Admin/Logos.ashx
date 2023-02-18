<%@ WebHandler Language="C#" Class="Logos" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Interfaz;

public class Logos : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        int codcli = 0;
        try
        {
            codcli = int.Parse(context.Request.QueryString["id"]);
        }
        catch (Exception)
        {
        }
        byte[] img= null;        
        if(codcli != 0)
            img = Task.Run( () =>  Datos.imgLogo(codcli)).Result;
        context.Response.ContentType = "image/webp";
        if(img == null)
        {
            Bitmap blankImage = new Bitmap(100, 100);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                blankImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                img = memoryStream.ToArray();
            }
        }
        context.Response.OutputStream.Write(img,0,img.Length);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}