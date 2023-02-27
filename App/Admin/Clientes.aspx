<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Clientes.aspx.cs" Inherits="Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Shuseki - Clientes</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">

    <div class="content ">
        <h3>Clientes</h3>
         <div style="float:right; top:-30px" class="form-floating"><asp:TextBox CssClass="form-control" ClientIDMode="Static" placeholder="Filtro"  ID="txtfilter" runat="server" /><label for="txtfilter">Filtrar</label><asp:ImageButton ImageUrl="~/images/icons/search.svg" ID="btnfilt" CssClass="search-btn" runat="server" OnClick="filtrar" /> </div>
         <div class="row" style="padding-bottom:20px;">
             <asp:Button runat="server" CssClass="btn btn-light col-auto" Text="Mostrar Inactivos"  id="btntoggle" OnClick="btntoggle_Click"/>             
         </div>
        <div class="row">
            <asp:Table ID="tblcli" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow Visible="true" runat="server">
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>NOMBRE</asp:TableHeaderCell>
                    <asp:TableHeaderCell>URLNOM</asp:TableHeaderCell>
                    <asp:TableHeaderCell>CORREO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TELEFONO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>PAIS</asp:TableHeaderCell>
                    <asp:TableHeaderCell>PLAN</asp:TableHeaderCell>
                    <asp:TableHeaderCell>VENCE</asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/images/icons/edit.svg" runat="server" Width="20px" Height="20px" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
         <div class="row d-flex">
             <ul class="pagination modal-3 justify-content-center align-items-center">
              <li><a href="/Clientes/<%=((cpage == 1) ? "1": (cpage-1).ToString()) %>" class="prev">&laquo</a></li>
                 <% for(int i=minp;i<maxp;i++)
                         Response.Write("<li><a href=\"/Clientes/" + i +"\" class=\"" + ((i == cpage) ? "active" : "") +"\">" + i +"</a></li>"); %>                           
              <li><a href="/Clientes/<%=(cpage+1).ToString() %>" class="next">&raquo;</a></li>
            </ul>
         </div>
    </div>
</asp:Content>

