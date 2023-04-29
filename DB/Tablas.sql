/*==============================================================*/
/* DBMS name:      MySQL                                        */
/*==============================================================*/

drop database if exists Control;
create database Control;
use Control;
/*==============================================================*/
/* Table: CLIENTES                                             */
/*==============================================================*/
create table CLIENTES
(
   CODCLI               int not null auto_increment,
   NOMBRE               varchar(200) not null,
   URL						VARCHAR(200),
   URLNOM					VARCHAR(200) unique NOT NULL,
   CORREO_CONTACTO      varchar(200) not null,
   TELEFONO_CONTACTO    varchar(100) not null,
   DIRECCION				VARCHAR(500),
   FECHA_REGISTRO       datetime not null,
   FECHA_FIN_SERVICIO   datetime not null,
   PLAN                 int not NULL,
   CAPTURARPANTALLA     enum('true','false') DEFAULT 'false',
   CAPTURARPROCESOS     enum('true','false') DEFAULT 'false',
   CAPTURARHISTORIALNAV enum('true','false') DEFAULT 'false',
   LOGINBACKGROUND		VARCHAR(10),		
   ZONAHORARIA          int not null,
   PAIS                 varchar(50) not null,
   INVERVALO            INT DEFAULT 60,
   PORCTCAPT            FLOAT DEFAULT 50,
   ACTIVO               enum('true','false') DEFAULT 'true',
   primary key(CODCLI)
);

/*==============================================================*/
/* Table: DEPARTAMENTOS                                         */
/*==============================================================*/
create table DEPARTAMENTOS
(
	CODDPTO					INT NOT NULL AUTO_INCREMENT,
   CODCLI               int not null,
   NOMBRE               varchar(200) not null,
   primary key (CODDPTO,CODCLI),
   foreign key (CODCLI) references CLIENTES(CODCLI)
);

/*==============================================================*/
/* Table: EMPLEADOS                                             */
/*==============================================================*/
create table EMPLEADOS
(
   CODEMP               int not null auto_increment,
   CODCLI               int not null,
   CODDPTO              INT NOT NULL,
   NOMBRES              varchar(200) not null,
   APELLIDOS            varchar(200) not null,
   TELEFONOS            varchar(20),
   CORREO               varchar(50),
   GENERO               ENUM('M','F') DEFAULT('M'),
   NACIMIENTO           DATE NOT null,
   DIRECCION            varchar(1000),
   DUI                  varchar(10),
   NIT                  varchar(20),
   AFP                  varchar(12),
   USUARIO              varchar(50) not null,
   PASSWORD             varchar(64) not null,
   ACTIVO               enum('true','false') DEFAULT('true'),
   primary key (CODEMP, CODCLI),
   UNIQUE(codcli,usuario),
   foreign key(CODCLI) references CLIENTES(CODCLI),
   FOREIGN KEY(CODCLI,CODDPTO) REFERENCES DEPARTAMENTOS(CODCLI,CODDPTO)
);

/*==============================================================*/
/* Table: PERMISOS                                              */
/*==============================================================*/
create table PERMISOS
(
   CODPER               int not null auto_increment,
   CODEMP               int not null,
   CODCLI               int not null,
   FECHA                date not null,
   TIPO                 char(1) not null,
   DESCRIPCION          VARCHAR(1000) not null,
   HORAINICIAL          time not null,
   HORAFINAL            time not null,
   ESTADO               ENUM('E','A','R'),
   primary key (CODPER),
   foreign key(CODEMP, CODCLI) references EMPLEADOS(CODEMP, CODCLI)
);

/*==============================================================*/
/* Table: REGISTROS                                             */
/*==============================================================*/
create table REGISTROS
(
   CODEMP               int not null,
   CODCLI               int not null,
   FECHA                date not null,
   HORAENTRADA          time not null,
   HORASALIDA           time,
   TOTAL                decimal,
   primary key (CODEMP, CODCLI,FECHA),
   foreign key(CODEMP, CODCLI) references EMPLEADOS(CODEMP, CODCLI)
);

