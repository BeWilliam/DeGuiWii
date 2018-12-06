<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Projets
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Projets</h2>
        </div>
    </div>

    <div class="form-row" style="margin: 0 auto">

        <div class="col-sm-2">
            <label for="validationTooltip01" style="text-align: center">Nom de Projet</label>
            <asp:TextBox CssClass="form-control" ID="tbx_nom" TextMode="Search" runat="server" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-2">
            <label for="validationTooltip01">Responsable</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="DDL_Responsable" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-2">
            <label for="validationTooltip01">Statut</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="DDL_Status" />
            <div class="valid-tooltip">
            </div>
        </div>


        <div class="col-sm-2">
            <label for="validationTooltip01">Description</label>
            <asp:TextBox CssClass="form-control" ID="tbx_descript" TextMode="Search" runat="server" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-1">

            <button id="btn_recherche" runat="server" class="btn btn-primary" style="margin-top: 32px; width: 100%; color: white;" onserverclick="btn_recherche_ServerClick">Rechercher</button>

        </div>

        <div class="col-sm-1">
            <button id="btn_remFiltre" runat="server" class="btn btn-danger" style="margin-top: 32px; width: 100%; color: white;" onserverclick="btn_remFiltre_ServerClick">Retirer filtre</button>
        </div>

        <div class="col-sm-1">
            <button id="btn_AddProject" type="button" runat="server" style="margin-top: 32px; width: 100%; color: white;"
                class="btn btn-success" onserverclick="btn_ajouter_Click">
                Ajouter Projet</button>
        </div>
        <div class="col-sm-1">
            <button type="button" runat="server" style="margin-top: 32px; width: 100%; color: white;"
                class="btn btn-success" onserverclick="btn_men_Click">
                Générer PDF</button>

        </div>

    </div>

    <div class="btn-group-vertical">

        <div class="form-row" style="margin: 0 auto">
        </div>

    </div>

    <asp:Table runat="server" ID="Tableau_Projets" CssClass="table" />

</asp:Content>
