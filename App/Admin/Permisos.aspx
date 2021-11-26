<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="Permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
   <div class="content ">
        <h3>Permisos</h3>
       <div style="float:right"><asp:TextBox TextMode="Month" ID="txtfilter" runat="server" AutoPostBack="true" OnTextChanged="txtfilter_TextChanged" /></div>  
       <asp:HiddenField ID="curstate" runat="server" Value="0" />      
       <div class="row" style="padding:30px;">
            <ul class="nav nav-tabs">
                 <li class='nav-item'>
                    <span style='display:flex;'><asp:LinkButton ID="linkPend" CssClass="nav-link active" Text="Espera" runat="server" OnClick="linkPend_Click" /></span>
                 </li>
                 <li class='nav-item'>
                    <span style='display:flex;'><asp:LinkButton ID="linkAprob" CssClass="nav-link" Text="Aprobados" runat="server" OnClick="linkAprob_Click" /></span>
                 </li>
                <li class='nav-item'>
                    <span style='display:flex;'><asp:LinkButton ID="linkRecha" CssClass="nav-link" Text="Rechazados" runat="server" OnClick="linkRecha_Click" /></span>
                 </li>     
            </ul>
        </div>
        <div class="row">
            <asp:Table ID="tblperm" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell>EMPLEADO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>FECHA</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TIPO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>INICIA</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell>FINALIZA</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/img/edit.svg" runat="server" Width="20px" Height="20px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
    </div>
    <div class="modal fade" id="verPerm" tabindex="-1" aria-labelledby="verPerm" aria-hidden="true">
        <asp:HiddenField ID="hcodper" runat="server" />
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title" id="titleLabel">Ver Permiso</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                   <div class="row">
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text bg-info">Empleado</span>
                          <asp:TextBox ReadOnly="true" ID="txtnom" MaxLength="200" placeholder="Nombres" CssClass="form-control input" runat="server" />
                          <asp:TextBox ReadOnly="true" ID="txtape" MaxLength="200" placeholder="Apellidos" CssClass="form-control input" runat="server" />
                        </div>
                    </div>                    
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text bg-info" id="basic-addon3">Fecha</span>
                          <asp:TextBox ReadOnly="true" ClientIDMode="Static" ID="txtDate" CssClass="form-control input" runat="server" />
                        </div>
                    </div>       
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text bg-info" id="basic-hi">Hora Inicial</span>
                          <asp:TextBox ReadOnly="true" TextMode="Time" ClientIDMode="Static" ID="txthi" CssClass="form-control input" runat="server" />
                        </div>
                    </div> 
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text bg-info" id="basic-hf">Hora Final</span>
                          <asp:TextBox ReadOnly="true" TextMode="Time" ClientIDMode="Static" ID="txthf" CssClass="form-control input" runat="server" />
                        </div>
                    </div>                                     
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <label class="input-group-text bg-info" for="inputGroupSelect01">Tipo</label>
                          <asp:DropDownList id="cmbTipo" Enabled="false" runat="server" CssClass="form-select select">
                              <asp:ListItem Text ="Particular" Value="P" />
                              <asp:ListItem Text="Salud" Value="S" />
                              <asp:ListItem Text="Oficial" Value="O" />
                          </asp:DropDownList>                      
                        </div>
                    </div>
                    <hr style="height:0px;" />
                    <div class="col-12">
                        <div class="input-group">
                          <span class="input-group-text bg-info" id="basic-addon5">Descripci&oacute;n</span>
                          <asp:TextBox ReadOnly="true" TextMode="MultiLine" MaxLength="500" Rows="2" ID="txtdesc" CssClass="form-control input" runat="server" />
                        </div>
                    </div>                   
                </div>
            </div>
            <div class="modal-footer">
            <span style="left:0px;position:absolute;margin: 10px;"><asp:Literal ID="linkdownload" runat="server" /></span>                          
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>                      
            <asp:Button ID="btnAprob" Text="Aprobar" CssClass="btn btn-success" OnClick="aprobar" runat="server" />
            <asp:Button ID="btnRech" Text="Rechazar" CssClass="btn btn-danger" OnClick="rechazar" runat="server" />   
            </div>
        </div>
        </div>
    </div>
</asp:Content>

