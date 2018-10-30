<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterEmploye.aspx.cs" Inherits="AjouterEmploye" theme="AjouterEmploye"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Ajouter un employé
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">
    <div>

        <p>
    <asp:Label ID="lb_nom" runat="server" Text="Nom" CssClass="label"></asp:Label>
    <asp:TextBox ID="tb_nom" runat="server" CssClass="textbox" Font-Size="Large"></asp:TextBox>
        </p>
        <p>
    <asp:Label ID="lb_prenom" runat="server" Text="Prénom" CssClass="label"></asp:Label>
    <asp:TextBox ID="tb_prenom" runat="server" CssClass="textbox" Font-Size="Large"></asp:TextBox>
            </p>
            <p>
    <asp:Label ID="lb_courriel" runat="server" Text="Adresse de couriel" CssClass="label"></asp:Label>
    <asp:TextBox ID="tb_courriel" runat="server" CssClass="textbox" Font-Size="Large"></asp:TextBox>
                </p>
                <p>
    <asp:Label ID="lb_fonction" runat="server" Text="Fonction" CssClass="label"></asp:Label>
    <asp:DropDownList ID="ddl_fonction" runat="server" Font-Size="Large">
        <asp:ListItem>Chef de projet</asp:ListItem>
        <asp:ListItem>Admin</asp:ListItem>
        <asp:ListItem>Employe de bureau</asp:ListItem>
    </asp:DropDownList>
                    </p>

        <p>
    <asp:Label ID="lb_actif" runat="server" Text="Actif" CssClass="label"></asp:Label>
            <asp:CheckBox ID="cb_actif" runat="server" Checked="True" />
                </p>
    </div>

    <section>
    <asp:Button ID="bt_ajouter" runat="server" Text="Ajouter" CssClass="button" OnClick="bt_ajouter_Click" />
    <asp:Button ID="bt_annuler" runat="server" Text="Annuler" CssClass="button" OnClick="bt_annuler_Click" />
    </section>
</asp:Content>

