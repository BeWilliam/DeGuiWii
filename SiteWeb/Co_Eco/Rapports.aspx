<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rapports.aspx.cs" Inherits="Rapports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    Rapports
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Rapports
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div>
        <asp:label runat="server">Date début </asp:label>
        <asp:TextBox id="tbx_dateDebut" runat="server" placeHolder="ex: 2018-01-22"></asp:TextBox>
    </div>
    <div>
        <asp:label runat="server">Date fin </asp:label>
        <asp:TextBox ID="tbx_DateFin" runat="server" placeHolder="ex: 2018-01-22"></asp:TextBox>
    </div>
    <div>
        <asp:label runat="server">Projets </asp:label>
        <asp:DropDownList ID="ddl_Projets" runat="server" OnSelectedIndexChanged="ddl_Projets_LoadCat" />
    </div>
    <div>
        <asp:label runat="server">Catégorie </asp:label>
        <asp:DropDownList ID="ddl_Categorie" runat="server" />
    </div>
    <div>
        <asp:Label runat="server">Employés</asp:Label>
        <asp:CheckBoxList ID="cbl_Employe" runat="server" />
    </div>
    <div>
        <label runat="server">Notes </label>
        <asp:TextBox runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button runat="server" Text="Rechercher"/>
        <asp:Button runat="server" Text="Actualiser" OnClick="Unnamed_Click"/>
    </div>

</asp:Content>

