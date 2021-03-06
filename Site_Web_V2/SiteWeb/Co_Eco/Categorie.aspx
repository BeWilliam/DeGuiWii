﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <div class="form-row">
        <div class="col">
            <label for="validationTooltip01">Choisir le projet</label>
            <asp:DropDownList CssClass="form-control" runat="server" ID="ddl_projet" AutoPostBack="True" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>


    <div class="form-row" style="margin: 0 auto">
        <div class="col">

            <asp:button id="btn_addCat" name="btn_addCat" runat="server" CssClass="btn btn-primary" style="margin-top: 10px; width: 100%; color: #000000;" OnClick="btn_addCat_Click"></asp:button>

            <asp:Label ID="lbl_nom" runat="server" Text="Nom de la catégorie"></asp:Label>
            <asp:TextBox ID="tbx_cat" runat="server" CssClass="form-control" style="margin-bottom: 10px;" required></asp:TextBox>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" />

            <asp:button id="btn_apply" runat="server" CssClass="btn btn-primary" style="margin-top: 10px; width: 100%; color: #000000;" OnClick="btn_apply_Click"></asp:button>


        </div>
    </div>


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
    <asp:Table runat="server" ID="Tableau_Categorie" CssClass="table">
        <asp:TableRow>
            <asp:TableHeaderCell Style="width: 100%">Catégories</asp:TableHeaderCell>
        </asp:TableRow>
    </asp:Table>

    <div class="btn-group-vertical">

        <%--        <input  runat="server" type="text" name="tbx_cat" class="form-control" id="tbx_cat" value="" required>--%>
        <%--<asp:TextBox ID="tbx_cat" runat="server" CssClass="form-control" required></asp:TextBox>--%>
        <%--<asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" />--%>

        <%--<button type="button" class="btn btn-success" id="btn_conf" style="margin-top: 10px; float: left; width: 205px; color: #000000;" runat="server" onserverclick="btn_Conf_Click">Confirmer l'ajout</button>--%>

    </div>

</asp:Content>

