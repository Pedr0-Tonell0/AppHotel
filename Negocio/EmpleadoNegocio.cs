﻿using System;
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

        public bool AgregarEmpleado(Empleado Empleado)
        {
            AccesoDatos datos = new AccesoDatos();
            bool Estado = false;

            try
            {
                datos.setearQuery("insert into Empleado (Dni,Nombre,Email,Estado,Rol)values(@DNI,@Nombre,@Email,@Estado,@Rol)");
                datos.agregarParametro("@DNI", Empleado.Dni);
                datos.agregarParametro("@Nombre", Empleado.Nombre);
                datos.agregarParametro("@Email", Empleado.Email);
                datos.agregarParametro("@Estado", true);
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
                datos.setearQuery("update Empleado set Estado = 0 where Dni = @DNI;");

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
                datos.setearQuery("Select e.Dni, e.Nombre, e.Email from Empleado as e where e.Estado=1");
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