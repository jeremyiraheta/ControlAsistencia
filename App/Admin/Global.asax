<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Interfaz" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition(
             "jquery",
             new ScriptResourceDefinition
             {
                 Path = "/js/jquery-3.6.0.min.js",
                 CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js",
                 CdnSupportsSecureConnection = true,
                 LoadSuccessExpression = "jQuery"
             });
        RegistrarRutas(RouteTable.Routes);
        Datos.apiLocal();
        GlobalV.URLBASE = Datos.APIURL;        
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Código que se ejecuta al cerrarse la aplicación

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Código que se ejecuta al iniciarse una nueva sesión

    }

    void Session_End(object sender, EventArgs e)
    {
        // Código que se ejecuta cuando finaliza una sesión. 
        // Nota: el evento Session_End se produce solamente con el modo sessionstate
        // se establece como InProc en el archivo Web.config. Si el modo de sesión se establece como StateServer
        // o SQLServer, el evento no se produce.

    }

    void RegistrarRutas(RouteCollection route)
    {
        route.MapPageRoute("Login", "Login/{urlnom}", "~/Login.aspx");
        route.MapPageRoute("LoginEx", "Login", "~/Login.aspx");
        route.MapPageRoute("Admin", "Admin", "~/Admin.aspx");
    }

</script>
