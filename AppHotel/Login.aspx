
<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AppHotel.Login" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<link href="css/Login.css" rel="stylesheet" >
        <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700,200" rel="stylesheet" />

</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
  <div class="page-header clear-filter" filter-color="orange">
    <div class="page-header-image" style="background-image:url('https://images.unsplash.com/photo-1438783122414-75b2c084bd44?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=2378&q=80 2378w')"></div>
    <div class="content">
      <div class="container">
        <div class="col-md-4 ml-auto mr-auto">
          <div class="card card-login card-plain">
          <div class="wrapper fadeInDown">
  <div id="formContent">
    <div class="fadeIn first">
          <br />
            <br />
<img class="img-fluid rounded-circle" src="https://espotmallorca.com/img/m/1.jpg" width:100 alt="">
    </div>

              <asp:TextBox ID="txtUsuario"  runat="server" placeholder="Usuario"></asp:TextBox>
      <br />
            <br />

        <asp:TextBox ID="txtContraseña" type="password" class="password" runat="server" placeholder="Contraseña"></asp:TextBox>
            <br />
            <br />

                  <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" class="btn btn-warning btn-sm" style="hover {
    box-shadow: 2px 1px 2px 3px #fff;
    background: #5900a6;
    color: darkviolet;
    transition: background-color 1.15s ease-in-out,border-color 1.15s ease-in-out,box-shadow 1.15s ease-in-out;
}" />
       <br />
            <br />
        <br />
            <br />
  </div>
</div>            </div>
          </div>
        </div>
      </div>
 <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>

</asp:Content>
