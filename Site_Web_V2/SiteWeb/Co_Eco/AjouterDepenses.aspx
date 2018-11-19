<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterDepenses.aspx.cs" Inherits="Depenses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <asp:button runat="server" type="button" id="btn_ok" class="btn btn-success" OnClick="btn_ok_ServerClick" Style="margin-top: 10px; width: 100%; color: #000000; margin-left:5px;" Text="Ajouter"></asp:button>

    <asp:button runat="server" type="button" id="btn_cancel" class="btn btn-danger" OnClick="btn_cancel_ServerClick" Style="margin-top: 10px; width: 100%; color: #000000; margin-left:5px;" Text="Annuler"></asp:button>

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

</asp:Content>

