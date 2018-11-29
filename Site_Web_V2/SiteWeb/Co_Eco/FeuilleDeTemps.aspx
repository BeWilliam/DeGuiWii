<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" style="width: 100%; margin-left: 5px; margin-top: 5px; text-decoration: none;"></asp:Calendar>
        <div class="div_bouton">
        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="false" OnClick="btn_ajouter_Click" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />
        <%--<asp:Button ID="btn_confirmer" runat="server" Text="Confirmer" OnClick="btn_confirmer_Click" Visible="False" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />--%>
        <%--<asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="False" OnClick="btn_annuler_Click" CssClass="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />--%>
        <%--<asp:Button ID="btn_confirmerModif" runat="server" Text="Confirmer la modification" OnClick="btn_confirmerModif_Click" Visible="false" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;"/>--%>
                <asp:Label ID="lb_erreur" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server" ClientIDMode="Inherit">

    

    <asp:table ID="t_feuilleTemps" runat="server" CssClass="table table-striped table-hover">
      <asp:TableRow>
        <asp:TableHeaderCell ID="thc_Projet">Projet</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Dimanche" BackColor="LightGray">Dimanche</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Lundi">Lundi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mardi">Mardi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mercredi">Mercredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Jeudi">Jeudi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Vendredi">Vendredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Samedi" BackColor="LightGray">Samedi</asp:TableHeaderCell>
      </asp:TableRow>
<%--      <asp:TableRow ID="tr_ajout"  Visible = "false">
          <asp:TableCell>--%>
<%--                           <asp:DropDownList ID="ddl_Projet" runat="server" CssClass="col-md-12" AutoPostBack="True" OnSelectedIndexChanged="ddl_Projet_SelectedIndexChanged"></asp:DropDownList>

              <asp:DropDownList ID="ddl_Categorie" runat="server" CssClass="col-md-12"></asp:DropDownList>

          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_dimanche" runat="server" MaxLength="4"  CssClass="col-sm-5"></asp:TextBox>
              
              <asp:Label ID="Label1" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_lundi" runat="server" MaxLength="4"  CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label7" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mardi" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label2" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mercredi" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label3" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_jeudi" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label4" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_vendredi" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label5" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_samedi" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label6" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_commentaire" runat="server"></asp:TextBox>
          </asp:TableCell>

      </asp:TableRow>
         <asp:TableRow ID="tr_modif"  Visible = "false">
          <asp:TableCell>
                  <asp:DropDownList ID="ddl_projetModif" runat="server" CssClass="col-md-12" AutoPostBack="True" OnSelectedIndexChanged="ddl_Projet_SelectedIndexChanged"></asp:DropDownList>
              
              <asp:DropDownList ID="ddl_categorieModif" runat="server" CssClass="col-md-12"></asp:DropDownList>

          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_dimancheModif" runat="server" MaxLength="4"  CssClass="col-sm-5"></asp:TextBox>
              
              <asp:Label ID="Label8" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_lundiModif" runat="server" MaxLength="4"  CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label9" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mardiModif" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label10" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_mercrediModif" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label11" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_jeudiModif" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label12" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_vendrediModif" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label13" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_samediModif" runat="server" MaxLength="4" CssClass="col-sm-5"></asp:TextBox>
              <asp:Label ID="Label14" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="tb_commentaireModif" runat="server"></asp:TextBox>
          </asp:TableCell>

      </asp:TableRow>--%>

    </asp:table>

    <%--<asp:Button ID="bt_modifier" runat="server" Text="modif" OnClick="bt_modifier_Click" />--%>
    </asp:Content>