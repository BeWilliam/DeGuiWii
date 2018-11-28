<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseEMP.aspx.cs" Inherits="DepenseEMP" Theme="DepensesADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">

        <asp:Button type="button" CssClass="btn btn-success" ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;"></asp:Button>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:Panel ID="pnl_Main" runat="server" />

</asp:Content>

