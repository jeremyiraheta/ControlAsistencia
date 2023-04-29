using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;
using System.Text.RegularExpressions;

public partial class Ubicaciones : System.Web.UI.Page
{
    Usuario usuario;
    public int minp = 1;
    public int maxp = 10;
    public int cpage = 1;
    public int id = 0;
    public string modalsize;    

    protected void Page_Load(object sender, EventArgs e)
    {
        bool noplan = Session["noplan"] != null;
        if (noplan) Response.Redirect("/Opciones");
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        int tmax = maxpages() + 1;
        minp = 1;
        if (tmax > 9)
            maxp = 9;
        else
            maxp = tmax;
        if (Page.RouteData.Values.ContainsKey("page"))
        {
            cpage = int.Parse(Page.RouteData.Values["page"].ToString());
            if (cpage > 9)
            {
                minp = 10 * Convert.ToInt32(cpage / 10);
                maxp = minp + 10;
                if (maxp > tmax)
                    maxp = tmax;
            }
        }
        var ubi = Datos.listUbicaciones(usuario.codcli, (cpage - 1) * 10);
        if(!IsPostBack || Session["filtrado"] == null)
        {
            filltable(ubi);
            Session.Remove("filtrado");
        }
        else
        {
            List<Ubicacion> filtrado = (List<Ubicacion>)Session["filtrado"];
            filltable(filtrado);
        }       
        if (!IsPostBack)
        {
            Cliente cli = Datos.getCliente(usuario.codcli);
            DateTime RNow = DateTime.Now.AddHours(cli.zonahoraria);
            filtdate.Text = String.Format("{2}-{1:00}-{0:00}", RNow.Day, RNow.Month, RNow.Year);
        }
    }

    protected void filtrar(object sender, ImageClickEventArgs e)
    {
        if (txtfilter.Text.Trim() == "") return;
        var ubi = Datos.filter<Ubicacion>("EMPLEADOS", String.Format("concat_ws(' ', NOMBRES, APELLIDOS, CORREO, NACIMIENTO, (SELECT NOMBRE FROM DEPARTAMENTOS d WHERE d.CODDPTO = EMPLEADOS.CODDPTO)) LIKE UPPER('%{0}%') and ACTIVO = 'true' and CODCLI = {1}", txtfilter.Text, usuario.codcli), "*");
        if (ubi == null)
            ubi = new List<Ubicacion>();
       Session["filtrado"] = ubi;
       filltable(ubi);
    }

    private int maxpages()
    {
        try
        {
            List<Datos.Counter> i = Datos.filter<Datos.Counter>("UBICACIONES", "CODCLI = " + usuario.codcli, "COUNT(*) count");
            int numero = i[0].count;
            Session["count_emps"] = numero;
            return (int)Math.Ceiling(numero / 10.0);
        }
        catch (Exception)
        {
            return 10;
        }

    }

    private void filltable(List<Ubicacion> ubi)
    {
        var emps = Datos.listEmpleados(usuario.codcli);
        var head = tblemp.Rows[0];
        tblemp.Rows.Clear();
        tblemp.Rows.Add(head);
        foreach (var item in ubi)
        {
           /* var latini = item.latinicial;
            var longini = item.longinicial;
            var latfin = item.latfinal;
            var longfin = item.longfinal;
            var dirini = item.direccioninicial;
            var dirfin = item.direccionfinal;
            var fecha = item.nacimientoformat;*/

            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = item.codemp.ToString() });
            row.Cells.Add(new TableCell() { Text = emps.Where(v => v.codemp == item.codemp).First().nombres + " " + emps.Where(v => v.codemp == item.codemp).First().apellidos.ToUpper() });
            row.Cells.Add(new TableCell() { Text = item.nacimientoformat });
            row.Cells.Add(new TableCell() { Text = item.direccioninicial});
            row.Cells.Add(new TableCell() { Text = item.direccionfinal });
            

