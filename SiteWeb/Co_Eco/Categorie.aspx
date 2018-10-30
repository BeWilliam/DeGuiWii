<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Catégorie
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

        <table style="width:75%">
      <tr>
        <th style="width:50%">Nom de la catégorie</th>
        <th style="width:50%">Status  </th>
      </tr>
      <tr>
          <td>Matériel</td>
          <td>Actif</td>
      </tr>
      <tr>
          <td>Analyse</td>
          <td>Inactif</td>

      </tr>

    </table>

    <asp:ImageButton ID="btn_addCategorie" runat="server" ImageUrl="~/App_Themes/Categorie/Image/logo_addCategorie.png" CssClass="btn_ajouterCategorie" OnClick="btn_addCategorie_Click"/>

</asp:Content>

