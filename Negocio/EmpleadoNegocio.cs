using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Net;
using System.Net.Mail;

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
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email, e.Foto from Empleado as e where e.Dni = " + Dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Empleado = new Empleado();
                    Empleado.Dni = datos.lector.GetInt32(0);
                    Empleado.Nombre = datos.lector.GetString(1);
                    Empleado.Email = datos.lector.GetString(2);
                    Empleado.Foto = datos.lector.GetString(3);

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

        public Empleado BuscarEmpleadoUsuario(int Dni)
        {
            Empleado Empleado;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email, e.Rol from Empleado as e where e.Dni = " + Dni);
                datos.ejecutarLector();

                if (datos.lector.Read())
                {
                    Empleado = new Empleado();
                    Empleado.Dni = datos.lector.GetInt32(0);
                    Empleado.Nombre = datos.lector.GetString(1);
                    Empleado.Email = datos.lector.GetString(2);
                    Empleado.Rol = datos.lector.GetInt32(3);
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

        public bool AgregarEmpleado(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("insert into Empleado (Dni,Nombre,Email,Estado,Rol,Foto)values(@DNI,@Nombre,@Email,@Estado,@Rol,@Foto)");
                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Nombre", Empleado.Nombre);
                datos.agregarParametro("@Email", Empleado.Email);
                datos.agregarParametro("@Estado", true);
                datos.agregarParametro("@Foto", Empleado.Foto);
                datos.agregarParametro("@Rol", 2);

                datos.ejecutarAccion();
                Estado = true;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Estado;

        }


        public bool GenerarUsuario(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("insert into Usuario (Dni,Usuario,Contraseña,Estado)values(@DNI,@Usuario,@Contraseña,0)");
                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Usuario", Empleado.Dni + ".bulldog");
                datos.agregarParametro("@Contraseña", Empleado.Dni);
                datos.ejecutarAccion();
                Estado = true;

            }

            catch (Exception ex)
            {
                throw ex;
            }
            return Estado;

        }

            public void EnviarCorreo(Empleado Empleado)
        {
            var fromAddress = new MailAddress("thebulldoghotelprogramacion@gmail.com", "Bulldog");
            var toAddress = new MailAddress(Empleado.Email, Empleado.Nombre);
            string mensaje = "<h2>Hola</h2>"+Empleado.Nombre+ "<h3>Su usuario es:</h3>" + Empleado.Dni + ".bulldog" + "<h3>Su contraseña es:</h3>" + Empleado.Dni ;
            const string fromPassword = "programacion3";
            const string subject = "Credenciales para entrar al sistema";
            string body = mensaje;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
        public bool ModificarEmpleado(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("update Empleado set Nombre = @Nombre where Dni = @DNI;update Empleado set Email = @Email where Dni = @DNI;update Empleado set Dni = @DNI where DNI = @DNI;");

                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Nombre", Empleado.Nombre);
                datos.agregarParametro("@Email", Empleado.Email);
                datos.ejecutarAccion();
                Estado = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Estado;
        }

        public bool EliminarEmpleado(int Dni)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;
            try
            {
                datos.setearQuery("update Empleado set Estado = 0 where Dni = @DNI; update Usuario set Estado = 1 where Dni = @DNI");

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

        public List<Empleado> ListarEmpleado()
        {
            List<Empleado> Lista = new List<Empleado>();
            Empleado Aux;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email from Empleado as e where e.Estado=1 and e.Rol=2");
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
