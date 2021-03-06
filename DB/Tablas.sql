/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     8/12/2021 9:51:19 PM                         */
/*==============================================================*/

drop database if exists Control;
create database Control;
use Control;

/*==============================================================*/
/* Table: DEPARTAMENTOS                                         */
/*==============================================================*/
create table DEPARTAMENTOS
(
   CODDPTO              int not null auto_increment,
   NOMBRE               varchar(200) not null,
   primary key (CODDPTO)
);

/*==============================================================*/
/* Table: EMPLEADOS                                             */
/*==============================================================*/
create table EMPLEADOS
(
   CODEMP               int not null auto_increment,
   CODDPTO              int,
   NOMBRES              varchar(200) not null,
   APELLIDOS            varchar(200) not null,
   TELEFONOS            varchar(20),
   CORREO               varchar(50),
   GENERO               char(1) not null,
   NACIMIENTO           date not null,
   DIRECCION            varchar(1000) not null,
   DUI                  varchar(10) not null,
   NIT                  varchar(18),
   AFP                  varchar(12),
   USUARIO              varchar(50) not null unique,
   PASSWORD             varchar(64) not null,
   ESTADO               char(1) not null,
   primary key (CODEMP)
);

/*==============================================================*/
/* Table: PERMISOS                                              */
/*==============================================================*/
create table PERMISOS
(
   CODPER               int not null auto_increment,
   CODEMP               int,
   FECHA                date not null,
   TIPO                 char(1) not null,
   DESCRIPCION          VARCHAR(1000) not null,
   HORAINICIAL          time,
   HORAFINAL            time,
   ESTADO               char(1),
   primary key (CODPER)
);

/*==============================================================*/
/* Table: REGISTROS                                             */
/*==============================================================*/
create table REGISTROS
(
   CODEMP               int not null,
   FECHA                date not null,
   HORAENTRADA          time not null,
   HORASALIDA           time,
   primary key (CODEMP, FECHA)
);

alter table EMPLEADOS add constraint FK_REFERENCE_2 foreign key (CODDPTO)
      references DEPARTAMENTOS (CODDPTO);

alter table PERMISOS add constraint FK_REFERENCE_3 foreign key (CODEMP)
      references EMPLEADOS (CODEMP);

alter table REGISTROS add constraint FK_REFERENCE_1 foreign key (CODEMP)
      references EMPLEADOS (CODEMP);

INSERT INTO departamentos(NOMBRE) VALUES(UPPER('admin'));
INSERT INTO departamentos(NOMBRE) VALUES(UPPER('sistemas'));
/*empleados dummy data*/
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO) VALUES(1,'admin','istrador','M',NOW(),'','','admin',MD5('admin'),'A');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Jamison','Stack','M','1964-06-22','60566 Roth Center','79934309-7','jamison.stack',MD5('12345'),'A','7824-3110','jstack0@gnu.org','4367-073090-448-3','691109318032');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Angy','Lewington','F','1924-07-12','9936 Pearson Lane','80527954-9','angy.lewington',MD5('12345'),'A','8558-8909','alewington1@marketwatch.com','0554-406598-358-0','850761609402');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Curtis','Mangenot','M','1918-12-19','7 Clemons Terrace','92049413-8','curtis.mangenot',MD5('12345'),'A','6838-3050','cmangenot2@xing.com','6058-372363-516-5','62517176055');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Jacky','Banat','F','1956-10-28','8363 Farmco Park','50127276-4','jacky.banat',MD5('12345'),'A','2971-3450','jbanat3@bluehost.com','3}2907-149559-546-4','596673043881');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Ryon','Colston','M','1952-07-23','0843 Schmedeman Drive','02130317-8','ryon.colston',MD5('12345'),'A','2214-5780','rcolston4@soundcloud.com','2821-007401-916-1','77442962880');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Nappy','Jovasevic','M','1937-01-14','75 Ridgeview Hill','39624328-3','nappy.jovasevic',MD5('12345'),'A','2492-7607','njovasevic5@washington.edu','6586-123405-712-7','727673068650');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Danyelle','Geany','F','1927-05-03','54718 Golden Leaf Point','22333557-0','danyelle.geany',MD5('12345'),'A','2680-1401','dgeany6@csmonitor.com','2612-436847-188-2','812043343154');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Poul','McConnel','M','1960-04-20','2564 Moland Street','52769643-5','poul.mcconnel',MD5('12345'),'A','2032-9227','pmcconnel7@privacy.gov.au','0115-827542-439-5','569999566665');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Radcliffe','Thorouggood','M','1986-09-12','7 Evergreen Junction','86366848-8','radcliffe.thorouggood',MD5('12345'),'A','2419-7999','rthorouggood8@printfriendly.com','8362-876683-175-7','686068663791');
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO,TELEFONOS,CORREO,NIT,AFP) values(2,'Grover','De Malchar','M','1953-05-26','1153 Myrtle Pass','40588322-5','grover.demalchar',MD5('12345'),'A','7137-1117','gdemalchar9@posterous.com','4342-927502-320-6','189857958125');

