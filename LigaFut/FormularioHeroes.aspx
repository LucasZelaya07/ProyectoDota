<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioHeroes.aspx.cs" Inherits="LigaFut.FormularioHeroes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNumero" class="form-label">Numero</label>
                <asp:TextBox runat="server" ID="txtNumero" TextMode="Number" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" CssClass="form-control" ID="txtDescripcion" />
            </div>
            <div class="mb-3">
                <label for="ddlTipo" class="form-label">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server">
                    <asp:ListItem Text="Agilidad" />
                    <asp:ListItem Text="Fuerza" />
                    <asp:ListItem Text="Inteligencia" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" />
                <a href="Default.aspx">Cancelar</a>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="ddlVentaja" class="form-label">Ventaja</label>
                <asp:DropDownList ID="ddlVentaja" CssClass="form-select" runat="server">
                    <asp:ListItem Text="Enigma" />
                    <asp:ListItem Text="Morphling" />
                    <asp:ListItem Text="Axe" />
                    <asp:ListItem Text="Silencer" />
                    <asp:ListItem Text="Huskar" />
                    <asp:ListItem Text="Clockwerk" />
                    <asp:ListItem Text="Ursa" />
                    <asp:ListItem Text="Necrophos" />
                    <asp:ListItem Text="Phantom Lancer" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlDebilidad" class="form-label">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server">
                    <asp:ListItem Text="Enigma" />
                    <asp:ListItem Text="Morphling" />
                    <asp:ListItem Text="Axe" />
                    <asp:ListItem Text="Silencer" />
                    <asp:ListItem Text="Huskar" />
                    <asp:ListItem Text="Clockwerk" />
                    <asp:ListItem Text="Ursa" />
                    <asp:ListItem Text="Necrophos" />
                    <asp:ListItem Text="Phantom Lancer" />
                </asp:DropDownList>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true"
                            OnTextChanged="txtImagenUrl_TextChanged" runat="server" />
                    </div>
                    <asp:Image ImageUrl="https://www.unfe.org/wp-content/uploads/2019/04/SM-placeholder.png"
                        ID="imgHeroe" Width="60%" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>
