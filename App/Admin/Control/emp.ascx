<%@ Control Language="C#" AutoEventWireup="true" CodeFile="emp.ascx.cs"  Inherits="Control_emp" %>
<div class="modal fade" id="addEmp" tabindex="-1" aria-labelledby="addEmp" aria-hidden="true">
    <div class="modal-dialog">
    <div class="modal-content">
        <div class="modal-header">
        <h5 class="modal-title" id="titleLabel"><asp:Literal ID="title" runat="server" /></h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
               <div class="row">
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text">Nombre y Apellido</span>
                      <asp:TextBox ID="txtnom" MaxLength="200" placeholder="Nombres" CssClass="form-control input" runat="server" />
                      <asp:TextBox ID="txtape" MaxLength="200" placeholder="Apellidos" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text" id="basic-addon1">Telefonos</span>
                      <asp:TextBox ID="txttel" ClientIDMode="Static" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text" id="basic-addon2">E-Correo</span>
                      <asp:TextBox TextMode="Email" MaxLength="50" ID="txtemail" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text" id="basic-addon3">Nacimiento</span>
                      <asp:TextBox TextMode="Date" ClientIDMode="Static" ID="txtDate" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">  
                      <span class="input-group-text" id="basic-gen">Genero</span>                 
                      <asp:RadioButtonList ID="rdoGen" CssClass="form-control" RepeatDirection="Horizontal" runat="server">
                          <asp:ListItem Selected="True" Text="Masculino" Value="M" />
                          <asp:ListItem Selected="False" Text="Femenino" Value="F" />
                      </asp:RadioButtonList>
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text" id="basic-addon4">Documentaci&oacute;n</span>
                      <asp:TextBox ID="txtdui" ClientIDMode="Static" placeholder="DUI" MaxLength="10" CssClass="form-control input" runat="server" />
                      <asp:TextBox ID="txtnit" ClientIDMode="Static" placeholder="NIT" MaxLength="17" CssClass="form-control input" runat="server" />
                      <asp:TextBox ID="txtafp" ClientIDMode="Static" placeholder="AFP" MaxLength="12" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <label class="input-group-text" for="inputGroupSelect01">Departamento</label>
                      <asp:DropDownList id="cmbDptos" runat="server" CssClass="form-select select">
                      </asp:DropDownList>                      
                    </div>
                </div>
                <hr style="height:0px;" />
                <div class="col-12">
                    <div class="input-group">
                      <span class="input-group-text" id="basic-addon5">Direcci&oacute;n</span>
                      <asp:TextBox TextMode="MultiLine" MaxLength="500" Rows="2" ID="txtdir" CssClass="form-control input" runat="server" />
                    </div>
                </div>
                <%
                    if (!this.editing)
                    {
                     %>
                   <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text">Usuario</span>
                          <asp:TextBox ID="txtuser" MaxLength="50" CssClass="form-control input" runat="server" />                      
                        </div>
                    </div>
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text">Password</span>
                          <asp:TextBox ID="txtpass" TextMode="Password" ClientIDMode="Static" placeholder="Ingrese password" CssClass="form-control input" runat="server" />
                          <asp:TextBox ID="txtpass2" TextMode="Password" ClientIDMode="Static" placeholder="Confirme password" CssClass="form-control input" runat="server" />
                        </div>
                    </div>
                   <%} %>
            </div>
        </div>
        <div class="modal-footer">
        <asp:HiddenField ID="codemp" runat="server" Value="0" /> 
        <span class="text-danger" style="left:0px;position:absolute;margin: 10px;" id="msgerror"></span> 
        <% if (this.editing)
            { %>
                <asp:Button ID="btnDisable" CssClass="btn btn-danger" runat="server" Text="Desactivar" OnClick="desactivar" />
        <%  } %>       
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary" Text="Guardar" runat="server" OnClientClick="return validateEmp();" OnClick="guardar" />            
        </div>
    </div>
    </div>
</div>

