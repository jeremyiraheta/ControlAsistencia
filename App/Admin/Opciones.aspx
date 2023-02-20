<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Opciones.aspx.cs" Inherits="Opciones" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script>
    function previewImage(event) {
        var input = event.target;
        var preview = document.getElementById("btnimg");
        var reader = new FileReader();

        reader.onload = function () {
            preview.src = reader.result;
        }

        reader.readAsDataURL(input.files[0]);
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">    
    <div class="content" style="text-align:left;">
        <h3 style="text-align:center">Opciones</h3> 
        <div class="row">
             <div class="col-md-6 mb-3">
                  <label for="txtclinom">Nombre de Cliente</label>
                  <asp:TextBox ID="txtclinom" ClientIDMode="Static" OnTextChanged="txtclinom_TextChanged" AutoPostBack="true" CssClass="form-control" placeholder="Ingrese el nombre de sus organización" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>
            <div class="col-md-6 mb-3">
                <label for="txtcliid">Dirección de ingreso</label>
              <div class="input-group">                  
                  <span class="input-group-text" id="basic-addon3"><%="https://" + Request.Url.Authority + "/Login/"%></span>
                  <asp:TextBox ID="txtcliid" ClientIDMode="Static" OnTextChanged="txtcliid_TextChanged" AutoPostBack="true" CssClass="form-control" MaxLength="200" placeholder="mi-negocio" runat="server" required/>
                  <i class="bi bi-check-circle" style="font-size: 2rem; padding-left: 10px; color: #1fdf25;<%=validdisplay %>" title="Dirección disponible"></i>                                 
                  <i class="bi bi bi-x-circle" style="font-size: 2rem; padding-left: 10px; color: red;<%=invaliddisplay %>" title="Dirección no disponible"></i>                           
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>
            </div>             
        </div>       
             
        <div class="row">
            <div class="col-md-6 mb-3">
                  <label for="txtnumcont">Número de contacto</label>
                  <asp:TextBox ID="txtnumcont" TextMode="Phone" ClientIDMode="Static" CssClass="form-control" MaxLength="100" placeholder="+1 223-222-4543" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>
            <div class="col-md-6 mb-3">
                  <label for="txtemail">Email de contacto</label>
                  <asp:TextBox TextMode="Email" MaxLength="200" ID="txtemail" placeholder="micorreo@minegocio.com" CssClass="form-control input" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido correo valido.
                  </div>
              </div>
        </div>
        <div class="row" >
            <div class="col-md-6 mb-3">
                <label for="txturl">Página web del Cliente (opcional)</label>
                <asp:TextBox ID="txturl" ClientIDMode="Static" CssClass="form-control" MaxLength="200" placeholder="www.minegocio.com" runat="server" />
            </div>
              
            <div class="col-md-6 mb-3">
                <label for="ddlTimeZones">Zona horaria</label>
                <asp:DropDownList ID="ddlTimeZones" CssClass="form-control" runat="server" />
            </div>
        </div>
              
              
             <div class="row">
                 <div class="col-md-2 mb-3">
                  <label for="btnimg">Logo</label>                      
                     <asp:Image ID="btnimg" ClientIDMode="Static" CssClass="form-control cursor-pointer" ImageUrl="~/Logos.ashx" runat="server" Height="200" Width="200"  AlternateText="Click para seleccionar imagen" ToolTip="Click para seleccionar imagen" onclick="$('#ulogo').trigger('click');" />                                         
                     <asp:FileUpload ID="ulogo" ClientIDMode="Static" AllowMultiple="false"  runat="server" style="display:none;" accept=".jpg,.jpeg,.png,.webp" onchange="previewImage(event)" />                                
              </div>
                <div class="mb-3 col-md-10">
                  <label for="txtdir">Dirección de negocio</label>
                  <asp:TextBox ID="txtdir" ClientIDMode="Static" TextMode="MultiLine" Rows="3" MaxLength="500" placeholder="1004 Park Avenue #231" CssClass="form-control" runat="server" required />
                    <div class="invalid-feedback">
                        Requerido.
                    </div> 
                    <div class="row">
                         <div class="col-md-3 mb-3 form-check" style="margin-top:30px;">                    
                            <asp:CheckBox ID="chkpant" ClientIDMode="Static" CssClass="form-check-inline" runat="server" />
                            <label for="chkpant" class="form-check-inline">Capturar Pantalla</label>
                        </div>
                        <div class="col-md-3 mb-3 form-check" style="margin-top:30px;">                    
                            <asp:CheckBox ID="chkpross" ClientIDMode="Static" CssClass="form-check-inline" runat="server" />
                            <label for="chkpross" class="form-check-inline">Capturar Procesos</label>
                        </div>
                        <div class="col-md-3 mb-3 form-check" style="margin-top:30px;">                    
                            <asp:CheckBox ID="chknav" ClientIDMode="Static" CssClass="form-check-inline" runat="server" />
                            <label for="chknav" class="form-check-inline">Capturar Navegación</label>
                        </div> 
                     </div>             
                </div> 
                           
            </div>
            
            <div class="row">                
              <div class="col-md-2 mb-3">                  
                  <label for="pcolor">Fondo Login</label>                  
                  <asp:TextBox TextMode="Color" CssClass="form-control form-control-color" ID="pickcolor" runat="server"  title="Seleccione un color para el fondo del login" />                  
              </div>
                <div class="col-md-2 mb-3">
                    <label for="country">País</label>
                      <asp:DropDownList ID="country" CssClass="form-control" ClientIDMode="Static" runat="server" required>
                          <asp:ListItem Text="Seleccione" Value="" />
                      </asp:DropDownList>                                      
                    <div class="invalid-feedback">
                      Seleccione un pais.
                    </div>
              </div>              
                <div class="col-md-4 mb-3" >
                    <label for="chkpant" style="form-control">Intervalo de captura (minutos)</label>                    
                    <asp:TextBox ID="txtint" ClientIDMode="Static" CssClass="form-control" MaxLength="4" TextMode="Number" runat="server" title="Seleccione cada cuanto se intentara capturar información de productividad" max="1440" min="5"/>
                    <asp:RangeValidator runat="server" ControlToValidate="txtint" ErrorMessage="El rango de valores es 5-1440" Type="Integer" MinimumValue="5" MaximumValue="1440" ForeColor="Red" />
                    
                </div> 
                <div class="col-md-4 mb-3" >
                    <label for="chkpant" style="form-control">Probabilidad de captura (%)</label>                    
                    <asp:TextBox ID="txtprob" ClientIDMode="Static" CssClass="form-control" MaxLength="6" TextMode="Number" step="0.10" runat="server" title="Seleccione la propablidad de capturar productividad" max="100.00" min="0.0" />
                    <asp:RangeValidator runat="server" ControlToValidate="txtprob" ErrorMessage="El rango de valores es 0-100" Type="Double" MinimumValue="0" MaximumValue="100" ForeColor="Red" />
                    
                </div>                
            </div>
        <div class="row">
            <div class="col-md-4 mb-3">
                <label for="country">Plan a Renovar</label>
                  <asp:DropDownList ID="plan" CssClass="form-control" ClientIDMode="Static" runat="server">                      
                  </asp:DropDownList> 
            </div>
            <div class="col-md-4 mb-3">
                <label for="txtfin">Renovación</label>
                <asp:TextBox ID="txtfin" ClientIDMode="Static" CssClass="form-control" TextMode="DateTime" runat="server" ReadOnly="true" />
            </div>
            <div class="col-md-4 mb-3" style="margin-top:25px;">
                <asp:Button CssClass="form-control btn-secondary btn" Text="Guardar" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            </div>
        </div>
    </div>    
</asp:Content>

