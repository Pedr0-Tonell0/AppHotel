<%@ Page Title="Principal Gerente" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AlquilerListaHome.aspx.cs" Inherits="AppHotel.AlquilerListaHome" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="css/PrincipalGerente.css" rel="stylesheet" >
        <%@ Import Namespace="Dominio" %>  
    <%@ Import Namespace="Negocio" %>  
    </asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark justify-content-center">
        <ul class="navbar-nav">
            <%Empleado Empleado = new Empleado();
                Empleado = (Empleado)Session["EmpleadoLogueado"];

                if(Empleado == null)
                {
                    Response.Redirect("Login.aspx");
                }
                %>
              <li class="nav-item active" style="margin-right: 350px;">
                                <a class="nav-link"><i class="fas fa-paw"></i> Bienvenido, <%=Empleado.Nombre %> </a>
            </li>
                        <li class="nav-item active">
                <a class="nav-link" href="PrincipalGerente.aspx"><i class="fas fa-home"></i> Home</a>
            </li>
           <li class="nav-item active">
      <a class="nav-link" ><i class="fas fa-shield-alt"></i> Alquileres</a>
    </li>
                    <li class="nav-item active">
      <a class="nav-link" href="GerenteCambiarPass.aspx" ><i class="fas fa-lock"></i> Contraseña</a>
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
    <div class="section-block-grey" style="margin-top: -80px;">
        <div class="container">
          
            <div class="row mt-60" style="margin-left:200px;">
                <div class="col-md-8 col-sm-12 col-12">
                    <div class="serv-section-2">
                        <div class="serv-section-2-icon"><i class="fas fa-hotel"></i></div>
                        <div class="serv-section-desc">
                            <h4>Alquileres en ejecución </h4>
                            <h5>Va poder ver los alquileres<br /> que se encuentran vigentes en este momento.</h5>
                        </div>
                        <div class="section-heading-line-left"></div>
                        <a class="btn btn-dark" href="AlquilerLista.aspx">Ingresar</a>
                    </div>
                </div>
                                   <div class="col-md-8 col-sm-12 col-12" style="margin-top:10px;">
                    <div class="serv-section-2">
                        <div class="serv-section-2-icon"><i class="fas fa-suitcase-rolling"></i></div>
                        <div class="serv-section-desc">
                            <h4>Alquileres finalizados</h4>
                             <h5>Va poder ver los alquileres<br /> que se encuentran finalizados.</h5>
                        </div>
                        <div class="section-heading-line-left"></div>
                        <a class="btn btn-dark" href="AlquilerListaFinalizado.aspx">Ingresar</a>
                    </div>
                </div>                          
            </div>
              
        </div>
    </div>
</asp:Content>
