const express = require('express');
const fs = require('fs');
const path = require('path');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;

//Sirve middleware para subir archivos adjuntos
router.post("/upload/permiso/codper/:codper/codcli/:codcli", async (req, res) => {
    try {
        if(DEBUG) console.log("post permiso codcli = " + req.params.codcli);
        if(!req.files) {
            res.send({
                status: false,
                message: 'No se pudo subir el archivo'
            });
        } else {
            let file = req.files.attch;
            let ext = file.name.substring(file.name.lastIndexOf("."));            
            let dir = path.join(__dirname, "..", "public", "permisos", req.params.codcli, req.params.codper + ext);
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
        res.status(500).send({
            status: false,
            message: err.message
        });
    }
});

router.post("/upload/captura/codprod/:codprod/codcli/:codcli", async (req, res) => {
    try {
        if(DEBUG) console.log("post captura codcli = " + req.params.codcli);
        if(!req.files) {
            res.send({
                status: false,
                message: 'No se pudo subir el archivo'
            });
        } else {
            let file = req.files.attch;                       
            let dir = path.join(__dirname, "..", "public", "screenshots", req.params.codcli, req.params.codprod + ".webp");
            file.mv(dir);            
            res.send({
                status: true,
                message: 'Archivo subido correctamente'                
            });            
        }            
    } catch (err) {
        res.status(500).send({
            status: false,
            message: 'Ocurrio un error al escribir el archivo'
        });
    }
});

router.post("/upload/logo/codcli/:codcli", async (req, res) => {
    try {
        if(DEBUG) console.log("post logo codcli = " + req.params.codcli);
        if(!req.files) {
            res.send({
                status: false,
                message: 'No se pudo subir el archivo'
            });
        } else {
            let file = req.files.attch;                       
            let dir = path.join(__dirname, "..", "public", "logos", req.params.codcli + ".webp");
            file.mv(dir);            
            res.send({
                status: true,
                message: 'Archivo subido correctamente'                
            });           
        }            
    } catch (err) {
        res.status(500).send({
            status: false,
            message: 'Ocurrio un error al escribir el archivo'
        });
    }
});

module.exports = router;