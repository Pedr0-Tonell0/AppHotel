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
Estado bit null,
Tipo int null
)

create table TipoHabitacion(
Id int primary key,
Nombre varchar(50) null,
Precio money null,
Descripcion varchar(200) null,
)

create table Alquiler(
Id int identity primary key,
NumeroHabitacion int null,
DniCliente int null,
DniEmpleadoAlquila int null,
DniEmpleadoEntrega int null,
FechaIngreso date null,
FechaEgreso date null,
Observaciones varchar(150) null,
Precio money null,
Estado bit null
)

create table Usuario(
Usuario varchar(50) null,
Contraseña varchar(50) null,
Dni int primary key,
Estado bit null
)



insert into TipoHabitacion (Id,Nombre,Precio,Descripcion) VALUES (1,'Matrimonial',1500,'Habitación de lujo y un elegante baño con ducha emocional.');
insert into TipoHabitacion (Id,Nombre,Precio,Descripcion) VALUES (2,'Familiar',3000,'Suite de 30 m² para un alojamiento elegante y confortable para 4 personas con jacuzzi circular, baño de hidromasaje y ducha con cascada emocional, ideal para familias.');
insert into TipoHabitacion (Id,Nombre,Precio,Descripcion) VALUES (3,'Compartida',800,'Alojamiento confortable con baño compartido.');
insert into TipoHabitacion (Id,Nombre,Precio,Descripcion) VALUES (4,'Suite',6000,'Ambiente inolvidable y romántica, decorado con estilo y gusto, baño con ducha de cromoterapia, y jacuzzi.');
insert into Usuario (Usuario,Contraseña,Dni,Estado) values ('40391972.bulldog',40391972,40391972,0)
insert into Empleado (Nombre,Email,Dni,Rol,Estado) values ('Admin','admin@bulldog.com',40391972,1,1)
insert into Usuario (Usuario,Contraseña,Dni,Estado) values ('40391970.bulldog',40391970,40391970,0)
insert into Empleado (Nombre,Email,Dni,Rol,Estado) values ('Pedro','pedro@bulldog.com',40391970,2,1)
insert into Habitacion(Numero,Piso,Estado,Tipo) values (1,1,1,1)
insert into Habitacion(Numero,Piso,Estado,Tipo) values (2,2,1,2)
insert into Habitacion(Numero,Piso,Estado,Tipo) values (3,3,1,3)
insert into Habitacion(Numero,Piso,Estado,Tipo) values (4,2,1,4)
insert into Cliente (Nombre,Email,Dni,Estado) values ('Juan Tonello','juan@gmail.com',40391962,1)

