<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BanqueHeureDetailAdmin.aspx.cs" Inherits="BanqueHeureDetailAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Banque d'heures</h2>
        </div>
    </div>
        <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="container">
                <div class="row justify-content-md-center" style="margin-top: 5px;">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="true" OnClick="btn_ajouter_Click" CssClass="btn btn-success" Style="margin-top: 10px; width: 100%; color: white;" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btn_annuler" runat="server" Text="Annuler" Visible="true" OnClick="btn_annuler_Click" CssClass="btn btn-danger" Style="margin-top: 10px; width: 100%; color: white;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
        <asp:Table runat="server" ID="Tableau_BanqueDheures" CssClass="table" />

</asp:Content>

