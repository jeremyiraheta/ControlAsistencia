<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Productividad.aspx.cs" Inherits="Productividad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Shuseki - Productividad</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="content ">
        <h3>Productividad</h3>
        <div class="row justify-content-between">
            <div class="col-sm-2">
                <asp:TextBox TextMode="Date" ID="filtdate" runat="server" />
            </div>
            <div style="float:right; top:-30px" class="form-floating col-sm-3"> 
                <asp:TextBox CssClass="form-control" ClientIDMode="Static" placeholder="Filtro"  ID="txtfilter" runat="server" /><label for="txtfilter">Filtrar</label><asp:ImageButton ImageUrl="~/images/icons/search.svg" ID="btnfilt" style="left:60%;" CssClass="search-btn" runat="server" OnClick="filtrar" /> 
            </div>         
        </div>         

        <div class="row">
            <asp:Table ID="tblemp" CssClass="table table-dark table-hover" runat="server" >
                <asp:TableHeaderRow runat="server">
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>DEPARTAMENTO</asp:TableHeaderCell>
                    <asp:TableHeaderCell>NOMBRES</asp:TableHeaderCell>
                    <asp:TableHeaderCell>APELLIDOS</asp:TableHeaderCell>
                    <asp:TableHeaderCell>TELEFONO</asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/images/icons/procesos.svg" runat="server" Width="20px" Height="20px" ToolTip="Procesos" /></asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/images/icons/ie.svg" runat="server" Width="20px" Height="20px" ToolTip="Navegacion" /></asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:Image ImageUrl="~/images/icons/capturas.svg" runat="server" Width="20px" Height="20px" ToolTip="Capturas" /></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
        </div>
         <div class="row d-flex">
             <ul class="pagination modal-3 justify-content-center align-items-center">
              <li><a href="/Productividad/<%=((cpage == 1) ? "1": (cpage-1).ToString()) %>" class="prev">&laquo</a></li>
                 <% for(int i=minp;i<maxp;i++)
                         Response.Write("<li><a href=\"/Productividad/" + i +"\" class=\"" + ((i == cpage) ? "active" : "") +"\">" + i +"</a></li>"); %>                           
              <li><a href="/Productividad/<%=(cpage+1).ToString() %>" class="next">&raquo;</a></li>
            </ul>
         </div>
    </div>
    <asp:Panel ID="modalContainer" runat="server">
        <div class="modal fade" id="vProd" tabindex="-1" aria-labelledby="vProd" aria-hidden="true">
            <div class="modal-dialog <%=modalsize %>">
            <div class="modal-content">
                <div class="modal-header">
                <h5 class="modal-title" id="titleLabel"><asp:Literal ID="title" runat="server" /></h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:Literal ID="popupContent" runat="server" />
                </div>                
            </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

