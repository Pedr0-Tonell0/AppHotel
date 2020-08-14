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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario Usuario = new Usuario();
                Usuario User = new Usuario();
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                Usuario.Pass = txtContraseña.Text;
                Usuario.User = txtUsuario.Text;
                Usuario.Dni = (Convert.ToInt32(txtContraseña.Text));
                if(txtContraseña.Text == "" || txtUsuario.Text == "")
                {
                    lblMensaje.Text = "Hay campos vacios.";

                }
                if (UsuarioNegocio.BuscarUsuario(Usuario) == null)
                {
                    lblMensaje.Text = "Usuario o contraseña incorrecta.";

                }
                else
                {
                    User = UsuarioNegocio.BuscarUsuario(Usuario);
                    EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
                    Empleado Empleado = new Empleado();
                    Empleado = EmpleadoNegocio.BuscarEmpleadoUsuario(User.Dni);
                    if (Empleado.Rol == 1)
                    {
                        Response.Redirect("PrincipalGerente.aspx");
                    }
                    else if (Empleado.Rol == 2)
                    {
                        Response.Redirect("PrincipalEmpleado.aspx");

                    }

                }

            }
            catch (Exception)
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }

        }
    }
}