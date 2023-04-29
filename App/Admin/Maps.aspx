<%@ Page Title="" Language="C#"  %>

<!DOCTYPE html>

<html>
<head>
    <title>Mapa de Google Maps con marcador</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style/maps.css" />   
    
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBfruvzXDcWasgbxlqyFBZVebK_roPdr4U"></script>
    <script>
        function initMap() {

            

            var lati = parseFloat('<%= Request["lati"] %>');
            var longi = parseFloat('<%= Request["longi"] %>');
            var myLatLng = { lat: lati, lng: longi };
            var marcador = '<%= Request["direccion"] %>'


            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 15,
                center: myLatLng
            });

            var marker = new google.maps.Marker({
                position: myLatLng,
                map: map,
                title: marcador
            });
        }
    </script>
</head>
<body  onload="initMap()">
    <div class="content">
     <h2>MAPA DE UBICACION</h2>
    
    <div id="map" style="width:100%; height:400px;"></div>
     <h4>Registro ubicacion <%= Request["iniofin"] %></h4>
    <p></p>
    <p>Usuario: <%= Request["direccion"] %></p>
    <p>Direccion <%= Request["direccion"] %></p>
    <p>Fecha del registro: <%= Request["fecha"] %></p>
    </div>

</body>
</html>