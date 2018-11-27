<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTempsADM.aspx.cs" Inherits="FeuilleDeTempsADM" Theme="FeuilleDeTempsADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Feuille de temps
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    <asp:TextBox TextMode="Week" CssClass="form-control" runat="server" ID="tbx_Semaine" OnTextChanged="tbx_Semaine_TextChanged" AutoPostBack="true" Style="width:100%;margin-left:5px; margin-top:5px;"/>
    <asp:Button runat="server" ID="btn_AllApp" Text="Tout approuver" CssClass="btn btn-success" OnClick="btn_AllApp_Click" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    
    <asp:Panel runat="server" ID="panel_Contenu">

    </asp:Panel>

</asp:Content>
