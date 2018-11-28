<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FDT_ConsultationAdm.aspx.cs" Inherits="FDT_ConsultationAdm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <asp:Table runat="server" ID="tab_FDT" CssClass="table"/>
    <asp:Button runat="server" ID="btn_approuver" CssClass="btn btn-success" OnClick="btn_approuver_Click" Text="Approuver"/>
</asp:Content>

