									THE BULLDOG HOTEL

Es una app web que se realizo para rendir el final de Programación III de la carrera Tecnicatura Universitaria en Programación en la UTN FRGP.
La web inicia con un Index, funciona como pagina informativa para atraer futuros clientes, el acceso a la app solo pueden hacerlo las personas
que trabajan dentro del hotel.
Al loguearse, segun el tipo de usuario que sea lo va llevar el home correspondiente. Si el usuario fue desempleado, no va poder acceder mas a la app.
Al iniciar la app siempre va contar con el usuario Gerente por default.

Usuario = 40391972.bulldog

Clave = 40391972
---------------------------------------------------------------------------------------------------------------------------------------------------
La app cuenta con dos perfiles:
- Gerente
- Administrativo

----------------------------------------------------------------------------------------------------------------------------------------------------
El perfil de Gerente cuenta con los siguientes modulos:

- Alquileres
El gerente va tener acceso a los alquileres activos, sabiendo que usuario los registró.
El gerente va tener acceso al historial de alquileres en la app.

- Cambiar la contraseña de su perfil

- ABML de empleados
El gerente va poder dar de alta, modificar, eliminar y listar empleados.
Cuando se agrega un empleado, se va poder cargar una foto para identificarlo correctamente.
A la hora de dar de alta un empleado administrativo, se le va a enviar un email con el usuario y la contraseña para ingresar a la app.
Cuenta con un grafico, mostrando cantidad de empleados actuales y cantidad de desempleados.

- ABML de habitaciones
El gerente va poder dar de alta, modificar, eliminar y listar Habitaciones.
Cuenta con un grafico de torta con la cantidad de Tipo X Habitaciones.

- Precios
Va poder ver precio de cada tipo de habitacion, cantidad de disponibles y alquiladas.
Cuenta con un grafico de barras de precio x tipo de habitacion

- Reporte
El gerente va poder ingresar dos fechas como parametro, y el reporte va traer la cantidad de habitaciones de cada tipo que se alquilaron entre esas dos fechas.
Cuenta con un grafico de torta de cantidad de reservas por tipo de habitaciones.

------------------------------------------------------------------------------------------------------------------------------------------------------

El perfil de Administrativo cuenta con los siguientes modulos:

- Alquilar
Va poder registrar el alquiler de una habitacion
Cuando se alquila una habitacion, deja de estar disponible.

- ABML de clientes
Va poder dar de alta, baja, modificar y eliminar un cliente.
Se necesita que el cliente este dado de alta en la app para poder alquilar una habitación.

- Cambiar la contraseña de su perfil

- Entregar habitación
Va poder hacer la entrega de la habitación.
Va poder generar una factura.
Cuando se entrega una habitación, vuelve a estar disponible para ser alquilada.

- Precios
Va poder ver precio de cada tipo de habitacion, cantidad de disponibles y alquiladas.
Cuenta con un grafico de barras de precio x tipo de habitacion

- Reporte
Va poder ver los alquileres que siguen activos y que fueron registrados por el usuario logueado
Va poder ver las entregas que realizo el usuario logueado


