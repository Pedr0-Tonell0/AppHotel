using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
   public class ClienteNegocio
    {
        public Cliente BuscarCliente(int Dni)
        {
            Cliente Cliente; ;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select c.Dni, c.Nombre, c.Email from Cliente as c where c.Dni = " + Dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Cliente = new Cliente();
                    Cliente.Dni = datos.lector.GetInt32(0);
                    Cliente.Nombre = datos.lector.GetString(1);
                    Cliente.Email = datos.lector.GetString(2);
                    return Cliente;
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

        public bool AgregarCliente(Cliente Cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("insert into Cliente (Dni,Nombre,Email,Estado)values(@DNI,@Nombre,@Email,@Estado)");
                datos.agregarParametro("@DNI", Cliente.Dni);
                datos.agregarParametro("@Nombre", Cliente.Nombre);
                datos.agregarParametro("@Email", Cliente.Email);
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
        public bool ModificarCliente(Cliente Cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Cliente set Nombre = @Nombre where Dni = @DNI;update Cliente set Email = @Email where Dni = @DNI;update Cliente set Dni = @DNI where DNI = @DNI;");

                datos.agregarParametro("@DNI", Cliente.Dni);
                datos.agregarParametro("@Nombre", Cliente.Nombre);
                datos.agregarParametro("@Email", Cliente.Email);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

        public bool EliminarCliente(int Dni)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;
            try
            {
                datos.setearQuery("update Cliente set Estado = 0 where Dni = @DNI;");

                datos.agregarParametro("@DNI", Dni);

                datos.ejecutarAccion();
                Estado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Estado;

        }

        public List<Cliente> ListarCliente()
        {
            List<Cliente> Lista = new List<Cliente>();
            Cliente Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select c.Dni, c.Nombre, c.Email from Cliente as c where c.Estado=1");
                datos.ejecutarLector();
                while (datos.lector.Read())
                {
                    Aux = new Cliente();
                    Aux.Dni = datos.lector.GetInt32(0);
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
