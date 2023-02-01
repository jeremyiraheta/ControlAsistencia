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
//Middleware Seguridad
function authentication(req, res, next) {
    var authheader = req.headers.authorization; 
    
    if(req.path == '/' || req.path.startsWith('/app/')){              
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
app.use('/app', express.static(path.join(__dirname,  'Instalador')));
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
//Obtiene listado de EMPLEADOS
app.get("/EMPLEADOS/codcli/:codcli/p/:page", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} limit ${req.params.page},10`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS`)
        res.send(result)
    })
});
//Obtiene listado de EMPLEADOS activos de un departamento
app.get("/EMPLEADOS/codcli/:codcli/coddpto/:coddpto/p/:page", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} and coddpto = ${req.params.coddpto} limit ${req.params.page},10`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS`)
        res.send(result)
    })
});
//Obtiene empleado por nombre de usuario
app.get("/EMPLEADOS/usuario/:usuario/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} and lower(usuario) = lower('${req.params.usuario}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADO ${req.params.usuario}`)
        res.send(result)
    })
});

//Obtiene datos de un empleado por codigo de empleado
app.get("/EMPLEADOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' AND codemp = ${req.params.codemp} and codcli = ${req.params.codcli}` , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Crea un empleado nuevo
app.post("/EMPLEADOS", (req, res) => {
    var query = connection.query(`INSERT INTO EMPLEADOS(CODDPTO, CODCLI, nombres, apellidos, telefonos, correo, genero, nacimiento,direccion, dui, nit, afp, usuario, password, activo) values(
            ${req.body.coddpto} , ${req.body.codcli},'${req.body.nombres}','${req.body.apellidos}','${req.body.telefonos}', '${req.body.correo}', '${req.body.genero}', STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),'${req.body.direccion}', 
            '${req.body.dui}','${req.body.nit}','${req.body.afp}','${req.body.usuario}',MD5('${req.body.password}'),'true')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a EMPLEADOS`)
        res.send(result)
    })
});

//Actualiza empleado por codigo de empleado
app.put("/EMPLEADOS", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET CODDPTO=${req.body.coddpto}, nombres='${req.body.nombres}', apellidos='${req.body.apellidos}', telefonos='${req.body.telefonos}'
    , correo='${req.body.correo}', genero='${req.body.genero}', nacimiento=STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),direccion='${req.body.direccion}', dui='${req.body.dui}', nit='${req.body.nit}', afp='${req.body.afp}' where codemp = ${req.body.codemp} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a EMPLEADOS id = ${req.body.codemp}`)
        res.send(result)
    })
});

//Deshabilita empleado por codigo de empleado
app.delete("/EMPLEADOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET activo='false' where codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Activa empleado por codigo de empleado
app.put("/EMPLEADOS/codemp/:codemp/codcli/:codcli/enable", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET activo='true' where codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`enable a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Obtiene listado de DEPARTAMENTOS por cliente
app.get("/DEPARTAMENTOS/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM DEPARTAMENTOS where codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a DEPARTAMENTOS`)
        res.send(result)
    })
});

//Obtiene los empleados de un departamento por id
app.get("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM EMPLEADOS WHERE CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)
    })
});

//Crea un nuevo departamento
app.post("/DEPARTAMENTOS", (req, res) => {
    var query = connection.query(`INSERT INTO DEPARTAMENTOS(nombre, codcli) values('${req.body.nombre}',${req.body.codcli})`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a DEPARTAMENTOS`)
        res.send(result)
    })
});

//Actualiza departamento por id
app.put("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE DEPARTAMENTOS SET nombre = '${req.body.nombre}' where CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)
    })
});

//Elimina departamento por id
app.delete("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM DEPARTAMENTOS where CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)
    })
});

//Obtiene listado de REGISTROS del control de asistencia
app.get("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha, horaentrada,horasalida FROM REGISTROS WHERE codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Obtiene listado de REGISTROS del control de asistencia de un mes especifico
app.get("/REGISTROS/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT e.CODEMP,e.codcli,DATE_FORMAT(r.FECHA,'%d/%m/%Y') fecha, r.HORAENTRADA, r.HORASALIDA FROM REGISTROS r LEFT JOIN EMPLEADOS e ON r.CODEMP = e.CODEMP AND YEAR(r.FECHA) = ${req.params.y} AND MONTH(r.FECHA) = ${req.params.m} WHERE e.activo = 'true' and e.codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS mes = ${req.params.m}, anyo= ${req.params.y}`)
        res.send(result)
    })
});

