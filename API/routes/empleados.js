const connection = require('../mysql.js');
const express = require('express');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;

//Obtiene listado de EMPLEADOS
router.get("/EMPLEADOS/codcli/:codcli/p/:page", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} order by codemp limit ${req.params.page},${req.params.page+10}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS`)
        res.send(result)                
    })
});
router.get("/EMPLEADOS/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} order by codemp`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS`)
        res.send(result)
    })
});
//Obtiene listado de EMPLEADOS activos de un departamento
router.get("/EMPLEADOS/codcli/:codcli/coddpto/:coddpto", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} and coddpto = ${req.params.coddpto}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS`)
        res.send(result)
    })
});
//Obtiene empleado por nombre de usuario
router.get("/EMPLEADOS/usuario/:usuario/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} and lower(usuario) = lower('${req.params.usuario}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADO ${req.params.usuario}`)
        res.send(result)
    })
});

//Obtiene datos de un empleado por codigo de empleado
router.get("/EMPLEADOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM EMPLEADOS where activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' AND codemp = ${req.params.codemp} and codcli = ${req.params.codcli}` , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Crea un empleado nuevo
router.post("/EMPLEADOS", (req, res) => {
    var query = connection.query(`INSERT INTO EMPLEADOS(CODDPTO, CODCLI, nombres, apellidos, telefonos, correo, genero, nacimiento,direccion, dui, nit, afp, usuario, password, activo) values(
            ${req.body.coddpto} , ${req.body.codcli},'${req.body.nombres}','${req.body.apellidos}','${req.body.telefonos}', '${req.body.correo}', '${req.body.genero}', STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),'${req.body.direccion}', 
            '${req.body.dui}','${req.body.nit}','${req.body.afp}','${req.body.usuario}',MD5('${req.body.password}'),'true')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a EMPLEADOS`)
        res.send(result)
    })
});

//Actualiza empleado por codigo de empleado
router.put("/EMPLEADOS", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET CODDPTO=${req.body.coddpto}, nombres='${req.body.nombres}', apellidos='${req.body.apellidos}', telefonos='${req.body.telefonos}'
    , correo='${req.body.correo}', genero='${req.body.genero}', nacimiento=STR_TO_DATE('${req.body.nacimiento}', '%d-%m-%Y'),direccion='${req.body.direccion}', dui='${req.body.dui}', nit='${req.body.nit}', afp='${req.body.afp}' where codemp = ${req.body.codemp} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a EMPLEADOS id = ${req.body.codemp}`)
        res.send(result)
    })
});

//Deshabilita empleado por codigo de empleado
router.delete("/EMPLEADOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET activo='false' where codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Activa empleado por codigo de empleado
router.put("/EMPLEADOS/codemp/:codemp/codcli/:codcli/enable", (req, res) => {
    var query = connection.query(`UPDATE EMPLEADOS SET activo='true' where codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`enable a EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Comprueba si un usuario es valido
router.post("/login", (req, res) => {
    var wcodcli = ""    
    if(req.body.codcli !== undefined && req.body.codcli > 0)
        wcodcli = `and codcli=${req.body.codcli}`
    var query = connection.query(`select codemp,codcli, usuario,UPPER(nombres) nombres, UPPER(apellidos) apellidos,activo,(select UPPER(nombre) from DEPARTAMENTOS d where e.CODDPTO = d.CODDPTO) departamento,(select if(UPPER(nombre) = 'ADMIN',TRUE,FALSE) from DEPARTAMENTOS d where e.CODDPTO = d.CODDPTO) admin  from EMPLEADOS e where usuario='${req.body.user}' and password=MD5('${req.body.password}') ${wcodcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`login user=${req.body.user}`)
        res.send(result)
    })
});

module.exports = router;