using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace AppHotel
{
    public partial class Grafico : System.Web.UI.Page
    {
        string[] Nombres = new string[4];
        Decimal[] Cantidad = new Decimal[4];
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void ObtenerDatos()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearQuery("select t.nombre,t.precio from TipoHabitacion as t");
                datos.ejecutarLector();
                int Contador = 0;
                while (datos.lector.Read())
                {
                    Nombres[Contador] = datos.lector.GetString(0);
                    Cantidad[Contador] = datos.lector.GetDecimal(1);
                    Contador++;
                }
                Graficos.Series["Series"].Points.DataBindXY(Nombres, Cantidad);
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