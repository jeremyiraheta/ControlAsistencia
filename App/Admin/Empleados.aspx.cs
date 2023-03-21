using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Interfaz;
using Interfaz.modelos;

public partial class Empleados : System.Web.UI.Page
{
    Usuario usuario;
    public int EDITID { get; set; }
    public bool editing;
    public int minp=1;
    public int maxp=10;
    public int cpage = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        usuario = (Usuario)Session["usuario"];
        if (usuario == null)
            Response.Redirect("/Login");
        int tmax = maxpages()+1;
        minp = 1;
        if (tmax > 9)
            maxp = 9;
        else
            maxp = tmax;
        if (Page.RouteData.Values.ContainsKey("page"))
        {
            cpage = int.Parse(Page.RouteData.Values["page"].ToString());  
            if(cpage > 9)
            {
                minp = 10 * Convert.ToInt32(cpage / 10);                
                maxp = minp + 10;
                if (maxp > tmax)
                    maxp = tmax;
            }
        }        
        var emps = Datos.listEmpleados(usuario.codcli, (cpage-1)*10);
        filltable(emps);
        var dptos = Datos.listDepartamentos(usuario.codcli);
        if (!IsPostBack || cmbDptos.Items.Count == 0)
        {
            cmbDptos.Items.Clear();
            cmbDptos.Items.Add(new ListItem("Seleccionar...", "0"));
            foreach (var item in dptos)
                cmbDptos.Items.Add(new ListItem(item.nombre.ToUpper(), item.coddpto.ToString()));
        }
        if (!IsPostBack) clearForm();
        if (EDITID > 0)
            editing = true;        
    }
    protected void editCommand(object sender, CommandEventArgs e)
    {                           
        this.EDITID = Convert.ToInt32(e.CommandArgument);
        var o = Datos.getEmpleado(this.EDITID, usuario.codcli);
        this.editForm(o);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addEmp", "new bootstrap.Modal(document.getElementById('addEmp'), { keyboard:false}).show()", true);
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
            row.Cells.Add(new TableCell() { Text = item.correo });
            row.Cells.Add(new TableCell() { Text = item.nacimientoformat });
            TableCell edit = new TableCell();
            Button btn = new Button();
            btn.Text = "Editar";
            btn.CssClass = "btn btn-success";
            btn.CommandArgument = item.codemp.ToString();
            btn.UseSubmitBehavior = true;
            btn.ID = "E" + btn.CommandArgument;
            btn.Command += new CommandEventHandler(editCommand);
            edit.Controls.Add(btn);
            row.Cells.Add(edit);
            tblemp.Rows.Add(row);
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {        
        this.EDITID = 0;
        this.clearForm();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addEmp", "new bootstrap.Modal(document.getElementById('addEmp'), { keyboard:false}).show()", true);
    }

    protected void filtrar(object sender, ImageClickEventArgs e)
    {
        if (txtfilter.Text.Trim() == "") return;
        var emps = Datos.filter<Empleado>("EMPLEADOS", String.Format("concat_ws(' ', NOMBRES, APELLIDOS, CORREO, NACIMIENTO, (SELECT NOMBRE FROM DEPARTAMENTOS d WHERE d.CODDPTO = EMPLEADOS.CODDPTO)) LIKE UPPER('%{0}%') and ACTIVO = 'true' and CODCLI = {1}", txtfilter.Text, usuario.codcli), "*");
        if (emps == null)
            emps = new List<Empleado>();
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
        emp.codcli = usuario.codcli;
        if (cod > 0)
        {
            var r = Datos.updateEmpleado(emp);
            if (r.affectedRows > 0)
                ((Layout)Master).toast("INFO", "Se actualizo el registro", 0, ClientScript);
            else
                ((Layout)Master).toast("ERROR", "Ocurrio un error y no se pudo actualizar", 2, ClientScript);
        }
        else
        {
            int max = maximo(((Cliente)Session["cliente"]).plan);
            int count = int.Parse(Session["count_emps"].ToString());
            if (max >= count && max > -1)
            {
                ((Layout)Master).toast("ERROR", "Ya llego al limite de empleados que puede ingresar con su plan", 2, ClientScript);
                return;
            }
            var r = Datos.insertEmpleado(emp);
           if ( r.affectedRows > 0 )
                ((Layout)Master).toast("INFO", "Se agrego el registro", 0, ClientScript);
           else
                ((Layout)Master).toast("ERROR", "No se pudo agregar el registro", 2, ClientScript);
        }
        filltable(Datos.listEmpleados(usuario.codcli, (cpage - 1) * 10));      
    }
    protected void desactivar(object sender, EventArgs e)
    {
        int cod = Convert.ToInt32(codemp.Value);
        Datos.disableEmpleado(cod, usuario.codcli);
        filltable(Datos.listEmpleados(usuario.codcli, (cpage - 1) * 10));
        ((Layout)Master).toast("INFO", "Se desactivo al empleado", 0, ClientScript);
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

    private int maximo(int plan)
    {
        if (plan > 0)
            return int.Parse(GlobalV.PLAN[plan - 1, 3]);
        else
            return int.Parse(GlobalV.PLAN[0, 3]);
    }



}