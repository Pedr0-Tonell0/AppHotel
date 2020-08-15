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
    public partial class Alquiler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocio ClienteNegocio = new ClienteNegocio();
            Cliente Cliente = new Cliente();
            Cliente = null;

            if (txtDNI.Text == "")
            {
                lblMensaje.Text = "Error para buscar tiene que ingresar el DNI";

            }

            else
            {
                Cliente = ClienteNegocio.BuscarCliente(Convert.ToInt32(txtDNI.Text));
                try
                {
                    if (Cliente != null)
                    {
                        txtDNI.Text = Cliente.Dni.ToString();
                        txtNombre.Text = Cliente.Nombre;
                        txtEmail.Text = Cliente.Email;
                    }
                    else if (Cliente == null)
                    {
                        txtDNI.Text = "";
                        txtNombre.Text = "";
                        txtEmail.Text = "";
                    }

                }

                catch (FormatException ex)
                {
                    throw ex;
                }
            }
            }

        protected void BtnAlquilar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Estado1;
                bool Estado2;
                ClienteNegocio ClienteNegocio = new ClienteNegocio();
                AlquilerNegocio AlquilerNegocio = new AlquilerNegocio();
                Cliente Cliente = new Cliente();
                Empleado Empleado = new Empleado();
                HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
                Cliente = null;
                Cliente = ClienteNegocio.BuscarCliente(Convert.ToInt32(txtDNI.Text));
                if (Cliente != null)
                {
                    Cliente.Dni = Convert.ToInt32(txtDNI.Text);
                    DateTime FechaIngreso = System.DateTime.Now;
                    int NumeroHabitacion = Convert.ToInt32(Request.QueryString["Habitacion"]);
                    Empleado = (Empleado)Session["EmpleadoLogueado"];
                    Estado1 = AlquilerNegocio.Alquilar(NumeroHabitacion, Cliente.Dni, Empleado.Dni, FechaIngreso);
                    Estado2 = HabitacionNegocio.CambiarEstadoHabitacion(NumeroHabitacion);
                    if (Estado1 == true && Estado2 == true)
                    {
                        lblMensaje.Text = "Habitacion alquilada correctamente.";
                        txtDNI.Text = "";
                        txtNombre.Text = "";
                        txtEmail.Text = "";
                    }
                    else
                    {
                        lblMensaje.Text = "Error la habitacion no fue alquilada correctamente.";

                    }

                }
                else
                {
                    lblMensaje.Text = "Error el cliente no se encuentra registrado.";

                }
            }
            catch (Exception)
            {

                lblMensaje.Text = "Error el cliente no se encuentra registrado.";
            }
        }
    }
}