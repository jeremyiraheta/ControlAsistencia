<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Registros.aspx.cs" Inherits="Registros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="content ">
        <h3>Registros</h3>
       <div style="float:right"><asp:TextBox TextMode="Month" ID="txtfilter" runat="server" AutoPostBack="true" OnTextChanged="txtfilter_TextChanged" /></div>    
        <div class="row" style="padding:30px;"><input type="button" class="btn btn-toolbar btn-outline-primary" style="width:100px;" value="Reporte" onclick="reporte()" /></div>   
        <div class="row">
            <asp:Table ID="tblreg" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell>DEPARTAMENTO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>EMPLEADO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>HORAS</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/images/icons/edit.svg" runat="server" Width="20px" Height="20px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
    </div>
    <div class="modal fade" id="detReg" tabindex="-1" aria-labelledby="detReg" aria-hidden="true">        
        <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title" id="titleLabel">Detalle Horas</h5>
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
                        <asp:Table ID="tbldet" CssClass="table table-striped" runat="server" >
                            <asp:TableHeaderRow runat="server">                                
                                <asp:TableHeaderCell>FECHA</asp:TableHeaderCell>                                
                                <asp:TableHeaderCell>ENTRADA</asp:TableHeaderCell>                    
                                <asp:TableHeaderCell>SALIDA</asp:TableHeaderCell>                                
                                <asp:TableHeaderCell>HORAS</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>                                                                                                                                                 
                </div>
            </div>
            <div class="modal-footer">                                     
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
            </div>
        </div>
        </div>
    </div>
</asp:Content>

