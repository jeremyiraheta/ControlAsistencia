const connection = require('../mysql.js');
const express = require('express');
const router = express.Router();
const fs = require('fs');
const path = require('path');
const DEBUG = process.env.DEBUG || true;

//Crea un registro de cliente nuevo
router.post("/CLIENTES", (req, res) => {
    var query = connection.query(`INSERT INTO CLIENTES(nombre,url,urlnom,correo_contacto,telefono_contacto,fecha_registro,fecha_fin_servicio,plan,capturarpantalla,capturarprocesos,capturarhistorialnav,loginbackground,zonahoraria,pais,invervalo,porctcapt,activo,direccion) 
    values('${req.body.nombre}','${req.body.url}','${req.body.urlnom}','${req.body.correo_contacto}', '${req.body.telefono_contacto}',NOW(),DATE_ADD(NOW(), INTERVAL 31 day), ${req.body.plan}, '${req.body.capturarpantalla}', '${req.body.capturarprocesos}', '${req.body.capturarhistorialnav}', '${req.body.loginbackground}', '${req.body.zonahoraria}', '${req.body.pais}', ${req.body.invervalo}, ${req.body.porctcapt}, 'true', '${req.body.direccion}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`post a CLIENTES`)        
        res.send(result)
    })
});

//Actualiza el registro de cliente
router.put("/CLIENTES", (req, res) => {
    var query = connection.query(`UPDATE CLIENTES SET nombre='${req.body.nombre}',url='${req.body.url}',urlnom='${req.body.urlnom}',correo_contacto='${req.body.correo_contacto}',telefono_contacto='${req.body.telefono_contacto}', fecha_fin_servicio=STR_TO_DATE('${req.body.fecha_fin_servicio}', '%d-%m-%YT%H:%i'), plan=${req.body.plan}, capturarpantalla='${req.body.capturarpantalla}', capturarprocesos='${req.body.capturarprocesos}', capturarhistorialnav='${req.body.capturarhistorialnav}', loginbackground='${req.body.loginbackground}', zonahoraria='${req.body.zonahoraria}', pais='${req.body.pais}', invervalo=${req.body.invervalo}, porctcapt=${req.body.porctcapt}, activo='${req.body.activo}', direccion='${req.body.direccion}'  where  codcli = ${req.body.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`put a CLIENTES id = ${req.body.codcli}`)
        res.send(result)
    })
});

//Reactiva un registro de cliente
router.put("/CLIENTES/codcli/:codcli/enable", (req, res) => {    
    var query = connection.query(`UPDATE CLIENTES SET activo='true' where codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a CLIENTES id = ${req.params.codcli}`)
        res.send(result)
    })
});

//Elimina un registro de cliente
router.delete("/CLIENTES/codcli/:codcli", (req, res) => {    
    var query = connection.query(`UPDATE CLIENTES SET activo='false' where codcli = ${req.params.codcli}`
        , function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`delete a CLIENTES id = ${req.params.codcli}`)
        res.send(result)
    })
});

//Consulta un registro de cliente
router.get("/CLIENTES/codcli/:codcli", (req, res) => {    
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' and codcli = ${req.params.codcli} `, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a CLIENTES id = ${req.params.codcli}`)    
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].CODCLI.toString() + ".webp"))) {
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
router.get("/CLIENTES/p/:page", (req, res) => {
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = '${req.query.activo === undefined ? 'true' : req.query.activo}' limit ${req.params.page},${req.params.page+10}`, function(error, result){
        if(error) console.log('[mysql error] : ', error)
        if(DEBUG)console.log(`get a CLIENTES page = ${req.params.page}`)           
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].CODCLI.toString() + ".webp"))) {
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
router.get("/CLIENTES/urlnom/:urlnom", (req, res) => {
    var query = connection.query(`SELECT * FROM CLIENTES WHERE activo = 'true' and lower(urlnom) = lower('${req.params.urlnom}')`, function(error, result){
        if(error) console.log('[mysql error] : ', error)        
        if(DEBUG)console.log(`get a CLIENTES id = ${req.params.urlnom}`)    
        try {
            for (let i = 0; i < result.length; i++) {
                if (fs.existsSync( path.join(__dirname, "public", "logos", result[i].CODCLI.toString() + ".webp"))) {
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
router.delete("/CLIENTES/codcli/:codcli/purge", (req, res) => {
    var query = connection.query(`CALL purgeCliente(${req.params.codcli})`, function(error, result){
        if(error) console.log('[mysql error] : ', error)        
        if(DEBUG)console.log(`purga a CLIENTES id = ${req.params.codcli}`)            
        res.send(result)
    })
});

module.exports = router;