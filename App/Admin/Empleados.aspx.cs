using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Empleados : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        ViewBag.Set("title", "Sistema Administrativo Control Asistencia Remota - Empleados - DIGESTYC");
        var emps = RESTAPI.listEmpleados();
        filltable(emps);               
    }
    protected void editCommand(object sender, CommandEventArgs e)
    {
        ASP.control_emp_ascx emp=null;
        foreach (var ctrl in modalContainer.Controls)
        {
            if (ctrl is ASP.control_emp_ascx)
                    emp = (ASP.control_emp_ascx)ctrl;
        }
        
        emp.EDITID = Convert.ToInt32(e.CommandArgument);
        var o = RESTAPI.getEmpleado(emp.EDITID);
        emp.editForm(o);
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addEmp", "new bootstrap.Modal(document.getElementById('addEmp'), { keyboard:false}).show()", true);
    }
    private void filltable(List<Empleado> emps)
    {
        var dpts = RESTAPI.listDepartamentos();
        var head = tblemp.Rows[0];
        tblemp.Rows.Clear();
        tblemp.Rows.Add(head);
        foreach (var item in emps.Where(v => v.coddpto != 1))
        {
            TableRow row = new TableRow();
            row.Cells.Add(new TableCell() { Text = item.codemp.ToString() });
            row.Cells.Add(new TableCell() { Text = dpts.Where(v => v.coddpto == item.coddpto).First().nombre.ToUpper() });
            row.Cells.Add(new TableCell() { Text = item.nombres });
            row.Cells.Add(new TableCell() { Text = item.apellidos });
            row.Cells.Add(new TableCell() { Text = item.telefonos });
            row.Cells.Add(new TableCell() { Text = item.correo });
            row.Cells.Add(new TableCell() { Text = item.formatdate });
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
        ASP.control_emp_ascx emp = null;
        foreach (var ctrl in modalContainer.Controls)
        {
            if (ctrl is ASP.control_emp_ascx)
                emp = (ASP.control_emp_ascx)ctrl;
        }

        emp.EDITID = 0;
        emp.clearForm();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "addEmp", "new bootstrap.Modal(document.getElementById('addEmp'), { keyboard:false}).show()", true);
    }

    protected void filtrar(object sender, ImageClickEventArgs e)
    {
        if (txtfilter.Text.Trim() == "") return;
        var emps = RESTAPI.filter<Empleado>("empleados", String.Format("concat_ws(' ', nombres, apellidos, correo, nacimiento, (SELECT nombre FROM departamentos d WHERE d.coddpto = empleados.coddpto)) LIKE '%{0}%' and estado = 'A'", txtfilter.Text));
        filltable(emps);
    }
}