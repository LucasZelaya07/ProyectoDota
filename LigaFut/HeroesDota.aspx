<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HeroesDota.aspx.cs" Inherits="LigaFut.Heroes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="dgvHeroes" CssClass="table table-dark table-bordered" runat="server"
        AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvHeroes_SelectedIndexChanged"
        OnPageIndexChanging="dgvHeroes_PageIndexChanging" AllowPaging="true" PageSize="5" >
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField ="Numero" />
            <asp:BoundField HeaderText="Tipo" DataField ="Tipo.Descripcion" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="Seleccionar" />
        </Columns>
    </asp:GridView>
    <a href="FormularioHeroes.aspx" class="btn btn-primary" >Agregar</a>
</asp:Content>
