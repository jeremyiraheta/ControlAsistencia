const connection = require('../mysql.js');
const express = require('express');
const fs = require('fs');
const path = require('path');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;


//Crea un registro de productividad nuevo
router.post("/PRODUCTIVIDAD", (req, res) => {
    var query = connection.query(`INSERT INTO PRODUCTIVIDAD(codemp,codcli,procesos,histnav,fecha) values(${req.body.codemp},${req.body.codcli},'${req.body.procesos}','${req.body.histnav}',NOW())`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a PRODUCTIVIDAD`)        
        res.send(result)
    })
});

//Actualiza el registro de productividad
router.put("/PRODUCTIVIDAD", (req, res) => {
    var query = connection.query(`UPDATE PRODUCTIVIDAD SET procesos='${req.body.procesos}',histnav='${req.body.histnav}'  where CODPROD = ${req.body.codprod} and codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a PRODUCTIVIDAD id = ${req.body.codprod}`)
        res.send(result)
    })
});

//Elimina un registro de productividad
router.delete("/PRODUCTIVIDAD/codprod/:codprod/codcli/:codcli", (req, res) => {
    var query = connection.query(`DELETE FROM PRODUCTIVIDAD where CODPROD = ${req.params.codprod} and codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a PRODUCTIVIDAD id = ${req.body.codprod}`)
        res.send(result)
    })
});

//Consulta un registro de productividad
router.get("/PRODUCTIVIDAD/codemp/:codemp/codcli/:codcli/fechaini/:fechaini/fechafin/:fechafin", (req, res) => {
    var query = connection.query(`SELECT * FROM PRODUCTIVIDAD WHERE codemp = ${req.params.codemp} and codcli = ${req.params.codcli} and fecha between  STR_TO_DATE('${req.params.fechaini}', '%d-%m-%Y') and STR_TO_DATE('${req.params.fechafin}', '%d-%m-%Y')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a PRODUCTIVIDAD id = ${req.params.codemp}`) 
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "screenshots", result[i].CODCLI.toString(), result[i].CODPROD.toString() + ".webp"))) {
                    result[i].attch = true;
                }
            }
        } catch(err) {
            console.error(err)
        }       
        res.send(result)
    })
});

module.exports = router;