/*Permisos dummy data*/
INSERT INTO registros VALUES(2,'2021-01-21','07:42','15:01');
INSERT INTO registros VALUES(5,'2020-11-14','07:55','15:05');
INSERT INTO registros VALUES(9,'2021-05-14','07:32','15:11');
INSERT INTO registros VALUES(10,'2021-07-30','07:59','15:12');
INSERT INTO registros VALUES(3,'2021-08-19','07:48','15:00');
INSERT INTO registros VALUES(7,'2021-08-24','07:42','15:21');
INSERT INTO registros VALUES(3,'2020-11-27','07:49','15:18');
INSERT INTO registros VALUES(10,'2021-02-03','07:48','15:22');
INSERT INTO registros VALUES(10,'2020-11-29','07:31','15:26');
INSERT INTO registros VALUES(3,'2021-06-06','07:42','15:02');
INSERT INTO registros VALUES(9,'2021-06-10','07:49','15:01');
INSERT INTO registros VALUES(5,'2021-03-12','07:57','15:20');
INSERT INTO registros VALUES(7,'2021-02-13','07:52','15:09');
INSERT INTO registros VALUES(8,'2021-09-15','07:44','15:04');
INSERT INTO registros VALUES(9,'2021-04-04','07:44','15:26');
INSERT INTO registros VALUES(8,'2021-12-18','07:50','15:23');
INSERT INTO registros VALUES(6,'2021-10-08','07:50','15:08');
INSERT INTO registros VALUES(2,'2021-02-20','07:58','15:19');
INSERT INTO registros VALUES(2,'2021-02-04','07:31','15:10');
INSERT INTO registros VALUES(9,'2021-08-07','07:44','15:10');
INSERT INTO registros VALUES(2,'2021-08-03','07:50','15:14');
INSERT INTO registros VALUES(8,'2020-11-29','07:41','15:11');
INSERT INTO registros VALUES(5,'2021-07-05','07:38','15:20');
INSERT INTO registros VALUES(4,'2021-07-29','07:33','15:16');
INSERT INTO registros VALUES(2,'2021-08-10','07:35','15:10');
INSERT INTO registros VALUES(3,'2021-11-16','07:38','15:15');
INSERT INTO registros VALUES(9,'2021-09-19','07:52','15:28');
INSERT INTO registros VALUES(9,'2021-07-05','07:54','15:20');
INSERT INTO registros VALUES(2,'2021-06-03','07:31','15:22');
INSERT INTO registros VALUES(8,'2021-09-12','07:36','15:29');
INSERT INTO registros VALUES(5,'2021-12-20','07:36','15:29');
INSERT INTO registros VALUES(6,'2021-07-26','07:38','15:13');
INSERT INTO registros VALUES(10,'2021-12-14','07:33','15:17');
INSERT INTO registros VALUES(4,'2020-12-03','07:48','15:14');
INSERT INTO registros VALUES(6,'2021-01-24','07:32','15:18');
INSERT INTO registros VALUES(3,'2021-09-08','07:36','15:01');
INSERT INTO registros VALUES(7,'2021-02-26','07:33','15:11');
INSERT INTO registros VALUES(9,'2021-07-27','07:42','15:11');
INSERT INTO registros VALUES(6,'2021-05-06','07:31','15:21');
INSERT INTO registros VALUES(8,'2020-10-24','07:31','15:29');
INSERT INTO registros VALUES(4,'2020-12-05','07:42','15:19');
INSERT INTO registros VALUES(6,'2021-09-30','07:58','15:21');
INSERT INTO registros VALUES(2,'2021-12-10','07:58','15:22');
INSERT INTO registros VALUES(6,'2021-12-25','07:49','15:02');
INSERT INTO registros VALUES(5,'2021-08-29','07:31','15:14');
INSERT INTO registros VALUES(6,'2020-11-06','07:50','15:01');
INSERT INTO registros VALUES(8,'2021-02-14','07:58','15:01');
INSERT INTO registros VALUES(2,'2021-08-26','07:36','15:21');
INSERT INTO registros VALUES(7,'2021-02-25','07:30','15:12');
INSERT INTO registros VALUES(7,'2021-02-28','07:31','15:07');
INSERT INTO registros VALUES(7,'2020-11-11','07:57','15:06');
INSERT INTO registros VALUES(8,'2021-08-08','07:43','15:24');
INSERT INTO registros VALUES(4,'2021-01-06','07:48','15:04');
INSERT INTO registros VALUES(10,'2021-04-24','07:48','15:02');
INSERT INTO registros VALUES(3,'2021-07-04','07:50','15:14');
INSERT INTO registros VALUES(4,'2021-09-12','07:53','15:18');
INSERT INTO registros VALUES(6,'2021-05-04','07:46','15:01');
INSERT INTO registros VALUES(7,'2021-08-25','07:37','15:15');
INSERT INTO registros VALUES(8,'2021-01-30','07:30','15:07');
INSERT INTO registros VALUES(6,'2020-11-15','07:55','15:03');
INSERT INTO registros VALUES(6,'2021-04-19','07:49','15:20');
INSERT INTO registros VALUES(9,'2021-10-02','07:42','15:11');
INSERT INTO registros VALUES(4,'2021-08-23','07:56','15:02');
INSERT INTO registros VALUES(3,'2021-05-19','07:30','15:20');
INSERT INTO registros VALUES(5,'2021-03-31','07:34','15:02');
INSERT INTO registros VALUES(6,'2021-08-10','07:50','15:10');
INSERT INTO registros VALUES(6,'2021-08-08','07:36','15:22');
INSERT INTO registros VALUES(5,'2020-12-06','07:45','15:20');
INSERT INTO registros VALUES(5,'2021-11-03','07:35','15:10');
INSERT INTO registros VALUES(8,'2021-09-28','07:36','15:19');
INSERT INTO registros VALUES(10,'2021-03-11','07:41','15:03');
INSERT INTO registros VALUES(7,'2021-01-18','07:45','15:01');
INSERT INTO registros VALUES(7,'2021-07-10','07:43','15:11');
INSERT INTO registros VALUES(10,'2021-10-08','07:31','15:20');
INSERT INTO registros VALUES(6,'2021-12-05','07:38','15:26');
INSERT INTO registros VALUES(8,'2021-06-18','07:52','15:18');
INSERT INTO registros VALUES(10,'2021-10-05','07:36','15:16');
INSERT INTO registros VALUES(7,'2021-11-26','07:53','15:07');
INSERT INTO registros VALUES(4,'2021-04-03','07:57','15:07');
INSERT INTO registros VALUES(4,'2021-04-07','07:35','15:09');
INSERT INTO registros VALUES(8,'2021-01-23','07:42','15:29');
INSERT INTO registros VALUES(4,'2021-08-22','07:31','15:04');
INSERT INTO registros VALUES(5,'2021-12-30','07:42','15:29');
INSERT INTO registros VALUES(8,'2021-01-26','07:55','15:06');
INSERT INTO registros VALUES(2,'2021-10-26','07:49','15:05');
INSERT INTO registros VALUES(6,'2021-06-19','07:54','15:27');
INSERT INTO registros VALUES(6,'2020-11-22','07:56','15:05');
INSERT INTO registros VALUES(5,'2021-02-10','07:38','15:22');
INSERT INTO registros VALUES(5,'2021-09-28','07:36','15:25');
INSERT INTO registros VALUES(6,'2021-01-22','07:46','15:17');
INSERT INTO registros VALUES(4,'2021-12-23','07:34','15:00');
INSERT INTO registros VALUES(2,'2021-04-27','07:30','15:15');
INSERT INTO registros VALUES(2,'2021-01-16','07:41','15:27');
INSERT INTO registros VALUES(3,'2020-12-28','07:37','15:25');
INSERT INTO registros VALUES(7,'2020-12-23','07:40','15:23');
INSERT INTO registros VALUES(8,'2021-10-30','07:31','15:12');
INSERT INTO registros VALUES(3,'2021-11-29','07:36','15:11');
INSERT INTO registros VALUES(9,'2021-12-13','07:43','15:20');
INSERT INTO registros VALUES(7,'2021-04-01','07:45','15:26');
INSERT INTO registros VALUES(7,'2021-02-22','07:50','15:29');
INSERT INTO registros VALUES(6,'2020-11-25','07:39','15:05');
INSERT INTO registros VALUES(8,'2021-10-08','07:58','15:14');
INSERT INTO registros VALUES(3,'2021-12-28','07:57','15:13');
INSERT INTO registros VALUES(9,'2021-08-18','07:46','15:17');
INSERT INTO registros VALUES(3,'2021-03-06','07:33','15:24');
INSERT INTO registros VALUES(6,'2021-04-12','07:35','15:20');
INSERT INTO registros VALUES(10,'2021-11-15','07:54','15:23');
INSERT INTO registros VALUES(2,'2021-10-12','07:50','15:16');
INSERT INTO registros VALUES(10,'2021-05-22','07:32','15:13');
INSERT INTO registros VALUES(2,'2021-03-29','07:30','15:22');
INSERT INTO registros VALUES(9,'2021-04-02','07:35','15:01');
INSERT INTO registros VALUES(3,'2021-03-31','07:33','15:22');
INSERT INTO registros VALUES(5,'2021-04-24','07:56','15:19');
INSERT INTO registros VALUES(7,'2021-10-23','07:34','15:26');
INSERT INTO registros VALUES(2,'2021-03-06','07:48','15:11');
INSERT INTO registros VALUES(7,'2021-02-23','07:33','15:26');
INSERT INTO registros VALUES(3,'2021-03-24','07:44','15:08');
INSERT INTO registros VALUES(2,'2021-05-20','07:30','15:22');
INSERT INTO registros VALUES(2,'2021-04-25','07:56','15:15');
INSERT INTO registros VALUES(3,'2021-07-22','07:49','15:29');
INSERT INTO registros VALUES(9,'2020-10-04','07:55','15:18');
INSERT INTO registros VALUES(5,'2021-03-20','07:50','15:01');
INSERT INTO registros VALUES(9,'2021-02-08','07:46','15:05');
INSERT INTO registros VALUES(6,'2021-05-18','07:55','15:13');
INSERT INTO registros VALUES(2,'2021-12-30','07:41','15:09');
INSERT INTO registros VALUES(5,'2021-03-19','07:49','15:22');
INSERT INTO registros VALUES(4,'2021-07-23','07:35','15:07');
INSERT INTO registros VALUES(8,'2021-08-24','07:31','15:05');
INSERT INTO registros VALUES(6,'2020-10-28','07:51','15:13');
INSERT INTO registros VALUES(7,'2021-03-15','07:57','15:11');
INSERT INTO registros VALUES(9,'2021-03-10','07:52','15:04');
INSERT INTO registros VALUES(2,'2021-03-22','07:58','15:03');
INSERT INTO registros VALUES(10,'2021-02-20','07:44','15:11');
INSERT INTO registros VALUES(10,'2021-02-06','07:52','15:13');
INSERT INTO registros VALUES(7,'2021-04-26','07:48','15:02');
INSERT INTO registros VALUES(5,'2021-04-19','07:40','15:02');
INSERT INTO registros VALUES(3,'2021-11-02','07:39','15:13');
INSERT INTO registros VALUES(7,'2021-12-16','07:50','15:28');
INSERT INTO registros VALUES(6,'2021-08-12','07:39','15:11');
INSERT INTO registros VALUES(6,'2021-10-14','07:42','15:12');
INSERT INTO registros VALUES(2,'2020-10-25','07:49','15:21');
INSERT INTO registros VALUES(7,'2020-10-04','07:56','15:01');
INSERT INTO registros VALUES(7,'2021-03-25','07:45','15:02');
INSERT INTO registros VALUES(6,'2021-07-29','07:51','15:08');
INSERT INTO registros VALUES(6,'2021-10-27','07:58','15:04');
INSERT INTO registros VALUES(4,'2021-07-08','07:31','15:27');
INSERT INTO registros VALUES(3,'2021-03-07','07:36','15:05');
INSERT INTO registros VALUES(3,'2021-08-29','07:47','15:01');
INSERT INTO registros VALUES(5,'2021-12-24','07:42','15:19');
INSERT INTO registros VALUES(10,'2021-04-10','07:45','15:06');
INSERT INTO registros VALUES(9,'2021-08-13','07:36','15:17');
INSERT INTO registros VALUES(9,'2021-08-04','07:53','15:17');
INSERT INTO registros VALUES(7,'2021-05-14','07:43','15:09');
INSERT INTO registros VALUES(10,'2021-10-01','07:35','15:24');
INSERT INTO registros VALUES(10,'2021-01-22','07:57','15:09');
INSERT INTO registros VALUES(4,'2020-11-23','07:39','15:17');
INSERT INTO registros VALUES(7,'2021-05-20','07:56','15:02');
INSERT INTO registros VALUES(2,'2021-07-04','07:52','15:27');
INSERT INTO registros VALUES(7,'2021-07-21','07:45','15:27');
INSERT INTO registros VALUES(6,'2021-03-01','07:30','15:21');
INSERT INTO registros VALUES(3,'2021-10-28','07:35','15:28');
INSERT INTO registros VALUES(2,'2021-12-05','07:49','15:16');
INSERT INTO registros VALUES(10,'2020-11-12','07:51','15:15');
INSERT INTO registros VALUES(8,'2021-06-06','07:56','15:29');
INSERT INTO registros VALUES(8,'2021-01-11','07:45','15:13');
INSERT INTO registros VALUES(3,'2020-10-08','07:37','15:28');
INSERT INTO registros VALUES(6,'2021-09-22','07:56','15:05');
INSERT INTO registros VALUES(4,'2021-02-12','07:31','15:07');
INSERT INTO registros VALUES(4,'2021-01-09','07:36','15:19');
INSERT INTO registros VALUES(3,'2021-03-29','07:34','15:01');
INSERT INTO registros VALUES(9,'2021-03-21','07:40','15:29');
INSERT INTO registros VALUES(2,'2021-10-22','07:40','15:08');
INSERT INTO registros VALUES(5,'2021-04-14','07:43','15:17');
INSERT INTO registros VALUES(4,'2020-10-18','07:44','15:14');
INSERT INTO registros VALUES(2,'2021-07-18','07:53','15:04');
INSERT INTO registros VALUES(9,'2020-10-28','07:49','15:20');
INSERT INTO registros VALUES(5,'2021-10-02','07:59','15:21');
INSERT INTO registros VALUES(10,'2021-06-20','07:33','15:08');
INSERT INTO registros VALUES(5,'2021-09-06','07:34','15:17');
INSERT INTO registros VALUES(4,'2021-05-13','07:48','15:23');
INSERT INTO registros VALUES(3,'2021-10-08','07:58','15:07');
INSERT INTO registros VALUES(8,'2021-12-14','07:31','15:09');
INSERT INTO registros VALUES(9,'2021-08-22','07:46','15:16');
INSERT INTO registros VALUES(8,'2021-01-04','07:54','15:06');
INSERT INTO registros VALUES(3,'2021-02-26','07:37','15:14');
INSERT INTO registros VALUES(6,'2021-03-26','07:44','15:07');
INSERT INTO registros VALUES(2,'2020-12-18','07:33','15:25');
INSERT INTO registros VALUES(4,'2021-06-30','07:43','15:24');
INSERT INTO registros VALUES(3,'2021-08-11','07:43','15:00');
INSERT INTO registros VALUES(9,'2021-07-30','07:39','15:01');
INSERT INTO registros VALUES(8,'2021-06-20','07:41','15:12');
INSERT INTO registros VALUES(10,'2020-10-27','07:37','15:27');
INSERT INTO registros VALUES(5,'2021-03-01','07:45','15:26');
INSERT INTO registros VALUES(6,'2021-02-28','07:33','15:29');
INSERT INTO registros VALUES(7,'2021-09-26','07:58','15:16');
INSERT INTO registros VALUES(7,'2021-11-24','07:58','15:09');
INSERT INTO registros VALUES(7,'2021-06-15','07:43','15:21');
INSERT INTO registros VALUES(7,'2021-06-08','07:39','15:17');
INSERT INTO registros VALUES(4,'2021-07-07','07:39','15:01');
INSERT INTO registros VALUES(6,'2021-08-02','07:53','15:08');
