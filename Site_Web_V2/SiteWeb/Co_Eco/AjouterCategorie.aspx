<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterCategorie.aspx.cs" Inherits="AjouterCategorie" Theme="AjouterCategorie" %>

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

        <p>
            <asp:Label ID="Label1" runat="server" Text="Projet lié : "></asp:Label>
            <asp:dropdownlist runat="server" ID="ddl_projet" CssClass="ddl_projet"></asp:dropdownlist>
        </p>
            <p>
                <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" CssClass="btn_ajouter" />
                <asp:Button ID="btn_annuler" runat="server" Text="Annuler" CssClass="btn_ajouter" OnClick="btn_annuler_Click" />
            </p>
        </div>

</asp:Content>

