<%@ Page Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    
    <title>Shuseki - Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div class="helper" style="top: 80%">
        
        <h3>Dashboard</h3>
        <div class="container" style="min-width: 1400px;">
            <div class="row">
                <% if (isclientes)
                    { %>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="planes" style="width:100%;height:100%"></canvas>
                </div>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="ganacias" style="width:100%;height:100%"></canvas>
                </div>
                <%}
    else
    { %>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="horasXdia" style="width:100%;height:100%"></canvas>
                </div>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="horasXmes" style="width:100%;height:100%"></canvas>
                </div>
            </div>
            <div class="row" style="padding-top:20px;">
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="permisoXmes" style="width:100%;height:100%"></canvas>
                </div>
                <div class="col" style="min-width:600px;min-height:600px;">
                        <canvas id="horasxemp" style="width:100%;height:100%"></canvas>
                </div>
                <%} %>
            </div>
        </div>
    </div> 

    <script>
        var xValues0 = ["Sin Plan", "Startup", "PYME", "Premium"];
    var yValues0 = [<%=planes %>];
    var barColors0 = [<%=planesColors %>];

    new Chart("planes", {
      type: "pie",
      data: {
        labels: xValues0,
        datasets: [{
          backgroundColor: barColors0,
          data: yValues0
        }]
      },
      options: {
        title: {
          display: true,
          text: "Planes"
        }
      }
    });
</script>
    <script>
var xValues = ["Startup", "PYME", "Premium"];
var yValues = [<%=ganacias %>];
var barColors = [<%=ganaciasColors %>];

        new Chart("ganacias", {
  type: "bar",
  data: {
    labels: xValues,
    datasets: [{
      backgroundColor: barColors,
      data: yValues
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: "Ganancias"
    }
  }
});
</script>
    <script>
    var xValues1 = ["Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado", "Domingo"];
    var yValues1 = [<%=mediaSemana %>];
    var barColors1 = [<%=mediaSColors %>];

    new Chart("horasXdia", {
      type: "pie",
      data: {
        labels: xValues1,
        datasets: [{
          backgroundColor: barColors1,
          data: yValues1
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
    var xValues2 = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
    var yValues2 = [<%=mediaMes %>];
    var barColors2 = [<%=mediaMColors %>];

    new Chart("horasXmes", {
      type: "pie",
      data: {
        labels: xValues2,
        datasets: [{
          backgroundColor: barColors2,
          data: yValues2
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

    <script>
var xValues3 = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];
var yValues3 = [<%=mediaPermisos %>];
var barColors3 = [<%=mediaPColors %>];

        new Chart("permisoXmes", {
  type: "bar",
  data: {
    labels: xValues3,
    datasets: [{
      backgroundColor: barColors3,
      data: yValues3
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: "Permisos por mes"
    }
  }
});
</script>

    <script>
var xValues3 = [<%=nombres %>];
var yValues3 = [<%=valores %>];
var barColors3 = [<%=mediaPColors %>];

new Chart("horasxemp", {
  type: "bar",
  data: {
    labels: xValues3,
    datasets: [{
      backgroundColor: barColors3,
      data: yValues3
    }]
  },
  options: {
    legend: {display: false},
    title: {
      display: true,
      text: "5 Empleados con menos horas registradas"
    }
  }
});
</script>

       
</asp:Content>

