using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Registros : System.Web.UI.Page
{
    Usuario usuario;
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {
            txtfilter.Text = String.Format("{0}-{1:00}", DateTime.Today.Year, DateTime.Today.Month);
            Session["m"] = DateTime.Today.Month;
            Session["y"] = DateTime.Today.Year;
            Session["t"] = 0;
        }
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        fillTable();        
    }

    public void fillTable()
    {
        var period = txtfilter.Text;
        int month = Convert.ToInt32(period.Substring(period.IndexOf("-") + 1));
        int year = Convert.ToInt32(period.Substring(0, period.IndexOf("-")));
        var regxmes = Datos.listRegistrosMes(usuario.codcli,month, year);
        Dictionary<int, Reg> horas = new Dictionary<int, Reg>();
        var empleados = Datos.listEmpleados(usuario.codcli);
        var departamentos = Datos.listDepartamentos(usuario.codcli);
        foreach (var item in regxmes)
        {
            var emp = empleados.Where(e => e.codemp == item.codemp).First();
            var dpto = departamentos.Where(d => d.coddpto == emp.coddpto).First();                                             
            if (!horas.Keys.Contains(item.codemp))
                horas.Add(emp.codemp, new Reg() { codemp = emp.codemp, departamento = dpto.nombre, empleado = emp.nombres + " " + emp.apellidos, horas = item.total });
            else
                horas[item.codemp].horas += item.total;
        }
        var sort = from e in horas orderby e.Value.horas ascending select e;
        var head = tblreg.Rows[0];
        tblreg.Rows.Clear();
        tblreg.Rows.Add(head);
        foreach (var i in sort)
        {                                   
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = i.Value.departamento.ToUpper() });
            row.Cells.Add(new TableCell() { Text = i.Value.empleado.ToUpper() });
            row.Cells.Add(new TableCell() { Text = i.Value.horas.ToString() });
            var btn = new Button();
            btn.Text = "Detalle";
            btn.CommandArgument = i.Value.codemp.ToString();
            btn.CssClass = "btn btn-success";
            btn.Command += detalle;
            TableCell ed = new TableCell();
            ed.Controls.Add(btn);
            row.Cells.Add(ed);
            tblreg.Rows.Add(row);
        }
    }

    protected void detalle(object sender, CommandEventArgs e)
    {
        int codemp = Convert.ToInt32(e.CommandArgument);
        var period = txtfilter.Text;
        int month = Convert.ToInt32(period.Substring(period.IndexOf("-") + 1));
        int year = Convert.ToInt32(period.Substring(0, period.IndexOf("-")));
        var det = Datos.listRegistrosEmpleado(codemp, usuario.codcli,month, year);
        var emp = Datos.getEmpleado(codemp, usuario.codcli);
        txtnom.Text = emp.nombres;
        txtape.Text = emp.apellidos;           
        foreach (var item in det)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = item.fecha });
            TableCell tchi = new TableCell();
            tchi.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horaentrada.Substring(0,5), ReadOnly = true, CssClass = "control-hide-gray" });
            row.Cells.Add(tchi);
            TableCell tchf = new TableCell();
            tchf.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horasalida.Substring(0,5), ReadOnly = true, CssClass = "control-hide-gray" });
            row.Cells.Add(tchf);
            row.Cells.Add(new TableCell() { Text = item.total.ToString() });
            tbldet.Rows.Add(row);            
        }        
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "detReg", "new bootstrap.Modal(document.getElementById('detReg'), { keyboard:false}).show()", true);
    }

    private string calcHours(string horaentrada, string horasalida)
    {        
        try
        {
            var hi = Convert.ToInt32(horaentrada.Substring(0, 2));
            var mi = Convert.ToInt32(horaentrada.Substring(3, 2));
            var hf = Convert.ToInt32(horasalida.Substring(0, 2));
            var mf = Convert.ToInt32(horasalida.Substring(3, 2));
            var dti = new DateTime(2000, 1, 1, hi, mi, 0);
            var dtf = new DateTime(2000, 1, 1, hf, mf, 0);
            var diff = dtf.Subtract(dti);
            return String.Format("{0:0.00}", diff.TotalHours);
        }
        catch (Exception)
        {
            return "0";
        }
    }

    private class Reg
    {
        public int codemp { get; set; }
        public string empleado { get; set; }
        public string departamento { get; set; }
        public decimal horas { get; set; }
    }

    protected void txtfilter_TextChanged(object sender, EventArgs e)
    {
        fillTable();
        var period = txtfilter.Text;
        int month = Convert.ToInt32(period.Substring(period.IndexOf("-") + 1));
        int year = Convert.ToInt32(period.Substring(0, period.IndexOf("-")));
        Session["m"] = month;
        Session["y"] = year;
    }
}