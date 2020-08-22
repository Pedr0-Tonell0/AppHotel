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
    public partial class AlquilerUsuario : System.Web.UI.Page
    {
        public List<Alquilar> ListaAlquilar;

        protected void Page_Load(object sender, EventArgs e)
        {
            Empleado Empleado = new Empleado();
            Empleado = (Empleado)Session["EmpleadoLogueado"];
            AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
            ListaAlquilar = AlquilerNegocio.ListarAlquilerUsuario(Empleado.Dni);
        }
    }
}