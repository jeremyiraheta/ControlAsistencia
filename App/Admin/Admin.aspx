<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    
    <title>Shuseki - Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="helper">
        
        <h3>Dashboard</h3>
        <div class="container" style="min-width: 1400px;">
            <div class="row">
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="horasXdia" style="width:100%;height:100%"></canvas>
                </div>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="horasXmes" style="width:100%;height:100%"></canvas>
                </div>
            </div>
        </div>
    </div> 
    <script>
    var xValues = ["Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"];
    var yValues = [<%=mediaSemana %>];
    var barColors = [<%=mediaSColors %>];

    new Chart("horasXdia", {
      type: "pie",
      data: {
        labels: xValues,
        datasets: [{
          backgroundColor: barColors,
          data: yValues
        }]
      },
      options: {
        title: {
          display: true,
          text: "Media de horas laboradas por dia esta semana"
        }
      }
    });
</script>
    <script>
    var xValues = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    var yValues = [<%=mediaMes %>];
    var barColors = [<%=mediaMColors %>];

    new Chart("horasXmes", {
      type: "pie",
      data: {
        labels: xValues,
        datasets: [{
          backgroundColor: barColors,
          data: yValues
        }]
      },
      options: {
        title: {
          display: true,
          text: "Media de horas laboradas por mes"
        }
      }
    });
</script>
       
</asp:Content>

