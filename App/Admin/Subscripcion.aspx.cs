using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Subscripcion : System.Web.UI.Page
{
    private int plan;
    public string validdisplay = "display:none";
    public string invaliddisplay = "display:none";
    private bool urlnomvalid = false;    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            plan = int.Parse(Request.Params["plan"]);
        }
        catch (Exception)
        {            
        }
        switch (plan)
        {
            case 1:
                outPlan.Text = "Plan Startup";
                outCobro.Text = "4.99";
                outTotal.Text = "4.99";
                break;
            case 2:
                outPlan.Text = "Plan PYME";
                outCobro.Text = "9.99";
                outTotal.Text = "9.99";
                break;
            case 3:
                outPlan.Text = "Plan Premium";
                outCobro.Text = "99.9";
                outTotal.Text = "99.9";
                break;
            default:
                outPlan.Text = "Plan Premium";
                outCobro.Text = "99.9";
                outTotal.Text = "99.9";
                break;
        }
        
        foreach (var p in PAISES)
        {
            country.Items.Add(p);
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

    private void validarnom(string nom)
    {
        if (nom.Trim() != "" && nom.Length > 3 &&  Datos.getCliente(nom) != null)
        {
            invaliddisplay = "display: block";
            urlnomvalid = true;
        }
        else
        {
            validdisplay = "display: block";
            urlnomvalid = false;
        }
    }

    public static string[] PAISES = { 
       "Afganistán", "Albania", "Argelia", "Andorra", "Angola", "Antigua y Barbuda",
       "Argentina", "Armenia", "Australia", "Austria", "Azerbaiyán", "Bahamas",
       "Bangladés", "Barbados", "Baréin", "Bélgica", "Belice", "Benín", "Bielorrusia",
       "Birmania", "Bolivia", "Bosnia y Herzegovina", "Botsuana", "Brasil", "Brunéi",
       "Bulgaria", "Burkina Faso", "Burundi", "Bután", "Cabo Verde", "Camboya",
       "Camerún", "Canadá", "Catar", "Chad", "Chile", "China", "Chipre", "Colombia",
       "Comoras", "Corea del Norte", "Corea del Sur", "Costa de Marfil", "Costa Rica",
       "Croacia", "Cuba", "Dinamarca", "Dominica", "Ecuador", "Egipto", "El Salvador",
       "Emiratos Árabes Unidos", "Eritrea", "Eslovaquia", "Eslovenia", "España",
       "Estados Unidos", "Estonia", "Etiopía", "Filipinas", "Finlandia", "Fiyi",
       "Francia", "Gabón", "Gambia", "Georgia", "Alemania", "Ghana", "Grecia",
       "Granada", "Guatemala", "Guinea", "Guinea-Bisáu", "Guinea Ecuatorial", "Guyana",
       "Haití", "Honduras", "Hungría", "Islandia", "India", "Indonesia", "Irán",
       "Irak", "Irlanda", "Israel", "Italia", "Jamaica", "Japón", "Jordania", "Kazajistán",
       "Kenia", "Kirguistán", "Kiribati", "Kuwait", "Laos", "Lesoto", "Letonia", "Líbano",
       "Liberia", "Libia", "Liechtenstein", "Lituania", "Luxemburgo", "Macedonia", "Madagascar",
       "Malasia", "Malaui", "Maldivas", "Malí", "Malta", "Marruecos", "Mauricio", "Mauritania",
       "México", "Micronesia", "Moldavia", "Mónaco", "Mongolia", "Montenegro", "Mozambique" };


    protected void pagar_Click(object sender, EventArgs e)
    {
        if(urlnomvalid)
        {
            alert("ALERTA", "Ingrese un nombre unico de acceso directo");
            return;
        }
        if(txtpass.Text != txtpass2.Text)
        {
            alert("ALERTA", "Los passwords no coinciden");
            return;
        }
        DateTime nacimiento = DateTime.ParseExact(txtnaci.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        if (nacimiento.CompareTo(DateTime.Now.AddYears(-18)) > -1)
        {
            alert("ALERTA", "La fecha de nacimiento no es valida");
            return;
        }
        try
        {            
            Cliente cliente = new Cliente();
            cliente.nombre = txtclinom.Text;
            cliente.urlnom = txtcliid.Text;
            cliente.correo_contacto = txtemail.Text;
            cliente.telefono_contacto = txtnumcont.Text;
            cliente.pais = country.Text;
            cliente.plan = plan;
            cliente.direccion = txtdir.Text;
            Datos.insertCliente(cliente);
            cliente = Datos.getCliente(cliente.urlnom);
            if (cliente == null)
            {
                alert("ERROR", "No se pudo crear el cliente, intente mas tarde");
                return;
            }
            Datos.insertDepartamento(cliente.codcli, "ADMIN");
            List<Departamento> dptos = Datos.listDepartamentos(cliente.codcli);
            if(dptos == null || dptos.Count == 0)
            {
                alert("ERROR", "No se pudo crear el departamento, intente mas tarde");
                Datos.purgeCliente(cliente.codcli);
                return;
            }
            Empleado empleado = new Empleado();
            empleado.codcli = cliente.codcli;
            empleado.coddpto = dptos[0].coddpto;
            empleado.nombres = txtnom.Text;
            empleado.apellidos = txtapell.Text;
            empleado.correo = txtemail.Text;
            empleado.telefonos = txtnumcont.Text;
            empleado.usuario = txtusername.Text;
            empleado.password = txtpass.Text;
            empleado.nacimiento = nacimiento.ToString("dd-MM-yyyy");
            Datos.insertEmpleado(empleado);
            empleado = Datos.getEmpleado(empleado.usuario, cliente.codcli);
            if(empleado == null)
            {
                alert("ERROR", "No se pudo crear el usuario, intente mas tarde");
                Datos.purgeCliente(cliente.codcli);
            }
            else
            {
                Session["urlnom"] = cliente.urlnom;
                Response.Redirect("/Confirmacion");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: (pagar_Click) " + ex.Message);
            alert("ERROR", "Ocurrio un error inesperado, intente mas tarde!");
        }
    }

    private void alert(string titulo, string msg)
    {
        alerttitle.Text = titulo;
        alertmsg.Text = msg;
        string script = "window.onload = function() { $('#alert').modal('show') }";
        ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
    }
}