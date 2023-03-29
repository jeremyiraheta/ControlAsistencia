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
    public String mediaPermisos;
    public String mediaPColors;
    public String nombres="";
    public String valores="";
    public String colors = "";
    public bool isclientes = false;
    public String planes;
    public String planesColors;
    public String ganacias;
    public String ganaciasColors;
    protected void Page_Load(object sender, EventArgs e)
    {
        bool noplan = Session["noplan"] != null;
        if (noplan) Response.Redirect("/Opciones");
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        isclientes = usuario.codcli == 1;
        if (isclientes)
        {
            planes = countPlanes();
            planesColors = arregloColores(4);
            ganacias = ganaciasPlanes(formatToList(planes));
            ganaciasColors = arregloColores(3);
        }
        else
        {
            mediaSemana = calcularMediaSemana();
            mediaSColors = arregloColores(7);
            mediaMes = calcularMediaMes();
            mediaMColors = arregloColores(12);
            mediaPermisos = calcularPermisosMes();
            mediaPColors = arregloColores(12);
            String[,] memps = empleadosMenosHoras();
            if (memps != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    nombres += "\"" + memps[i, 0] + "\",";
                    valores += memps[i, 1] + ",";
                }
                nombres = nombres.Substring(0, nombres.Length - 1);
                valores = valores.Substring(0, valores.Length - 1);
            }
            colors = arregloColores(5);
        }
        
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
        if (registros == null || registros.Count == 0) return "";
        decimal avgLunes;
        try
        {
            avgLunes = registros.Where(x => FormatDateTime(x.fecha).Date == lunes).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgLunes = 0;           
        }
        decimal avgMartes;
        try
        {
            avgMartes = registros.Where(x => FormatDateTime(x.fecha).Date == martes).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgMartes = 0;
        }
        decimal avgMiercoles;
        try
        {
            avgMiercoles = registros.Where(x => FormatDateTime(x.fecha).Date == miercoles).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgMiercoles = 0;
        }
        decimal avgJueves;
        try
        {
            avgJueves = registros.Where(x => FormatDateTime(x.fecha).Date == jueves).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgJueves = 0;
        }
        decimal avgViernes;
        try
        {
            avgViernes = registros.Where(x => FormatDateTime(x.fecha).Date == viernes).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgViernes = 0;
        }
        decimal avgSabado;
        try
        {
            avgSabado = registros.Where(x => FormatDateTime(x.fecha).Date == sabado).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgSabado = 0;
        }
        decimal avgDomingo;
        try
        {
            avgDomingo = registros.Where(x => FormatDateTime(x.fecha).Date == domingo).ToList().Average(a => a.total);
        }
        catch (Exception)
        {
            avgDomingo = 0;
        }        
        return String.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00}", ConvertMinutesToHours(avgLunes), ConvertMinutesToHours(avgMartes), ConvertMinutesToHours(avgMiercoles), ConvertMinutesToHours(avgJueves), ConvertMinutesToHours(avgViernes), ConvertMinutesToHours(avgSabado), ConvertMinutesToHours(avgDomingo));
    }

    private string calcularMediaMes()
    {
        decimal[] mes = new decimal[12];
        for (int i = 1; i < 13; i++)
        {
            var rmes = Datos.listRegistrosMes(usuario.codcli, i, DateTime.Now.Year);
            if (rmes == null || rmes.Count == 0) continue;
            mes[i - 1] = ConvertMinutesToHours(rmes.Average(a => a.total));
        }                
        return String.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8:0.00},{9:0.00},{10:0.00},{11:0.00}", mes[0], mes[1], mes[2], mes[3], mes[4], mes[5], mes[6], mes[7], mes[8], mes[9], mes[10], mes[11]);
    }

    private String calcularPermisosMes()
    {
        decimal[] mes = new decimal[12];
        for (int i = 1; i < 13; i++)
        {
            var rmes = Datos.listPermisos(usuario.codcli, i, DateTime.Now.Year);
            if (rmes == null || rmes.Count == 0) continue;
            mes[i - 1] = rmes.Count();
        }
        return String.Format("{0:0.00},{1:0.00},{2:0.00},{3:0.00},{4:0.00},{5:0.00},{6:0.00},{7:0.00},{8:0.00},{9:0.00},{10:0.00},{11:0.00}", mes[0], mes[1], mes[2], mes[3], mes[4], mes[5], mes[6], mes[7], mes[8], mes[9], mes[10], mes[11]);
    }

    private string[,] empleadosMenosHoras()
    {
        string[,] ret = new string[5,2];
        var reg = Datos.listRegistrosMes(usuario.codcli, DateTime.Now.Month, DateTime.Now.Year);
        if (reg == null || reg.Count == 0) return null;
        var grp = reg.GroupBy(y => y.codemp);
        Dictionary<int, decimal> empxtotal = new Dictionary<int, decimal>();
        foreach (var m in grp)
        {
            empxtotal.Add(m.Key, 0);
            foreach (var n in m)
                empxtotal[m.Key] += n.total;
        }
        var ord = empxtotal.OrderBy(t => t.Value);
        for (int j = 0; j < 5; j++)
        {
            if (j >= ord.Count()) break;
            var e = Datos.getEmpleado(ord.ElementAt(j).Key, reg[j].codcli);
            ret[j, 0] = e.nombres + " " + e.apellidos;
            ret[j, 1] = String.Format("{0:0.00}", ConvertMinutesToHours( ord.ElementAt(j).Value ));
        }
        return ret;
    }

    private String countPlanes()
    {        
        var plan0 = Datos.filter<Datos.Counter>("CLIENTES", "plan=0", "count(*) count");
        var plan1 = Datos.filter<Datos.Counter>("CLIENTES", "plan=1", "count(*) count");
        var plan2 = Datos.filter<Datos.Counter>("CLIENTES", "plan=2", "count(*) count");
        var plan3 = Datos.filter<Datos.Counter>("CLIENTES", "plan=3", "count(*) count");

        return String.Format("{0},{1},{2},{3}",plan0 != null ? plan0[0].count : 0, plan1 != null ? plan1[0].count : 0, plan2 != null ? plan2[0].count : 0, plan3 != null ? plan3[0].count : 0);
    }

    private String ganaciasPlanes(List<int> count)
    {
        return String.Format("{0:0.00},{1:0.00},{2:0.00}", count[1] * float.Parse(GlobalV.PLAN[0, 1]), count[2] * float.Parse(GlobalV.PLAN[1, 1]), count[3] * float.Parse(GlobalV.PLAN[2, 1]));
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

    private List<int> formatToList(String from)
    {
        List<int> ret = new List<int>();
        String[] sp = from.Split(new char[] { ',' });
        foreach (var item in sp)
        {
            try
            {
                ret.Add(int.Parse(item.Trim()));
            }
            catch (Exception)
            {
            }
        }
        return ret;
    }
}