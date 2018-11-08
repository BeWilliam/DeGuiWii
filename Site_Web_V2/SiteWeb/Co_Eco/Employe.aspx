<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" theme="Employe"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:table runat="server" id="Tableau_Employes" CssClass="table">
      <asp:TableRow>
        <asp:TableHeaderCell style="width:25%">#</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:25%">Prénom</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:25%">Nom</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:25%">Statut</asp:TableHeaderCell>
      </asp:TableRow>
    </asp:table>

</asp:Content>