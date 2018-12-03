<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Feuille de temps
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
    <%--    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" style="width: 100%; margin-left: 5px; margin-top: 5px; text-decoration: none;"></asp:Calendar>
        <div class="div_bouton">--%>
    <%-- <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="false" OnClick="btn_ajouter_Click" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />--%>
    <%--<asp:Button ID="btn_confirmer" runat="server" Text="Confirmer" OnClick="btn_confirmer_Click" Visible="False" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />--%>
    <%--<asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="False" OnClick="btn_annuler_Click" CssClass="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />--%>
    <%--<asp:Button ID="btn_confirmerModif" runat="server" Text="Confirmer la modification" OnClick="btn_confirmerModif_Click" Visible="false" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;"/>--%>
    <%--                <asp:Label ID="lb_erreur" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>--%>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
    <div class="col-md-4 offset-md-4">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Feuilles de temps</h2>

            <label for="validationTooltip01">Choisir la semaine</label>
            <asp:TextBox TextMode="Date" CssClass="form-control" runat="server" ID="tbx_Semaine" OnTextChanged="Calendar1_SelectionChanged" AutoPostBack="true" style="padding-left:40%; margin-bottom: 10px;" />
            <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="false" OnClick="btn_ajouter_Click" CssClass="btn btn-success" Style="margin-bottom: 10px; width: 50%; color: #000000; margin-left: 5px;" />
        </div>
    </div>

    <asp:Table ID="t_feuilleTemps" runat="server" CssClass="table">
        <asp:TableRow>
            <asp:TableHeaderCell ID="thc_Projet" Width="15%">Projet</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Dimanche" Width="10%" BackColor="LightGray">Dimanche</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Lundi" Width="10%">Lundi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Mardi" Width="10%">Mardi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Mercredi" Width="10%">Mercredi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Jeudi" Width="10%">Jeudi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Vendredi" Width="10%">Vendredi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Samedi" Width="10%" BackColor="LightGray">Samedi</asp:TableHeaderCell>
            <asp:TableHeaderCell ID="Modif" Width="5%"></asp:TableHeaderCell>
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
    </asp:Table>

    <%--<asp:Button ID="bt_modifier" runat="server" Text="modif" OnClick="bt_modifier_Click" />--%>
</asp:Content>
