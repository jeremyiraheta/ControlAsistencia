const DEBUG = process.env.DEBUG || true;
var mysql = require('mysql');
var connection = mysql.createConnection({
   host: 'localhost',
   user: 'root',
   password: '',
   database: 'Control',
   port: 3306
});
connection.connect(function(error){
   if(error){
      console.log('Conexion fallida.');
      console.log('[mysql error] : ', error)
   }else{
      console.log('Conexion correcta.');
   }
});

var express = require('express');
var app = express();
app.use(express.json());

app.get("/empleados", (req, res) => {
    var query = connection.query("SELECT * FROM empleados where estado = 'A'", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a empleados`)
        res.send(result)
    })
});

app.get("/empleados/:id", (req, res) => {
    var query = connection.query("SELECT * FROM empleados where estado = 'A' AND codemp = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

app.post("/empleados", (req, res) => {
    var query = connection.query("INSERT INTO empleados(CODDPTO, nombres, apellidos, telefonos, correo, genero, nacimiento,direccion, dui, nit, afp, usuario, password, estado) values(" +
            req.body.coddpto + ", '" + req.body.nombres + "','" + req.body.apellidos + "','" + req.body.telefonos + "', '" + req.body.correo + "', '" + req.body.genero + "', STR_TO_DATE('" + req.body.nacimiento + "', '%d-%m-%Y'),'" + req.body.direccion + "','" + 
            req.body.dui + "','" + req.body.nit + "','" + req.body.afp + "','" + req.body.usuario + "',MD5('" + req.body.password + "'),'" + req.body.estado +
        "')", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a empleados`)
        res.send(result)
    })
});

app.put("/empleados/:id", (req, res) => {
    var query = connection.query(`UPDATE empleados SET CODDPTO=${req.body.coddpto}, nombres='${req.body.nombres}', apellidos='${req.body.apellidos}', telefonos='${req.body.telefonos}'
    , correo='${req.body.correo}', genero='${req.body.genero}', nacimiento=STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),direccion='${req.body.direccion}', dui='${req.body.dui}', nit='${req.body.nit}', afp='${req.body.afp}' where codemp = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

app.delete("/empleados/:id", (req, res) => {
    var query = connection.query(`UPDATE empleados SET estado='D' where codemp = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

app.get("/departamentos", (req, res) => {
    var query = connection.query("SELECT * FROM departamentos", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a departamentos`)
        res.send(result)
    })
});

app.get("/departamentos/:id", (req, res) => {
    var query = connection.query("SELECT * FROM departamentos WHERE CodDpto = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

app.post("/departamentos", (req, res) => {
    var query = connection.query(`INSERT INTO departamentos(nombre) values('${req.body.nombre}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a departamentos`)
        res.send(result)
    })
});

app.put("/departamentos/:id", (req, res) => {
    var query = connection.query(`UPDATE departamentos SET nombre = '${req.body.nombre}' where CodDpto = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

app.delete("/departamentos/:id", (req, res) => {
    var query = connection.query(`DELETE FROM departamentos where CodDpto = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

app.get("/registros/:id", (req, res) => {
    var query = connection.query("SELECT * FROM registros WHERE codemp = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a registros id = ${req.params.id}`)
        res.send(result)
    })
});

app.get("/registros/:id/:date", (req, res) => {
    var query = connection.query(`SELECT * FROM registros WHERE fecha = STR_TO_DATE('${req.params.date}', '%d-%m-%Y') and codemp = ${req.params.id}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a registros id = ${req.params.id}`)
        res.send(result)
    })
});

app.post("/registros/:id", (req, res) => {
    var query = connection.query(`INSERT INTO registros(fecha, horaentrada, horasalida, codemp) values( CURDATE(), TIME('${req.body.horaentrada}'), TIME('${req.body.horasalida}'), ${req.params.id})`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a registros`)
        res.send(result)
    })
});

app.put("/registros/:id/:date", (req, res) => {
    var query = connection.query(`UPDATE registros SET horaentrada = TIME('${req.body.horaentrada}'), horasalida = TIME('${req.body.horasalida}') where codemp = ${req.params.id} and fecha = STR_TO_DATE('${req.params.date}', '%d-%m-%Y')`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a registros id = ${req.params.id}`)
        res.send(result)
    })
});

app.delete("/registros/:id/:date", (req, res) => {
    var query = connection.query(`DELETE FROM registros where codemp = ${req.params.id} and fecha = STR_TO_DATE('${req.params.date}', '%d-%m-%Y')`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a registros id = ${req.params.id}`)
        res.send(result)
    })
});

app.get("/permisos", (req, res) => {
    var query = connection.query("SELECT * FROM permisos", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a permisos`)
        res.send(result)
    })
});

app.get("/permisos/:id", (req, res) => {
    var query = connection.query(`SELECT * FROM permisos WHERE CODPER = ${req.params.id}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a permisos id = ${req.params.id}`)
        res.send(result)
    })
});

app.post("/permisos", (req, res) => {
    var query = connection.query(`INSERT INTO permisos(codemp,fecha,tipo,descripcion,horainicial,horafinal,estado) values(${req.body.codemp},STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),'${req.body.tipo}','${req.body.descripcion}',TIME('${req.body.horainicial}'), TIME('${req.body.horafinal}'), '${req.body.estado}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a permisos`)
        res.send(result)
    })
});

app.put("/permisos/:id", (req, res) => {
    var query = connection.query(`UPDATE permisos SET fecha=STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),tipo='${req.body.tipo}', descripcion='${req.body.descripcion}', horainicial=TIME('${req.body.horainicial}'),horafinal=TIME('${req.body.horafinal}'),estado='${req.body.estado}' where CODPER = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a permisos id = ${req.params.id}`)
        res.send(result)
    })
});

app.delete("/permisos/:id", (req, res) => {
    var query = connection.query(`DELETE FROM permisos where CODPER = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a permisos id = ${req.params.id}`)
        res.send(result)
    })
});
var server = app.listen(process.env.PORT || 8000, function () {
    var host = server.address().address
    var port = server.address().port
    
    console.log("Servidor Escuchando en http://%s:%s", host, port)
 });