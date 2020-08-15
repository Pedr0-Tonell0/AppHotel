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
                datos.setearQuery("insert into Alquiler (NumeroHabitacion,DniCliente,DniEmpleado,FechaIngreso,Estado) values (@Numero,@DniC,@DniE,@FechaI,@Estado)");
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

        public bool EntregarHabitacion(Alquilar Alquilar)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Alquiler set FechaEgreso = @FechaE where Id=@Id;update Alquiler set Observaciones=@Obs where Id=@Id; update Alquiler set Precio=@Precio where Id=@Id; update Alquiler set Estado=0 where Id=@Id;");
                datos.agregarParametro("@Id", Alquilar.Id);
                datos.agregarParametro("@FechaE", Alquilar.FechaEgreso);
                datos.agregarParametro("@Obs", Alquilar.Observaciones);
                datos.agregarParametro("@Precio", Alquilar.Precio);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

    }
}
