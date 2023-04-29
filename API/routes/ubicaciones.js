const connection = require('../mysql.js');
const express = require('express');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;


//Obtiene listado de UBICACIONES
router.get("/UBICACIONES/codcli/:codcli/p/:page", (req, res) => {    
    var query = connection.query(`SELECT * FROM UBICACIONES where codcli = ${req.params.codcli} order by codemp limit ${req.params.page},${req.params.page+10}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a UBICACIONES`)
        res.send(result)                
    })
});
router.get("/UBICACIONES/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM UBICACIONES where codcli = ${req.params.codcli} order by codemp`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a UBICACIONES`)
        res.send(result)
    })
});

//Obtiene listado de UBICACIONES del control de asistencia 
router.get("/UBICACIONES/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha, horaentrada,horasalida,latinicial,longinicial,direccioninicial,latfinal,longfinal,direccionfinal, total FROM UBICACIONES WHERE codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a UBICACIONES id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Obtiene listado de UBICACIONES del control de asistencia de un mes especifico
router.get("/UBICACIONES/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT e.CODEMP,e.codcli,DATE_FORMAT(u.FECHA,'%d/%m/%Y') fecha, u.HORAENTRADA, u.HORASALIDA, latinicial, longinicial, direccioninicial, latfinal, longfinal, direccionfinal, total FROM UBICACIONES u LEFT JOIN EMPLEADOS e ON u.CODEMP = e.CODEMP AND YEAR(u.FECHA) = ${req.params.y} AND MONTH(u.FECHA) = ${req.params.m} WHERE e.activo = 'true' and e.codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS mes = ${req.params.m}, anyo= ${req.params.y}`)
        res.send(result)
    })
});


//Obtiene un UBICACIONES del control de asistencia por codigo de empleado y fecha
router.get("/UBICACIONES/codemp/:codemp/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,horaentrada,horasalida, total FROM UBICACIONES WHERE YEAR(fecha) = ${req.params.y} and MONTH(fecha) = ${req.params.m} and codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS de EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});





//crea una registro de ubicacion

router.post("/UBICACIONES", (req, res) => {
    var query = connection.query(`INSERT INTO UBICACIONES(codemp,codcli,fecha,horaentrada,horasalida,latinicial,longinicial,direccioninicial,latfinal, longfinal, direccionfinal,total) values(
        ${req.body.codemp},${req.body.codcli},DATE_ADD(NOW(),INTERVAL (SELECT ZONAHORARIA FROM CLIENTES WHERE CODCLI = ${req.body.codcli})  HOUR), DATE_ADD(NOW(),INTERVAL (SELECT ZONAHORARIA FROM CLIENTES WHERE CODCLI = ${req.body.codcli})  HOUR), DATE_ADD(NOW(),INTERVAL (SELECT ZONAHORARIA FROM CLIENTES WHERE CODCLI = ${req.body.codcli})  HOUR),
        ${req.body.latinicial},${req.body.longinicial},'${req.body.direccioninicial}',0.0,0.0,'${req.body.direccionfinal}', 0)`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a UBICACIONES`)        
        res.send(result)
    })
});
//actualiza una registro de ubicacion

router.put("/UBICACIONES", (req, res) => {
    var query = connection.query(`UPDATE UBICACIONES set horasalida = DATE_ADD(NOW(),INTERVAL (SELECT ZONAHORARIA FROM CLIENTES WHERE CODCLI = ${req.body.codcli})  HOUR),
        latfinal=${req.body.latfinal},longfinal=${req.body.longfinal},direccionfinal='${req.body.direccionfinal}', total = total+1 where codemp = ${req.body.codemp} and codcli = ${req.body.codcli} and fecha = DATE(DATE_ADD(NOW(),INTERVAL (SELECT ZONAHORARIA FROM CLIENTES WHERE CODCLI = ${req.body.codcli})  HOUR))`, 
        function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a UBICACIONES`)        
        res.send(result)
    })
});



module.exports = router;
