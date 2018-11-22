<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Options.aspx.cs" Inherits="Options" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    
    <div id="div_TauxAuto">
        <asp:Label ID="lbl_TauxAuto" runat="server" Text="Taux auto" />
        <asp:TextBox ID="tbx_TauxAuto" runat="server" />
        <asp:Button ID="btn_ModTauxAuto" runat="server" Text="Modifier" CssClass="btn btn-success" OnClick="btn_ModTauxAuto_Click" />
    </div>
    
    <div id="div_TauxCamion">
        <asp:Label ID="lbl_TauxCamion" runat="server" Text="Taux Camion" />
        <asp:TextBox ID="tbx_TauxCamion" runat="server" />
        <asp:Button ID="btn_ModTauxCamion" runat="server" Text="Modifier" CssClass="btn btn-success" OnClick="btn_ModTauxCamion_Click"/>
    </div>
    

</asp:Content>