/*==============================================================*/
/* Table: PRODUCTIVIDAD                                             */
/*==============================================================*/
create table PRODUCTIVIDAD
(
   CODPROD              int not null auto_increment,
   CODEMP					INT NOT NULL,
   CODCLI               int not null,
   PROCESOS             mediumtext,
   HISTNAV              mediumtext,
   FECHA                datetime not null,
   primary key(CODPROD),
   foreign key(CODEMP, CODCLI) references EMPLEADOS(CODEMP, CODCLI)
);
/*==============================================================*/
/* Table: UBICACIONES                                             */
/*==============================================================*/
create table UBICACIONES
(
   CODEMP               int not null,
   CODCLI               int not null,
   FECHA                date not null,
   HORAENTRADA          time not null,
   HORASALIDA           time,
   LATINICIAL			double,
   LONGINICIAL			double,
   DIRECCIONINICIAL		VARCHAR(500),
   LATFINAL				double,   
   LONGFINAL				double,
   DIRECCIONFINAL		VARCHAR(500),
   TOTAL                decimal,
   primary key (CODEMP, CODCLI,FECHA),
   foreign key(CODEMP, CODCLI) references EMPLEADOS(CODEMP, CODCLI)
);


/*CLIENTES dummy data*/
INSERT INTO CLIENTES (`NOMBRE`, `URL`, `URLNOM`,`CORREO_CONTACTO`, `TELEFONO_CONTACTO`, `FECHA_REGISTRO`, `FECHA_FIN_SERVICIO`, `PLAN`, `CAPTURARPANTALLA`, `CAPTURARPROCESOS`, `CAPTURARHISTORIALNAV`, `ZONAHORARIA`, `PAIS`, `INVERVALO`, `PORCTCAPT`, `ACTIVO`) VALUES ('SHUSEKI', 'shuseki.azurewebsites.net', 'shuseki', 'jeremy.iraheta@hotmail.com','+50325249228', NOW(), DATE_ADD(NOW(), INTERVAL 31 day), 1, 'true', 'true', 'true', -6, 'El Salvador', 60, 50, 'true');
INSERT INTO CLIENTES (`NOMBRE`, `URL`, `URLNOM`,`CORREO_CONTACTO`, `TELEFONO_CONTACTO`, `FECHA_REGISTRO`, `FECHA_FIN_SERVICIO`, `PLAN`, `CAPTURARPANTALLA`, `CAPTURARPROCESOS`, `CAPTURARHISTORIALNAV`, `ZONAHORARIA`, `PAIS`, `INVERVALO`, `PORCTCAPT`, `ACTIVO`) VALUES ('DIGESTYC', 'digestyc.gob.sv', 'digestyc','info@digestyc.gob.sv','+50325255555', NOW(), DATE_ADD(NOW(), INTERVAL 31 day), 1, 'true', 'true', 'true', -6, 'El Salvador', 60, 50, 'true');
SET @codcli = 2;
/*DEPARTAMENTOS dummy data*/
INSERT INTO DEPARTAMENTOS(NOMBRE,CODCLI) VALUES(UPPER('admin'),1);
INSERT INTO DEPARTAMENTOS(NOMBRE,CODCLI) VALUES(UPPER('admin'),@codcli);
INSERT INTO DEPARTAMENTOS(NOMBRE,CODCLI) VALUES(UPPER('sistemas'),@codcli);
/*EMPLEADOS dummy data*/
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO) VALUES(1,1,'admin','istrador','M',NOW(),'','','admin',MD5('admin'),'true');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(2,@codcli,'Jamison','Stack','M','1964-06-22','60566 Roth Center','79934309-7','jamison.stack',MD5('12345'),'true','7824-3110','jstack0@gnu.org','4367-073090-448-3','691109318032');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Angy','Lewington','F','1924-07-12','9936 Pearson Lane','80527954-9','angy.lewington',MD5('12345'),'true','8558-8909','alewington1@marketwatch.com','0554-406598-358-0','850761609402');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Curtis','Mangenot','M','1918-12-19','7 Clemons Terrace','92049413-8','curtis.mangenot',MD5('12345'),'true','6838-3050','cmangenot2@xing.com','6058-372363-516-5','62517176055');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Jacky','Banat','F','1956-10-28','8363 Farmco Park','50127276-4','jacky.banat',MD5('12345'),'true','2971-3450','jbanat3@bluehost.com','3}2907-149559-546-4','596673043881');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Ryon','Colston','M','1952-07-23','0843 Schmedeman Drive','02130317-8','ryon.colston',MD5('12345'),'true','2214-5780','rcolston4@soundcloud.com','2821-007401-916-1','77442962880');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Nappy','Jovasevic','M','1937-01-14','75 Ridgeview Hill','39624328-3','nappy.jovasevic',MD5('12345'),'true','2492-7607','njovasevic5@washington.edu','6586-123405-712-7','727673068650');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Danyelle','Geany','F','1927-05-03','54718 Golden Leaf Point','22333557-0','danyelle.geany',MD5('12345'),'true','2680-1401','dgeany6@csmonitor.com','2612-436847-188-2','812043343154');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Poul','McConnel','M','1960-04-20','2564 Moland Street','52769643-5','poul.mcconnel',MD5('12345'),'true','2032-9227','pmcconnel7@privacy.gov.au','0115-827542-439-5','569999566665');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Radcliffe','Thorouggood','M','1986-09-12','7 Evergreen Junction','86366848-8','radcliffe.thorouggood',MD5('12345'),'true','2419-7999','rthorouggood8@printfriendly.com','8362-876683-175-7','686068663791');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(3,@codcli,'Grover','De Malchar','M','1953-05-26','1153 Myrtle Pass','40588322-5','grover.demalchar',MD5('12345'),'true','7137-1117','gdemalchar9@posterous.com','4342-927502-320-6','189857958125');
INSERT INTO EMPLEADOS(CODDPTO,CODCLI,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ACTIVO,TELEFONOS,CORREO,NIT,AFP) VALUES(2,@codcli,'Jeremy','Iraheta','M','1953-05-26','1153 Myrtle Pass','40588322-5','jiraheta',MD5('12345'),'true','7137-1117','jiraheta@posterous.com','4342-927502-320-6','189857958125');

