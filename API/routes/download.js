const express = require('express');
const fs = require('fs');
const path = require('path');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;


//Descarga el adjunto vinculado al permiso
router.get("/download/permiso/codper/:codper/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "..", "public", "permisos", req.params.codcli)
        };        
        res.sendFile(`${req.params.codper}.zip`, options, (err) => {
            if(err)
                console.log(err)
        });
    } catch (error) {
        res.status(500).send(error);
    }
});

router.get("/img/captura/codprod/:codprod/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join(__dirname, "..", "public", "screenshots", req.params.codcli)
        };   
        if(fs.existsSync(path.join(options.root, `${req.params.codprod}.webp`)))     
            res.sendFile(`${req.params.codprod}.webp`, options, (err) => {
                if(err)
                    console.log(err)
            });
        else
            res.status(200).send(null);
    } catch (error) {
        res.status(500).send(error);
    }
});

router.get("/img/logo/codcli/:codcli", async (req, res) => {
    try {
        var options = {
            root: path.join( __dirname, "..","public", "logos")
        };  
        if(fs.existsSync(path.join(options.root, `${req.params.codcli}.webp`)))      
            res.sendFile(`${req.params.codcli}.webp`, options, (err) => {
                if(err)
                    console.log(err)
            });
        else
            res.status(200).send(null);
    } catch (error) {
        res.status(500).send(error);
    }
});

module.exports = router;