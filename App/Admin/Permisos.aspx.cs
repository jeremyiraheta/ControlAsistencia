using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Permisos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) txtfilter.Text = DateTime.Today.Year + "-" + DateTime.Today.Month;
        switch(curstate.Value)
        {
            case "1":
                fillTable(RESTAPI.ESTADO.APROBADO);
                break;
            case "2":
                fillTable(RESTAPI.ESTADO.RECHAZADO);
                break;
            case "0":
            default:
                fillTable(RESTAPI.ESTADO.ESPERA);
                break;
        }                
    }

    protected void linkPend_Click(object sender, EventArgs e)
    {
        linkPend.CssClass = "nav-link active";
        linkAprob.CssClass = "nav-link";
        linkRecha.CssClass = "nav-link";
        curstate.Value = "0";
        fillTable(RESTAPI.ESTADO.ESPERA);
    }    

    protected void linkAprob_Click(object sender, EventArgs e)
    {
        linkPend.CssClass = "nav-link ";
        linkAprob.CssClass = "nav-link active";
        linkRecha.CssClass = "nav-link";
        curstate.Value = "1";
        fillTable(RESTAPI.ESTADO.APROBADO);
    }

    protected void linkRecha_Click(object sender, EventArgs e)
    {
        linkPend.CssClass = "nav-link ";
        linkAprob.CssClass = "nav-link";
        linkRecha.CssClass = "nav-link active";
        curstate.Value = "2";
        fillTable(RESTAPI.ESTADO.RECHAZADO);
    }
    public void fillTable(RESTAPI.ESTADO estado)
    {
        var period = txtfilter.Text;
        int month = Convert.ToInt32(period.Substring(period.IndexOf("-")+1));
        int year = Convert.ToInt32(period.Substring(0, period.IndexOf("-")));
        var permisos = RESTAPI.listPermisos(month,year);
        var h = tblperm.Rows[0];
        tblperm.Rows.Clear();
        tblperm.Rows.Add(h);   
        switch(estado)
        {
            case RESTAPI.ESTADO.APROBADO:
                foreach (var item in permisos.Where( a => a.estado == 'A' ))
                {
                    var emp = RESTAPI.getEmpleado(item.codemp);
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell() { Text = emp.nombres + " " + emp.apellidos });
                    row.Cells.Add(new TableCell() { Text = item.fecha });
                    row.Cells.Add(new TableCell() { Text = item.formatTipo() });
                    TableCell tchi = new TableCell();
                    tchi.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horainicial, ReadOnly = true, CssClass = "control-hide" });
                    row.Cells.Add(tchi);
                    TableCell tchf = new TableCell();
                    tchf.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horafinal, ReadOnly = true, CssClass = "control-hide" });
                    row.Cells.Add(tchf);
                    Button btn = new Button();
                    btn.ID = "b" + item.codper;
                    btn.Text = "Ver";
                    btn.CssClass = "btn btn-success";
                    btn.Command += ver;
                    btn.CommandArgument = item.codper.ToString();
                    TableCell tb = new TableCell();
                    tb.Controls.Add(btn);
                    row.Cells.Add(tb);
                    tblperm.Rows.Add(row);
                }
                break;
            case RESTAPI.ESTADO.ESPERA:
                foreach (var item in permisos.Where(a => a.estado == 'E'))
                {
                    var emp = RESTAPI.getEmpleado(item.codemp);
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell() { Text = emp.nombres + " " + emp.apellidos });
                    row.Cells.Add(new TableCell() { Text = item.fecha });
                    row.Cells.Add(new TableCell() { Text = item.formatTipo() });
                    TableCell tchi = new TableCell();
                    tchi.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horainicial, ReadOnly = true, CssClass = "control-hide" });
                    row.Cells.Add(tchi);
                    TableCell tchf = new TableCell();
                    tchf.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horafinal, ReadOnly = true, CssClass = "control-hide" });
                    row.Cells.Add(tchf);
                    Button btn = new Button();
                    btn.ID = "b" + item.codper;
                    btn.Text = "Ver";
                    btn.CssClass = "btn btn-success";
                    btn.Command += ver;
                    btn.CommandArgument = item.codper.ToString();
                    TableCell tb = new TableCell();
                    tb.Controls.Add(btn);
                    row.Cells.Add(tb);
                    tblperm.Rows.Add(row);
                }
                break;
            case RESTAPI.ESTADO.RECHAZADO:
                foreach (var item in permisos.Where(a => a.estado == 'R'))
                {
                    var emp = RESTAPI.getEmpleado(item.codemp);
                    TableRow row = new TableRow();
                    row.Cells.Add(new TableCell() { Text = emp.nombres + " " + emp.apellidos });
                    row.Cells.Add(new TableCell() { Text = item.fecha });
                    row.Cells.Add(new TableCell() { Text = item.formatTipo() });
                    TableCell tchi = new TableCell();
                    tchi.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horainicial, ReadOnly=true,CssClass="control-hide" });
                    row.Cells.Add(tchi);
                    TableCell tchf = new TableCell();
                    tchf.Controls.Add(new TextBox() { TextMode = TextBoxMode.Time, Text = item.horafinal,ReadOnly=true, CssClass="control-hide" });
                    row.Cells.Add(tchf);
                    Button btn = new Button();
                    btn.ID = "b" + item.codper;
                    btn.Text = "Ver";
                    btn.CssClass = "btn btn-success";
                    btn.Command += ver;
                    btn.CommandArgument = item.codper.ToString();
                    TableCell tb = new TableCell();
                    tb.Controls.Add(btn);
                    row.Cells.Add(tb);
                    tblperm.Rows.Add(row);
                }
                break;
        }
    }

    protected void ver(object sender, CommandEventArgs e)
    {
        int codper = Convert.ToInt32(e.CommandArgument);
        var permisos = RESTAPI.getPermiso(codper);
        var emp = RESTAPI.getEmpleado(permisos.codemp);
        hcodper.Value = codper.ToString();
        txtnom.Text = emp.nombres;
        txtape.Text = emp.apellidos;
        txtDate.Text = permisos.fecha;
        txtdesc.Text = Uri.UnescapeDataString(permisos.descripcion);
        txthi.Text = permisos.horainicial;
        txthf.Text = permisos.horafinal;
        cmbTipo.SelectedValue = permisos.tipo + "";
        if (permisos.attch)
            linkdownload.Text = String.Format("<a href='{0}download/{1}' target='_blank' >Adjunto</a>", RESTAPI.APIURL, permisos.codper);
        else
            linkdownload.Text = "";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "verPerm", "new bootstrap.Modal(document.getElementById('verPerm'), { keyboard:false}).show()", true);
    }

    protected void aprobar(object sender, EventArgs e)
    {
        int codper = Convert.ToInt32(hcodper.Value);
        int state = Convert.ToInt32(curstate.Value);
        RESTAPI.cambiarEstadoPermiso(codper, RESTAPI.ESTADO.APROBADO);
        switch(state)
        {
            case 0:
                fillTable(RESTAPI.ESTADO.ESPERA);
                break;
            case 1:
                fillTable(RESTAPI.ESTADO.APROBADO);
                break;
            case 2:
                fillTable(RESTAPI.ESTADO.RECHAZADO);
                break;
        }
    }
    protected void rechazar(object sender, EventArgs e)
    {
        int codper = Convert.ToInt32(hcodper.Value);
        int state = Convert.ToInt32(curstate.Value);
        RESTAPI.cambiarEstadoPermiso(codper, RESTAPI.ESTADO.RECHAZADO);
        switch (state)
        {
            case 0:
                fillTable(RESTAPI.ESTADO.ESPERA);
                break;
            case 1:
                fillTable(RESTAPI.ESTADO.APROBADO);
                break;
            case 2:
                fillTable(RESTAPI.ESTADO.RECHAZADO);
                break;
        }
    }
    protected void txtfilter_TextChanged(object sender, EventArgs e)
    {
        int state = Convert.ToInt32(curstate.Value);
        switch(state)
        {
            case 0:
                fillTable(RESTAPI.ESTADO.ESPERA);
                break;
            case 1:
                fillTable(RESTAPI.ESTADO.APROBADO);
                break;
            case 2:
                fillTable(RESTAPI.ESTADO.RECHAZADO);
                break;
        }
    }
}