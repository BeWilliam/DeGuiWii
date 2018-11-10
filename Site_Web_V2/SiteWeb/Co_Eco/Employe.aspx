<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" Theme="Employe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <div class="btn-group-vertical">
        <button id="btn_AddEmp" type="button" class="btn btn-success" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;" runat="server" onserverclick="btn_ajouter_Click">Ajouter Employé</button>
        <button id="btn_GenPDF" type="button" class="btn btn-success" style="margin-top: 10px; margin-left: 15px; float: left; width: 150px; color: #000000;" runat="server" onserverclick="btn_GenPDF_ServerClick">Générer PDF</button>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <form runat="server">

        <label>Prénom</label>
        <asp:TextBox runat="server" ID="tbx_prenom"/>
        <label>Nom</label>
        <asp:TextBox runat="server" ID="tbx_nom"/>
        <label>Fonction</label>
        <asp:DropDownList runat="server" id="ddl_fonction"/>
        <label>Statut</label>
        <asp:DropDownList runat="server" id="ddl_statut"/>
        <button runat="server" id="btn_rech" class="btn btn-primary" onserverclick="btn_rech_ServerClick">Filtrer</button>
        <button runat="server" id="btn_cancel" class="btn btn-danger" onserverclick="btn_cancel_ServerClick">Retirer filtre</button>

        <asp:Table runat="server" ID="Tableau_Employes" CssClass="table" />
    </form>
    

</asp:Content>