<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BanqueHeureAdmin.aspx.cs" Inherits="BanqueHeureAdmin" Theme="BanqueHeureADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Banque d'heures
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

        <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Banque d'heures</h2>
        </div>
    </div>

        <asp:Table runat="server" ID="Tableau_BanqueHeure" CssClass="table" />


</asp:Content>

