<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Projets
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

 <asp:table runat="server" style="width:75%" ID="Tableau_Projets">
      <asp:TableRow>
        <asp:TableHeaderCell style="width:33%">Nom du projet</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:33%">Status  </asp:TableHeaderCell>
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell><a href="Menu.aspx">Ce bouton à faire</a></asp:TableCell>
          <asp:TableCell>NE PAS OUBLIER DE FAIRE LE BOUTON POUR OUVRIR LA MODIF D'UN PROJET</asp:TableCell>
      </asp:TableRow>
    </asp:table>
        <asp:ImageButton ID="btn_addProject" runat="server" ImageUrl="~/App_Themes/Projet/Image/logo_addProject.png" class="btn_addProject" OnClick="btn_addProject_Click"/>
</asp:Content>


