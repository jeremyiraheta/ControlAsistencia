<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Departamentos.aspx.cs" Inherits="Departamentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Shuseki - Departamentos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="content ">
        <h3>Departamentos</h3>
        <div class="row">
            <label for="txtdpto" style="width:0px">Nombre</label>
        </div>
        <div class="row">
            <div class="col-9">
                <asp:TextBox ID="txtdpto" CssClass="form-control" runat="server"/>                
            </div>
            <div class="col-3">
                <asp:Button CssClass="btn btn-primary" ID="btnAdd" runat="server" Text="Crear" OnClick="btnAdd_Click" />
            </div>
        </div>
        <div class="row" style="padding:30px;">
            <ul class="nav nav-tabs">
                <asp:Literal ID="ltabs" runat="server" />              
            </ul>
        </div>
        <div class="row">
            <table class="table table-dark table-hover">
                <thead>
                    <tr>
                      <th scope="col">ID</th>
                      <th scope="col">NOMBRES</th>
                      <th scope="col">APELLIDOS</th>                      
                    </tr>
                  </thead>
                <tbody id="table">
                    <asp:Literal ID="tbldpto" runat="server" />
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>

