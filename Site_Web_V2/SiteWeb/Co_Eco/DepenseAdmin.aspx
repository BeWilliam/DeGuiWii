<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseAdmin.aspx.cs" Inherits="DepenseAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">

        <asp:LinkButton runat="server" type="button" ID="btn_ajouter" class="btn btn-success" OnClick="btn_ajouter_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;"><i class="fas fa-plus"></i> Ajouter</asp:LinkButton>
        
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <asp:Table runat="server" ID="tableauDepense" CssClass="table" />
</asp:Content>

