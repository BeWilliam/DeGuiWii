<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseEMP.aspx.cs" Inherits="DepenseEMP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">

        <asp:Button type="button" CssClass="btn btn-success" ID="btn_ajouter" runat="server" Text="Ajouter" OnClick="btn_ajouter_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;"></asp:Button>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:Table ID="table_depense" runat="server" CssClass="table"></asp:Table>

</asp:Content>

