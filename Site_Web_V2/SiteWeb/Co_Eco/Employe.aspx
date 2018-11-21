<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Employe.aspx.cs" Inherits="Employe" Theme="Employe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Employés
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">


        <div class="form-row" style="margin: 0 auto">
            <div class="col">
                <label for="validationTooltip01" style="text-align: center">Prénom</label>
                <input type="text" class="form-control" id="tbx_prenom" name="tbx_prenom" value="">
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row" style="margin: 0 auto">
            <div class="col">
                <label for="validationTooltip01" style="text-align: center">Nom</label>
                <input type="text" class="form-control" id="tbx_nom" name="tbx_nom" value="">
                <div class="valid-tooltip">
                </div>
            </div>
        </div>


        <div class="form-row">
            <div class="col">
                <label for="validationTooltip01">Fonction</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_fonction" />
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row">
            <div class="col">
                <label for="validationTooltip01">Statut</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_Status" />
                <div class="valid-tooltip">
                </div>
            </div>
        </div>


        <div class="btn-group-vertical">

            <div class="form-row" style="margin: 0 auto">
                <div class="col">

                    <button id="btn_recherche" runat="server" class="btn btn-primary" style="margin-top: 10px; width: 100%; color: #000000;" onserverclick="btn_rech_ServerClick">Rechercher</button>

                    <button id="Button1" runat="server" class="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000;" onserverclick="btn_cancel_ServerClick">Annuler</button>

                    <button type="button" runat="server" style="margin-top: 10px; width: 100%; color: #000000;"
                        class="btn btn-success" onserverclick="bt_AjouterEmploye_Click"><i class="fas fa-plus"></i>
                        Ajouter Employé</button>

                    <button type="button" runat="server" style="margin-top: 10px; width: 100%; color: #000000;"
                        class="btn btn-success" onserverclick=" btn_GenPDF_ServerClick">
                        Générer PDF</button>

                </div>
            </div>

        </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <asp:Table runat="server" ID="Tableau_Employes" CssClass="table" />

</asp:Content>
