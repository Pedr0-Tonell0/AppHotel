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
    public partial class Reporte : System.Web.UI.Page
    {
        public List<TipoHabitacion> Lista;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaInicio.Text == "" || txtFechaFin.Text == "") lblMensaje.Text = "Error tiene que ingresar los parametros de busqueda.";
                Alquilar Alquilar = new Alquilar();
                AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
                Alquilar.FechaIngreso = DateTime.Parse(txtFechaInicio.Text);
                Alquilar.FechaEgreso = DateTime.Parse(txtFechaFin.Text);
                Lista = AlquilerNegocio.Reporte(Alquilar);
                txtFechaInicio.Text = "";
                txtFechaFin.Text = "";
            }
            catch (Exception)
            {

                lblMensaje.Text = "Error tiene que ingresar los parametros de busqueda.";
            }

        }
    }
}