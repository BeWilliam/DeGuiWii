<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">

    <form runat="server">
        <div class="btn-group-vertical">
            <button type="button" runat="server" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;"
                class="btn btn-success" onserverclick="btn_ajouter_Click">Ajouter Projet</button>
            <button type="button" runat="server" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;"
                class="btn btn-success" onserverclick="btn_men_Click">Générer PDF</button>
        </div>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <asp:Table runat="server" ID="Tableau_Projets" CssClass="table">
        <asp:TableRow>
            <asp:TableHeaderCell Style="width: 25%">#</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Nom du projet</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Chef de projet</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Statut</asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>


</asp:Content>
