
const express = require('express');
const path = require('path');
const fileUpload = require('express-fileupload');
const connection = require('./mysql.js');
const departamentos = require('./routes/departamentos.js');
const clientes = require('./routes/clientes.js');
const download = require('./routes/download.js');
const permisos = require('./routes/permisos.js');
const empleados = require('./routes/empleados.js');
const productividad = require('./routes/productividad.js');
const registros = require('./routes/registros.js');
const reportes = require('./routes/reportes.js');
const upload = require('./routes/upload.js');
const DEBUG = process.env.DEBUG || true;
var app = express();
//Middleware Seguridad
function authentication(req, res, next) {
    var authheader = req.headers.authorization; 
    
    if(req.path == '/' || req.path.startsWith('/app')){              
        return next();//si admite acceder sin loguear al endpoint raiz
    }        
    
    if (!authheader) {
        var err = new Error('Usted no esta autorizado!');
        res.setHeader('WWW-Authenticate', 'Basic');
        err.stack="";
        err.status = 401;        
        return next(err)
    }
    var auth = new Buffer.from(authheader.split(' ')[1],
    'base64').toString().split(':');
    var user = auth[0];
    var pass = auth[1];

    connection.query(`select if(e.CODDPTO = 1,TRUE,FALSE) admin, codcli  from EMPLEADOS e where usuario='${user}' and password=MD5('${pass}') and codcli = 1 and activo = 'true'`, function(error, result){                    
        //Valida que el usuario que consume el recurso forme parte del cliente que tiene asignado
        if(error || (result.length == 0 || result[0].admin === undefined || result[0].admin == false)) 
        {
            var err = new Error('Usted no esta autorizado!');
            err.stack="";
            res.setHeader('WWW-Authenticate', 'Basic');
            err.status = 401;        
            return next(err)
        }else        
            return next();
    })    
 
}
app.use(authentication)
app.use(express.json());
app.use(fileUpload({
    createParentPath: true,
    limits: { 
        fileSize: 20 * 1024 * 1024 //20MB max
    }
}), upload);
app.use('/app', express.static(path.join(__dirname,  'Instalador')));
app.use('/api', departamentos, clientes, download, empleados, permisos, productividad, registros, reportes, upload);

//Acceso al instalador de la aplicacion de escritorio
app.get("/", (req, res) => {
    res.redirect("/app")
});


//Permite realizar un filtro a una tabla especifica
app.post("/query/:table", (req,res) => {
    var query = connection.query(`SELECT ${req.body.fields === undefined ? '*' : req.body.fields} FROM ${req.params.table} WHERE ${req.body.query}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`filtro tabla=${req.params.table}, query=${req.body.query}`)
        res.send(result)
    })
});



//Inicia el servidor
var server = app.listen(process.env.PORT || 8081, function () {
    var host = server.address().address
    var port = server.address().port
    setInterval(() => {
	    connection.query("select 1")
    },10000)
    console.log("Servidor Escuchando en http://%s:%s, MYSQLHOST=%s", host, port, process.env.MYSQL_HOST)
 });
