const connection = require('../mysql.js');
const express = require('express');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;

//Obtiene listado de DEPARTAMENTOS por cliente
router.get("/DEPARTAMENTOS/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM DEPARTAMENTOS where codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a DEPARTAMENTOS`)
        res.send(result)                                     
    })
});

//Obtiene los empleados de un departamento por id
router.get("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`SELECT * FROM EMPLEADOS WHERE CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)        
    })
});

//Crea un nuevo departamento
router.post("/DEPARTAMENTOS", (req, res) => {
    var query = connection.query(`INSERT INTO DEPARTAMENTOS(nombre, codcli) values('${req.body.nombre}',${req.body.codcli})`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a DEPARTAMENTOS`)
        res.send(result)
    })
});

//Actualiza departamento por id
router.put("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`UPDATE DEPARTAMENTOS SET nombre = '${req.body.nombre}' where CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)
    })
});

//Elimina departamento por id
router.delete("/DEPARTAMENTOS/coddpto/:coddpto/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM DEPARTAMENTOS where CodDpto = ${req.params.coddpto} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a DEPARTAMENTOS id = ${req.params.coddpto}`)
        res.send(result)
    })
});

module.exports = router;