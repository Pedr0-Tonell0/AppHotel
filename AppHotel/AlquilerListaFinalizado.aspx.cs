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
    public partial class AlquilerListaFinalizado : System.Web.UI.Page
    {
        public List<Alquilar> ListaAlquilar;

        protected void Page_Load(object sender, EventArgs e)
        {
            AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
            ListaAlquilar = AlquilerNegocio.ListarAlquilerFinalizado();

        }
    }
}