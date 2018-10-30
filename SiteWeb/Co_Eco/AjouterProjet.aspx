<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Ajouter un projet
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div>
        <p>
        <asp:Label ID="lbl_nom" runat="server" Text="Nom du projet : "></asp:Label>
        <asp:TextBox ID="tbx_nom" runat="server" Font-Size="Large"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbl_categorie" runat="server" Text="Catégorie du projet : "></asp:Label>
        <asp:DropDownList ID="ddl_categorie" runat="server" CssClass="ddl_categorie" Font-Size="Large"></asp:DropDownList>
        </p>
        <asp:Label ID="lbl_chef" runat="server" Text="Chef du projet : "></asp:Label>
        <p>
        <asp:DropDownList ID="ddl_chef" runat="server" CssClass="ddl_chef" Font-Size="Large"></asp:DropDownList>
        </p>
        <p>
        <asp:Label ID="lbl_nbHeure" runat="server" Text="Nombre d'heure alloué au projet : "></asp:Label>
        <asp:TextBox ID="tbx_nbHeure" runat="server" Font-Size="Large"></asp:TextBox>
        </p>
    </div>

    <section>

        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" class="btn_ajouterProjet" BackColor="#53b34f" Font-Size="18px" OnClick="btn_ajouter_Click"/>

    </section>
</asp:Content>

