create database AppHotel
use AppHotel

create table Empleado(
Dni int primary key,
Nombre varchar (100) null,
Email varchar (50) null,
Rol int null,
Estado bit null
)

create table Cliente(
Dni int primary key,
Nombre varchar (100) null,
Email varchar (50) null,
Estado bit null
)

create table Habitacion(
Numero int primary key,
Piso int null,
Descripcion varchar(150) null,
Estado bit null,
Tipo int null
)

create table TipoHabitacion(
Id int primary key,
Nombre varchar(50) null,
Precio money null
)

create table Alquiler(
Id int identity primary key,
NumeroHabitacion int null,
DniCliente int null,
DniEmpleado int null,
FechaIngreso date null,
FechaEgreso date null,
Observaciones varchar(150) null,
Precio money null,
Estado bit null
)

create table Usuario(
Usuario varchar(50) null,
Contraseña varchar(50) null,
Dni int primary key
)




insert into TipoHabitacion (Id,Nombre,Precio) VALUES (1,'Matrimonial',1500);
insert into TipoHabitacion (Id,Nombre,Precio) VALUES (2,'Familiar',3000);
insert into TipoHabitacion (Id,Nombre,Precio) VALUES (3,'Compartida',800);
insert into TipoHabitacion (Id,Nombre,Precio) VALUES (4,'Suite',6000);
insert into Usuario (Usuario,Contraseña,Dni) values ('40403031.bulldog',40403031,40403031)
insert into Empleado (Nombre,Email,Dni,Rol,Estado) values ('Admin','admin@bulldog.com',40403031,1,1)
