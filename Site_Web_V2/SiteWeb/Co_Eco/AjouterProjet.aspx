<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="form-row">
        <div class="col-sm-1">
            <asp:Button type="button" CssClass="btn btn-success" ID="btn_addProject" runat="server" Text="Ajouter" OnClick="btn_addProject_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
        </div>

        <div class="col-sm-1">
            <asp:Button type="button" CssClass="btn btn-success" ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
        </div>
        <div class="col-sm-1">
            <asp:Button type="button" CssClass="btn btn-success" ID="btn_apply" runat="server" Text="Appliquer" OnClick="btn_apply_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
        </div>
        <div class="col-sm-1">
            <asp:Button type="button" formnovalidate CssClass="btn btn-danger" ID="btn_retour" runat="server" Text="Retour" OnClick="btn_retour_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
        </div>
    </div>

    <%--Nom projet--%>
    <div class="form-row">
        <div class="col-xl-6" style="text-align: center;">
            <h2>Projet</h2>
        </div>
        <div class="col-xl-6" style="text-align: center;">
            <h2>Catégories</h2>
        </div>
    </div>
    <div class="form-row">
        <div class="col-xl-3">
            <label for="validationTooltip01">Nom du projet</label>
            <asp:TextBox ID="tbx_nom" runat="server" CssClass="form-control" placeholder="Ex : Création d'un site web"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
        <%--Responsable projet--%>
        <div class="col-xl-3">
            <label for="validationTooltip01">Responsable de projet</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_responsable" AutoPostBack="True" />
        </div>
    </div>

    <div class="form-row">
        <%--tableau pour catégorie--%>
        <div class="col-md-6 offset-md-6">
            <asp:Table ID="tableau_categorie" runat="server" CssClass="table"></asp:Table>
        </div>
    </div>

    <%--Description projet--%>
    <div class="form-row">
        <div class="col-xl-6">
            <label for="validationTooltip01">Description du projet</label>
            <asp:TextBox ID="tbx_projet" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>

    </div>



    <%--Nombre d'heure alloué--%>
    <div class="form-row">
        <div class="col-xl-3">
            <label for="validationTooltip01">Nombre d'heure alloué</label>
            <asp:TextBox ID="tbx_heure" runat="server" CssClass="form-control" placeholder="Ex : 40"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
        <div class="col-xl-3">
            <label for="validationTooltip01">Statut du projet</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" AutoPostBack="True" />
        </div>
    </div>

    <%--Date début--%>
    <div class="form-row">
        <div class="col-xl-3">
            <label for="validationTooltip01">Date de début</label>
            <asp:TextBox ID="dateDebut" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-xl-3">
            <label for="validationTooltip01">Date de fin</label>
            <asp:TextBox ID="dateFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
    </div>

    <div class="form-row" style="margin-top: 10px;">

        <div class="col-xs-3">
            <label for="validationTooltip01">Liste d'employés</label>
            <asp:ListBox runat="server" CssClass="form-control" ID="lst_employe" Style="height: 300px; width: 350px;"></asp:ListBox>
        </div>

        <div class="col-xs-1" style="margin-top: 140px;">
            <asp:Button ID="btn_ajouter" runat="server" Text=">" CssClass="btn btn-primary" OnClick="btn_ajouter_Click" Style="margin-bottom: 10px; width: 100%" />
            <asp:Button ID="btn_retirer" runat="server" Text="<" CssClass="btn btn-primary" OnClick="btn_retirer_Click" Style="width: 100%" />
        </div>

        <div class="col-xs-3">
            <label for="validationTooltip01">Liste d'employés liées au projets</label>
            <asp:ListBox runat="server" CssClass="form-control" ID="lst_employeAjouter" Style="height: 300px; width: 350px;"></asp:ListBox>
        </div>
    </div>

</asp:Content>

