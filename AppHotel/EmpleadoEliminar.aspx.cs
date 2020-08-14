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
    public partial class EmpleadoEliminar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Si_Click(object sender, EventArgs e)
        {
            bool Estado; 
            int Dni = Convert.ToInt32(Request.QueryString["Dni"]);
            EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
            Estado = EmpleadoNegocio.EliminarEmpleado(Dni);
            if (Estado == true)
            {
                lblMensaje.Text = "Empleado eliminado correctamente";
            }
        }
    }
}