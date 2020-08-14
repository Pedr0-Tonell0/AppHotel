using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
   public class UsuarioNegocio
    {
        public Usuario BuscarUsuario(string User, string Pass)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select u.Dni, u.Usuario, u.Contraseña from Usuario as u where u.Usuario = @Usuario and u.Contraseña = @Contraseña" );
                datos.agregarParametro("@Usuario", User);
                datos.agregarParametro("@Contraseña", Pass);
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    Usuario Usuario = new Usuario();
                    Usuario.Dni = datos.lector.GetInt32(0);
                    Usuario.User = datos.lector.GetString(1);
                    Usuario.Pass= datos.lector.GetString(2);
                    return Usuario;
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

        public bool BuscarUserPass(string User, string Pass)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("Select u.Dni, u.Usuario, u.Contraseña from Usuario as u where u.Usuario = @Usuario and u.Contraseña = @Contraseña");
                datos.agregarParametro("@Usuario", User);
                datos.agregarParametro("@Contraseña", Pass);
                datos.ejecutarLector();

                while (datos.lector.Read())
                {
                    Usuario Usuario = new Usuario();
                    Usuario.Dni = datos.lector.GetInt32(0);
                    Usuario.User = datos.lector.GetString(1);
                    Usuario.Pass = datos.lector.GetString(2);
                    Estado = true;
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
            return Estado;
        }

        public bool CambiarContraseña(string ContraseñaAntigua, string ContraseñaNueva, int Dni)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Usuario set Contraseña = @Contraseña2 where Dni = @DNI and Contraseña = @Contraseña1;");

                datos.agregarParametro("@DNI", Dni);
                datos.agregarParametro("@Contraseña1", ContraseñaAntigua);
                datos.agregarParametro("@Contraseña2", ContraseñaNueva);
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
