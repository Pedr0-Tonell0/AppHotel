using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.tool.xml;
using System.IO;
using itextsharp.pdfa;


namespace AppHotel
{
    public partial class Entregar : System.Web.UI.Page
    {
        static Document pdf;

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
        public void GenerarFactura()
        {
            pdf = new Document(PageSize.LETTER);
            string rutaImagen = Server.MapPath("~/Fotos/logo.png");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Factura.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            PdfWriter.GetInstance(pdf, Response.OutputStream);
            pdf.Open();
            pdf.AddAuthor("The Bulldog");
            pdf.AddCreationDate();
            pdf.AddTitle("FACTURA HOTEL THE BULLDOG");
            // Creamos la imagen y le ajustamos el tamaño
         iTextSharp.text.Image imagen = iTextSharp.text.Image.GetInstance(rutaImagen);
           imagen.BorderWidth = 0;
            imagen.Alignment = Element.ALIGN_LEFT;
            float percentage = 0.0f;
            percentage = 150 / imagen.Width;
            imagen.ScalePercent(percentage * 100);

        //     Insertamos la imagen en el documento
            pdf.Add(imagen);
            Paragraph parrafo = new Paragraph("FACTURA HOTEL THE BULLDOG");
            parrafo.Alignment = Element.ALIGN_CENTER;
            //agregar el titulo al documento
            pdf.Add(parrafo);
            pdf.Add(new Paragraph(" "));
            pdf.Add(new Paragraph(" "));

            //crear la tabla con los datos de la factura
            PdfPTable tabla = new PdfPTable(2);
            tabla.HorizontalAlignment = Element.ALIGN_CENTER;
            tabla.AddCell("Dni Cliente:"); tabla.AddCell(txtDNI.Text);
            tabla.AddCell("Nombre Cliente:"); tabla.AddCell(txtNombre.Text);
            tabla.AddCell("Fecha:"); tabla.AddCell(DateTime.Now.Date.ToShortDateString());
            tabla.AddCell("Fecha de Ingreso:"); tabla.AddCell(txtFechaIngreso.Text);
            tabla.AddCell("Fecha de Salida:"); tabla.AddCell(txtFechaEgreso.Text);
            tabla.AddCell("Número de Días:"); tabla.AddCell(TxtDias.Text);
            tabla.AddCell("Costo Noche:"); tabla.AddCell("$" + txtCosto.Text);
            tabla.AddCell("Costo Total:"); tabla.AddCell("$" + txtFinal.Text);
            //agrega la tabla al documento
            pdf.Add(tabla);
            //agrega varias líneas vacías
            pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" "));
            pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" ")); pdf.Add(new Paragraph(" "));
           rutaImagen = Server.MapPath("~/Fotos/firma.jpg");
            iTextSharp.text.Image imagen2 = iTextSharp.text.Image.GetInstance(rutaImagen);
            imagen2.BorderWidth = 0;
            imagen2.Alignment = Element.ALIGN_CENTER;
            percentage = 0.0f;
            percentage = 150 / imagen2.Width;
            imagen2.ScalePercent(percentage * 50);
            pdf.Add(imagen2);
            parrafo = new Paragraph("________________________________");
            parrafo.Alignment = Element.ALIGN_CENTER;
            pdf.Add(parrafo);
            parrafo = new Paragraph("Gerente");
            parrafo.Alignment = Element.ALIGN_CENTER;
            pdf.Add(parrafo);
            pdf.Close();
            Response.Write(pdf);
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
                    BtnEntregar.Visible = false;
                    txtObservaciones.Text = "";
                    txtNombre.Text = "";
                    txtFinal.Text = "";
                    txtCosto.Text = "";
                    TxtDias.Text = "";
                    txtFechaEgreso.Text = "";
                    txtDNI.Text = "";
                    txtFechaIngreso.Text = "";

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            GenerarFactura();
        }
    }
}