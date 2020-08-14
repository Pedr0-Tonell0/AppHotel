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
    public partial class GerenteCambiarPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario Usuario = new Usuario();
                Usuario User = new Usuario();
                Usuario UsuarioSession = new Usuario();
                UsuarioSession = (Usuario)Session["UsuarioLogueado"];
                UsuarioNegocio UsuarioNegocio = new UsuarioNegocio();
                bool Estado;
                Usuario.Pass = txtPassNew.Text;
                User.Pass = txtPassOld.Text;
                if (txtPassNew.Text == "" || txtPassOld.Text=="")
                {
                    lblMensaje.Text = "Hay campos vacios.";

                }
                if (UsuarioNegocio.BuscarUserPass(UsuarioSession.User,User.Pass) == true)
                {
                    if (Usuario.Pass.Equals(User.Pass) == false)
                    {
                        Estado = UsuarioNegocio.CambiarContraseña(User.Pass, Usuario.Pass, UsuarioSession.Dni);
                        if (Estado == true)
                        {
                            lblMensaje.Text = "La contraseña ha sido cambiada correctamente.";

                        }
                        else
                        {
                            lblMensaje.Text = "Error la contraseña no ha sido cambiada correctamente.";
                        }
                    }
                    else if (Usuario.Pass.Equals(User.Pass) == true)
                    {
                        lblMensaje.Text = "La contraseña nueva no puede ser igual a la antigua.";

                    }
                }
                else
                {
                    lblMensaje.Text = "Error la contraseña actual no coincide con el nombre de usuario.";

                }
            }
            catch (Exception)
            {

                lblMensaje.Text = "Error hay campos vacios.";
            }

        }
    }
}