//Obtiene un registro del control de asistencia por codigo de empleado y fecha
app.get("/REGISTROS/codemp/:codemp/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,horaentrada,horasalida FROM REGISTROS WHERE YEAR(fecha) = ${req.params.y} and MONTH(fecha) = ${req.params.m} and codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS de EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//crea un registro de un empleado
app.post("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`INSERT INTO REGISTROS(fecha, horaentrada, horasalida, codemp, codcli) values( CURDATE(), TIME(NOW()), TIME(NOW()), ${req.params.codemp}, ${req.params.codcli})`, function(error, result){
        if(error && error.errno != 1062) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post tick a REGISTROS`)
        res.send(result)
    })
});

//Genera un tick de hora de salida en el registro del control de asistencia por codigo de empleado
app.put("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE REGISTROS SET horasalida = TIME(NOW()) where codemp = ${req.params.codemp} and codcli = ${req.params.codcli} and fecha = CURDATE()`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put tick a REGISTROS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Obtiene todo el listado de PERMISOS de un empleado
app.get("/PERMISOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS where codemp= ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS codemp = ${req.params.codemp}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli, result[i].codper + ".zip"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }
        res.send(result)
    })
});

//Obtiene listado de PERMISOS de un mes especifico
app.get("/PERMISOS/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS where DATE_FORMAT(fecha,'%Y/%m') = '${req.params.y}/${req.params.m}' and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS mes=${req.params.m}, anyo=${req.params.y}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli, result[i].codper + ".zip"))) {
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
app.get("/PERMISOS/codper/:codper/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS WHERE codper = ${req.params.codper} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS id = ${req.params.codper}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli, result[i].codper + ".zip"))) {
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
app.post("/PERMISOS", (req, res) => {
    var query = connection.query(`INSERT INTO PERMISOS(codemp,codcli,fecha,tipo,descripcion,horainicial,horafinal,estado) values(${req.body.codemp},${req.body.codcli},STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),'${req.body.tipo}','${req.body.descripcion}',TIME('${req.body.horainicial}'), TIME('${req.body.horafinal}'), 'E')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a PERMISOS`)        
        res.send(result)
    })
});

//Actualiza un permiso
app.put("/PERMISOS", (req, res) => {
    var query = connection.query(`UPDATE PERMISOS SET fecha=STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),tipo='${req.body.tipo}', descripcion='${req.body.descripcion}', horainicial=TIME('${req.body.horainicial}'),horafinal=TIME('${req.body.horafinal}'), estado='${req.body.estado}' where CODPER = ${req.body.codper} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PERMISOS id = ${req.body.codper}`)
        res.send(result)
    })
});
//Actualiza el estado de un permiso
app.put("/PERMISOS/codper/:codper/codcli/:codcli/estado/:estado", (req, res) => {
    var query = connection.query(`UPDATE PERMISOS SET estado='${req.params.estado}' where CODPER = ${req.params.codper} and codcli = ${req.params.codcli}`
    , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PERMISOS id = ${req.body.codper}`)
        res.send(result)
    })
});

//Elimina un permiso por su id
app.delete("/PERMISOS/codper/:codper/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM PERMISOS where CODPER = ${req.params.codper} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a PERMISOS id = ${req.params.codper}`)
        res.send(result)
    })
});

//Crea un registro de productividad nuevo
app.post("/PRODUCTIVIDAD", (req, res) => {
    var query = connection.query(`INSERT INTO PRODUCTIVIDAD(codemp,codcli,procesos,histnav,fecha) values(${req.body.codemp},${req.body.codcli},'${req.body.procesos}','${req.body.histnav}',NOW())`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a PRODUCTIVIDAD`)        
        res.send(result)
    })
});

//Actualiza el registro de productividad
app.put("/PRODUCTIVIDAD", (req, res) => {
    var query = connection.query(`UPDATE PRODUCTIVIDAD SET procesos='${req.body.procesos}',histnav='${req.body.histnav}'  where CODPROD = ${req.body.codprod} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PRODUCTIVIDAD id = ${req.body.codprod}`)
        res.send(result)
    })
});

//Elimina un registro de productividad
app.delete("/PRODUCTIVIDAD/codprod/:codprod/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM PRODUCTIVIDAD where CODPROD = ${req.params.codprod} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a PRODUCTIVIDAD id = ${req.body.codprod}`)
        res.send(result)
    })
});

