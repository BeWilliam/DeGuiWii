<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Depense.aspx.cs" Inherits="Depense" theme="Depenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Dépenses
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Dépenses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <%-- Partie pour l'ajout d'une dépense --%>
     <asp:table runat="server" style="width:40%" id="TableDepenses">
      <asp:TableHeaderRow>
          <asp:TableHeaderCell Width="25%">Type de dépense</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:25%">Description</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:25%">Montant</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:25%">Date</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>
              <asp:DropDownList runat="server" ID="DDL_TypeDepense"/>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox1" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox2" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox3" runat="server" />
          </asp:TableCell>
      </asp:TableRow>
    </asp:table>

    <asp:Button ID="bt_ajouterDepense" runat="server" Text="Ajouter une dépense" BackColor="#53b34f" Font-Size="18px" CssClass="btn"/>


    <%-- Partie pour l'ajout du Kilométrage --%>
    <asp:table runat="server" style="width:40%" id="TableKilometrage">
      <asp:TableHeaderRow>
        <asp:TableHeaderCell style="width:20%">Description</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Nombre de kilomètres</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Montant par kilomètre</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Total</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Date</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>
              <asp:TextBox ID="TextBox7" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox8" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox9" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox13" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox14" runat="server" />
          </asp:TableCell>

      </asp:TableRow>
    </asp:table>
    <asp:Button ID="bt_ajouterKilometrage" runat="server" Text="Ajouter du kilométrage" BackColor="#53b34f" Font-Size="18px" CssClass="btn"/>
</asp:Content>

