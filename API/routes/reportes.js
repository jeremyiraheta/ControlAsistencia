const connection = require('../mysql.js');
const express = require('express');
const fs = require('fs');
const path = require('path');
const pdf = require('html-pdf');
const Handlebars = require('handlebars');
const router = express.Router();
const DEBUG = process.env.DEBUG || true;


router.post("/reporteHoras.pdf", (req, res) => {
    try {        
        if(req.body.codcli == undefined)
            throw Error("La peticion no tiene parametros validos");
        if(DEBUG) console.log("get reporte horas codcli = " + req.body.codcli);
        var html = fs.readFileSync( path.join(__dirname, "..", "templates","reporteHoras.html"), "utf8");
        var options = {
            format: "A4",
            orientation: "landscape",
            border: {
                top: "0mm",            // default is 0, units: mm, cm, in, px
                right: "24mm",
                bottom: "0mm",
                left: "24mm"
              },
            header: {
                height: "24mm",
                contents: '<div style="text-align: center;"><h1>Reporte de Horas Laboradas</h1></div>'
            },
            footer: {
                height: "24mm",
                contents: {                    
                    default: '<div style="text-align:center;">{{page}}/{{pages}}</div>'
                }
            }
        };
        var query = connection.query(`SELECT distinct e.NOMBRES nombres, e.APELLIDOS apellidos, d.NOMBRE departamento,
        (select COUNT(*) from PERMISOS p where p.CODCLI = r.CODCLI and p.CODEMP = r.CODEMP and YEAR(p.FECHA) = YEAR(r.FECHA) AND MONTH(p.FECHA) = MONTH(r.FECHA)) permisos, 
        (select CONCAT(FLOOR(SUM(t.TOTAL) / 60), 'h',LPAD(SUM(t.TOTAL) % 60, 2, 0), 'm') from REGISTROS t where t.CODCLI = r.CODCLI and t.CODEMP = r.CODEMP and YEAR(t.FECHA) = YEAR(r.FECHA) AND MONTH(t.FECHA) = MONTH(r.FECHA)) horas, 
        c.NOMBRE cliente, YEAR(r.FECHA) anio, LPAD(MONTH(r.FECHA),2,0) mes FROM REGISTROS r LEFT JOIN EMPLEADOS e ON r.CODEMP = e.CODEMP 
        LEFT JOIN CLIENTES c on r.CODCLI = c.CODCLI
        LEFT JOIN DEPARTAMENTOS d on r.CODCLI = d.CODCLI AND e.CODDPTO = d.CODDPTO        
        WHERE e.activo = 'true' and e.CODCLI = ${req.body.codcli} AND YEAR(r.FECHA) = '${req.body.y}' AND MONTH(r.FECHA) = '${req.body.m}' ORDER BY horas asc`, function(error, result){
            if(error)
            {
                console.log('[mysql error] : ', error)
                throw new Error(error);
            }                 
            else
            {
                var document = {
                    html: html,
                    data: {
                      rows: result,
                    }
                  };
                  HTMLtoPDF(document, options)
                    .then((f) => {
                        res.contentType('application/pdf;'); 
                        res.setHeader('Content-Disposition','inline; name="ReporteHoras"; filename="ReporteHoras.pdf";');                                            
                        res.send(f);
                    })
                    .catch((error) => {
                        throw new Error(error);
                    });
            }
            
        });          
    } catch (ex) {
        res.status(500).send(ex.message);
    }
});

router.post("/reportePermisos.pdf", (req, res) => {
    try {
        if(req.body.codcli == undefined)
            throw Error("La peticion no tiene parametros validos");
        if(DEBUG) console.log("get reporte permisos codcli = " + req.body.codcli);
        var html = fs.readFileSync( path.join(__dirname, "..", "templates","reportePermisos.html"), "utf8");
        var options = {
            format: "A4",
            orientation: "landscape",
            border: {
                top: "0mm",            // default is 0, units: mm, cm, in, px
                right: "24mm",
                bottom: "0mm",
                left: "24mm"
              },
            header: {
                height: "24mm",
                contents: '<div style="text-align: center;"><h1>Reporte de Permisos</h1></div>'
            },
            footer: {
                height: "24mm",
                contents: {                    
                    default: '<div style="text-align:center;">{{page}}/{{pages}}</div>'
                }
            }
        };
        var query = connection.query(`SELECT distinct e.NOMBRES nombres, e.APELLIDOS apellidos, d.NOMBRE departamento,
        DATE_FORMAT(r.FECHA,'%d-%m-%Y') fecha, r.TIPO tipo, if(r.ESTADO='E', 'Espera', if(r.ESTADO='A', 'Aprobado', 'Rechazado')) estado, r.HORAFINAL ini, r.HORAFINAL fin,
        c.NOMBRE cliente, YEAR(r.FECHA) anio, LPAD(MONTH(r.FECHA),2,0) mes FROM PERMISOS r LEFT JOIN EMPLEADOS e ON r.CODEMP = e.CODEMP 
        LEFT JOIN CLIENTES c on r.CODCLI = c.CODCLI
        LEFT JOIN DEPARTAMENTOS d on r.CODCLI = d.CODCLI AND e.CODDPTO = d.CODDPTO        
        WHERE e.activo = 'true' and e.CODCLI = ${req.body.codcli} AND YEAR(r.FECHA) = '${req.body.y}' AND MONTH(r.FECHA) = '${req.body.m}' order by fecha`, function(error, result){
            if(error)
            {
                console.log('[mysql error] : ', error)
                throw new Error(error);
            }                 
            else
            {
                var document = {
                    html: html,
                    data: {
                      rows: result,
                    }
                  };
                  HTMLtoPDF(document, options)
                    .then((f) => {
                        res.contentType('application/pdf;'); 
                        res.setHeader('Content-Disposition','inline; name="ReportePermisos"; filename="ReportePermisos.pdf";');                                            
                        res.send(f);
                    })
                    .catch((error) => {
                        throw new Error(error);
                    });
            }
            
        });          
    } catch (ex) {
        res.status(500).send(ex.message);
    }
});
//Envia datos a un template html de handlebar para generar pdf, devuelve promise
const HTMLtoPDF = (doc, options) => {
	return new Promise((resolve, reject) => {
		if (!doc || !doc.html || !doc.data) {
			reject(new Error('Falta la estructura del documento.'));
		}
		let html = Handlebars.compile(doc.html)(doc.data);        
        pdf.create(html, options).toBuffer(function (err, res) {
            if (err) handleError('ERROR: ', err);            
            resolve(res);
        });
	});
}

module.exports = router;