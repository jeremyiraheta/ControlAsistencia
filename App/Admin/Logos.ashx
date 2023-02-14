<%@ WebHandler Language="C#" Class="Logos" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using Interfaz;
using Interfaz.modelos;

public class Logos : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        Cliente cliente=null;
        try
        {
            cliente = (Cliente)context.Session["cliente"];
        }
        catch (Exception)
        {
        }
        byte[] img;
        if(cliente == null || !cliente.attch)
        {
            Bitmap blankImage = new Bitmap(100, 100);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                blankImage.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                img = memoryStream.ToArray();
            }
        }else
        {
            img = Task.Run( () =>  Datos.imgLogo(cliente.codcli)).Result;
        }
        context.Response.ContentType = "image/webp";
        context.Response.OutputStream.Write(img,0,img.Length);
    }

    public bool IsReusable {
        get {
            return false;
        }
    }

}