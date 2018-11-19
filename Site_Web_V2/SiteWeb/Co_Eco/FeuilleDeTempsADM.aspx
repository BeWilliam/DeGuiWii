<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTempsADM.aspx.cs" Inherits="FeuilleDeTempsADM" Theme="FeuilleDeTempsADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Feuille de temps
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    <asp:TextBox TextMode="Week" CssClass="form-control" runat="server" ID="tbx_Semaine" OnTextChanged="tbx_Semaine_TextChanged" AutoPostBack="true" />
    <asp:Button runat="server" ID="btn_allCheck" Text="Tout sélectionner" OnClick="btn_allCheck_Click" AutoPostBack="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:Table runat="server" ID="tab_emp" CssClass="table"/>


</asp:Content>

