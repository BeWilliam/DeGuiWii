<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterDepenses.aspx.cs" Inherits="Depenses" Theme="DepensesADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <asp:Button runat="server" type="button" ID="btn_ok" class="btn btn-success" OnClick="btn_ok_ServerClick" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Ajouter"></asp:Button>

    <asp:Button runat="server" type="button" ID="btn_apply" class="btn btn-success" OnClick="btn_apply_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Appliquer"></asp:Button>

    <asp:Button runat="server" type="button" ID="btn_modifier" class="btn btn-success" OnClick="btn_modifier_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Modifier"></asp:Button>

    <asp:Button runat="server" type="button" ID="btn_cancel" class="btn btn-danger" OnClick="btn_cancel_ServerClick" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Annuler"></asp:Button>

    <asp:Button runat="server" type="button" ID="btn_retour" class="btn btn-danger" OnClick="btn_retour_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Retour"></asp:Button>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">


    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Projet</label>
            <asp:DropDownList runat="server" ID="ddl_projet" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Catégorie*</label>
            <asp:DropDownList runat="server" ID="ddL_categorie" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Type de dépense</label>
            <asp:DropDownList runat="server" ID="ddl_typeDepense" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Description</label>
            <asp:TextBox ID="tbx_description" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Montant</label>
            <asp:TextBox ID="tbx_montant" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Date</label>
            <asp:TextBox ID="Ddate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Employé</label>
            <asp:DropDownList runat="server" ID="ddl_employe" CssClass="form-control" Enabled="false" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <asp:Button ID="btn_approuver" runat="server" OnClick="btn_approuver_Click" Visible="false" Text="Approuver" CssClass="btn btn-success"/>
    <asp:Button ID="btn_desapprouver" runat="server" OnClick="btn_desapprouver_Click" Visible="false" Text="Désapprouver" CssClass="btn btn-danger"/>

</asp:Content>

