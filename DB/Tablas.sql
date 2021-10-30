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
   NACIMIENTO           datetime not null,
   DIRECCION            varchar(1000) not null,
   DUI                  varchar(10) not null,
   NIT                  varchar(14),
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

INSERT INTO departamentos(NOMBRE) VALUES(UPPER('Sistemas'));
INSERT INTO empleados(CODDPTO,NOMBRES,APELLIDOS,GENERO,NACIMIENTO,DIRECCION,DUI,USUARIO,PASSWORD,ESTADO) VALUES(1,'admin','','','S','','','admin',MD5('admin'),'A');