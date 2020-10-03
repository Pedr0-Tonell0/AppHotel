<%@ Page Title="Trabajos hechos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  CodeBehind="EmpleadoListaHome.aspx.cs" Inherits="AppHotel.EmpleadoListaHome" %>
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
                <a class="nav-link" href="PrincipalEmpleado.aspx"><i class="fas fa-home"></i> Home</a>
            </li>
     <li class="nav-item active">
      <a class="nav-link" href="HabitacionDisponible.aspx"><i class="far fa-clock"></i> Alquilar</a>
    </li>
  <li class="nav-item active">
      <a class="nav-link" href="ClienteABML.aspx"><i class="fas fa-user-friends"></i> Clientes</a>
    </li>
                     <li class="nav-item active">
      <a class="nav-link" href="EmpleadoCambiarPass.aspx" ><i class="fas fa-lock"></i> Contraseña</a>
    </li>

           <li class="nav-item active">
      <a class="nav-link" href="HabitacionAlquilada.aspx"><i class="fas fa-bed"></i> Entregar</a>
    </li>
            
             <li class="nav-item active">
      <a class="nav-link" href="HabitacionTipoPrecio.aspx"><i class="fas fa-dollar-sign"></i> Precios</a>
    </li>
               <li class="nav-item active">
      <a class="nav-link" ><i class="fas fa-suitcase-rolling"></i> Reporte</a>
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
                            <h4>Alquileres registrados por usted </h4>
                            <h5>Va poder ver los alquileres registrados por usted<br />  que siguen activos en este momento.</h5>
                        </div>
                        <div class="section-heading-line-left"></div>
                        <a class="btn btn-dark" href="AlquilerUsuario.aspx">Ingresar</a>
                    </div>
                </div>
                                   <div class="col-md-8 col-sm-12 col-12" style="margin-top:10px;">
                    <div class="serv-section-2">
                        <div class="serv-section-2-icon"><i class="fas fa-suitcase-rolling"></i></div>
                        <div class="serv-section-desc">
                            <h4>Entregas registradas por usted</h4>
                             <h5>Va poder ver las entregas que fueron realizadas por usted<br /> que fueron finalizadas.</h5>
                        </div>
                        <div class="section-heading-line-left"></div>
                        <a class="btn btn-dark" href="EntregaUsuario.aspx">Ingresar</a>
                    </div>
                </div>                          
            </div>
              
        </div>
    </div>
</asp:Content>