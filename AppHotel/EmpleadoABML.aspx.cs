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
    public partial class EmpleadoABML : System.Web.UI.Page
    {
        public List<Empleado> ListaEmpleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
            ListaEmpleado = EmpleadoNegocio.ListarEmpleado();
            }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
            Empleado Empleado = new Empleado();
            Empleado = null;

            if (txtDNI.Text == "")
            {
            }

            else
            {
                Empleado = EmpleadoNegocio.BuscarEmpleado(Convert.ToInt32(txtDNI.Text));
            }
            try
            {
                if (Empleado != null)
                {
                    txtDNI.Text = Empleado.Dni.ToString();
                    txtNombre.Text = Empleado.Nombre;
                    txtEmail.Text = Empleado.Email;
                }
                else if (Empleado == null)
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

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
                Empleado Empleado = new Empleado();
                Empleado = null;
                Empleado = EmpleadoNegocio.BuscarEmpleado(Convert.ToInt32(txtDNI.Text));
                if (Empleado == null)
                {
                    Empleado = new Empleado();
                    Empleado.Dni = Convert.ToInt32(txtDNI.Text);
                    Empleado.Nombre = txtNombre.Text;
                    Empleado.Email = txtEmail.Text;
                    EmpleadoNegocio.AgregarEmpleado(Empleado);
                }
                else if (Empleado != null)
                {
                    Empleado.Dni = Convert.ToInt32(txtDNI.Text);
                    Empleado.Nombre = txtNombre.Text;
                    Empleado.Email = txtEmail.Text;
                    EmpleadoNegocio.ModificarEmpleado(Empleado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  



    }
}   