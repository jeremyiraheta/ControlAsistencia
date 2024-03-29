const mysql = require('mysql');
require('dotenv').config();
const connection = mysql.createConnection({
    host: process.env.MYSQL_HOST,
    user: process.env.MYSQL_USER,
    password: process.env.MYSQL_PASSWORD,
    database: process.env.MYSQL_DATABASE,
    port: process.env.MYSQL_PORT
 });
 connection.connect(function(error){
    if(error){
       console.log('Conexion fallida.');
       console.log('[mysql error] : ', error)
    }else{
       console.log('Conexion correcta.');       
    }
 });
module.exports = connection;