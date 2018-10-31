<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" theme="Employe"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Employés
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <div class="div_content">

    
    <asp:Table runat="server" style="width:75%">
      <asp:TableHeaderRow>
        <asp:TableHeaderCell style="width:75%">Liste des employés actifs</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>Sophie Vachon</asp:TableCell>

      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell>Somebody else</asp:TableCell>
      </asp:TableRow>

    </asp:Table>
        <asp:Button ID="bt_AjouterEmploye" runat="server" Text="Ajouter un employé" CssClass="btn_ajouter" OnClick="bt_AjouterEmploye_Click" />

    <asp:Table runat="server" style="width:75%" class="tableau_inactif">
              <asp:TableHeaderRow>
        <asp:TableHeaderCell style="width:75%">Liste des employés Inactif</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>William Lemieux</asp:TableCell>

      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell>Somebody else</asp:TableCell>
      </asp:TableRow>
    </asp:Table>

        </div>

</asp:Content>