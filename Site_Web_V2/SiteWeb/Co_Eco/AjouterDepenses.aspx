<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterDepenses.aspx.cs" Inherits="Depenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div>
        <label>Projet</label>
        <asp:DropDownList runat="server" ID="ddl_projet" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" AutoPostBack="true" />
    </div>
    <div>
        <label>Catégorie</label>
        <asp:DropDownList runat="server" ID="ddL_categorie" />
    </div>
    <div>
        <label>Type de dépense</label>
        <asp:DropDownList runat="server" ID="ddl_typeDepense" />
    </div>
    <div>
        <label>Description</label>
        <asp:TextBox runat="server" ID="tbx_description" />
    </div>
    <div>
        <label>Montant</label>
        <asp:TextBox runat="server" ID="tbx_montant" />
    </div>
    <div>
        <label>Date</label>
        <asp:TextBox runat="server" TextMode="Date" ID="Ddate"/>
    </div>
    <div>
        <label>Employé</label>
        <asp:DropDownList runat="server" ID="ddl_employe" Enabled="false"/>
    </div>
    <div>
        <button runat="server" id="btn_ok" class="btn btn-success" onserverclick="btn_ok_ServerClick">Enregistrer</button>
        <button runat="server" id="btn_cancel" class="btn btn-danger" onserverclick="btn_cancel_ServerClick">Annuler</button>
    </div>

</asp:Content>

