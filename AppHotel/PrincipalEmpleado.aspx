<%@ Page Title="Principal Empleado" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  CodeBehind="PrincipalEmpleado.aspx.cs" Inherits="AppHotel.PrincipalEmpleado" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="css/PrincipalGerente.css" rel="stylesheet" >

</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark justify-content-center">
    <ul class="navbar-nav">  
           <li class="nav-item active" style="margin-right:500px;">
      <a class="nav-link" ><i class="fas fa-home"></i> Home</a>
    </li>
          <li class="nav-item active">
      <a class="nav-link" href="Alquilar.aspx"><i class="fas fa-shield-alt"></i> Alquilar</a>
    </li>
  <li class="nav-item active">
      <a class="nav-link" href="ClienteABML.aspx"><i class="fas fa-user-friends"></i> Clientes</a>
    </li>
      <li class="nav-item active">
      <a class="nav-link" href="HabitacionDisponible2.aspx"><i class="far fa-clock"></i> Disponibles</a>
    </li>
         <li class="nav-item active">
      <a class="nav-link" href="Entregar.aspx"><i class="fas fa-bed"></i> Entregar</a>
    </li>
  </ul>
</nav>
   <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css">
 <div class="section-block-grey" style="margin-top:-80px;">
    <div class="container">
  <div class="row mt-60">
          <div class="col-md-4 col-sm-12 col-12">
                <div class="serv-section-2">
                    <div class="serv-section-2-icon"> <i class="fas fa-shield-alt"></i> </div>
                    <div class="serv-section-desc">
                        <h4> Alquilar</h4>
                        <h5>Usted va poder registrar el alquiler de una habitacion.</h5> </div>
                    <div class="section-heading-line-left"></div>
                                            <a class="btn btn-dark" href="Alquilar.aspx">Ingresar</a>

           </div>
            </div>    
                      <div class="col-md-4 col-sm-12 col-12">
                <div class="serv-section-2">
                    <div class="serv-section-2-icon"> <i class="fas fa-users"></i> </div>
                    <div class="serv-section-desc">
                        <h4>Clientes</h4>
                        <h5>Usted va poder agregar y modificar clientes.</h5> </div>
                    <div class="section-heading-line-left"></div>
        <a class="btn btn-dark" href="ClienteABML.aspx">Ingresar</a>

        </div>
            </div>
               <div class="col-md-4 col-sm-12 col-12">
                <div class="serv-section-2 serv-section-2-act">
                    <div class="serv-section-2-icon serv-section-2-icon-act"> <i class="far fa-clock"></i> </div>
                    <div class="serv-section-desc">
                        <h4>Disponibles </h4>
                        <h5>Usted va poder ver las habitaciones disponibles. </h5> </div>
                    <div class="section-heading-line-left"></div>
                                                                <a class="btn btn-dark" href="HabitacionDisponible2.aspx">Ingresar</a>

                </div>
            </div>
            </div>
          <div class="row mt-60">
            <div class="col-md-4 col-sm-12 col-12">
                <div class="serv-section-2 serv-section-2-act">
                    <div class="serv-section-2-icon serv-section-2-icon-act"> <i class="fas fa-bed"></i> </div>
                    <div class="serv-section-desc">
                        <h4>Entregar</h4>
                        <h5>Usted va poder registrar la entrega de la habitacion.</h5> </div>
                    <div class="section-heading-line-left"></div>
                                                               <a class="btn btn-dark" href="Entregar.aspx">Ingresar</a>
                                    </div>
            </div>
              </div>
        </div>
     </div>
</asp:Content>

