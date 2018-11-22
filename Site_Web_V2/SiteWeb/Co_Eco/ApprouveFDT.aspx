<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ApprouveFDT.aspx.cs" Inherits="ApprouveFDT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    <asp:Button runat="server" id="btn_app" CssClass="btn btn-success" Style="width:100%;margin-left:5px;margin-top:5px;" OnClick="btn_app_Click"/>
    <asp:Button runat="server" ID="btn_retour" Text="Retour" CssClass="btn btn-danger" Style="width:100%;margin-left:5px;margin-top:5px;" OnClick="btn_retour_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <asp:Label Font-Size="Larger" Font-Bold="true" runat="server" id="lbl_nomEmp" />
    <asp:Label runat="server" ID="lbl_idSem" />
    <asp:Table runat="server" ID="tab_FDT" CssClass="table" />

</asp:Content>

