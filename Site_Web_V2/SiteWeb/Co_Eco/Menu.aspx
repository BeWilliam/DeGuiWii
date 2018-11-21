<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
   <h3>Nouveaux projets débutés <span class="badge badge-secondary"></span></h3>

    <asp:Table runat="server" ID="Tableau_NewProjects" CssClass="table" />

       <h3>Nouveaux employés <span class="badge badge-secondary"></span></h3>

    <asp:Table runat="server" ID="Tableau_NewEmploye" CssClass="table" />

</asp:Content>



