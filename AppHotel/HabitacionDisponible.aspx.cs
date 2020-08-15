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
    public partial class HabitacionDisponible2 : System.Web.UI.Page
    {
        public List<Habitacion> HabitacionLista;

        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
            HabitacionLista = HabitacionNegocio.ListarHabitacionDisponible();
        }
    }
}