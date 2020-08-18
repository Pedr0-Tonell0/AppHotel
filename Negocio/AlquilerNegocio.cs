using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class AlquilerNegocio
    {
        public bool Alquilar(int NumeroHabitacion, int DniCliente, int DniEmpleado, DateTime FechaIngreso)
        {
            bool Bandera = false;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("insert into Alquiler (NumeroHabitacion,DniCliente,DniEmpleadoAlquila,FechaIngreso,Estado) values (@Numero,@DniC,@DniE,@FechaI,@Estado)");
                datos.agregarParametro("@Numero", NumeroHabitacion);
                datos.agregarParametro("@DniC", DniCliente);
                datos.agregarParametro("@DniE", DniEmpleado);
                datos.agregarParametro("@FechaI", FechaIngreso);
                datos.agregarParametro("@Estado", 1);
                datos.ejecutarAccion();
                Bandera = true;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Bandera;

        }
        public Alquilar BuscarAlquiler(int NumeroHabitacion)
        {
            Alquilar Alquiler;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("SELECT a.Id,a.FechaIngreso,a.DniCliente,c.Nombre from ALQUILER as a inner join cliente as c on c.Dni= a.DniCliente where a.estado=1 and a.NumeroHabitacion = " + NumeroHabitacion);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Alquiler = new Alquilar();
                    Alquiler.Id = datos.lector.GetInt32(0);
                    Alquiler.FechaIngreso = datos.lector.GetDateTime(1);
                    Alquiler.Cliente = new Cliente();
                    Alquiler.Cliente.Dni = datos.lector.GetInt32(2);
                    Alquiler.Cliente.Nombre = datos.lector.GetString(3);
                    return Alquiler;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return null;
        }

        public bool BuscarClienteAlquilerActivo(Cliente Cliente)
        {
            Alquilar Alquiler;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("SELECT a.Id,a.FechaIngreso,a.DniCliente from alquiler as a where a.Estado=1 and a.DniCliente = " + Cliente.Dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Alquiler = new Alquilar();
                    Alquiler.Id = datos.lector.GetInt32(0);
                    Alquiler.FechaIngreso = datos.lector.GetDateTime(1);
                    Alquiler.Cliente = new Cliente();
                    Alquiler.Cliente.Dni = datos.lector.GetInt32(2);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return false;
        }


        public bool EntregarHabitacion(Alquilar Alquilar, int DNI)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Alquiler set FechaEgreso = @FechaE where Id=@Id;update Alquiler set Observaciones=@Obs where Id=@Id; update Alquiler set Precio=@Precio where Id=@Id; update Alquiler set Estado=0 where Id=@Id;update Alquiler set DniEmpleadoEntrega=@Dni where Id=@Id;");
                datos.agregarParametro("@Id", Alquilar.Id);
                datos.agregarParametro("@FechaE", Alquilar.FechaEgreso);
                datos.agregarParametro("@Obs", Alquilar.Observaciones);
                datos.agregarParametro("@Precio", Alquilar.Precio);
                datos.agregarParametro("@Dni", DNI);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

        public List<Alquilar> ListarAlquilerFinalizado()
        {
            List<Alquilar> Lista = new List<Alquilar>();
            Alquilar Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select a.FechaEgreso,a.FechaIngreso,a.Precio,a.DniEmpleadoAlquila,a.DniEmpleadoEntrega,c.Dni,c.Nombre,h.Numero,h.Piso,t.Nombre,t.Descripcion,t.Precio from habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo inner join Alquiler as a on a.NumeroHabitacion=h.Numero inner join Cliente as c on c.Dni=a.DniCliente where a.Estado=0");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Alquilar();
                    Aux.FechaEgreso = datos.lector.GetDateTime(0);
                    Aux.FechaIngreso = datos.lector.GetDateTime(1);
                    Aux.Precio = datos.lector.GetDecimal(2);
                    Aux.Empleado = new Empleado();
                    Aux.Empleado.Dni= datos.lector.GetInt32(3);
                    Aux.Empleado2 = new Empleado();
                    Aux.Empleado2.Dni = datos.lector.GetInt32(4);
                    Aux.Cliente = new Cliente();
                    Aux.Cliente.Dni = datos.lector.GetInt32(5);
                    Aux.Cliente.Nombre = datos.lector.GetString(6);
                    Aux.Habitacion = new Habitacion();
                    Aux.Habitacion.Numero = datos.lector.GetInt32(7);
                    Aux.Habitacion.Piso= datos.lector.GetInt32(8);
                    Aux.Tipo = new TipoHabitacion();
                    Aux.Tipo.Nombre = datos.lector.GetString(9);
                    Aux.Tipo.Descripcion = datos.lector.GetString(10);
                    Aux.Tipo.Precio = datos.lector.GetDecimal(11);
                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }

        }

        public List<Alquilar> ListarAlquilerEjecucion()
        {
            List<Alquilar> Lista = new List<Alquilar>();
            Alquilar Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select a.FechaIngreso,a.DniEmpleadoAlquila,c.Dni,c.Nombre,h.Numero,h.Piso,t.Nombre,t.Descripcion,t.Precio from habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo inner join Alquiler as a on a.NumeroHabitacion=h.Numero inner join Cliente as c on c.Dni=a.DniCliente where a.Estado=1");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Alquilar();
                    Aux.FechaIngreso = datos.lector.GetDateTime(0);
                    Aux.Empleado = new Empleado();
                    Aux.Empleado.Dni = datos.lector.GetInt32(1);
                    Aux.Cliente = new Cliente();
                    Aux.Cliente.Dni = datos.lector.GetInt32(2);
                    Aux.Cliente.Nombre = datos.lector.GetString(3);
                    Aux.Habitacion = new Habitacion();
                    Aux.Habitacion.Numero = datos.lector.GetInt32(4);
                    Aux.Habitacion.Piso = datos.lector.GetInt32(5);
                    Aux.Tipo = new TipoHabitacion();
                    Aux.Tipo.Nombre = datos.lector.GetString(6);
                    Aux.Tipo.Descripcion = datos.lector.GetString(7);
                    Aux.Tipo.Precio = datos.lector.GetDecimal(8);
                    Lista.Add(Aux);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
                datos = null;
            }

        }

        public List<TipoHabitacion> Reporte(Alquilar Alquilar )
        {
            List<TipoHabitacion> Lista = new List<TipoHabitacion>();
            TipoHabitacion Aux;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select count(t.Id) as cantidad,t.Nombre from Alquiler as a inner join Habitacion as h on h.Numero=a.NumeroHabitacion inner join TipoHabitacion as t on t.Id=h.Tipo where a.Estado=0 and FechaIngreso >= @FechaIngreso and FechaEgreso<=@FechaEgreso group by t.Nombre");
                datos.agregarParametro("@FechaEgreso", Alquilar.FechaEgreso);
                datos.agregarParametro("@FechaIngreso", Alquilar.FechaIngreso);
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    Aux = new TipoHabitacion();

                    Aux.Disponibles = datos.lector.GetInt32(0);
                    Aux.Nombre = datos.lector.GetString(1);
                    Lista.Add(Aux);
                }
                return Lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
