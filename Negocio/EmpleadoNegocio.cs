using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
  public  class EmpleadoNegocio
    {
        public Empleado BuscarEmpleado(int Dni)
        {
            Empleado Empleado;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email from Empleado as e where e.Dni = " + Dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Empleado = new Empleado();
                    Empleado.Dni = datos.lector.GetInt32(0);
                    Empleado.Nombre = datos.lector.GetString(1);
                    Empleado.Email = datos.lector.GetString(2);
                    return Empleado;
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

        public void AgregarEmpleado(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("insert into Empleado (Dni,Nombre,Email)values(@DNI,@Nombre,@Email)");
                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Nombre", Empleado.Nombre);
                datos.agregarParametro("@Email", Empleado.Email);
                datos.ejecutarAccion();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarEmpleado(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("update Empleado set Nombre = @Nombre where Dni = @DNI;update Empleado set Email = @Email where Dni = @DNI;update Empleado set Dni = @DNI where DNI = @DNI;");

                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Nombre", Empleado.Nombre);
                datos.agregarParametro("@Email", Empleado.Email);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Empleado> ListarEmpleado()
        {
            List<Empleado> Lista = new List<Empleado>();
            Empleado Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email from Empleado as e");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Empleado();
                    Aux.Dni= datos.lector.GetInt32(0);
                    Aux.Nombre = datos.lector.GetString(1);
                    Aux.Email = datos.lector.GetString(2);
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
