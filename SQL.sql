drop database biblioteca

create database biblioteca

use biblioteca

create table Libro
(	codigo  char(6) primary key,
	isbn varchar(12) unique,
	titulo varchar(50),
	editorial varchar(50),
	descripcion text
)

create table ejemplar
(
	codigo  char(6) references libro(codigo),
	numeroEjemp smallint,
	fechaPublicacion smalldatetime,
	estado char check (estado in ('D', 'P')),
	primary key (codigo,numeroEjemp) 
)

create table socio
(
	codigo char(5) primary key,
	dni char(9) unique,
	nombre varchar(15),
	apellidos varchar(30),
	direccion varchar(60),
	correo varchar(50),
	telefono char(9)
)

create table prestamo
(	codigo  char(6) ,
	numeroEjemp smallint,
	codigoSocio char(5) references socio(codigo),
	fechaPrestamo smalldatetime,
	fechaDevolucion smalldateTime,
	foreign key (codigo,numeroEjemp) references ejemplar(codigo,numeroEjemp),
	primary key(codigo,numeroEjemp,fechaPrestamo)
)

select * from Libro

select * from ejemplar

Insert Libro values(2,23,'hola','Editores Rigobertos','Un buen librote')

Select * from Libro Where isbn = 4

-- Pone el estado='P' del ejemplar:
update ejemplar set estado ='D' where codigo = 2 and numeroEjemp = 2

-- Busca el primer libro disponible:
Select top 1 numeroEjemp from Ejemplar Where codigo = 2 and estado='D'