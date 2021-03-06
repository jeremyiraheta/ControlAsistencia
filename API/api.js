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

const express = require('express');
const fileUpload = require('express-fileupload');
const fs = require('fs');
const path = require('path');
var app = express();
app.use(express.json());
app.use('/app', express.static(path.join(__dirname, '../Instalador/')));
app.use(fileUpload({
    createParentPath: true,
    limits: { 
        fileSize: 20 * 1024 * 1024 //20MB max
    }
}));
//Acceso al instalador de la aplicacion de escritorio
app.get("/", (req, res) => {
    res.redirect("/app")
});
//Obtiene listado de empleados activos
app.get("/empleados", (req, res) => {
    var query = connection.query("SELECT * FROM empleados where estado = 'A'", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a empleados`)
        res.send(result)
    })
});

//Obtiene datos de un empleado por codigo de empleado
app.get("/empleados/:id", (req, res) => {
    var query = connection.query("SELECT * FROM empleados where estado = 'A' AND codemp = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

//Crea un empleado nuevo
app.post("/empleados", (req, res) => {
    var query = connection.query("INSERT INTO empleados(CODDPTO, nombres, apellidos, telefonos, correo, genero, nacimiento,direccion, dui, nit, afp, usuario, password, estado) values(" +
            req.body.coddpto + ", '" + req.body.nombres + "','" + req.body.apellidos + "','" + req.body.telefonos + "', '" + req.body.correo + "', '" + req.body.genero + "', STR_TO_DATE('" + req.body.nacimiento + "', '%d-%m-%Y'),'" + req.body.direccion + "','" + 
            req.body.dui + "','" + req.body.nit + "','" + req.body.afp + "','" + req.body.usuario + "',MD5('" + req.body.password + "'),'A')", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a empleados`)
        res.send(result)
    })
});

//Actualiza empleado por codigo de empleado
app.put("/empleados/:id", (req, res) => {
    var query = connection.query(`UPDATE empleados SET CODDPTO=${req.body.coddpto}, nombres='${req.body.nombres}', apellidos='${req.body.apellidos}', telefonos='${req.body.telefonos}'
    , correo='${req.body.correo}', genero='${req.body.genero}', nacimiento=STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),direccion='${req.body.direccion}', dui='${req.body.dui}', nit='${req.body.nit}', afp='${req.body.afp}' where codemp = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

//Deshabilita empleado por codigo de empleado
app.delete("/empleados/:id", (req, res) => {
    var query = connection.query(`UPDATE empleados SET estado='D' where codemp = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

//Activa empleado por codigo de empleado
app.get("/empleados/:id/enable", (req, res) => {
    var query = connection.query(`UPDATE empleados SET estado='E' where codemp = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`enable a empleados id = ${req.params.id}`)
        res.send(result)
    })
});

//Obtiene listado de departamentos
app.get("/departamentos", (req, res) => {
    var query = connection.query("SELECT * FROM departamentos", function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a departamentos`)
        res.send(result)
    })
});

//Obtiene departamento por id
app.get("/departamentos/:id", (req, res) => {
    var query = connection.query("SELECT * FROM departamentos WHERE CodDpto = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

//Crea un nuevo departamento
app.post("/departamentos", (req, res) => {
    var query = connection.query(`INSERT INTO departamentos(nombre) values('${req.body.nombre}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a departamentos`)
        res.send(result)
    })
});

//Actualiza departamento por id
app.put("/departamentos/:id", (req, res) => {
    var query = connection.query(`UPDATE departamentos SET nombre = '${req.body.nombre}' where CodDpto = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

//Elimina departamento por id
app.delete("/departamentos/:id", (req, res) => {
    var query = connection.query(`DELETE FROM departamentos where CodDpto = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a departamentos id = ${req.params.id}`)
        res.send(result)
    })
});

//Obtiene listado de registros del control de asistencia
app.get("/registros/:id", (req, res) => {
    var query = connection.query("SELECT codemp,DATE_FORMAT(fecha,'%d/%m/%Y'), horaentrada,horasalida FROM registros WHERE codemp = " + req.params.id, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a registros id = ${req.params.id}`)
        res.send(result)
    })
});

//Obtiene listado de registros del control de asistencia de un mes especifico
app.get("/registros/:m/:y", (req, res) => {
    var query = connection.query(`SELECT e.CODEMP,DATE_FORMAT(r.FECHA,'%d/%m/%Y'), r.HORAENTRADA, r.HORASALIDA FROM empleados e LEFT JOIN registros r ON r.CODEMP = e.CODEMP AND YEAR(r.FECHA) = ${req.params.y} AND MONTH(r.FECHA) = ${req.params.m} WHERE e.ESTADO = 'A';`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a registros mes = ${req.params.m}, anyo= ${req.params.y}`)
        res.send(result)
    })
});

//Obtiene un registro del control de asistencia por codigo de empleado y fecha
app.get("/registros/:id/:m/:y", (req, res) => {
    var query = connection.query(`SELECT codemp,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,horaentrada,horasalida FROM registros WHERE YEAR(fecha) = ${req.params.y} and MONTH(fecha) = ${req.params.m} and codemp = ${req.params.id}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a registros id = ${req.params.id}`)
        res.send(result)
    })
});

//Obtiene un registro del control de asistencia por codigo de empleado
app.post("/registros/:id", (req, res) => {
    var query = connection.query(`INSERT INTO registros(fecha, horaentrada, horasalida, codemp) values( CURDATE(), TIME(NOW()), TIME(NOW()), ${req.params.id})`, function(error, result){
        if(error && error.errno != 1062) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a registros`)
        res.send(result)
    })
});

