using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class HabitacionNegocio
    {
        public List<TipoHabitacion> ListarTipoHabitacion()
        {
            List<TipoHabitacion> Lista = new List<TipoHabitacion>();
            TipoHabitacion Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select t.Id,t.Nombre from TipoHabitacion as t");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new TipoHabitacion();
                    Aux.Id = datos.lector.GetInt32(0);
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
                datos = null;
            }
        }

        public bool AgregarHabitacion(Habitacion Habitacion)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("insert into Habitacion (Numero,Piso,Descripcion,Tipo,Estado)values(@Numero,@Piso,@Descripcion,@Tipo,@Estado)");
                datos.agregarParametro("@Numero", Habitacion.Numero);
                datos.agregarParametro("@Piso", Habitacion.Piso);
                datos.agregarParametro("@Descripcion", Habitacion.Descripcion);
                datos.agregarParametro("@Tipo", Habitacion.Tipo.Id);
                datos.agregarParametro("@Estado", true);

                datos.ejecutarAccion();
                Estado = true;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Estado;

        }

        public Habitacion BuscarHabitacion(int NumeroHabitacion)
        {
            Habitacion Habitacion = new Habitacion();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select h.Numero,h.Piso,h.Descripcion,t.Id from Habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo where h.Numero= " + NumeroHabitacion);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Habitacion = new Habitacion();
                    Habitacion.Numero = datos.lector.GetInt32(0);
                    Habitacion.Piso = datos.lector.GetInt32(1);
                    Habitacion.Descripcion = datos.lector.GetString(2);
                    Habitacion.Tipo = new TipoHabitacion();
                    Habitacion.Tipo.Id = datos.lector.GetInt32(3);
                    return Habitacion;
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

        public int BuscarTipo(string Nombre)
        {
            TipoHabitacion TipoHabitacion = new TipoHabitacion();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select t.Id from TipoHabitacion as t where t.Nombre= @Nombre");
                datos.agregarParametro("@Nombre", Nombre);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    TipoHabitacion = new TipoHabitacion();
                    TipoHabitacion.Id = datos.lector.GetInt32(0);
                    return TipoHabitacion.Id;
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
            return 0;
        }

        public Decimal BuscarPrecio(Habitacion Habitacion)
        {
            TipoHabitacion TipoHabitacion = new TipoHabitacion();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select t.Precio from TipoHabitacion as t where t.Id= @Tipo");
                datos.agregarParametro("@Tipo", Habitacion.Tipo.Id);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    TipoHabitacion = new TipoHabitacion();
                    TipoHabitacion.Precio= datos.lector.GetDecimal(0);
                    return TipoHabitacion.Precio;
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
            return 0;
        }
        public bool ModificarHabitacion(Habitacion Habitacion)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Habitacion set Piso = @Piso where Numero = @Numero;update Habitacion set Descripcion = @Descripcion where Numero = @Numero;update Habitacion set Tipo = @Tipo where Numero = @Numero;");

                datos.agregarParametro("@Numero", Habitacion.Numero);
                datos.agregarParametro("@Piso", Habitacion.Piso);
                datos.agregarParametro("@Descripcion", Habitacion.Descripcion);
                datos.agregarParametro("@Tipo", Habitacion.Tipo.Id);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

        public bool CambiarEstadoHabitacion(int NumeroHabitacion)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Habitacion set Estado = 0 where Numero = @Numero;");
                datos.agregarParametro("@Numero", NumeroHabitacion);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

        public bool VolverDisponibleHabitacion(int NumeroHabitacion)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Habitacion set Estado = 1 where Numero = @Numero;");
                datos.agregarParametro("@Numero", NumeroHabitacion);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }


        public List<Habitacion> ListarHabitacion()
        {
            List<Habitacion> Lista = new List<Habitacion>();
            Habitacion Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select h.Numero,h.Piso,h.Descripcion,t.Nombre,t.Precio from Habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Habitacion();
                    Aux.Numero = datos.lector.GetInt32(0);
                    Aux.Piso = datos.lector.GetInt32(1);
                    Aux.Descripcion = datos.lector.GetString(2);
                    Aux.Tipo = new TipoHabitacion();
                    Aux.Tipo.Nombre = datos.lector.GetString(3);
                    Aux.Tipo.Precio = datos.lector.GetDecimal(4);
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
        public List<Habitacion> ListarHabitacionDisponible()
        {
            List<Habitacion> Lista = new List<Habitacion>();
            Habitacion Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select h.Numero,h.Piso,h.Descripcion,t.Nombre,t.Precio from Habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo where h.Estado=1");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Habitacion();
                    Aux.Numero = datos.lector.GetInt32(0);
                    Aux.Piso = datos.lector.GetInt32(1);
                    Aux.Descripcion = datos.lector.GetString(2);
                    Aux.Tipo = new TipoHabitacion();
                    Aux.Tipo.Nombre = datos.lector.GetString(3);
                    Aux.Tipo.Precio = datos.lector.GetDecimal(4);
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

        public List<Habitacion> ListarHabitacionAlquilada()
        {
            List<Habitacion> Lista = new List<Habitacion>();
            Habitacion Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("select h.Numero,h.Piso,h.Descripcion,t.Nombre,t.Precio from Habitacion as h inner join TipoHabitacion as t on t.Id=h.Tipo where h.Estado=0");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Habitacion();
                    Aux.Numero = datos.lector.GetInt32(0);
                    Aux.Piso = datos.lector.GetInt32(1);
                    Aux.Descripcion = datos.lector.GetString(2);
                    Aux.Tipo = new TipoHabitacion();
                    Aux.Tipo.Nombre = datos.lector.GetString(3);
                    Aux.Tipo.Precio = datos.lector.GetDecimal(4);
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

    }
}
