using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Control_emp : UserControl
{
    public EventHandler refmain;
    public int EDITID { get; set; }
    public bool editing;        
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var dptos = Datos.listDepartamentos(1);
        if(!IsPostBack || cmbDptos.Items.Count == 0)
        {
            cmbDptos.Items.Clear();
            cmbDptos.Items.Add(new ListItem("Seleccionar...", "0"));
            foreach (var item in dptos)
                cmbDptos.Items.Add(new ListItem(item.nombre.ToUpper(), item.coddpto.ToString()));
        }        
        if (!IsPostBack) clearForm();
        if (EDITID > 0)
            editing = true;
        title.Text = "Agregar Empleado";
    }    

    protected void guardar(object sender, EventArgs e)
    {
        if (txtnom.Text == "") return;
        string nombres = txtnom.Text;
        string apellidos = txtape.Text;
        string nacimiento = txtDate.Text;
        string email = txtemail.Text;
        string tel = txttel.Text;
        string dui = txtdui.Text;
        string afp = txtafp.Text;
        string nit = txtnit.Text;
        string dir = txtdir.Text;        
        string genero = rdoGen.SelectedValue;
        int dpto = Convert.ToInt32(cmbDptos.SelectedValue);
        string user = txtuser.Text;
        string password = txtpass.Text;
        int cod = Convert.ToInt32(codemp.Value);     
        Empleado emp = new Empleado();
        emp.codemp = cod;
        emp.nombres = nombres;
        emp.apellidos = apellidos;
        emp.coddpto = dpto;       
        emp.correo = email;
        emp.telefonos = tel;
        emp.dui = dui;
        emp.afp = afp;
        emp.nit = nit;
        emp.genero = genero;
        emp.direccion = dir;
        emp.nacimiento = formatDate(nacimiento);
        emp.usuario = user;
        emp.password = password;
        if (cod > 0)
            Datos.updateEmpleado(emp);
        else
            Datos.insertEmpleado(emp);
        Response.Redirect(Request.RawUrl);        
    }
    protected void desactivar(object sender, EventArgs e)
    {
        int cod = Convert.ToInt32(codemp.Value);
        Datos.disableEmpleado(cod,1);
        Response.Redirect(Request.RawUrl);
    }
    public void editForm(Empleado emp)
    {
        txtnom.Text = emp.nombres;
        txtape.Text = emp.apellidos;
        txtDate.Text = emp.nacimiento.Substring(0, emp.nacimiento.IndexOf('T'));
        txtemail.Text = emp.correo;
        txttel.Text = emp.telefonos;
        txtdui.Text = emp.dui;
        txtafp.Text = emp.afp;
        txtnit.Text = emp.nit;
        cmbDptos.SelectedValue = emp.coddpto.ToString();
        rdoGen.SelectedValue = emp.genero;
        txtdir.Text = emp.direccion;
        txtuser.Text = emp.usuario;
        codemp.Value = EDITID.ToString();
        editing = true;
        title.Text = "Editar Empleado";
    }
    private string formatDate(string date)
    {
        DateTime theDate = DateTime.ParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        return theDate.ToString("dd-MM-yyyy");
    }
    public void clearForm()
    {
        txtnom.Text = "";
        txtape.Text = "";
        txtDate.Text = "";
        txtafp.Text = "";
        txtdir.Text = "";
        txtdui.Text = "";
        txtemail.Text = "";
        txtnit.Text = "";
        txttel.Text = "";
        txtuser.Text = "";
        txtpass.Text = "";
        txtpass2.Text = "";
        cmbDptos.SelectedIndex = 0;
        codemp.Value = "0";
    }
    
}