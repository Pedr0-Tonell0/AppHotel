<%@ Page Title="Home" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AppHotel.Home" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<script src="js/Home.js"></script>
<link href="css/Home.css" rel="stylesheet">
</asp:Content>

<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
	<div id="fb-root"></div>
<script async defer src="https://connect.facebook.net/en_US/sdk.js#xfbml=1&version=v2.6"></script>
   <nav class="navbar navbar-expand-md fixed-top top-nav">
	<div class="container">
		  <a class="navbar-brand" href="#"><strong>The Bulldog</strong></a>
		  <div class="collapse navbar-collapse" id="navbarSupportedContent">
		    <ul class="navbar-nav ml-auto">
		      <li class="nav-item">
		        <a class="nav-link" href="#">Inicio <span class="sr-only">(current)</span></a>
		      </li>
				      <li class="nav-item">
		        <a class="nav-link" href="#Nosotros">Nosotros</a>
		      </li>
		      <li class="nav-item">
		        <a class="nav-link" href="#Servicios">Servicios</a>
		      </li>	  
		      <li class="nav-item">
		        <a class="nav-link" href="#Contacto">Contacto</a>
		      </li>
				  <li class="nav-item">
		        <a class="nav-link" href="#Desarrollador">Desarrollador</a>
		      </li>
				  <li class="nav-item">
		        <a class="nav-link" href="Login.aspx">Login</a>
		      </li>		 
		    </ul>
		  </div>	
	</div>
</nav>

<section class="intro carousel slide bg-overlay-light h-auto" id="Home">

    <div class="carousel-inner" role="listbox">
      <div class="carousel-item active" style="background-color:darkblue;">
        <div class="carousel-caption ">
  <img class="img-fluid rounded-circle" src="https://seeklogo.com/images/T/The_Bulldog-logo-40503E4E6B-seeklogo.com.png" alt="">
			<p class="text-white mb-3 px-5 lead">Es un lugar perfecto para venir con amigues y relajarse. </p>
			<a href="#Contacto" class="btn btn-primary btn-capsul px-4 py-2">Contactate con nosotros</a>
        </div>
      </div>
    </div>
</section>

	<section class="info-section" id="Servicios">
	<div class="container">
		<div class="head-box text-center mb-5">
			<h2>Servicios</h2>
			<h6 class="text-underline-primary"></h6>
		</div>
		<div class="three-panel-block mt-5">
			<div class="row">
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center mb-5 p-lg-3">
						<i class="fa fa-wifi box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Wi-Fi gratuito</h3>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center mb-5 p-lg-3">
						<i class="fa fa-coffee box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Desayuno</h3>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center mb-5 p-lg-3">
						<i class="fa fa-car box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Cochera privada</h3>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center p-lg-3">
						<i class="fa fa-television box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Tv por cable</h3>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center p-lg-3">
						<i class="fa fa-cutlery box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Room Service</h3>
					</div>
				</div>
				<div class="col-lg-4 col-md-6 col-sm-6">
					<div class="service-block-overlay text-center p-lg-3">
						<i class="fa fa-bathtub box-circle-solid mt-3 mb-3" aria-hidden="true"></i>
						<h3>Hidromasajes</h3>
					</div>
				</div>
			</div>
		</div>
	</div>
</section>
	        <label style="color: white;">.</label>
    <section class="about-sec parallax-section" id="Nosotros">
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <h2><strong>Nosotros</strong></h2>
                    <h2 class="text-underline-primary" style="margin-right: 90px;"></h2>
                </div>
                <div class="col-md-4">
 
		


                    <p>El Hotel Bulldog fue fundado hace muchos años, y desde ese instante brindamos a nuestros huéspedes el mejor confort y una atención personalizada para que su estadía sea muy agradable. </p>
                    <p>Contamos con un espacio diseñado especialmente para que pueda relajarse en armonía con la naturaleza. Ya sea en familia, en pareja o con amigos, nuestra misión es transformar su experiencia en una sucesión de momentos placenteros.</p>
                </div>
                <div class="col-md-4">
                    <p>La diversidad de servicios y la calidad de nuestras instalaciones convierten a nuestro hotel en el lugar ideal para realizar eventos empresariales, congresos, conferencias, bodas y festejos especiales.</p>
                 <p>Venga a disfrutar del lugar donde la naturaleza y el bienestar se armonizan para que tenga una estadía inolvidable.</p>
                    <p><a href="#Contacto" class="btn btn-transparent-white btn-capsul">Contactanos</a></p>
                </div>
            </div>
        </div>
    </section>
	 <section class="info-section" >
            <div class="container" >
                <div class="head-box text-center mb-5">
             <div class="video-responsive">
				 <iframe width="560" height="315" src="https://www.youtube.com/embed/Nj7eONb0F9M" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                    </div>
                </div>
            </div>
        </section>
