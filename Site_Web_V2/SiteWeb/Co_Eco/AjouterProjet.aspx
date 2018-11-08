<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Ajouter un projet
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div class="div_content">
        <p>
        <asp:Label ID="lbl_nom" runat="server" Text="Nom du projet : "></asp:Label>
        <asp:TextBox ID="tbx_nom" runat="server" Font-Size="Large"></asp:TextBox>
        </p>
        
        <p>
        <asp:Label ID="lbl_chef" runat="server" Text="Responsable du projet : "></asp:Label>
        <asp:DropDownList ID="ddl_chef" runat="server" CssClass="ddl_chef" Font-Size="Large"></asp:DropDownList>
        </p>
        <p>
        <asp:Label ID="lbl_nbHeure" runat="server" Text="Nombre d'heure alloué au projet : "></asp:Label>
        <asp:TextBox ID="tbx_nbHeure" runat="server" Font-Size="Large"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbl_dateDebut" runat="server" Text="Date de début : "></asp:Label>
            <asp:TextBox ID="tbx_dateDebut" runat="server" Font-Size="Large" placeHolder="Ex : 2018-10-30"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="Label1" runat="server" Text="Date de fin : "></asp:Label>
            <asp:TextBox ID="tbx_dateFin" runat="server" Font-Size="Large" placeHolder="Ex : 2018-10-30"></asp:TextBox>
        </p>
        <p>
        <asp:Label ID="lbl_descrption" runat="server" Text="Description : "></asp:Label>
            <asp:TextBox ID="tbx_description" runat="server" Font-Size="Large" CssClass="tbx_description" TextMode="MultiLine"></asp:TextBox>
        </p>
    </div>
    <div class="div_lst">

<%--        <div>
            <h3>Catégories</h3>
            <asp:ImageButton ID="btn_addCategorie" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/logo_addCategorie.png" class="btn_addCategorie" OnClick="btn_addCategorie_Click"/>
        </div>--%>

            
        <!--
            <asp:ListBox ID="lst_catIn" runat="server" CssClass="lst_catIn"></asp:ListBox>

            <asp:ImageButton ID="ImageButton1" CssClass="btn_left" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/left.png"/>
            <asp:ImageButton ID="ImageButton3" CssClass="btn_right" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/right.png"/>

            <asp:ListBox ID="lst_catOut" runat="server" CssClass="lst_catOut"></asp:ListBox> -->

    </div>

            <div class="div_titre1">   
                <h3>Employés</h3>            
            </div>

        <div class="div_lst">

        <p>

            <asp:ListBox ID="lst_empIn" runat="server" CssClass="lst_empIn"></asp:ListBox>

            <asp:ImageButton ID="ImageButton2" OnClick="AddEmpPro_Click" CssClass="btn_left" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/left.png"/>
            <asp:ImageButton ID="ImageButton4" OnClick="RemEmpPro_Click" CssClass="btn_right" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/right.png"/>

            <asp:ListBox ID="lst_empOut" runat="server" CssClass="lst_empOut"></asp:ListBox>
        </p>
    </div>

    <section>

        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" class="btn_ajouterProjet" BackColor="#53b34f" Font-Size="18px" OnClick="btn_ajouter_Click"/>
        <asp:Button ID="btn_annnuler" runat="server" Text="Annuler" class="btn_ajouterProjet" BackColor="#53b34f" Font-Size="18px" OnClick="btn_annnuler_Click"/>

    </section>
</asp:Content>

