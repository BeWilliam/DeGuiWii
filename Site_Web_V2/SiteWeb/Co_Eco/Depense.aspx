<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Depense.aspx.cs" Inherits="Depense" theme="Depenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Dépenses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <%-- Partie pour l'ajout d'une dépense --%>
     <asp:table runat="server" style="width:40%" id="TableDepenses">
      <asp:TableHeaderRow>
          <asp:TableHeaderCell Width="20%">Projet</asp:TableHeaderCell>
          <asp:TableHeaderCell Width="20%">Type de dépense</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Description</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Montant</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:20%">Date</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>
              <asp:DropDownList runat="server" ID="ddl_projet"/>
          </asp:TableCell>
          <asp:TableCell>
              <asp:DropDownList runat="server" ID="DDL_TypeDepense"/>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_description" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_montant" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_date" runat="server" />
          </asp:TableCell>
      </asp:TableRow>
    </asp:table>

    <button ID="bt_ajouterDepense" runat="server" class="btn btn-light" onserverclick="bt_ajouterDepense_ServerClick">Ajouter une dépense</button>


    <%-- Partie pour l'ajout du Kilométrage --%>
    <asp:table runat="server" style="width:50%" id="TableKilometrage">
      <asp:TableHeaderRow>
          <asp:TableHeaderCell Width="16%">Projet</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:16%">Description</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:16%">Nombre de kilomètres</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:16%">Montant par kilomètre</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:16%">Total</asp:TableHeaderCell>
          <asp:TableHeaderCell style="width:16%">Date</asp:TableHeaderCell>
      </asp:TableHeaderRow>
      <asp:TableRow>
          <asp:TableCell>
              <asp:DropDownList runat="server" ID="ddl_projetKilo"/>
          </asp:TableCell>

          <asp:TableCell>
              <asp:TextBox ID="tb_descriptionKilo" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_nbKilo" runat="server" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_montantKilo" runat="server" Enabled="False" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_total" runat="server" Enabled="False" />
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_dateKilo" runat="server" />
          </asp:TableCell>

      </asp:TableRow>
    </asp:table>
    <asp:Button ID="bt_ajouterKilometrage" runat="server" Text="Ajouter du kilométrage" BackColor="#53b34f" Font-Size="18px" CssClass="btn"/>
</asp:Content>

