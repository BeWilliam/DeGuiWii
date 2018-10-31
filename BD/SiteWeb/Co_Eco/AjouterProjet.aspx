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
    </div>
    <div class="div_lst">
        <p>

            <h3>Catégories</h3>

            <asp:ListBox ID="lst_catIn" runat="server" CssClass="lst_catIn"></asp:ListBox>

            <asp:ImageButton ID="ImageButton1" CssClass="btn_left" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/left.png"/>
            <asp:ImageButton ID="ImageButton3" CssClass="btn_right" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/right.png"/>

            <asp:ListBox ID="lst_catOut" runat="server" CssClass="lst_catOut"></asp:ListBox>
        </p>
    </div>

            <div class="div_titre1">   
                <h3>Employés</h3>            
            </div>

        <div class="div_lst">

        <p>

            <asp:ListBox ID="lst_empIn" runat="server" CssClass="lst_empIn"></asp:ListBox>

            <asp:ImageButton ID="ImageButton2" OnClick="AddEmpPro_Click" CssClass="btn_left" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/left.png"/>
            <asp:ImageButton ID="ImageButton4" CssClass="btn_right" runat="server" ImageUrl="~/App_Themes/AjouterProjet/Image/right.png"/>

            <asp:ListBox ID="lst_empOut" runat="server" CssClass="lst_empOut"></asp:ListBox>
        </p>
    </div>

    <section>

        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" class="btn_ajouterProjet" BackColor="#53b34f" Font-Size="18px" OnClick="btn_ajouter_Click"/>

    </section>
</asp:Content>

