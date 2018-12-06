<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseEMP.aspx.cs" Inherits="DepenseEMP" Theme="DepensesADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Dépenses
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <asp:Button type="button" CssClass="btn btn-success" ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" Style="margin-top: 10px; margin-bottom:10px; color: #ffffff; width:30%"></asp:Button>
        </div>

    </div>

    <asp:Panel ID="pnl_Main" runat="server" />

</asp:Content>

