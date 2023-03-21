const connection = require('../mysql.js');
const express = require('express');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;


//Obtiene listado de REGISTROS del control de asistencia
router.get("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha, horaentrada,horasalida, total FROM REGISTROS WHERE codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//Obtiene listado de REGISTROS del control de asistencia de un mes especifico
router.get("/REGISTROS/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT e.CODEMP,e.codcli,DATE_FORMAT(r.FECHA,'%d/%m/%Y') fecha, r.HORAENTRADA, r.HORASALIDA, total FROM REGISTROS r LEFT JOIN EMPLEADOS e ON r.CODEMP = e.CODEMP AND YEAR(r.FECHA) = ${req.params.y} AND MONTH(r.FECHA) = ${req.params.m} WHERE e.activo = 'true' and e.codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS mes = ${req.params.m}, anyo= ${req.params.y}`)
        res.send(result)
    })
});

//Obtiene un registro del control de asistencia por codigo de empleado y fecha
router.get("/REGISTROS/codemp/:codemp/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,horaentrada,horasalida, total FROM REGISTROS WHERE YEAR(fecha) = ${req.params.y} and MONTH(fecha) = ${req.params.m} and codemp = ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a REGISTROS de EMPLEADOS id = ${req.params.codemp}`)
        res.send(result)
    })
});

//crea un registro de un empleado
router.post("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`INSERT INTO REGISTROS(fecha, horaentrada, horasalida, codemp, codcli, total) values(DATE_ADD(CURDATE(),INTERVAL (SELECT ZONAHORARIA FROM clientes WHERE CODCLI = ${req.params.codcli})  HOUR), TIME(NOW()), TIME(NOW()), ${req.params.codemp}, ${req.params.codcli}, 0)`, function(error, result){
        if(error && error.errno != 1062) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post tick a REGISTROS`)
        res.send(result)
    })
});

//Genera un tick de hora de salida en el registro del control de asistencia por codigo de empleado
router.put("/REGISTROS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE REGISTROS SET horasalida = TIME(NOW()), total = total+1 where codemp = ${req.params.codemp} and codcli = ${req.params.codcli} and fecha = DATE_ADD(CURDATE(),INTERVAL (SELECT ZONAHORARIA FROM clientes WHERE CODCLI = ${req.params.codcli})  HOUR)`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put tick a REGISTROS id = ${req.params.codemp}`)
        res.send(result)
    })
});

module.exports = router;