            //Boton inicial
            TableCell nav = new TableCell();
          var btn = new Button();
            btn.Text = "Inicio";         
            btn.CommandArgument = item.codemp.ToString() + "," + item.fecha.ToString() + "," + item.latinicial.ToString() + "," + item.longinicial.ToString() + "," + item.latfinal.ToString() + "," + item.longfinal.ToString() + "," + item.direccioninicial + "," + item.direccionfinal;
            btn.CssClass = "btn btn-success";
            btn.Command += abrirpag;
            TableCell ed = new TableCell();
            ed.Controls.Add(btn);
            row.Cells.Add(ed);
            tblemp.Rows.Add(row);

            //Boton final
            TableCell fin = new TableCell();
            var btnFin = new Button();
            btnFin.Text = "Final";            
            btnFin.CommandArgument = item.codemp.ToString() + ","  +item.fecha.ToString() + ","+item.latinicial.ToString() + "," + item.longinicial.ToString() + "," + item.latfinal.ToString() + "," + item.longfinal.ToString() + "," + item.direccioninicial + "," + item.direccionfinal;

            btnFin.CssClass = "btn btn-danger";
            btnFin.Command += direFinal;
            TableCell fn = new TableCell();
            fn.Controls.Add(btnFin);
            row.Cells.Add(fn);
            tblemp.Rows.Add(row);

        }
    }

    protected void abrirpag(object sender, CommandEventArgs e)
    {
        //string url = "Maps.aspx";
        string[] ubicacionInfo = e.CommandArgument.ToString().Split(',');
        Ubicacion ubi = new Ubicacion();
        ubi.codemp = int.Parse(ubicacionInfo[0]);
        ubi.fecha = ubicacionInfo[1];
        ubi.latinicial = double.Parse(ubicacionInfo[2]);
        ubi.longinicial = double.Parse(ubicacionInfo[3]);
        ubi.latfinal = double.Parse(ubicacionInfo[4]);
        ubi.longfinal = double.Parse(ubicacionInfo[5]);
        ubi.direccioninicial = ubicacionInfo[6];
        ubi.direccionfinal = ubicacionInfo[7];
        string direccion = ubi.direccioninicial;
        int codigo = ubi.codemp;
        double lati = ubi.latinicial;
        double longi = ubi.longinicial;
        string fecha = ubi.fecha;
        string iniofin = "inicial";

        //string script = "window.open('" + url + "', '_blank');";
        // Response.Redirect("Maps.aspx?lati=" + lati+ "&longi=" + longi + "&latfin="+latfin);
        string url = "Maps.aspx?lati=" + lati + "&longi=" + longi + "&direccion=" + direccion + "&iniofin=" + iniofin + "&fecha=" + fecha;
        string script = "window.open('" + url + "', '_blank');";
        ClientScript.RegisterStartupScript(this.GetType(), "openWindow", script, true);




    }

    protected void direFinal(object sender, CommandEventArgs e)
    {
        //string url = "Maps.aspx";
        string[] ubicacionInfo = e.CommandArgument.ToString().Split(',');
        Ubicacion ubi = new Ubicacion();
        ubi.codemp = int.Parse(ubicacionInfo[0]);
        ubi.fecha = ubicacionInfo[1];
        ubi.latinicial = double.Parse(ubicacionInfo[2]);
        ubi.longinicial = double.Parse(ubicacionInfo[3]);
        ubi.latfinal = double.Parse(ubicacionInfo[4]);
        ubi.longfinal = double.Parse(ubicacionInfo[5]);
        ubi.direccioninicial = ubicacionInfo[6];
        ubi.direccionfinal = ubicacionInfo[7];
        string direccion = ubi.direccionfinal;
        int codigo = ubi.codemp;
        double latini = ubi.latfinal;
        double longini = ubi.longfinal;
        double lati = ubi.latfinal;
        double longi = ubi.longfinal;
        string fecha = ubi.fecha;
        string iniofin = "final";

        //string script = "window.open('" + url + "', '_blank');";
        //Response.Redirect("Maps.aspx?lati=" + lati + "&longi=" + longi + "&codigo=" + codigo);
        string url = "Maps.aspx?lati=" + lati + "&longi=" + longi + "&direccion=" + direccion + "&iniofin=" + iniofin + "&fecha=" + fecha;
        string script = "window.open('" + url + "', '_blank');";
        ClientScript.RegisterStartupScript(this.GetType(), "openWindow", script, true);


    }
    
}