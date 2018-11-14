<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    Feuilles de temps 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server" ClientIDMode="Inherit">
    <asp:Label ID="lb_erreur" runat="server" Text="" ></asp:Label>
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

    <asp:table ID="t_feuilleTemps" runat="server" CssClass="table">
      <asp:TableRow>
        <asp:TableHeaderCell ID="thc_Projet">Projet</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Dimanche">Dimanche</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Lundi">Lundi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mardi">Mardi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mercredi">Mercredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Jeudi">Jeudi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Vendredi">Vendredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Samedi">Samedi</asp:TableHeaderCell>
        <asp:TableHeaderCell >Commentaires</asp:TableHeaderCell>
      </asp:TableRow>
      <asp:TableRow ID="tr_ajout">
          <asp:TableCell>
              <asp:DropDownList ID="ddl_Projet" runat="server" CssClass="form-control"></asp:DropDownList>
              <asp:DropDownList ID="ddl_Categorie" runat="server" CssClass="form-control"></asp:DropDownList>

          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_dimanche" runat="server" MaxLength="4" ></asp:TextBox>
              <asp:Label ID="Label1" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_lundi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label7" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mardi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label2" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mercredi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label3" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_jeudi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label4" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_vendredi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label5" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_samedi" runat="server" MaxLength="4"></asp:TextBox>
              <asp:Label ID="Label6" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_commentaire" runat="server"></asp:TextBox>
          </asp:TableCell>

      </asp:TableRow>

    </asp:table>

    <div class="div_bouton">
        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click"/>
        <asp:Button ID="btn_confirmer" runat="server" Text="Confirmer" OnClick="btn_confirmer_Click" Visible="False" />
        <asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="False" OnClick="btn_annuler_Click" />
    </div>
    </asp:Content>