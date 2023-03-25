using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;
using System.Drawing;

public partial class Admin : System.Web.UI.Page
{
    Usuario usuario;
    public String mediaSemana;
    public String mediaSColors;
    public String mediaMes;
    public String mediaMColors;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool noplan = Session["noplan"] != null;
        if (noplan) Response.Redirect("/Opciones");
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");

        mediaSemana = calcularMediaSemana();
        mediaSColors = arregloColores(7);
        mediaMes = calcularMediaMes();
        mediaMColors = arregloColores(12);
    }

    private string calcularMediaSemana()
    {        
        DateTime lunes = inicioSemana();
        DateTime martes = lunes.AddDays(1);
        DateTime miercoles = martes.AddDays(1);
        DateTime jueves = miercoles.AddDays(1);
        DateTime viernes = jueves.AddDays(1);
        DateTime sabado = viernes.AddDays(1);
        DateTime domingo = sabado.AddDays(1);
        var registros = Datos.listRegistrosMes(usuario.codcli, lunes.Month, lunes.Year);
        var avgLunes = registros.Where(x => FormatDateTime(x.fecha).Date == lunes).ToList().Average(a => a.total);
        var avgMartes = registros.Where(x => FormatDateTime(x.fecha).Date == martes).ToList().Average(a => a.total);
        var avgMiercoles = registros.Where(x => FormatDateTime(x.fecha).Date == miercoles).ToList().Average(a => a.total);
        var avgJueves = registros.Where(x => FormatDateTime(x.fecha).Date == jueves).ToList().Average(a => a.total);
        var avgViernes = registros.Where(x => FormatDateTime(x.fecha).Date == viernes).ToList().Average(a => a.total);
        var avgSabado = registros.Where(x => FormatDateTime(x.fecha).Date == sabado).ToList().Average(a => a.total);
        var avgDomingo = registros.Where(x => FormatDateTime(x.fecha).Date == domingo).ToList().Average(a => a.total);        
        return String.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00}", ConvertMinutesToHours(avgLunes), ConvertMinutesToHours(avgMartes), ConvertMinutesToHours(avgMiercoles), ConvertMinutesToHours(avgJueves), ConvertMinutesToHours(avgViernes), ConvertMinutesToHours(avgSabado), ConvertMinutesToHours(avgDomingo));
    }

    private string calcularMediaMes()
    {
        decimal[] mes = new decimal[12];
        for (int i = 1; i < 13; i++)
        {
            var rmes = Datos.listRegistrosMes(usuario.codcli, i, DateTime.Now.Year);
            mes[i - 1] = ConvertMinutesToHours(rmes.Average(a => a.total));
        }                
        return String.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8:0.00},{9:0.00},{10:0.00},{11:0.00}", mes[0], mes[1], mes[2], mes[3], mes[4], mes[5], mes[6], mes[7], mes[8], mes[9], mes[10], mes[11]);
    }

    private string GetRandomHexColor()
    {
        Random random = new Random(DateTime.Now.Millisecond);
        Color color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }

    private string arregloColores(int n)
    {
        String ret = "";
        for (int i = 0; i < n; i++)
        {
            ret += "\"" + GetRandomHexColor() + "\",";
            System.Threading.Thread.Sleep(10);
        }
        return ret.Substring(0, ret.Length - 1);
    }

    private DateTime inicioSemana()
    {
        DateTime today = DateTime.Today;
        int daysUntilMonday = ((int)today.DayOfWeek - 1 + 7) % 7;
        DateTime monday = today.AddDays(-daysUntilMonday);
        return monday;
    }
    private DateTime FormatDateTime(string dateTimeString)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy", null);
        return dateTime;
    }

    public static decimal ConvertMinutesToHours(decimal minutes)
    {
        decimal hours = minutes / 60;
        return hours;
    }
}