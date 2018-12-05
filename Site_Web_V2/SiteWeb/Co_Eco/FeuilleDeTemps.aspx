<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Feuille de temps
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

    </asp:Table>

</asp:Content>
