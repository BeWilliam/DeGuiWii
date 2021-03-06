﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepenseAdmin.aspx.cs" Inherits="DepenseAdmin" Theme="DepensesADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Dépenses
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Dépenses</h2>
            <asp:Button runat="server" type="button" ID="btn_ajouter" class="btn btn-success" OnClick="btn_ajouter_Click" Style="margin-bottom: 10px; width: 30%; color: white;" Text="Ajouter"></asp:Button>
            <asp:Button runat="server" ID="btn_allApp" Text="Tout approuver" OnClick="btn_AllApp_Click" Style="margin-bottom: 10px; width: 30%; color: white;" CssClass="btn btn-success"/>           
        </div>
    </div>

    <asp:Panel runat="server" ID="pnl_master" />

</asp:Content>

