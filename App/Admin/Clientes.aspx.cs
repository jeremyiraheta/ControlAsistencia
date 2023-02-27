using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz.modelos;
using Interfaz;

public partial class Clientes : System.Web.UI.Page
{
    Usuario usuario;
    public int minp = 1;
    public int maxp = 10;
    public int cpage = 1;
    public bool enabled = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        try
        {
            enabled = !Boolean.Parse(Request.Params["disabled"]);
        }
        catch (Exception)
        {
        }
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
        var clis = Datos.listClientes(enabled, (cpage - 1) * 10);
        filltable(clis);
        if(!enabled)
        {
            btntoggle.Text = "Mostrar Activos";
        }
    }

    private void filltable(List<Cliente> clientes)
    {
        var head = tblcli.Rows[0];
        tblcli.Rows.Clear();
        tblcli.Rows.Add(head);
        foreach (var itm in clientes)
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = itm.codcli.ToString() });
            if(itm.url != null && itm.url.Trim().Length > 0)
                row.Cells.Add(new TableCell() { Text = String.Format("<a href='https://{1}' title='{1}' target='_blank'>{0}</a>", itm.nombre, itm.url) });
            else
                row.Cells.Add(new TableCell() { Text = itm.nombre });
            row.Cells.Add(new TableCell() { Text = itm.urlnom });
            row.Cells.Add(new TableCell() { Text = itm.correo_contacto });
            row.Cells.Add(new TableCell() { Text = itm.telefono_contacto });
            row.Cells.Add(new TableCell() { Text = itm.pais });
            row.Cells.Add(new TableCell() { Text =  PLAN(itm.plan)});
            row.Cells.Add(new TableCell() { Text = itm.fecha_fin_servicio_format });
            TableCell edit = new TableCell();
            Button btn = new Button();
            if(itm.activo)
            {
                btn.Text = "Desactivar";
                btn.CssClass = "btn btn-danger";
                btn.CommandName = "false";
            }
            else
            {
                btn.Text = "Activar";
                btn.CssClass = "btn btn-success";
                btn.CommandName = "true";
            }            
            btn.CommandArgument = itm.codcli.ToString();            
            btn.UseSubmitBehavior = true;
            btn.ID = "E" + btn.CommandArgument;
            btn.Command += new CommandEventHandler(Command);
            edit.Controls.Add(btn);
            row.Cells.Add(edit);
            tblcli.Rows.Add(row);
        }
    }

    protected void filtrar(object sender, ImageClickEventArgs e)
    {
        if (txtfilter.Text.Trim() == "") return;
        var clis = Datos.filter<Cliente>("CLIENTES", String.Format("UPPER(concat_ws(' ', NOMBRE, URLNOM, CORREO_CONTACTO, TELEFONO_CONTACTO, FECHA_FIN_SERVICIO, PAIS)) LIKE UPPER('%{0}%') and ACTIVO = '{1}'", txtfilter.Text, enabled.ToString().ToLower()));
        if (clis == null)
            clis = new List<Cliente>();
        filltable(clis);
    }

    protected void Command(object sender, CommandEventArgs e)
    {
        int codcli = Convert.ToInt32(e.CommandArgument);
        bool disable = !Boolean.Parse(e.CommandName);
        if (disable)
            Datos.deleteCliente(codcli);
        else
            Datos.enableCliente(codcli);
        List<Cliente> clis = Datos.listClientes(enabled, (cpage - 1) * 10);
        filltable(clis);
        ((Layout)Master).toast("INFO", "Se actualizo el registro", 0, ClientScript);
    }

    private string PLAN(int p)
    {
        switch(p)
        {
            case 0:
                return "Ninguno";
            default:
                return GlobalV.PLAN[p, 0];                
        }
    }

    private int maxpages()
    {
        try
        {
            List<Datos.Counter> i = Datos.filter<Datos.Counter>("CLIENTES", "ACTIVO = 'true'", "COUNT(*) count");
            int numero = i[0].count;
            return (int)Math.Ceiling(numero / 10.0);
        }
        catch (Exception)
        {
            return 10;
        }

    }

    protected void btntoggle_Click(object sender, EventArgs e)
    {
        if(enabled)
            Response.Redirect(Request.Url.LocalPath + "?disabled=true");
        else
            Response.Redirect(Request.Url.LocalPath);
    }
}