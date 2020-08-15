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

    }
}
