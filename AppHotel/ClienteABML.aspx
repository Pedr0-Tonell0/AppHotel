<%@ Page Title="Clientes" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"CodeBehind="ClienteABML.aspx.cs" Inherits="AppHotel.ClienteABML" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="css/PrincipalGerente.css" rel="stylesheet" >
    </asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
<nav class="navbar navbar-expand-sm bg-dark navbar-dark justify-content-center">
    <ul class="navbar-nav">   
            <li class="nav-item active" style="margin-right:350px;">
      <a class="nav-link" href="PrincipalGerente.aspx" ><i class="fas fa-home"></i> Home</a>
    </li>
           <li class="nav-item active">
      <a class="nav-link" href="AlquilerLista.aspx"><i class="fas fa-shield-alt"></i> Alquileres</a>
    </li>
          <li class="nav-item active">
      <a class="nav-link"><i class="fas fa-user-friends"></i> Clientes</a>
    </li>
        <li class="nav-item active">
      <a class="nav-link" href="HabitacionDisponible.aspx"><i class="far fa-clock"></i> Disponibles</a>
    </li>
            <li class="nav-item active">
      <a class="nav-link" href="EmpleadoABML.aspx"> <i class="fas fa-users"></i> Empleados</a>
    </li>
    <li class="nav-item active">
      <a class="nav-link" href="HabitacionABML.aspx"><i class="fas fa-bed"></i> Habitaciones</a>
    </li>
      <li class="nav-item active">
      <a class="nav-link" href="Reporte.aspx"><i class="fas fa-chart-bar"></i> Reportes</a>
    </li>
                </ul>
</nav>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
 <section>
     
    <style>
        .Error {
            border: solid 2px #ff0000;
        }
    </style>

   <br />
         <div class="container">
               <div class="form-row">
            <div class="form-group col-md-4">
                <h4>Ingresá los datos del cliente</h4>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label Text="DNI" ID="LblDNI" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onfocus="Seleccionar(this.id)" onkeyup="validarDNI()" onKeyPress="return soloNumeros(event)" MaxLength="8" ClientIDMode="Static" Style="margin-top: 10px;" ID="TboxDNI" CssClass="form-control" />
                <p id="MensajeErrorDNI"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Button Text="Buscar" ID="BtnBuscar" ClientIDMode="Static" class="btn btn-dark" autoposback="false" Style="margin-top: 33px; margin-left: 10px;" runat="server"  disabled="true"  />
            </div>
        </div>
        <div class="form-row " style="margin-top: 10px;">
            <div class="form-group col-md-3">
                <asp:Label Text="Nombre" ID="LblNombre" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxNombre" CssClass="form-control" />
                <p id="MensajeErrorNombre"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="Apellido" ID="LblApellido" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxApellido" CssClass="form-control" />
                <p id="MensajeErrorApellido"></p>
            </div>
            <div class="form-group col-md-4">
                <asp:Label Text="Email" ID="LblEmail" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <div class="input-group" style="margin-top: 10px;">
                    <div class="input-group-prepend">
                        <div class="input-group-text">@</div>
                    </div>
                    <asp:TextBox runat="server" onkeyup="validarEmail()" onfocus="Seleccionar(this.id)" MaxLength="33" ClientIDMode="Static" placeholder="Ejemplo@gmail.com" ID="TboxEmail" CssClass="form-control " />
                    <p id="MensajeErrorEmail"></p>
                </div>
            </div>
        </div>
                <div class="form-row" style="margin-top: 10px;">
            <div class="form-group col-md-5">
                <asp:Label Text="Dirección" ID="LblDireccion" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="40" Style="margin-top: 10px;" ID="TboxDirreccion" ClientIDMode="Static"  CssClass="form-control " />
                <p id="MensajeErrorDireccion"></p>
            </div>
            <div class="form-group col-md-">
                <asp:Label Text="Ciudad" ID="LblCiudad" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxCiudad"  CssClass="form-control" />
                <p id="MensajeErrorCiudad"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="CP" ID="LblCP" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="8" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxCP"  CssClass="form-control" />
                <p id="MensajeErrorCP"></p>
            </div>
        </div>
        <div>
<asp:Button Text="Agregar" Style="margin-top: 20px;" class="btn btn-dark" ClientIDMode="Static" ID="BtnParticipar" runat="server"  disabled="true" />
   </div>
            </div>
    
 </section>
       <br />

</asp:Content>

