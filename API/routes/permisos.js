const connection = require('../mysql.js');
const express = require('express');
const fs = require('fs');
const path = require('path');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;

//Obtiene todo el listado de PERMISOS de un empleado
router.get("/PERMISOS/codemp/:codemp/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS where codemp= ${req.params.codemp} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS codemp = ${req.params.codemp}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli.toString(), result[i].codper.toString() + ".zip"))) {
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
router.get("/PERMISOS/codcli/:codcli/m/:m/y/:y", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS where DATE_FORMAT(fecha,'%Y/%m') = '${req.params.y}/${req.params.m}' and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS mes=${req.params.m}, anyo=${req.params.y}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli.toString(), result[i].codper.toString() + ".zip"))) {
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
router.get("/PERMISOS/codper/:codper/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT codper,codemp,codcli,DATE_FORMAT(fecha,'%d/%m/%Y') fecha,estado,tipo,descripcion,horainicial,horafinal FROM PERMISOS WHERE codper = ${req.params.codper} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PERMISOS id = ${req.params.codper}`)
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "permisos", result[i].codcli.toString(), result[i].codper.toString() + ".zip"))) {
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
router.post("/PERMISOS", (req, res) => {
    var query = connection.query(`INSERT INTO PERMISOS(codemp,codcli,fecha,tipo,descripcion,horainicial,horafinal,estado) values(${req.body.codemp},${req.body.codcli},STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),'${req.body.tipo}','${req.body.descripcion}',TIME('${req.body.horainicial}'), TIME('${req.body.horafinal}'), 'E')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a PERMISOS`)        
        res.send(result)
    })
});

//Actualiza un permiso
router.put("/PERMISOS", (req, res) => {
    var query = connection.query(`UPDATE PERMISOS SET fecha=STR_TO_DATE('${req.body.fecha}', '%d-%m-%Y'),tipo='${req.body.tipo}', descripcion='${req.body.descripcion}', horainicial=TIME('${req.body.horainicial}'),horafinal=TIME('${req.body.horafinal}'), estado='${req.body.estado}' where CODPER = ${req.body.codper} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PERMISOS id = ${req.body.codper}`)
        res.send(result)
    })
});
//Actualiza el estado de un permiso
router.put("/PERMISOS/codper/:codper/codcli/:codcli/estado/:estado", (req, res) => {
    var query = connection.query(`UPDATE PERMISOS SET estado='${req.params.estado}' where CODPER = ${req.params.codper} and codcli = ${req.params.codcli}`
    , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PERMISOS id = ${req.body.codper}`)
        res.send(result)
    })
});

//Elimina un permiso por su id
router.delete("/PERMISOS/codper/:codper/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM PERMISOS where CODPER = ${req.params.codper} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a PERMISOS id = ${req.params.codper}`)
        res.send(result)
    })
});

module.exports = router;