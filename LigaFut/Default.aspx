<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LigaFut.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Información sobre Dota 2</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        
       <%-- <%
            foreach (Dominio.Heroes heroe in ListaHeroes)
            {
        %>

        <div class="col">
            <div class="card">
                <img src="<%:heroe.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%:heroe.Nombre %></h5>
                    <p class="card-text"><%:heroe.Descripcion %></p>
                    <a href="DetalleHeroe.aspx?id=<%:heroe.Id %> ">Ver más detalle</a>
                </div>
            </div>
        </div>
        <% } %>--%>

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="DetalleHeroe.aspx?id=<%#Eval("Id")%> ">Ver más detalle</a>
                            <asp:Button Text="Ejemplo" CssClass="btn btn-primary" Id="btnEjemplo" OnClick="btnEjemplo_Click" CommandArgument='<%#Eval("Id") %>' CommandName="HeroeId" runat="server" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
