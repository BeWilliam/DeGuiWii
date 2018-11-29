<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" Theme="Employe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Employés</h2>
        </div>
    </div>

    <div class="form-row" style="margin-bottom: 24px;">
        <div class="col-sm-2">
            <label for="validationTooltip01" style="text-align: center">Prénom</label>
            <asp:TextBox CssClass="form-control" ID="tbx_prenom" TextMode="Search" runat="server" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-2">
            <label for="validationTooltip01" style="text-align: center">Nom</label>
            <asp:TextBox CssClass="form-control" ID="tbx_nom" TextMode="Search" runat="server" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-2">
            <label for="validationTooltip01">Fonction</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_fonction" />
            <div class="valid-tooltip">
            </div>
        </div>

        <div class="col-sm-2">
            <label for="validationTooltip01">Statut</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_Status" />
            <div class="valid-tooltip">
            </div>
        </div>


        <div class="col-sm-1">

            <button id="btn_recherche" runat="server" class="btn btn-primary" style="margin-top: 32px; width: 100%; color: white;" onserverclick="btn_rech_ServerClick">Rechercher</button>

        </div>

        <div class="col-sm-1">
            <button id="btn_remFiltre" runat="server" class="btn btn-danger" style="margin-top: 32px; width: 100%; color: white;" onserverclick="btn_cancel_ServerClick">Retirer filtre</button>
        </div>

        <div class="col-sm-1">
            <button type="button" runat="server" style="margin-top: 10px; width: 100%; color: white; margin-top: 32px;"
                class="btn btn-success" onserverclick="bt_AjouterEmploye_Click">
                Ajouter Employé</button>
        </div>
        <div class="col-sm-1">
            <button type="button" runat="server" style="margin-top: 10px; width: 100%; color: white; margin-top: 32px;"
                class="btn btn-success" onserverclick=" btn_GenPDF_ServerClick">
                Générer PDF</button>

        </div>

    </div>

    <asp:Table runat="server" ID="Tableau_Employes" CssClass="table" />

</asp:Content>
