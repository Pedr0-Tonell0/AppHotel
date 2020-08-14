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
        public Usuario BuscarUsuario(Usuario Usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select u.Dni, u.Usuario, u.Contraseña from Usuario as u where u.Dni = @DNI and u.Usuario = @Usuario and u.Contraseña = @Contraseña" );
                datos.agregarParametro("@DNI", Usuario.Dni);
                datos.agregarParametro("@Usuario", Usuario.User);
                datos.agregarParametro("@Contraseña", Usuario.Pass);
                datos.ejecutarLector();

                while(datos.lector.Read())
                {
                    Usuario User = new Usuario();
                    User.Dni = datos.lector.GetInt32(0);
                    User.User = datos.lector.GetString(1);
                    User.Pass= datos.lector.GetString(2);
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
    }
}
