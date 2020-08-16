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
                if(txtContraseña.Text == "" || txtUsuario.Text == "")
                {
                    lblMensaje.Text = "Hay campos vacios.";

                }
                User = UsuarioNegocio.BuscarUsuario(Usuario.User, Usuario.Pass);

                if (User == null )
                {
                    lblMensaje.Text = "Usuario o contraseña incorrecta.";

                }
                if (User.Estado ==true)
                {
                    lblMensaje.Text = "El usuario ingresado fue dado de baja.";

                }
                if (User != null && User.Estado==false)
                {
                    EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
                    Empleado Empleado = new Empleado();
                    Empleado = EmpleadoNegocio.BuscarEmpleadoUsuario(User.Dni);
                    Session["UsuarioLogueado"] = User;
                    Session["EmpleadoLogueado"] = Empleado;
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