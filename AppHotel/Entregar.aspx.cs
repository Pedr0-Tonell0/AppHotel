using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace AppHotel
{
    public partial class Entregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
                Alquilar Alquilar = new Alquilar();
                Habitacion Habitacion = new Habitacion();
                HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
                int NumeroHabitacion = Convert.ToInt32(Request.QueryString["Habitacion"]);
                Alquilar = AlquilerNegocio.BuscarAlquiler(NumeroHabitacion);
                DateTime FechaI = Alquilar.FechaIngreso.Date;
                txtFechaIngreso.Text = FechaI.ToString("dd/MM/yyyy");
                txtNombre.Text = Alquilar.Cliente.Nombre;
                txtDNI.Text = Alquilar.Cliente.Dni.ToString();
                DateTime FechaE = System.DateTime.Now;
                txtFechaEgreso.Text = FechaE.Date.ToString("dd/MM/yyyy");
                TimeSpan Dias = System.DateTime.Now - Alquilar.FechaIngreso;
                int Days = Convert.ToInt32(Dias.TotalDays);
                TxtDias.Text = Days.ToString();
                Habitacion = HabitacionNegocio.BuscarHabitacion(NumeroHabitacion);
                Decimal Precio = HabitacionNegocio.BuscarPrecio(Habitacion);
                txtCosto.Text = Math.Truncate(Precio).ToString();
                int PrecioFinal = Convert.ToInt32(Precio) * Days;
                txtFinal.Text = PrecioFinal.ToString();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void BtnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                Alquilar Alquilar = new Alquilar();
                AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
                Habitacion Habitacion = new Habitacion();
                HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
                Empleado Empleado = new Empleado();
                bool Estado1;
                bool Estado2;
                int NumeroHabitacion = Convert.ToInt32(Request.QueryString["Habitacion"]);
                Empleado = (Empleado)Session["EmpleadoLogueado"];
                Alquilar = AlquilerNegocio.BuscarAlquiler(NumeroHabitacion);
                Alquilar.Observaciones = txtObservaciones.Text;
                Alquilar.FechaEgreso = System.DateTime.Now;
                TimeSpan Dias = System.DateTime.Now - Alquilar.FechaIngreso;
                int Days = Convert.ToInt32(Dias.TotalDays);
                Habitacion = HabitacionNegocio.BuscarHabitacion(NumeroHabitacion);
                Decimal Precio = HabitacionNegocio.BuscarPrecio(Habitacion);
                Alquilar.Precio = Convert.ToInt32(Precio) * Days;
                Estado1 = AlquilerNegocio.EntregarHabitacion(Alquilar,Empleado.Dni);
                Estado2 = HabitacionNegocio.VolverDisponibleHabitacion(NumeroHabitacion);
                if (Estado1 == true && Estado2 == true)
                {
                    lblMensaje.Text = "Habitacion entregada correctamente";
                    txtObservaciones.Text = "";
                    txtNombre.Text = "";
                    txtFinal.Text = "";
                    txtCosto.Text = "";
                    TxtDias.Text = "";
                    txtFechaEgreso.Text = "";
                    txtDNI.Text = "";
                    txtFechaIngreso.Text = "";
                    BtnEntregar.Visible = false;
                }
                else
                {
                    lblMensaje.Text = "Error la habitacion no fue entregada correctamente";

                }

            }
            catch (Exception)
            {

                throw;
            }
         }
    }
}