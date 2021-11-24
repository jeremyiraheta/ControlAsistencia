<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Empleados.aspx.cs" Inherits="Empleados" %>
<%@ Register src="~/Control/emp.ascx" TagName="customEmp" TagPrefix="emp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    
     <div class="content ">
        <h3>Empleados</h3>
         <div class="row" style="padding-bottom:20px;">
             <asp:Button runat="server" CssClass="btn btn-primary col-auto" Text="Agregar" data-bs-toggle="modal" data-bs-target="#addEmp" id="btnAdd" OnClick="btnAdd_Click"/>             
         </div>

        <div class="row">
            <asp:Table ID="tblemp" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell>DEPARTAMENTO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>NOMBRES</asp:TableHeaderCell>
                    <asp:TableHeaderCell>APELLIDOS</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TELEFONO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>CORREO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>NACIMIENTO</asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/img/edit.svg" runat="server" Width="20px" Height="20px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
    </div>
    <asp:Panel ID="modalContainer" runat="server">
        <emp:customEmp ID="empcontrol" runat="server" />
    </asp:Panel>
    
</asp:Content>