//Genera un tick de hora de salida en el registro del control de asistencia por codigo de empleado
app.put("/registros/:id", (req, res) => {
    var query = connection.query(`UPDATE registros SET horasalida = TIME(NOW()) where codemp = ${req.params.id} and fecha = CURDATE()`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`tick a registros id = ${req.params.id}`)
        res.send(result)
    })
});

//Elimina un registro del control de asistencia por codigo de empleado y fecha
app.delete("/registros/:id/:date", (req, res) => {
    var query = connection.query(`DELETE FROM registros where codemp = ${req.params.id} and fecha = STR_TO_DATE('${req.params.date}', '%d-%m-%Y')`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a registros id = ${req.params.id}`)
        res.send(result)
    })
});

//Obtiene todo el listado de permisos de un empleado
app.get("/permisos/emp/:id", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM permisos where codemp= ${req.params.id}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a permisos codemp = ${req.params.id}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public") + path.sep + result[i].codper + ".zip")) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }
        res.send(result)
    })
});

//Obtiene listado de permisos de un mes especifico
app.get("/permisos/:m/:y", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM permisos where DATE_FORMAT(fecha,'%Y/%m') = '${req.params.y}/${req.params.m}'`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a permisos mes=${req.params.m}, anyo=${req.params.y}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public") + path.sep + result[i].codper + ".zip")) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }
        res.send(result)
    })
});

//Obtiene los datos de un permiso particular
app.get("/permisos/:id", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM permisos WHERE codper = ${req.params.id}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a permisos id = ${req.params.id}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public") + path.sep + result[i].codper + ".zip")) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }
        res.send(result)
    })
});

//Crea un permiso nuevo
app.post("/permisos", (req, res) => {
    var query = connection.query(`INSERT INTO permisos(codemp,fecha,tipo,descripcion,horainicial,horafinal,estado) values(${req.body.codemp},STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),'${req.body.tipo}','${req.body.descripcion}',TIME('${req.body.horainicial}'), TIME('${req.body.horafinal}'), 'E')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a permisos`)        
        res.send(result)
    })
});

//Actualiza un permiso por su id
app.put("/permisos/:id", (req, res) => {
    var query = connection.query(`UPDATE permisos SET fecha=STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),tipo='${req.body.tipo}', descripcion='${req.body.descripcion}', horainicial=TIME('${req.body.horainicial}'),horafinal=TIME('${req.body.horafinal}') where CODPER = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a permisos id = ${req.params.id}`)
        res.send(result)
    })
});

//Actualiza el estado del permizo
app.put("/permisos/:id/:estado", (req, res) => {
    var query = connection.query(`UPDATE permisos SET estado='${req.params.estado}' where CODPER = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a permisos id = ${req.params.id}`)
        res.send(result)
    })
});

//Elimina un permiso por su id
app.delete("/permisos/:id", (req, res) => {
    var query = connection.query(`DELETE FROM permisos where CODPER = ${req.params.id}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a permisos id = ${req.params.id}`)
        res.send(result)
    })
});

//Comprueba si un usuario es valido
app.post("/login", (req, res) => {
    var query = connection.query(`select codemp,UPPER(nombres) nombres, UPPER(apellidos) apellidos,estado,(select UPPER(nombre) from departamentos d where e.CODDPTO = d.CODDPTO) departamento,if(e.CODDPTO = 1,TRUE,FALSE) admin  from empleados e where usuario='${req.body.user}' and password=MD5('${req.body.password}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`login user=${req.body.user}`)
        res.send(result)
    })
});

//Sirve middleware para subir archivos adjuntos
app.post("/upload/:id", async (req, res) => {
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No se pudo subir el archivo'
            });
        } else {
            let file = req.files.attch;
            let ext = file.name.substring(file.name.lastIndexOf("."));            
            let dir = path.join(__dirname, "public") + path.sep + req.params.id + ext;
            if(ext.toLowerCase() == ".zip")
            {
                file.mv(dir);            
                res.send({
                    status: true,
                    message: 'Archivo subido correctamente'                
                });
            }else{
                res.send({
                    status: false,
                    message: 'Solo se admiten archivos zip'
                });
            }        
        }
    } catch (err) {
        res.status(500).send(err);
    }
});

//Descarga el adjunto vinculado al permiso
app.get("/download/:id", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "public")
        };        
        res.sendFile(`${req.params.id}.zip`, options, (err) => {
            if(err)
                console.log(err)
        });
    } catch (error) {
        res.status(500).send(error);
    }
});
//Permite realizar un filtro a una tabla especifica
app.post("/query/:table", (req,res) => {
    var query = connection.query(`SELECT * FROM ${req.params.table} WHERE ${req.body.query}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`filtro tabla=${req.params.table}, query=${req.body.query}`)
        res.send(result)
    })
})

//Inicia el servidor
var server = app.listen(process.env.PORT || 8000, function () {
    var host = server.address().address
    var port = server.address().port
    
    console.log("Servidor Escuchando en http://%s:%s", host, port)
 });