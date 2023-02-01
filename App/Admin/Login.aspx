<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Forms_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login Sistema Administrativo - Control Asistencia Remota</title>
<style>
    @import url(https://fonts.googleapis.com/css?family=Open+Sans:100,300,400,700);
body, html {
  height: 100%;
}

body {
  font-family: "Open Sans";
  font-weight: 100;
  display: flex;
  overflow: hidden;
  background: url(../img/background.png);
}

input ::-webkit-input-placeholder {
  color: rgba(255, 255, 255, 0.7);
}
input ::-moz-placeholder {
  color: rgba(255, 255, 255, 0.7);
}
input :-ms-input-placeholder {
  color: rgba(255, 255, 255, 0.7);
}
input:focus {
  outline: 0 transparent solid;
}
input:focus ::-webkit-input-placeholder {
  color: rgba(0, 0, 0, 0.7);
}
input:focus ::-moz-placeholder {
  color: rgba(0, 0, 0, 0.7);
}
input:focus :-ms-input-placeholder {
  color: rgba(0, 0, 0, 0.7);
}
.logo{
    max-height:200px;
    max-width: 200px;
    align-content:center;
}
.result{
    color:red;
    font: bold 20px;
}
.login-form {
  min-height: 10rem;
  margin: auto;
  max-width: 50%;
  padding: 0.5rem;
}

.login-text {
  color: white;
  font-size: 1.5rem;
  margin: 0 auto;
  max-width: 50%;
  padding: 0.5rem;
  text-align: center;
}
.login-text .fa-stack-1x {
  color: black;
}

.login-username, .login-password {
  background: transparent;
  border: 0 solid;
  border-bottom: 1px solid rgba(255, 255, 255, 0.5);
  color: white;
  display: block;
  margin: 1rem;
  padding: 0.5rem;
  transition: 250ms background ease-in;
  width: calc(100% - 3rem);
}
.login-username:focus, .login-password:focus {
  background: white;
  color: black;
  transition: 250ms background ease-in;
}

.login-forgot-pass {
  bottom: 0;
  color: white;
  cursor: pointer;
  display: block;
  font-size: 75%;
  left: 0;
  opacity: 0.6;
  padding: 0.5rem;
  position: absolute;
  text-align: center;
  width: 100%;
}
.login-forgot-pass:hover {
  opacity: 1;
}

.login-submit {
  border: 1px solid white;
  background: transparent;
  color: white;
  display: block;
  margin: 1rem auto;
  min-width: 1px;
  padding: 0.25rem;
  transition: 250ms background ease-in;
}
.login-submit:hover, .login-submit:focus {
  background: white;
  color: black;
  transition: 250ms background ease-in;
}

[class*=underlay] {
  left: 0;
  min-height: 100%;
  min-width: 100%;
  position: fixed;
  top: 0;
}

.underlay-photo {
  -webkit-animation: hue-rotate 6s infinite;
          animation: hue-rotate 6s infinite;  
  background-size: cover;
  -webkit-filter: grayscale(30%);
  z-index: -1;
}

.underlay-black {
  background: rgba(0, 0, 0, 0.7);
  z-index: -1;
}

@-webkit-keyframes hue-rotate {
  from {
    -webkit-filter: grayscale(30%) hue-rotate(0deg);
  }
  to {
    -webkit-filter: grayscale(30%) hue-rotate(360deg);
  }
}

@keyframes hue-rotate {
  from {
    -webkit-filter: grayscale(30%) hue-rotate(0deg);
  }
  to {
    -webkit-filter: grayscale(30%) hue-rotate(360deg);
  }
}
</style>
</head>
<body>
   <form class="login-form" runat="server">
  <%       
      if (cliente != null && cliente.attch)
      {
          Response.Write("<img src='" + GlobalV.URLBASE + "/img/logo/codcli/" + cliente.codcli + ".webp' class='logo' />");
      }
      else
      {
          Response.Write("<img src='/images/footer-logo.png' class='logo' />");
      }  %>
  <asp:TextBox  CssClass="login-username" ID="txtuser" autofocus="true" required="true" placeholder="Usuario" runat="server" />
  <asp:TextBox  TextMode="Password" CssClass="login-password" ID="txtpass" required="true" placeholder="Password" runat="server" />
  <asp:Button name="Login" Text="Login" CssClass="login-submit" runat="server" OnClick="btnLogin_Click" />
  <div class="result"><asp:Literal ID="msg" runat="server" /></div>
</form>
<div class="underlay-photo"></div>
<div class="underlay-black"></div> 
</body>
</html>
