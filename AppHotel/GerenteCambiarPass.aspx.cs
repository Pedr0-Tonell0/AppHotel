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
                if (UsuarioSession.Pass.Equals(User.Pass) == true)
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
                    else
                    {
                        lblMensaje.Text = "La contraseña nueva no puede ser igual a la antigua.";

                    }
                }
                else
                {
                    lblMensaje.Text = "Error la contraseña no ha sido cambiada correctamente.";

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}