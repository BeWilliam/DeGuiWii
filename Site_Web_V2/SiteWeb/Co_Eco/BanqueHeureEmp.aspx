<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BanqueHeureEmp.aspx.cs" Inherits="BanqueHeureEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Banque d"heures
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Banque d'heures</h2>
        </div>
    </div>

        <asp:Table runat="server" ID="Tableau_BanqueDheures" CssClass="table" />

</asp:Content>

