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
            btnimg.ImageUrl = "/Logos.ashx?id=" + cliente.codcli;
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
        cliente = (Cliente)Session["cliente"];
        cliente.nombre = txtclinom.Text;
        cliente.urlnom = txtcliid.Text;
        cliente.url = txturl.Text;
        cliente.correo_contacto = txtemail.Text;
        cliente.telefono_contacto = txtnumcont.Text;
        try
        {
            cliente.porctcapt = int.Parse(txtprob.Text);
        }
        catch (Exception)
        {
        }
        try
        {
            cliente.invervalo = int.Parse(txtint.Text);
        }
        catch (Exception)
        {
        }
        cliente.direccion = txtdir.Text;
        cliente.pais = country.SelectedValue;
        cliente.plan = int.Parse(plan.SelectedValue);
        cliente.zonahoraria = int.Parse(ddlTimeZones.SelectedValue);
        cliente.capturarhistorialnav = chknav.Checked;
        cliente.capturarpantalla = chkpant.Checked;
        cliente.capturarprocesos = chkpross.Checked;
        try
        {
            Datos.updateCliente(cliente);
        }
        catch (Exception)
        {
            
        }
        try
        {
            if(ulogo.HasFile)
            {                
                byte[] file = ulogo.FileBytes;
                Datos.UploadState state = Datos.uploadLogo(cliente.codcli, file);
                if (!state.status)
                    throw new Exception("No se pudo subir el logotipo");
            }            
        }
        catch (Exception)
        {                        
        }

    }
}