<%@ Page Title="Alquilar" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"  CodeBehind="Grafico.aspx.cs" Inherits="AppHotel.Grafico" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="header" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="home" ContentPlaceHolderID="cuerpo" runat="server">
    <asp:Chart runat="server" ID="Graficos" Palette="Chocolate" DataSourceID="SqlDataSource1" BackColor="DarkOrange" BorderlineColor="DimGray" OnLoad="Graficos_Load">
        <Series>
            <asp:Series Name="Series" ChartType="Pie" ChartArea="ChartArea1" XValueMember="nombre" YValueMembers="CantidadDeReservas" YValuesPerPoint="2"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
        <Titles>
            <asp:Title Font="Microsoft Sans Serif, 9.75pt, style=Bold" Name="Title1" Text="Cantidad de reservas por tipo de habitación">
            </asp:Title>
        </Titles>
    </asp:Chart>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AppHotelConnectionString %>" SelectCommand="select t.nombre,(select count (h1.tipo) from Habitacion as h1 
inner join TipoHabitacion
as t1 on t1.Id=h1.Tipo
inner join Alquiler as a
on a.NumeroHabitacion=h1.Numero
where a.Estado=0 and t1.Id=t.Id) as CantidadDeReservas
from TipoHabitacion as t "></asp:SqlDataSource>
    </asp:Content>
