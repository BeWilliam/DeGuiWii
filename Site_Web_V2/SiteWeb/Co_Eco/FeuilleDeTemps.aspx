<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps" Theme="FeuilleDeTemps"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    Feuilles de temps 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server" ClientIDMode="Inherit">
    <asp:Label ID="lb_erreur" runat="server" Text="" ></asp:Label>
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>

    <asp:table ID="t_feuilleTemps" runat="server" style="width:75%">
      <asp:TableRow>
        <asp:TableHeaderCell ID="thc_Projet" style="width:11%">Projet</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Dimanche" style="width:11%">Dimanche</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Lundi" style="width:11%">Lundi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mardi" style="width:11%">Mardi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mercredi" style="width:11%">Mercredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Jeudi" style="width:11%">Jeudi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Vendredi" style="width:11%">Vendredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Samedi" style="width:11%">Samedi</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:11%">Commentaires</asp:TableHeaderCell>
      </asp:TableRow>
      <asp:TableRow ID="tr_ajout">
          <asp:TableCell>
              <asp:DropDownList ID="ddl_Projet" runat="server" CssClass="ddl_projet"></asp:DropDownList>
              <asp:DropDownList ID="ddl_Categorie" runat="server" CssClass="ddl_categorie"></asp:DropDownList>

          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_dimanche" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label1" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_lundi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label7" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mardi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label2" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mercredi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label3" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_jeudi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label4" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_vendredi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label5" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_samedi" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label6" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_commentaire" runat="server" CssClass="tbx_h"></asp:TextBox>
          </asp:TableCell>

      </asp:TableRow>

    </asp:table>

    <div class="div_bouton">
        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click"/>
        <asp:Button ID="btn_confirmer" runat="server" Text="Confirmer" OnClick="btn_confirmer_Click" Visible="False" />
        <asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="False" OnClick="btn_annuler_Click" />
    </div>
    </asp:Content>