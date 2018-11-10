<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">
    <div class="btn-group-vertical">
        <button type="button" runat="server" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;"
            class="btn btn-success" onserverclick="btn_ajouter_Click">
            Ajouter Projet</button>
        <button type="button" runat="server" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;"
            class="btn btn-success" onserverclick="btn_men_Click">
            Générer PDF</button>
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <form runat="server" id="div_Recherche" class="c_recherche">
        Nom
        <asp:TextBox ID="tbx_nom" runat="server" Text="" />
        Responsable
        <asp:DropDownList ID="DDL_Responsable" runat="server" />
        Statut
        <asp:DropDownList ID="DDL_Status" runat="server" />
        Description
        <asp:TextBox ID="tbx_descript" runat="server" Text="" />
        <button id="btn_recherche" runat="server" class="btn btn-success" onserverclick="btn_recherche_ServerClick">Rechercher</button>
    </form>
    <asp:Table runat="server" ID="Tableau_Projets" CssClass="table" />
</asp:Content>
