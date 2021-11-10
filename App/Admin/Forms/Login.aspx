<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Forms_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <style>
        label{
            padding:10px;
            margin:30px;            
        }       
        div{
            padding:10px;
        } 
        #btnLogin{
            margin:20px 200px;
        }
    </style>
    <form id="form1" runat="server">
    <div style="display:block; padding: 20px;">

        <h1>Login</h1>
        <table>
            <tr><td><label for="txtuser" >Usuario: </label></td><td><asp:TextBox ID="txtuser" runat="server" /></td></tr>
            <tr><td><label for="txtpass" >Password: </label></td><td><asp:TextBox ID="txtpass" runat="server" TextMode="Password" /></td></tr>
        </table>
        <div>
            <asp:Button ID="btnLogin" runat="server" Text="Logear" OnClick="btnLogin_Click" />
        </div>
        <div>
            <asp:Literal ID="response" runat="server" />
    </div>
        <div>
            <%
                if(Session.Count > 0)
                if ((bool)Session["logged"])
                {

                 %>
            <asp:TextBox ID="txtnombre" runat="server" placeholder ="Nombre del departamento" />
            <asp:Button ID="btnAdd" runat="server" Text="Agregar nuevo departamento" BorderStyle="Groove" OnClick="btnAdd_Click" />
            <%
                } %>
        </div>
    </form>
</body>
</html>
