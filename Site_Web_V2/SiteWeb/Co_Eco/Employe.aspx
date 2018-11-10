<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" Theme="Employe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <form runat="server">

        <div class="btn-group-vertical">


            <button type="button" class="btn btn-success"
                style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;"
                runat="server" onserverclick="btn_ajouter_Click">
                Ajouter Employé</button>

        </div>
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <asp:Table runat="server" ID="Tableau_Employes" CssClass="table">
        <asp:TableRow>
            <asp:TableHeaderCell Style="width: 25%">#</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Prénom</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Nom</asp:TableHeaderCell>
            <asp:TableHeaderCell Style="width: 25%">Statut</asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>

</asp:Content>
