using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz.modelos;
using Interfaz;

public partial class Opciones : System.Web.UI.Page
{

    public string validdisplay = "display:none";
    public string invaliddisplay = "display:none";
    private bool urlnomvalid = false;    
    private Cliente cliente;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            foreach (TimeZoneInfo timeZone in TimeZoneInfo.GetSystemTimeZones())
            {
                ddlTimeZones.Items.Add(new ListItem(timeZone.DisplayName, timeZone.BaseUtcOffset.Hours.ToString()));
            }
            foreach (var p in GlobalV.PAISES)
            {
                country.Items.Add(p);
            }
            plan.Items.Add(new ListItem("Ninguno", "0"));
            for(int i = 0; i< GlobalV.PLAN.GetLength(0);i++)
            {
                plan.Items.Add(new ListItem(GlobalV.PLAN[i, 0], GlobalV.PLAN[i, 2]));
            }          
            cliente = (Cliente)Session["cliente"];
            if(cliente == null)
            {
                Response.RedirectLocation = "/Login";
                return;
            }
            txtclinom.Text = cliente.nombre;
            txtcliid.Text = cliente.urlnom;
            txturl.Text = cliente.url;
            txtemail.Text = cliente.correo_contacto;
            txtnumcont.Text = cliente.telefono_contacto;
            txturl.Text = cliente.url;
            txtprob.Text = String.Format("%d", cliente.porctcapt);
            txtint.Text = String.Format("%f", cliente.invervalo);
            txtdir.Text = cliente.direccion;
            txtfin.Text = cliente.fecha_fin_servicio_format;
            country.SelectedValue = cliente.pais;
            plan.SelectedValue = cliente.plan.ToString();
            ddlTimeZones.SelectedValue = cliente.zonahoraria.ToString();
            chknav.Checked = cliente.capturarhistorialnav;
            chkpant.Checked = cliente.capturarpantalla;
            chkpross.Checked = cliente.capturarprocesos;
            if(cliente.attch)
            {
                btnimg.ImageUrl = "/Logos.ashx";
            }
        }
    }

    protected void txtcliid_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtclinom_TextChanged(object sender, EventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

    }
}