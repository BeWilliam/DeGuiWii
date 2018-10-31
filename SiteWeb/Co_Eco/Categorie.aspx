<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Catégorie
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

        <asp:Table runat="server" style="width:75%">
      <asp:TableRow>
        <asp:TableHeaderCell style="width:50%">Nom de la catégorie</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:50%">Status  </asp:TableHeaderCell>
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell>Matériel</asp:TableCell>
          <asp:TableCell>Actif</asp:TableCell>
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell>Analyse</asp:TableCell>
          <asp:TableCell>Inactif</asp:TableCell>

      </asp:TableRow>

    </asp:Table>

    <asp:ImageButton ID="btn_addCategorie" runat="server" ImageUrl="~/App_Themes/Categorie/Image/logo_addCategorie.png" CssClass="btn_ajouterCategorie" OnClick="btn_addCategorie_Click"/>

</asp:Content>

