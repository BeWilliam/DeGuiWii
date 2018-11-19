<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTempsADM.aspx.cs" Inherits="FeuilleDeTempsADM" Theme="FeuilleDeTempsADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Feuille de temps
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:ImageButton runat="server" ImageUrl="~/App_Themes/FeuilleDeTempsADM/Images/FlecheGauche.png" />
    <asp:ImageButton runat="server" ImageUrl="~/App_Themes/FeuilleDeTempsADM/Images/FlecheDroite.png" />

</asp:Content>