//Consulta un registro de productividad
app.get("/PRODUCTIVIDAD/codemp/:codemp/codcli/:codcli/fechaini/:fechaini/fechafin/:fechafin", (req, res) => {
    var query = connection.query(`SELECT * FROM PRODUCTIVIDAD WHERE codemp = ${req.params.codemp} and codcli = ${req.params.codcli} and fecha between  STR_TO_DATE('${req.params.fechaini}', '%d-%m-%Y') and STR_TO_DATE('${req.params.fechafin}', '%d-%m-%Y')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PRODUCTIVIDAD id = ${req.params.codemp}`) 
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "screenshots", result[i].codcli, result[i].codprod + ".webp"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }       
        res.send(result)
    })
});

//Crea un registro de cliente nuevo
app.post("/CLIENTES", (req, res) => {
    var query = connection.query(`INSERT INTO CLIENTES(nombre,url,urlnom,correo_contacto,telefono_contacto,fecha_registro,fecha_fin_servicio,plan,capturarpantalla,capturarprocesos,capturarhistorialnav,loginbackground,zonahoraria,pais,invervalo,porctcapt,activo) 
    values('${req.body.nombre}','${req.body.url}','${req.body.urlnom}','${req.body.correo_contacto}', '${req.body.telefono_contacto}',NOW(),DATE_ADD(NOW(), INTERVAL 31 day), ${req.body.plan}, '${req.body.capturarpantalla}', '${req.body.capturarprocesos}', '${req.body.capturarhistorialnav}', '${req.body.loginbackground}', '${req.body.zonahoraria}', '${req.body.pais}', ${req.body.invervalo}, ${req.body.porctcapt}, 'true')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a CLIENTES`)        
        res.send(result)
    })
});

//Actualiza el registro de cliente
app.put("/CLIENTES", (req, res) => {
    var query = connection.query(`UPDATE CLIENTES SET nombre='${req.body.nombre}',url='${req.body.url}',urlnom='${req.body.urlnom}',correo_contacto='${req.body.correo_contacto}',telefono_contacto='${req.body.telefono_contacto}', fecha_fin_servicio=STR_TO_DATE('${req.body.fecha_fin_servicio}', '%d-%m-%YT%H:%i'), plan=${req.body.plan}, capturarpantalla='${req.body.capturarpantalla}', capturarprocesos='${req.body.capturarprocesos}', capturarhistorialnav='${req.body.capturarhistorialnav}', loginbackground='${req.body.loginbackground}', zonahoraria='${req.body.zonahoraria}', pais='${req.body.pais}', invervalo=${req.body.invervalo}, porctcapt=${req.body.porctcapt}, activo='${req.body.activo}'  where  codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a CLIENTES id = ${req.body.codcli}`)
        res.send(result)
    })
});

//Reactiva un registro de cliente
app.put("/CLIENTES/codcli/:codcli/enable", (req, res) => {
    var query = connection.query(`UPDATE CLIENTES SET activo='true' where codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a CLIENTES id = ${req.params.codcli}`)
        res.send(result)
    })
});

//Elimina un registro de cliente
app.delete("/CLIENTES/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE CLIENTES SET activo='false' where codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a CLIENTES id = ${req.params.codcli}`)
        res.send(result)
    })
});

//Consulta un registro de cliente
app.get("/CLIENTES/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} `, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a CLIENTES id = ${req.params.codcli}`)    
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].codcli + ".webp"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }     
        res.send(result)
    })
});

//Consulta un registro de cliente
app.get("/CLIENTES/p/:page", (req, res) => {
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' limit ${req.params.page},10`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a CLIENTES`)  
        if(DEBUG)console.log(`get a CLIENTES id = ${req.params.codcli}`)    
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].codcli + ".webp"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }       
        res.send(result)
    })
});

