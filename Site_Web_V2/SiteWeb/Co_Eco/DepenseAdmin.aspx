<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseAdmin.aspx.cs" Inherits="DepenseAdmin" Theme="DepensesADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Dépenses</h2>

            <asp:Button runat="server" type="button" ID="btn_ajouter" class="btn btn-success" OnClick="btn_ajouter_Click" Style="margin-bottom: 10px; width: 30%; color: white;" Text="Ajouter"></asp:Button>
        </div>
    </div>

    <asp:Panel runat="server" ID="pnl_master" />

</asp:Content>

