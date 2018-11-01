<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Catégorie
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    
    <section class="section_recherche">
        <p class="p_recherche">
        <asp:TextBox ID="tbx_recherche" runat="server" CssClass="tbx_recherche"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_Themes/Categorie/Image/logo_recherche.png" CssClass="logo_rechercher"/>
        </p>
    </section>

    <asp:Panel ID="Panel1" runat="server" CssClass="panel_contenu">

        <asp:Label ID="lbl_projet" runat="server" Text="Nom du projet"></asp:Label>
        
        <div class="div_categorie">
            <p>
            <asp:Label ID="Label2" runat="server" Text="Catégorie"></asp:Label>
                </p>
            <p>
            <asp:Label ID="Label3" runat="server" Text="Catégorie"></asp:Label>
                </p>
        </div>
        
        <asp:ImageButton ID="btn_addCategorie" runat="server" ImageUrl="~/App_Themes/Categorie/Image/logo_addCategorie.png" CssClass="btn_ajouterCategorie" OnClick="btn_addCategorie_Click"/>

    </asp:Panel>

        <asp:Panel ID="Panel2" runat="server" CssClass="panel_contenu">

        <asp:Label ID="Label1" runat="server" Text="Nom du projet"></asp:Label>
        
        <div class="div_categorie">
            <p>
            <asp:Label ID="Label4" runat="server" Text="Catégorie"></asp:Label>
                </p>
            <p>
            <asp:Label ID="Label5" runat="server" Text="Catégorie"></asp:Label>
                </p>
        </div>
        
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_Themes/Categorie/Image/logo_addCategorie.png" CssClass="btn_ajouterCategorie" OnClick="btn_addCategorie_Click"/>

    </asp:Panel>


    

</asp:Content>