<section class="info-section bg-primary py-0" id="Contacto">
	<div class="container-fluid">
		<div class="row"  style="margin-left:470px;">
			     <div class="col-md-6 p-0 m-0">
				   <div class="col-md-6 col-lg-6 content-half mt-md-0 pl-5 pt-4">

                <div class="head-box mb-5 pl-5 mt-2">
					<h2 class="text-white">Contacto</h2>
					<h6 class="text-white text-underline-rb-white" style="margin-left:50px;"></h6>
				</div>
					   <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2435.8816887866733!2d4.894138951089737!3d52.3725652547987!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47c609b8afe93d6d%3A0x59ba5e127f0d2cc2!2sThe%20Bulldog%20Hotel!5e0!3m2!1ses-419!2sar!4v1596752558717!5m2!1ses-419!2sar"  width="500" height="350" frameborder="0" style="border:0;margin-top:-10px;margin-left:-350px;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
				</div>	
					 </div>

				   <div class="col-md-6 col-lg-6 content-half mt-md-0 pl-5 pt-4">
                <ul class="pl-5"  style="margin-top:150px;margin-left:-300px">
		<a href="https://api.whatsapp.com/send?phone=1173685728&text=Bienvenido,%20somos%20Bulldog!!"><img src="https://img.icons8.com/color/60/000000/whatsapp.png"/></a>
            <a href =https://www.instagram.com/explore/locations/285406947/netherlands/amsterdam-netherlands/the-bulldog-hotel/"> <img src="https://img.icons8.com/fluent/60/000000/instagram-new.png"/></a>	
                          <li style=" width:750px;margin-left:0 auto; ">

                    	<i class="fa fa-map-marker box-round-outline" aria-hidden="true"></i>

                    	<span class="list-content">

                    		<strong>Ubicación</strong>
                    		<br>Estamos ubicados en Oudezijds Voorburgwal 218, 1012 GJ Amsterdam, Países Bajos.
                    	</span>
                    </li>
                    <li style=" width:750px;margin:0 auto; " >
                    	<i class="fa fa-envelope box-round-outline" aria-hidden="true"></i>
                    	<span class="list-content">
                    		<strong>Email</strong>
                    		<br> bulldog@bulldog.com
                    	</span>
                    </li>
					<br /><br />
			     	<br /><br />
					<br /><br />
					<br /><br />
					<br /><br />
					<br /><br />
                </ul>	
            </div>
            </div>
			        </div>
</section>
	 <section class="info-section" id="Comentarios">
            <div class="container">
                <div class="head-box text-center mb-5">
                    <h2>Dejanos tu comentario</h2>
                    <div style="margin-top: 30px;" class="fb-comments" data-mobile="true" data-colorscheme="dark" data-href="https://localhost:44392/Home.aspx" data-numposts="5" data-width=""></div>
                </div>
            </div>
        </section>
<section class="team-section py-5" id="Desarrollador">
	<div class="container">
		<div class="head-box text-center mb-5">
			<h2><strong>Conoce a nuestro desarrollador</strong></h2>
			<h6 class="text-underline-primary"></h6>
		</div>
			<div class="col-md-4 mb-md-0 mb-sm-4" style="margin-left:380px;">
				<div class="member-box anim-lf t-bottom">
			        <img class="img-fluid" src="https://avatars0.githubusercontent.com/u/54557275?s=460&u=934fb7150c0fbf0d6e5ccfd1f08e3783e8e2ccb0&v=4" alt="">
			        <div class="overlay-content">
			          <h3 class="text-white ml-3 my-0">Pedro Tonello</h3>
			          <p class="text-white ml-3 mb-3">Developer</p>
			          <span class="socail-l ml-3 mb-3">
			            <a href="https://github.com/Pedr0-Tonell0" class="mr-2"><i class="fa fa-github box-circle-solid"></i></a>
						<a href="https://www.linkedin.com/in/pedro-ignacio-tonello/" class="mr-2"><i class="fa fa-linkedin box-circle-solid"></i></a>
						<a href="http://pedrotonello.tonohost.com/" class="mr-2"><img style="margin-top:-10px;" src="https://img.icons8.com/fluent/48/000000/chrome.png"/></a>
			          </span>
			        </div>
			    </div>
			</div>
		</div>
</section>
</asp:Content>

