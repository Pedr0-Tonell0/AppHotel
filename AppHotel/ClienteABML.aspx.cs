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
    public partial class ClienteABML2 : System.Web.UI.Page
    {
        public List<Cliente> ListaCliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            ClienteNegocio ClienteNegocio = new ClienteNegocio();
            ListaCliente = ClienteNegocio.ListarCliente();
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
            }
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

        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bool Estado;
                ClienteNegocio ClienteNegocio = new ClienteNegocio();
                Cliente Cliente = new Cliente();
                Cliente = null;
                Cliente = ClienteNegocio.BuscarCliente(Convert.ToInt32(txtDNI.Text));
                if (Cliente == null)
                {
                    Cliente = new Cliente();
                    Cliente.Dni = Convert.ToInt32(txtDNI.Text);
                    Cliente.Nombre = txtNombre.Text;
                    Cliente.Email = txtEmail.Text;
                    if (txtDNI.Text == "" || txtNombre.Text == "" || txtEmail.Text == "")
                    {
                        lblMensaje.Text = "Hay campos que se encuentran vacios";

                    }
                    Estado = ClienteNegocio.AgregarCliente(Cliente);
                    if (Estado == true)
                    {
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
                else if (Cliente != null)
                {
                    Cliente.Dni = Convert.ToInt32(txtDNI.Text);
                    Cliente.Nombre = txtNombre.Text;
                    Cliente.Email = txtEmail.Text;
                    if (txtDNI.Text == "" || txtNombre.Text == "" || txtEmail.Text == "")
                    {
                        lblMensaje.Text = "Hay campos que se encuentran vacios";

                    }
                    Estado = ClienteNegocio.ModificarCliente(Cliente);
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
            catch (FormatException )
            {
                lblMensaje.Text = "Hay campos que se encuentran vacios";

            }
        }
    }
}