/*Ubicaciones dummy data*/
INSERT INTO UBICACIONES VALUES(2,2,'2023-01-26','07:42','07:42',13.694254,-89.261200,"Direccion inicial SS",0.0,0.0,"Direccion final US",10);
INSERT INTO UBICACIONES VALUES(2,2,'2023-01-25','07:42','07:42',13.694254,-89.261200,"Direccion inicial SS",0.0,0.0,"Direccion final US",10);
INSERT INTO UBICACIONES VALUES(1,1,'2023-01-26','07:42','07:42',13.694254,-89.261200,"2Direccion inicial SS",0.0,0.0,"Direccion final US",10);
INSERT INTO UBICACIONES VALUES(3,2,'2023-01-26','07:42','07:42',13.694254,-89.261200,"3Direccion inicial SS",0.0,0.0,"Direccion final US",10);
INSERT INTO UBICACIONES VALUES(4,2,'2023-01-27','07:42','07:42',13.701300,-89.224480,"Salvador del mundo, SS",0.0,0.0,"Direccion final US",10);
INSERT INTO UBICACIONES VALUES(5,2,'2023-01-27','07:42','07:42',13.701300,-89.224480,"Rotonda Salvador del mundo SS",0.0,0.0,"Direccion final San Salvador El Salvador",10);
UPDATE UBICACIONES SET HORASALIDA ='03:22', LATFINAL = 13.694254, LONGFINAL = -89.261200, DIRECCIONFINAL = "URBANIZACION FINAL, SS", TOTAL = 11 WHERE CODEMP = 4 AND CODCLI = 2 AND FECHA ='2023-01-27';

