<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Permisos.aspx.cs" Inherits="Permisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
   <div class="content ">
        <h3>Permisos</h3>
         <div class="row" style="padding-bottom:20px;">             
             <asp:Button runat="server" CssClass="btn btn-primary col-auto" Text="Agregar" data-bs-toggle="modal" data-bs-target="#addPerm" id="btnAdd"/>             
         </div>

        <div class="row">
            <asp:Table ID="tblemp" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell>EMPLEADO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>FECHA</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TIPO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>ESTADO</asp:TableHeaderCell>                    
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/img/edit.svg" runat="server" Width="20px" Height="20px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
    </div>
</asp:Content>

