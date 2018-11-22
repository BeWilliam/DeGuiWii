<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTempsADM.aspx.cs" Inherits="FeuilleDeTempsADM" Theme="FeuilleDeTempsADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Feuille de temps
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
    <asp:TextBox TextMode="Week" CssClass="form-control" runat="server" ID="tbx_Semaine" OnTextChanged="tbx_Semaine_TextChanged" AutoPostBack="true" Style="width:100%;margin-left:5px; margin-top:5px;"/>
    <input id="btn_allCheck" type="button" class="btn btn-success" value="Tout sélectionner"Style="width:100%;margin-left:5px; margin-top:5px;" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <asp:Table runat="server" ID="tab_emp" CssClass="table"/>
    <input id="btn_App_Click" type="button" class="btn btn-success" value="Appliquer" onclick="enr()"/>

    


</asp:Content>