//Consulta un registro de cliente
app.get("/CLIENTES/urlnom/:urlnom", (req, res) => {
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = 'true' and lower(urlnom) = lower('${req.params.urlnom}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a CLIENTES`)  
        if(DEBUG)console.log(`get a CLIENTES id = ${req.params.urlnom}`)    
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].codcli + ".webp"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }       
        res.send(result)
    })
});
//Ejecuta un procedimiento que elimina toda la informacion de un cliente
app.delete("/CLIENTES/codcli/:codcli/purge", (req, res) => {
    var query = connection.query(`CALL purgeCliente(${req.params.codcli})`, function(error, result){
        if(error) console.log('[mysql error] : ', error)        
        if(DEBUG)console.log(`purga a CLIENTES id = ${req.params.codcli}`)            
        res.send(result)
    })
});

//Comprueba si un usuario es valido
app.post("/login", (req, res) => {
    var wcodcli = ""    
    if(req.body.codcli !== undefined && req.body.codcli > 0)
        wcodcli = `and codcli=${req.body.codcli}`
    var query = connection.query(`select codemp,codcli, usuario,UPPER(nombres) nombres, UPPER(apellidos) apellidos,activo,(select UPPER(nombre) from DEPARTAMENTOS d where e.CODDPTO = d.CODDPTO) departamento,(select if(UPPER(nombre) = 'ADMIN',TRUE,FALSE) from DEPARTAMENTOS d where e.CODDPTO = d.CODDPTO) admin  from EMPLEADOS e where usuario='${req.body.user}' and password=MD5('${req.body.password}') ${wcodcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`login user=${req.body.user}`)
        res.send(result)
    })
});

//Sirve middleware para subir archivos adjuntos
app.post("/upload/permiso/codper/:codper/codcli/:codcli", async (req, res) => {
    try {
        if(!req.files) {
            res.send({
                status: false,
                message: 'No se pudo subir el archivo'
            });
        } else {
            let file = req.files.attch;
            let ext = file.name.substring(file.name.lastIndexOf("."));            
            let dir = path.join(__dirname, "public", "permisos", req.params.codcli, req.params.codper + ext);
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

app.post("/upload/captura/codprod/:codprod/codcli/:codcli", async (req, res) => {
    try {
        if(req.body.file === undefined){
            res.status(500).send("No se envio nada que procesar")
        }else{
            let file = req.body.file                       
            let dir = path.join(__dirname, "public", "screenshots", req.params.codcli, req.params.codprod + ".webp");
            fs.writeFile(dir, Buffer.from(file), 'binary', (err) => {
                res.status(500).send("Ocurrio un error al escribir el archivo:" + err.message)
            })
        }            
    } catch (err) {
        res.status(500).send(err);
    }
});

app.post("/upload/logo/codcli/:codcli", async (req, res) => {
    try {
        if(req.body.file !== undefined){
            res.status(500).send("No se envio nada que procesar")
        }else{
            let file = req.body.file                       
            let dir = path.join(__dirname, "public", "logos", req.params.codcli + ".webp");
            fs.writeFile(dir, Buffer.from(file), 'binary', (err) => {
                res.status(500).send("Ocurrio un error al escribir el archivo")
            })
        }            
    } catch (err) {
        res.status(500).send(err);
    }
});

//Descarga el adjunto vinculado al permiso
app.get("/download/permiso/codper/:codper/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "public", "permisos", req.params.codcli)
        };        
        res.sendFile(`${req.params.codper}.zip`, options, (err) => {
            if(err)
                console.log(err)
        });
    } catch (error) {
        res.status(500).send(error);
    }
});

app.get("/img/captura/codprod/:codprod/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "public", "screenshots", req.params.codcli)
        };        
        res.sendFile(`${req.params.codprod}.webp`, options, (err) => {
            if(err)
                console.log(err)
        });
    } catch (error) {
        res.status(500).send(error);
    }
});

app.get("/img/logo/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "public", "logos")
        };        
        res.sendFile(`${req.params.codcli}.webp`, options, (err) => {
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
var server = app.listen(process.env.PORT || 8081, function () {
    var host = server.address().address
    var port = server.address().port
    setInterval(() => {
	    connection.query("select 1")
    },10000)
    console.log("Servidor Escuchando en http://%s:%s", host, port)
 });
