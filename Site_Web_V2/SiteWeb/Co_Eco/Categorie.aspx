<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <form runat="server">

        <asp:Label ID="Label1" CssClass="lbl_choisir" runat="server" Text="Choisir le projet"></asp:Label>
        <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_projet" AutoPostBack="True" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" />

        <asp:Table runat="server" ID="Tableau_Categorie" CssClass="table">
            <asp:TableRow>
                <asp:TableHeaderCell Style="width: 100%">Catégories</asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>

        <div class="btn-group-vertical">

            <asp:TextBox ID="tbx_cat" runat="server" CssClass="tbx_categorie"></asp:TextBox>
            <button type="button" class="btn btn-success" id="add_cat" style="margin-top: 10px; float: left; width: 220px; color: #000000;" runat="server" onserverclick="btn_addCat_Click">Ajouter une Catégorie</button>
            <button type="button" class="btn btn-success" id="btn_conf" style="margin-top: 10px; float: left; width: 205px; color: #000000;" runat="server" onserverclick="btn_Conf_Click">Confirmer l'ajout</button>

        </div>

    </form>
</asp:Content>

