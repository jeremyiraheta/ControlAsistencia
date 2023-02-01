<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Subscripcion.aspx.cs" Inherits="Subscripcion" EnableEventValidation="false" %>

<!doctype html>
<html lang="en">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" type="image/ico" href="favicon.ico">

    <title>Shuseki - Subcripción al servicio</title>    

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.3/font/bootstrap-icons.css">
  </head>

  <body class="bg-light">
   <form id="form" runat="server" class="container-fluid needs-validation" novalidate>
    <div class="container">
      <div class="py-5 text-center">
        <img class="d-block mx-auto mb-4" src="/images/logo.png" alt="" width="72" height="72">
        <h2>Formulario de subcripción</h2>
        <p class="lead">Rellene el formulario con su información y la de la organización a la que pertenece.</p>
      </div>

      <div class="row">
        <div class="col-md-4 order-md-2 mb-4">
          <h4 class="d-flex justify-content-between align-items-center mb-3">
            <span class="text-muted">Plan seleccionado</span>
            <span class="badge badge-secondary badge-pill">3</span>
          </h4>
          <ul class="list-group mb-3">
            <li class="list-group-item d-flex justify-content-between lh-condensed">
              <div>
                <h6 class="my-0"><asp:Literal ID="outPlan" runat="server" /></h6>
                <small class="text-muted">Cobro Mensual</small>
              </div>
              <span class="text-muted">$<asp:Literal ID="outCobro" runat="server" /></span>
            </li>
           
            <li class="list-group-item d-flex justify-content-between bg-light">
              <div class="text-success">
                <h6 class="my-0">Promociones</h6>
                <small></small>
              </div>
              <span class="text-success">$0</span>
            </li>
            <li class="list-group-item d-flex justify-content-between">
              <span>Total (USD)</span>
              <strong>$<asp:Literal ID="outTotal" runat="server" /></strong>
            </li>
          </ul>

          
        </div>
        <div class="col-md-8 order-md-1">
          <h4 class="mb-3">Información de administrador</h4>          
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="txtnom">Nombres</label>
                  <asp:TextBox ID="txtnom" ClientIDMode="Static" pattern="\w{3,}" MaxLength="200" CssClass="form-control" required runat="server" />                
                <div class="invalid-feedback">
                  Requerido.
                </div>
              </div>
              <div class="col-md-6 mb-3">
                <label for="txtapell">Apellidos</label>
                <asp:TextBox ID="txtapell" ClientIDMode="Static" pattern="\w{3,}" MaxLength="200" CssClass="form-control" required runat="server" />
                <div class="invalid-feedback">
                  Requerido.
                </div>
              </div>
            </div>

            <div class="mb-3">
              <label for="txtusername">Nombre de usuario</label>
              <div class="input-group">
                <div class="input-group-prepend">
                  <span class="input-group-text">@</span>
                </div>
                  <asp:TextBox ID="txtusername" ClientIDMode="Static" MaxLength="50" CssClass="form-control" placeholder="Usuario de ingreso administrativo" pattern="^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$" required runat="server" />                
                <div class="invalid-feedback" style="width: 100%;">
                  Requerido, no caracteres especiales ni espacios.
                </div>
              </div>
            </div>
              <label for="txtpass">Password</label>
              <div class="mb-3">
                  <div class="input-group">                      
                      <asp:TextBox ID="txtpass" ClientIDMode="Static" type="password" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" placeholder="Ingrese password" CssClass="form-control" runat="server" required />
                      <asp:TextBox ID="txtpass2" ClientIDMode="Static" type="password" pattern="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" placeholder="Confirme password" CssClass="form-control" runat="server" required />
                      <div class="invalid-feedback">
                        Requiere mas complejidad, 8 caracteres mínimos almenos 1 letra mayúscula y 1 numero.
                      </div>
                  </div>                  
              </div>

            <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="txtemail">Email</label>
                  <asp:TextBox TextMode="Email" MaxLength="200" ID="txtemail" placeholder="micorreo@minegocio.com" CssClass="form-control input" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido correo valido.
                  </div>
                </div>
                <div class="col-md-6 mb-3">
                  <label for="txtnaci">Nacimiento</label>
                  <asp:TextBox TextMode="Date" ID="txtnaci" CssClass="form-control input" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
                </div>
            </div>
            <h4 class="mb-3">Información de Cliente</h4>
              <div class="mb-3">
                  <label for="txtclinom">Nombre de Cliente</label>
                  <asp:TextBox ID="txtclinom" ClientIDMode="Static" OnTextChanged="txtclinom_TextChanged" AutoPostBack="true" CssClass="form-control" placeholder="Ingrese el nombre de sus organización" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>
             <label for="txtcliid">Dirección de ingreso</label>
              <div class="input-group mb-3">                  
                  <span class="input-group-text" id="basic-addon3"><%= "https://" + Request.Url.Authority + "/Login/" %></span>
                  <asp:TextBox ID="txtcliid" ClientIDMode="Static" OnTextChanged="txtcliid_TextChanged" AutoPostBack="true" CssClass="form-control" MaxLength="200" placeholder="mi-negocio" runat="server" required/>
                  <i class="bi bi-check-circle" style="font-size: 2rem; padding-left: 10px; color: #1fdf25;<%=validdisplay %>" title="Dirección disponible"></i>                                 
                  <i class="bi bi bi-x-circle" style="font-size: 2rem; padding-left: 10px; color: red;<%=invaliddisplay %>" title="Dirección no disponible"></i>                           
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>

              <div class="mb-3">
                  <label for="txtnumcont">Número de contacto</label>
                  <asp:TextBox ID="txtnumcont" TextMode="Phone" ClientIDMode="Static" CssClass="form-control" MaxLength="100" placeholder="+1 223-222-4543" runat="server" required />
                  <div class="invalid-feedback">
                    Requerido.
                  </div>
              </div>
              <div class="mb-3">
                  <label for="txturl">Página web del Cliente (opcional)</label>
                  <asp:TextBox ID="txturl" TextMode="Url" ClientIDMode="Static" CssClass="form-control" MaxLength="200" placeholder="www.minegocio.com" runat="server" />
              </div>
              
              
            <div class="mb-3">
              <label for="txtdir">Dirección de negocio</label>
              <asp:TextBox ID="txtdir" ClientIDMode="Static" TextMode="MultiLine" Rows="3" MaxLength="500" placeholder="1004 Park Avenue #231" CssClass="form-control" runat="server" required />
                <div class="invalid-feedback">
                    Requerido.
                </div>              
            </div>            

            <div class="row">
              <div class="col-md-5 mb-3">
                <label for="country">País</label>
                  <asp:DropDownList ID="country" ClientIDMode="Static" runat="server" required>
                      <asp:ListItem Text="Seleccione" Value="" />
                  </asp:DropDownList>                                      
                <div class="invalid-feedback">
                  Seleccione un pais.
                </div>
              </div>              
            </div>
            
            <h4 class="mb-3">Pago</h4>

            <div class="d-block my-3">
              <div class="custom-control custom-radio">
                <input id="credit" name="paymentMethod" type="radio" class="custom-control-input" checked required>
                <label class="custom-control-label" for="credit">Tarjeta de crédito</label>
              </div>
              <div class="custom-control custom-radio" style="display:none;">
                <input id="debit" name="paymentMethod" type="radio" class="custom-control-input" required>
                <label class="custom-control-label" for="debit">Tarjeta de débito</label>
              </div>
              <div class="custom-control custom-radio" style="display:none;">
                <input id="paypal" name="paymentMethod" type="radio" class="custom-control-input" required>
                <label class="custom-control-label" for="paypal">Paypal</label>
              </div>
            </div>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="ccname">Nombre de tarjeta</label>
                  <asp:TextBox MaxLength="200" ID="ccname" placeholder="" pattern="\w{3,}" CssClass="form-control input" runat="server" required />                            
                <div class="invalid-feedback">
                  Requerido
                </div>
              </div>
              <div class="col-md-6 mb-3">
                <label for="ccnumber">Numero de tarjeta</label>                
                  <asp:TextBox ID="ccnumber" placeholder="" pattern="\d{16}" MaxLength="16" CssClass="form-control input" runat="server" required />
                <div class="invalid-feedback">
                  Requerido
                </div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="ccexpiration">Expiración</label>                
                  <asp:TextBox MaxLength="5" ID="ccexpiration" placeholder="00/00" pattern="\d{2}\/\d{2}" CssClass="form-control input" runat="server" required />
                <div class="invalid-feedback">
                  Requerido
                </div>
              </div>
              <div class="col-md-3 mb-3">
                <label for="cccvv">CVV</label>                
                  <asp:TextBox MaxLength="3" ID="cccvv" placeholder="000" CssClass="form-control input" runat="server" required />
                <div class="invalid-feedback">
                  Requerido
                </div>
              </div>
            </div>
            <hr class="mb-4">
              <asp:Button ID="pagar" CssClass="btn btn-primary btn-lg" Text="Pagar" runat="server" OnClick="pagar_Click" />                      
        </div>
      </div>

      <footer class="my-5 pt-5 text-muted text-center text-small">
        <p class="mb-1">&copy; <%=DateTime.Now.Year %> Shuseki</p>        
      </footer>

        <div class="modal fade" id="alert" tabindex="-1" role="dialog" aria-labelledby="alertTitle" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="alertTitle"><asp:Literal ID="alerttitle" runat="server" /></h5>                
              </div>
              <div class="modal-body">
                <asp:Literal ID="alertmsg" runat="server" />
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-secondary" onclick="$('#alert').modal('hide')">OK</button>                
              </div>
            </div>
          </div>
        </div>
    </div>
       </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script>window.jQuery || document.write('<script src="../../assets/js/vendor/jquery-slim.min.js"><\/script>')</script>
    <script src="../../assets/js/vendor/popper.min.js"></script>
    <script src="../../dist/js/bootstrap.min.js"></script>
    <script src="../../assets/js/vendor/holder.min.js"></script>
    <script>
      // Example starter JavaScript for disabling form submissions if there are invalid fields
      (function() {
        'use strict';

        window.addEventListener('load', function() {
          // Fetch all the forms we want to apply custom Bootstrap validation styles to
          var forms = document.getElementsByClassName('needs-validation');

          // Loop over them and prevent submission
          var validation = Array.prototype.filter.call(forms, function(form) {
            form.addEventListener('submit', function(event) {
              if (form.checkValidity() === false) {
                event.preventDefault();
                event.stopPropagation();
              }
              form.classList.add('was-validated');
            }, false);
          });
        }, false);
      })();
    </script>
  </body>
</html>

