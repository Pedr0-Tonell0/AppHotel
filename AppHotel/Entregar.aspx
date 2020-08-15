<%@ Page Title="Entregar" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Entregar.aspx.cs" Inherits="AppHotel.Entregar" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<meta charset="utf-8" />
<link rel="icon" type="image/png" href="assets/img/favicon.ico">
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<meta
	content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0"
	name="viewport" />

<!-- Canonical SEO -->
<link rel="canonical"
	href="https://www.creative-tim.com/product/fresh-bootstrap-table" />

<!--  Social tags    -->
<meta name="keywords"
	content="creative tim, html table, html css table, web table, freebie, free bootstrap table, bootstrap, css3 table, bootstrap table, fresh bootstrap table, frontend, modern table, responsive bootstrap table, responsive bootstrap table">

<meta name="description"
	content="Probably the most beautiful and complex bootstrap table you've ever seen on the internet, this bootstrap table is one of the essential plugins you will need.">

<!-- Schema.org markup for Google+ -->
<meta itemprop="name" content="Fresh Bootstrap Table by Creative Tim">
<meta itemprop="description"
	content="Probably the most beautiful and complex bootstrap table you've ever seen on the internet, this bootstrap table is one of the essential plugins you will need.">

<meta itemprop="image"
	content="http://s3.amazonaws.com/creativetim_bucket/products/31/original/opt_fbt_thumbnail.jpg">
<!-- Twitter Card data -->

<meta name="twitter:card" content="product">
<meta name="twitter:site" content="@creativetim">
<meta name="twitter:title"
	content="Fresh Bootstrap Table by Creative Tim">

<meta name="twitter:description"
	content="Probably the most beautiful and complex bootstrap table you've ever seen on the internet, this bootstrap table is one of the essential plugins you will need.">
<meta name="twitter:creator" content="@creativetim">
<meta name="twitter:image"
	content="http://s3.amazonaws.com/creativetim_bucket/products/31/original/opt_fbt_thumbnail.jpg">
<meta name="twitter:data1"
	content="Fresh Bootstrap Table by Creative Tim">
<meta name="twitter:label1" content="Product Type">
<meta name="twitter:data2" content="Free">
<meta name="twitter:label2" content="Price">

<!-- Open Graph data -->
<meta property="og:title"
	content="Fresh Bootstrap Table by Creative Tim" />
<meta property="og:type" content="article" />
<meta property="og:url"
	content="https://wenzhixin.github.io/fresh-bootstrap-table/compact-table.html" />
<meta property="og:image"
	content="http://s3.amazonaws.com/creativetim_bucket/products/31/original/opt_fbt_thumbnail.jpg" />
<meta property="og:description"
	content="Probably the most beautiful and complex bootstrap table you've ever seen on the internet, this bootstrap table is one of the essential plugins you will need." />
<meta property="og:site_name" content="Creative Tim" />
        <link href="css/PrincipalGerente.css" rel="stylesheet" >
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
	<link rel="stylesheet"
	href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.4.1/css/bootstrap.min.css">
<link href="css/fresh-bootstrap-table.css" rel="stylesheet" />
<link href="css/demo.css" rel="stylesheet" />
<link rel="stylesheet"
	href="https://use.fontawesome.com/releases/v5.6.3/css/all.css"
	integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/"
	crossorigin="anonymous">
<link href="http://fonts.googleapis.com/css?family=Roboto:400,700,300"
	rel="stylesheet" type="text/css">

<script src="https://code.jquery.com/jquery-3.3.1.min.js"
	integrity="sha256-FgpCb/KJQlLNfOu91ta32o/NMZxltwRo8QtmkMRdAu8="
	crossorigin="anonymous"></script>
<script
	src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.4.1/js/bootstrap.min.js"></script>
<script
	src="https://unpkg.com/bootstrap-table/dist/bootstrap-table.min.js"></script>

<!--  Just for demo purpose, do not include in your project   -->
<script src="js/gsdk-switch.js"></script>
<script src="js/jquery.sharrre.js"></script>
<script src="js/demo.js"></script>
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
      <a class="nav-link"><i class="fas fa-bed"></i> Entregar</a>
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
                <h4 style="margin-top:-10px;">Entregar una habitación</h4>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-3">
                <asp:Label Text="Numero de habitacion" ID="LblDNI" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onfocus="Seleccionar(this.id)" onkeyup="validarDNI()" onKeyPress="return soloNumeros(event)" MaxLength="8" ClientIDMode="Static" Style="margin-top: 10px;" ID="txtNumeroHabitacion" CssClass="form-control" />
                <p id="MensajeErrorDNI"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Button Text="Buscar" ID="BtnBuscar" ClientIDMode="Static" class="btn btn-dark" autoposback="false" Style="margin-top: 33px; margin-left: 10px;background-color:black;" runat="server"  disabled="true"  />
            </div>
        </div>
        <div class="form-row " style="margin-top: 10px;">
            <div class="form-group col-md-3">
                <asp:Label Text="Nombre" ID="LblNombre" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="TboxNombre" CssClass="form-control" />
                <p id="MensajeErrorNombre"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="Fecha de ingreso" ID="LblApellido" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="txtFechaIngreso" CssClass="form-control" />
                <p id=""></p>
            </div>
             <div class="form-group col-md-3">
                <asp:Label Text="Fecha de egreso" ID="Label1" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeypress="return soloLetras(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="txtFechaEgreso" CssClass="form-control" />
                <p id="MensajeErrorApellido"></p>
            </div>
        </div>
                <div class="form-row" style="margin-top: 10px;">
            <div class="form-group col-md-5">
                <asp:Label Text="Dias" ID="LblDireccion" ClientIDMode="Static" runat="server" CssClass="control-label " />
                <asp:TextBox runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="40" Style="margin-top: 10px;" ID="TxtDias" ClientIDMode="Static"  CssClass="form-control " />
                <p id="MensajeErrorDireccion"></p>
            </div>
            <div class="form-group col-md-">
                <asp:Label Text="Costo" ID="LblCiudad" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="20" Style="margin-top: 10px;" ClientIDMode="Static" ID="txtCosto"  CssClass="form-control" />
                <p id="MensajeErrorCiudad"></p>
            </div>
            <div class="form-group col-md-3">
                <asp:Label Text="Observaciones" ID="LblCP" runat="server" ClientIDMode="Static" CssClass="control-label " />
                <asp:TextBox runat="server" onKeyPress="return soloNumeros(event)" onkeyup="validarVacio(this.id)" onfocus="Seleccionar(this.id)" MaxLength="8" Style="margin-top: 10px;" ClientIDMode="Static" ID="txtObservaciones"  CssClass="form-control" />
                <p id="MensajeErrorCP"></p>
            </div>
        </div>
        <div>
<asp:Button Text="Entregar" Style="margin-top: 20px;background-color:black;" class="btn btn-dark" ClientIDMode="Static" ID="BtnParticipar" runat="server"  disabled="true" />
   </div>
            </div>
    
 </section>
       <br />

</asp:Content>
