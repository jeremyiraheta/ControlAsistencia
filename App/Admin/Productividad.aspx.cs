using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;
using System.Text.RegularExpressions;

public partial class Productividad : System.Web.UI.Page
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
        var emps = Datos.listEmpleados(usuario.codcli, (cpage - 1) * 10);
        if(!IsPostBack || Session["filtrado"] == null)
        {
            filltable(emps);
            Session.Remove("filtrado");
        }
        else
        {
            List<Empleado> filtrado = (List<Empleado>)Session["filtrado"];
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
        var emps = Datos.filter<Empleado>("EMPLEADOS", String.Format("concat_ws(' ', NOMBRES, APELLIDOS, CORREO, NACIMIENTO, (SELECT NOMBRE FROM DEPARTAMENTOS d WHERE d.CODDPTO = EMPLEADOS.CODDPTO)) LIKE UPPER('%{0}%') and ACTIVO = 'true' and CODCLI = {1}", txtfilter.Text, usuario.codcli), "*");
        if (emps == null)
            emps = new List<Empleado>();
       Session["filtrado"] = emps;
       filltable(emps);
    }

    private int maxpages()
    {
        try
        {
            List<Datos.Counter> i = Datos.filter<Datos.Counter>("EMPLEADOS", "ACTIVO = 'true' and CODCLI = " + usuario.codcli, "COUNT(*) count");
            int numero = i[0].count;
            Session["count_emps"] = numero;
            return (int)Math.Ceiling(numero / 10.0);
        }
        catch (Exception)
        {
            return 10;
        }

    }

    private void filltable(List<Empleado> emps)
    {
        var dpts = Datos.listDepartamentos(usuario.codcli);
        var head = tblemp.Rows[0];
        tblemp.Rows.Clear();
        tblemp.Rows.Add(head);
        foreach (var item in emps)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = item.codemp.ToString() });
            row.Cells.Add(new TableCell() { Text = dpts.Where(v => v.coddpto == item.coddpto).First().nombre.ToUpper() });
            row.Cells.Add(new TableCell() { Text = item.nombres });
            row.Cells.Add(new TableCell() { Text = item.apellidos });
            row.Cells.Add(new TableCell() { Text = item.telefonos });
            TableCell process = new TableCell();
            Button btnp = new Button();
            btnp.Text = "Procesos";
            btnp.CssClass = "btn btn-success";
            btnp.CommandArgument = item.codemp.ToString();
            btnp.UseSubmitBehavior = true;
            btnp.ID = "EP" + btnp.CommandArgument;
            btnp.Command += new CommandEventHandler(viewProcCommand);
            process.Controls.Add(btnp);
            row.Cells.Add(process);
            TableCell nav = new TableCell();
            Button btnn = new Button();
            btnn.Text = "Navegacion";
            btnn.CssClass = "btn btn-success";
            btnn.CommandArgument = item.codemp.ToString();
            btnn.UseSubmitBehavior = true;
            btnn.ID = "EN" + btnn.CommandArgument;
            btnn.Command += new CommandEventHandler(viewNavCommand);
            nav.Controls.Add(btnn);
            row.Cells.Add(nav);
            TableCell capturas = new TableCell();
            Button btnc = new Button();
            btnc.Text = "Capturas";
            btnc.CssClass = "btn btn-success";
            btnc.CommandArgument = item.codemp.ToString();
            btnc.UseSubmitBehavior = true;
            btnc.ID = "EC" + btnc.CommandArgument;
            btnc.Command += new CommandEventHandler(viewSCCommand);
            capturas.Controls.Add(btnc);
            row.Cells.Add(capturas);
            tblemp.Rows.Add(row);
        }
    }

    protected void viewProcCommand(object sender, CommandEventArgs e)
    {
        this.id = Convert.ToInt32(e.CommandArgument);
        var o = Datos.getProductividad(this.id, usuario.codcli, filtdate.Text, filtdate.Text);
        title.Text = "Procesos registrados dia: " + filtdate.Text;
        if (o.Count == 0)
        {            
            popupContent.Text = "<p>El empleado no tiene registros este día</p>";
        }
        else
        {
            String body = @"<div class=""accordion"" id=""accordionView"">" + Environment.NewLine;
            foreach (var p in o)
            {
                if(p.procesos != null && p.procesos.Trim().Length > 0)
                    body += toggleBtn(p.codprod, p.fecha, Uri.UnescapeDataString(p.procesos), @"\w*:(.*?), \w*: (.*?), .*: (.*)", "Proceso", "Nombre", "Actividad") + Environment.NewLine;
            }
            popupContent.Text = body + "</div>" + Environment.NewLine;
        }
        modalsize = "modal-lg";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "vProd", "new bootstrap.Modal(document.getElementById('vProd'), { keyboard:false}).show()", true);
    }

    protected void viewNavCommand(object sender, CommandEventArgs e)
    {
        this.id = Convert.ToInt32(e.CommandArgument);
        var o = Datos.getProductividad(this.id, usuario.codcli, filtdate.Text, filtdate.Text);
        title.Text = "Navegación registrada día: " + filtdate.Text;
        if (o.Count == 0)
        {            
            popupContent.Text = "<p>El empleado no tiene registros este día</p>";
        }
        else
        {
            String body = @"<div class=""accordion"" id=""accordionView"">" + Environment.NewLine;
            foreach (var p in o)
            {
                if(p.histnav != null && p.histnav.Trim().Length > 0)
                    body += toggleBtn(p.codprod, p.fecha, Uri.UnescapeDataString(p.histnav), @"\w*:(.*?), \w*: (.*?), .*: .*?(\d{2}:\d{2}:\d{2})", "URL", "Titulo", "Hora") + Environment.NewLine;
            }
            popupContent.Text = body + "</div>" + Environment.NewLine;
        }
        modalsize = "modal-lg";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "vProd", "new bootstrap.Modal(document.getElementById('vProd'), { keyboard:false}).show()", true);
    }

    protected void viewSCCommand(object sender, CommandEventArgs e)
    {
        this.id = Convert.ToInt32(e.CommandArgument);
        var o = Datos.getProductividad(this.id, usuario.codcli, filtdate.Text, filtdate.Text);
        title.Text = "Capturas registradas día: " + filtdate.Text;
        if (o.Count == 0)
        {
            popupContent.Text = "<p>El empleado no tiene registros este día</p>";
        }
        else
        {            
            popupContent.Text = carousel(o);
        }
        modalsize = "modal-xl";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "vProd", "new bootstrap.Modal(document.getElementById('vProd'), { keyboard:false}).show()", true);
    }



    private String toggleBtn(int id, String btn, String text, String pattern,params String[] columns )
    {
        Regex reg = new Regex(pattern);
        String[] r = text.Split(new String[] { "*" }, StringSplitOptions.RemoveEmptyEntries);
        String rows = "";
        String cols = "";
        foreach (var cl in columns)
        {
            cols += "<th>" + cl + "</th>";
        }
        foreach (var ln in r)
        {
            var match = reg.Match(ln);
            rows += "<tr>";
            for (int i = 1; i < match.Groups.Count; i++)
            {
                rows += "<td>" + match.Groups[i] + "</td>";
            }            
            rows += "</tr>";
        }                                              
        String table = String.Format("<table class=\"table\"><thead><tr>{0}</tr></thead><tbody>{1}</tbody></table>", cols, rows);
        String ret = @"
  <div class=""accordion-item"">
    <h2 class=""accordion-header"" id=""heading{0}"">
      <button class=""accordion-button collapsed"" type=""button"" data-bs-toggle=""collapse"" data-bs-target=""#collapse{0}"" aria-expanded=""true"" aria-controls=""collapse{0}"">
        {1}
      </button>
    </h2>
    <div id = ""collapse{0}"" class=""accordion-collapse collapse"" aria-labelledby=""heading{0}"" data-bs-parent=""#accordionView"">
      <div class=""accordion-body"" style=""overflow: auto;"">
        {2}
      </div>
    </div>
  </div>";
        if (r.Length == 0)
            return "<p>El empleado no tiene registros este día</p>";
        else
            return String.Format(ret, id,FormatDateTime(btn), table);
    }

    private String carousel(List<Interfaz.modelos.Productividad> prodlist)
    {
        int active = 0;
        String btns = "";
        String imgs = "";
        int c = 1;
        foreach (var b in prodlist)
        {
            if (active == 0 && b.attch)
            {
                active = b.codprod;
                continue;
            }
            if (!b.attch) continue;
            btns += String.Format(@"<button type = ""button"" data-bs-target=""#carouselCapturas"" data-bs-slide-to=""{0}"" aria-label=""Slide {1}""></button>" + Environment.NewLine, c, c+1);
            imgs += String.Format(@"<div class=""carousel-item"">
      <img src = ""/Captura.ashx?id={0}"" class=""d-block w-100"" alt=""..."">
    </div>" + Environment.NewLine, b.codprod);
            c++;
        }
        String ret = @"<div id=""carouselCapturas"" class=""carousel slide"">
  <div class=""carousel-indicators"">
    <button type = ""button"" data-bs-target=""#carouselCapturas"" data-bs-slide-to=""0"" class=""active"" aria-current=""true"" aria-label=""Slide 1""></button>
    {0}
  </div>
  <div class=""carousel-inner"">
    <div class=""carousel-item active"">
      <img src = ""/Captura.ashx?id={1}"" class=""d-block w-100"" alt=""..."">
    </div>
    {2}
  </div>
  <button class=""carousel-control-prev"" type=""button"" data-bs-target=""#carouselCapturas"" data-bs-slide=""prev"">
    <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
    <span class=""visually-hidden"">Previo</span>
  </button>
  <button class=""carousel-control-next"" type=""button"" data-bs-target=""#carouselCapturas"" data-bs-slide=""next"">
    <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
    <span class=""visually-hidden"">Siguiente</span>
  </button>
</div>";
        if (active == 0)
            return "<p>El empleado no tiene registros este día</p>";
        else
            return String.Format(ret,btns, active, imgs);
    }

    private string FormatDateTime(string dateTimeString)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
        return dateTime.ToString("HH:mm");
    }
}