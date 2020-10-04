using System;
using System.Collections.Generic;
using System.IO;
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
            Image1.Visible = false;


        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
            Empleado Empleado = new Empleado();
            Empleado = null;

            if (txtDNI.Text == "")
            {
                lblMensaje.Text = "Error para buscar tiene que ingresar el DNI";

            }

            else
            {
                Empleado = EmpleadoNegocio.BuscarEmpleado(Convert.ToInt32(txtDNI.Text));
            }
            try
            {
                if (Empleado != null)
                {
                    Image1.Visible = true;
                    txtDNI.Text = Empleado.Dni.ToString();
                    txtNombre.Text = Empleado.Nombre;
                    txtEmail.Text = Empleado.Email;
                    Image1.ImageUrl = Empleado.Foto;
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
                bool Estado;
                string Extension;
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
                    if (Foto.HasFile)
                    {
                       Extension = Path.GetExtension(Foto.FileName).ToLower();
                        if (Extension == ".jpg" || Extension == ".gif" || Extension == ".jpeg")
                        {
                            Foto.SaveAs(Server.MapPath("~/Fotos/" + Foto.FileName));
                            Empleado.Foto = "~/Fotos/" + Foto.FileName;
                        }
                        else
                        {
                            lblMensaje.Text = "El formato de la imagen es incorrecto";

                        }

                    }  
                    else
                    {
                        Empleado.Foto = "";
                    }
                    
                    if (txtDNI.Text == "" || txtNombre.Text == "" || txtEmail.Text == "")

                    {
                        lblMensaje.Text = "Hay campos que se encuentran vacios";

                    }

                    else
                    {

                        Estado = EmpleadoNegocio.AgregarEmpleado(Empleado);
                        if (Estado == true)
                        {
                            EmpleadoNegocio.GenerarUsuario(Empleado);
                            lblMensaje.Text = "Empleado agregado correctamente";
                            txtDNI.Text = "";
                            txtNombre.Text = "";
                            txtEmail.Text = "";
                        }
                        else
                        {
                            lblMensaje.Text = "Error el empleado no fue agregado correctamente";
                        }

                    }

                }
                else if (Empleado != null)
                {
                    Empleado.Dni = Convert.ToInt32(txtDNI.Text);
                    Empleado.Nombre = txtNombre.Text;
                    Empleado.Email = txtEmail.Text;

                    if (txtDNI.Text == "" || txtNombre.Text == "" || txtEmail.Text == "")

                    {
                        lblMensaje.Text = "Hay campos que se encuentran vacios";

                    }

                    else
                    {
                        Estado = EmpleadoNegocio.ModificarEmpleado(Empleado);
                        if (Estado == true)
                        {
                            lblMensaje.Text = "Empleado modificado correctamente";
                            txtDNI.Text = "";
                            txtNombre.Text = "";
                            txtEmail.Text = "";
                        }
                        else
                        {
                            lblMensaje.Text = "Error el empleado no fue modificado correctamente";

                        }

                    }

                }
            }
            catch (Exception)
            {
                lblMensaje.Text = "Hay campos que se encuentran vacios o verificar el formato de la imagen";

            }
        }

    }
}   