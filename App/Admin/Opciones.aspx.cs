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
    public bool noplan;           
    protected void Page_Load(object sender, EventArgs e)
    {
        noplan = Session["noplan"] != null;
        Cliente cliente = (Cliente)Session["cliente"];
        if (!IsPostBack)
        {
            Session["urlnomvalid"] = true;
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
            if(cliente == null)
            {
                Response.RedirectLocation = "/Login";
                return;
            }
            txtclinom.Text = cliente.nombre;
            txtcliid.Text = cliente.urlnom;
            txturl.Text = cliente.url == null ? "" : cliente.url;
            txtemail.Text = cliente.correo_contacto;
            txtnumcont.Text = cliente.telefono_contacto;           
            txtprob.Text = String.Format("{0:F2}", cliente.porctcapt);
            txtint.Text = String.Format("{0}", cliente.invervalo);
            txtdir.Text = cliente.direccion;
            txtfin.Text = cliente.fecha_fin_servicio_format;
            country.SelectedValue = cliente.pais;
            plan.SelectedValue = cliente.plan.ToString();
            ddlTimeZones.SelectedValue = cliente.zonahoraria.ToString();
            chknav.Checked = cliente.capturarhistorialnav;
            chkpant.Checked = cliente.capturarpantalla;
            chkpross.Checked = cliente.capturarprocesos;
            pickcolor.Text = cliente.loginbackground;
        }
    }

    protected void txtcliid_TextChanged(object sender, EventArgs e)
    {
        string nom = txtcliid.Text;
        validarnom(nom);
    }

    protected void txtclinom_TextChanged(object sender, EventArgs e)
    {
        string nom = txtclinom.Text;
        nom = GlobalV.RemoveSpecialCharacters(nom).ToLower();
        txtcliid.Text = nom;
        validarnom(nom);
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Cliente cliente = (Cliente)Session["cliente"];
        bool urlnomvalid = bool.Parse(Session["urlnomvalid"].ToString());
        cliente.nombre = txtclinom.Text;
        cliente.urlnom = txtcliid.Text;
        cliente.url = txturl.Text;
        cliente.correo_contacto = txtemail.Text;
        cliente.telefono_contacto = txtnumcont.Text;
        try
        {
            cliente.porctcapt = float.Parse(txtprob.Text);
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
        int nplan = int.Parse(plan.SelectedValue);        
        DateTime fechafin = DateTime.ParseExact(cliente.fecha_fin_servicio, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
        if (cliente.plan == 0 && nplan > 0 && DateTime.Now > fechafin)
        {
            cliente.fecha_fin_servicio = FormatDateTime(DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
            Session.Remove("noplan");
            noplan = false;
        }
        cliente.plan = nplan;
        cliente.zonahoraria = int.Parse(ddlTimeZones.SelectedValue);
        cliente.capturarhistorialnav = chknav.Checked;
        cliente.capturarpantalla = chkpant.Checked;
        cliente.capturarprocesos = chkpross.Checked;
        cliente.loginbackground = pickcolor.Text;        
        if(!urlnomvalid)
        {
            ((Layout)Master).toast("ALERT", "El nombre de acceso no esta disponible", 1, ClientScript);
            return;
        }
        try
        {
            var r = Datos.updateCliente(cliente);
            if(r.affectedRows == 0)
            {
                ((Layout)Master).toast("ALERT", "No se pudo actualizar el registro", 1, ClientScript);
                return;
            }
            Session["cliente"] = cliente;
            ((Layout)Master).toast("INFO", "Se guardo correctamente", 0,ClientScript);
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

    private void validarnom(string nom)
    {
        Cliente cliente = (Cliente)Session["cliente"];
        if (nom.Trim() != "" && nom.Length > 3 && Datos.getCliente(nom) != null && txtcliid.Text != cliente.urlnom)
        {
            invaliddisplay = "display: block";
            Session["urlnomvalid"] = false;
        }
        else
        {
            validdisplay = "display: block";
            Session["urlnomvalid"] = true;
        }
    }

    private string FormatDateTime(string dateTimeString)
    {
        DateTime dateTime = DateTime.ParseExact(dateTimeString, "yyyy-MM-ddTHH:mm:ss.fffZ", null);
        return dateTime.AddDays(31).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    }    

}