<%@ Page Title="Eliminar" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmpleadoEliminar.aspx.cs" Inherits="AppHotel.EmpleadoEliminar" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <%@ Import Namespace="Dominio" %>  
    <%@ Import Namespace="Negocio" %>  
    </asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
    <div class="modal in" style="display: block;">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
     <center><h4 class="modal-title">Eliminar</h4> </center>   
      </div>
      <div class="modal-body">
               <% int Dni = Convert.ToInt32(Request.QueryString["Dni"]);
            EmpleadoNegocio EmpleadoNegocio = new EmpleadoNegocio();
            Empleado Empleado = new Empleado();
            Empleado = EmpleadoNegocio.BuscarEmpleado(Dni);   %>
     <center> <p>Usted esta seguro de eliminar a  <%=Empleado.Nombre%>?</p></center>  
        <div class="row">
            <div class="col-12-xs text-center">
                <asp:Button ID="Si" runat="server" Text="Si" class="btn btn-success btn-md" OnClick="Si_Click"/>
                <a href="EmpleadoABML.aspx" class="btn btn-danger btn-md">Volver</a>

            </div>
            <br />
                  <center><asp:Label ID="lblMensaje" runat="server" style="font:icon;color:green;"></asp:Label> </center>  

        </div>
      </div>
    </div>
    </div>
    </div>
    </asp:Content>
