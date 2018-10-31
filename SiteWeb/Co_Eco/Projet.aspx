<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Projets
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <table style="width:75%">
      <tr>
        <th style="width:33%">Nom du projet</th>
        <th style="width:33%">Catégorie</th> 
        <th style="width:33%">Status  </th>
      </tr>
      <tr>
          <td><a href="Menu.aspx">Réparation du site web</a></td>
          <td>Web</td>
          <td>En Cours</td>

      </tr>
      <tr>
          <td>Pelletage du trou</td>
          <td>CSI</td>
          <td>Terminer</td>
      </tr>

    </table>

          <asp:ImageButton ID="btn_addProject" runat="server" ImageUrl="~/App_Themes/Projet/Image/logo_addProject.png" class="btn_addProject" OnClick="btn_addProject_Click"/>
          <asp:ImageButton ID="btn_addCategorie" runat="server" ImageUrl="~/Image/logo_addCategorie.png" class="btn_addCategorie" OnClick="btn_addCategorie_Click"/>
  

</asp:Content>


