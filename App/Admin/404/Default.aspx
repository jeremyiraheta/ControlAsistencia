<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_404_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="404.css" rel="stylesheet" type="text/css" />
    <title>Error 404</title>
</head>
<body>
    <form id="form1" runat="server">
    <main class="bsod container">
      <h1 class="neg title"><span class="bg">Error - 404</span></h1>
      <p>Ocurrio un error pagina no encontrada:</p>
      <p>* Regresa a la pagina principal.<br />
      * Envianos un correo de consulta.</p>
      <nav class="nav">
          <%if (Request.UrlReferrer != null)
              {%>
        <a href="<%=Request.UrlReferrer.AbsolutePath %>" class="link">Regresar</a>
          <%}
    else
    { %>
        <a href="/" class="link">Regresar</a>
          <%} %>
      </nav>
    </main>
    </form>
</body>
</html>
