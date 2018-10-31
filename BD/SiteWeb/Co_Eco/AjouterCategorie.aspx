<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterCategorie.aspx.cs" Inherits="AjouterCategorie" Theme="AjouterCategorie"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Ajouter une Catégorie
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

        <div class="div_content">
        <p>
        <asp:Label ID="lbl_nom" runat="server" Text="Nom de la catégorie : "></asp:Label>
        <asp:TextBox ID="tbx_nom" runat="server" Font-Size="Large"></asp:TextBox>
        </p>
        </div>

</asp:Content>