/*Permisos dummy data*/
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-01-21','07:42','15:01',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-11-14','07:55','15:05',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-05-14','07:32','15:11',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-07-30','07:59','15:12',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-08-19','07:48','15:00',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-08-24','07:42','15:21',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-11-27','07:49','15:18',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-02-03','07:48','15:22',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-11-29','07:31','15:26',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-06-06','07:42','15:02',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-06-10','07:49','15:01',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-03-12','07:57','15:20',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-13','07:52','15:09',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-09-15','07:44','15:04',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-04-04','07:44','15:26',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-12-18','07:50','15:23',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-10-08','07:50','15:08',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-02-20','07:58','15:19',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-02-04','07:31','15:10',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-08-07','07:44','15:10',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-08-03','07:50','15:14',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-11-29','07:41','15:11',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-07-05','07:38','15:20',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-07-29','07:33','15:16',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-08-10','07:35','15:10',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-11-16','07:38','15:15',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-09-19','07:52','15:28',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-07-05','07:54','15:20',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-06-03','07:31','15:22',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-09-12','07:36','15:29',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-12-20','07:36','15:29',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-07-26','07:38','15:13',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-12-14','07:33','15:17',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-12-03','07:48','15:14',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-01-24','07:32','15:18',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-09-08','07:36','15:01',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-26','07:33','15:11',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-07-27','07:42','15:11',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-05-06','07:31','15:21',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-10-24','07:31','15:29',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-12-05','07:42','15:19',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-09-30','07:58','15:21',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-12-10','07:58','15:22',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-12-25','07:49','15:02',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-08-29','07:31','15:14',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-11-06','07:50','15:01',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-02-14','07:58','15:01',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-08-26','07:36','15:21',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-25','07:30','15:12',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-28','07:31','15:07',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-11-11','07:57','15:06',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-08-08','07:43','15:24',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-01-06','07:48','15:04',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-04-24','07:48','15:02',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-07-04','07:50','15:14',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-09-12','07:53','15:18',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-05-04','07:46','15:01',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-08-25','07:37','15:15',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-01-30','07:30','15:07',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-11-15','07:55','15:03',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-04-19','07:49','15:20',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-10-02','07:42','15:11',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-08-23','07:56','15:02',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-05-19','07:30','15:20',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-03-31','07:34','15:02',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-08-10','07:50','15:10',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-08-08','07:36','15:22',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-12-06','07:45','15:20',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-11-03','07:35','15:10',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-09-28','07:36','15:19',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-03-11','07:41','15:03',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-01-18','07:45','15:01',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-07-10','07:43','15:11',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-10-08','07:31','15:20',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-12-05','07:38','15:26',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-06-18','07:52','15:18',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-10-05','07:36','15:16',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-11-26','07:53','15:07',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-04-03','07:57','15:07',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-04-07','07:35','15:09',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-01-23','07:42','15:29',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-08-22','07:31','15:04',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-12-30','07:42','15:29',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-01-26','07:55','15:06',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-10-26','07:49','15:05',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-06-19','07:54','15:27',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-11-22','07:56','15:05',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-02-10','07:38','15:22',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-09-28','07:36','15:25',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-01-22','07:46','15:17',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-12-23','07:34','15:00',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-04-27','07:30','15:15',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-01-16','07:41','15:27',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-12-28','07:37','15:25',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-12-23','07:40','15:23',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-10-30','07:31','15:12',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-11-29','07:36','15:11',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-12-13','07:43','15:20',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-04-01','07:45','15:26',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-22','07:50','15:29',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-11-25','07:39','15:05',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-10-08','07:58','15:14',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-12-27','07:57','15:13',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-08-18','07:46','15:17',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-03-06','07:33','15:24',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-04-12','07:35','15:20',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-11-15','07:54','15:23',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-10-12','07:50','15:16',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-05-22','07:32','15:13',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-03-29','07:30','15:22',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-04-02','07:35','15:01',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-03-31','07:33','15:22',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-04-24','07:56','15:19',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-10-23','07:34','15:26',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-03-06','07:48','15:11',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-02-23','07:33','15:26',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-03-24','07:44','15:08',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-05-20','07:30','15:22',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-04-25','07:56','15:15',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-07-22','07:49','15:29',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-10-04','07:55','15:18',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-03-20','07:50','15:01',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-02-08','07:46','15:05',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-05-18','07:55','15:13',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-12-30','07:41','15:09',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-03-19','07:49','15:22',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-07-23','07:35','15:07',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-08-24','07:31','15:05',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-10-28','07:51','15:13',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-03-15','07:57','15:11',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-03-10','07:52','15:04',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-03-22','07:58','15:03',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-02-20','07:44','15:11',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-02-06','07:52','15:13',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-04-26','07:48','15:02',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-04-19','07:40','15:02',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-11-02','07:39','15:13',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-12-16','07:50','15:28',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-08-12','07:39','15:11',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-10-14','07:42','15:12',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-10-25','07:49','15:21',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-10-04','07:56','15:01',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-03-25','07:45','15:02',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-07-29','07:51','15:08',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-10-27','07:58','15:04',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-07-08','07:31','15:27',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-03-07','07:36','15:05',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-08-29','07:47','15:01',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-12-24','07:42','15:19',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-04-10','07:45','15:06',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-08-13','07:36','15:17',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-08-04','07:53','15:17',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-05-14','07:43','15:09',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-10-01','07:35','15:24',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-01-22','07:57','15:09',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-11-23','07:39','15:17',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-05-20','07:56','15:02',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-07-04','07:52','15:27',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-07-21','07:45','15:27',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-03-01','07:30','15:21',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-10-28','07:35','15:28',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-12-05','07:49','15:16',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-11-12','07:51','15:15',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-06-06','07:56','15:29',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-01-11','07:45','15:13',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-10-08','07:37','15:28',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-09-22','07:56','15:05',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-02-12','07:31','15:07',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-01-09','07:36','15:19',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-03-29','07:34','15:01',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-03-21','07:40','15:29',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-10-22','07:40','15:08',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-04-14','07:43','15:17',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-10-18','07:44','15:14',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-07-18','07:53','15:04',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-10-28','07:49','15:20',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-10-02','07:59','15:21',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-06-20','07:33','15:08',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-09-06','07:34','15:17',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-05-13','07:48','15:23',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-11-08','07:58','15:07',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-12-14','07:31','15:09',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-08-22','07:46','15:16',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-01-04','07:54','15:06',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-02-26','07:37','15:14',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-03-26','07:44','15:07',10);
INSERT INTO REGISTROS VALUES(2,@codcli,'2023-12-18','07:33','15:25',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-06-30','07:43','15:24',10);
INSERT INTO REGISTROS VALUES(3,@codcli,'2023-08-11','07:43','15:00',10);
INSERT INTO REGISTROS VALUES(9,@codcli,'2023-07-30','07:39','15:01',10);
INSERT INTO REGISTROS VALUES(8,@codcli,'2023-06-20','07:41','15:12',10);
INSERT INTO REGISTROS VALUES(10,@codcli,'2023-10-27','07:37','15:27',10);
INSERT INTO REGISTROS VALUES(5,@codcli,'2023-03-01','07:45','15:26',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-02-28','07:33','15:29',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-09-26','07:58','15:16',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-11-24','07:58','15:09',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-06-15','07:43','15:21',10);
INSERT INTO REGISTROS VALUES(7,@codcli,'2023-06-08','07:39','15:17',10);
INSERT INTO REGISTROS VALUES(4,@codcli,'2023-07-07','07:39','15:01',10);
INSERT INTO REGISTROS VALUES(6,@codcli,'2023-08-02','07:53','15:08',10);

UPDATE REGISTROS SET total = 400 + RAND() * 100;

--Procedimientos
delimiter //

CREATE PROCEDURE purgeCliente(IN cliente INT)
BEGIN
	DELETE FROM PRODUCTIVIDAD WHERE codcli = cliente;
	DELETE FROM PERMISOS WHERE codcli = cliente;	
	DELETE FROM REGISTROS WHERE codcli = cliente;
	DELETE FROM EMPLEADOS WHERE codcli = cliente;
	DELETE FROM DEPARTAMENTOS WHERE codcli = cliente; 
	DELETE FROM CLIENTES WHERE codcli = cliente;
END//
delimiter ;