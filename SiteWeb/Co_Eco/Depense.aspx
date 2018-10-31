<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Depense.aspx.cs" Inherits="Depense" theme="Depenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Dépenses
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <asp:Table ID="TableDepenses" runat="server"></asp:Table>
    <asp:Table ID="Kilometrage" runat="server"></asp:Table>
</asp:Content>

