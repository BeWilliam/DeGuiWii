<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" theme="Employe"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Employés

        <table style="width:50%">
      <tr>
        <th style="width:75%">Liste des employés actifs</th>
      </tr>
      <tr>
          <td>Sophie Vachon</td>

      </tr>
      <tr>
          <td>Somebody else</td>
      </tr>

    </table>
    <asp:Button ID="bt_AjouterEmploye" runat="server" Text="Ajouter un employé" CssClass="button" OnClick="bt_AjouterEmploye_Click" />

</asp:Content>

