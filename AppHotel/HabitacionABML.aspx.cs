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
    public partial class HotelABML : System.Web.UI.Page
    {
        public List<Habitacion> HabitacionLista;
        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
            HabitacionLista = HabitacionNegocio.ListarHabitacion();

        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            Habitacion Habitacion = new Habitacion();
            HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
            Habitacion = null;

            if (txtNumeroHabitacion.Text == "")
            {
                lblMensaje.Text = "Error para buscar tiene que ingresar el numero de habitacion.";

            }

            else
            {
                Habitacion = HabitacionNegocio.BuscarHabitacion(Convert.ToInt32(txtNumeroHabitacion.Text));
            }
            try
            {
                if (Habitacion != null)
                {
                    txtNumeroHabitacion.Text =Habitacion.Numero.ToString();
                    txtTipo.SelectedValue = Habitacion.Tipo.Id.ToString();
                    ddlPiso.SelectedValue = Habitacion.Piso.ToString();
                }
                else if (Habitacion == null)
                {
                    txtNumeroHabitacion.Text = "";
                    txtTipo.Text = "";
                    ddlPiso.Text = "";

                }

            }

            catch (FormatException ex)
            {
                throw ex;
            }
        }

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Estado;
                Habitacion Habitacion = new Habitacion();
                HabitacionNegocio HabitacionNegocio = new HabitacionNegocio();
                Habitacion = null;
                Habitacion = HabitacionNegocio.BuscarHabitacion(Convert.ToInt32(txtNumeroHabitacion.Text));
                if (Habitacion == null)
                {
                    Habitacion = new Habitacion();
                    HabitacionNegocio = new HabitacionNegocio();
                    Habitacion.Numero = int.Parse(txtNumeroHabitacion.Text);
                    Habitacion.Piso = int.Parse(ddlPiso.SelectedValue);
                    Habitacion.Tipo = new TipoHabitacion();
                    Habitacion.Tipo.Id = int.Parse(txtTipo.SelectedValue);
                    if (txtNumeroHabitacion.Text == "" || ddlPiso.SelectedValue == "" ||  txtTipo.SelectedValue == "")
                    {
                        lblMensaje.Text = "Hay campos vacios.";

                    }
                    else
                    {
                        Estado = HabitacionNegocio.AgregarHabitacion(Habitacion);
                        if (Estado == true)
                        {
                            lblMensaje.Text = "Habitacion agregada correctamente";
                            txtNumeroHabitacion.Text = "";
                            txtTipo.Text = "";
                            ddlPiso.Text = "";
                        }
                        else
                        {
                            lblMensaje.Text = "Error la habitacion no fue agregado correctamente.";

                        }

                    }
                }
                else if (Habitacion != null)
                {
                    HabitacionNegocio = new HabitacionNegocio();
                    Habitacion.Numero = int.Parse(txtNumeroHabitacion.Text);
                    Habitacion.Piso = int.Parse(ddlPiso.SelectedValue);
                    Habitacion.Tipo = new TipoHabitacion();
                    Habitacion.Tipo.Id = int.Parse(txtTipo.SelectedValue);
                    if (txtNumeroHabitacion.Text == "" || ddlPiso.SelectedValue == "" ||  txtTipo.SelectedValue == "")
                    {
                        lblMensaje.Text = "Hay campos vacios.";

                    }
                    else
                    {
                        Estado = HabitacionNegocio.ModificarHabitacion(Habitacion);
                        if (Estado == true)
                        {
                            lblMensaje.Text = "Habitacion modificada correctamente";
                            txtNumeroHabitacion.Text = "";
                            txtTipo.Text = "";
                            ddlPiso.Text = "";
                        }
                        else
                        {
                            lblMensaje.Text = "Error la habitacion no fue modificada correctamente.";

                        }
                    }
                }
            }
            catch (Exception)
            {

                lblMensaje.Text = "Hay campos vacios.";
            }

        }
        }
    }
