﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">

<<<<<<< HEAD

=======
>>>>>>> c241a3a807cc3b68bd3f0cbc2cfdf531af33b5b5
        <div class="form-row" style="margin: 0 auto">
            <div class="col">
                <label for="validationTooltip01" style="text-align: center">Nom de Projet</label>
                <input type="text" class="form-control" id="tbx_nom" name="tbx_nom" value="">
                <div class="valid-tooltip">
                </div>
            </div>
        </div>


        <div class="form-row">
            <div class="col">
                <label for="validationTooltip01">Responsable</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="DDL_Responsable" />
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row">
            <div class="col">
                <label for="validationTooltip01">Statut</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="DDL_Status" />
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row" style="margin: 0 auto">
            <div class="col">
                <label for="validationTooltip01">Description</label>
                <input type="text" class="form-control" id="tbx_descript" name="tbx_descript" value="">
                <div class="valid-tooltip">
                </div>
            </div>
        </div>


        <div class="btn-group-vertical">

            <div class="form-row" style="margin: 0 auto">
                <div class="col">

                    <button id="btn_recherche" runat="server" class="btn btn-primary" style="margin-top: 10px; width: 100%; color: #000000;" onserverclick="btn_recherche_ServerClick">Filtrer</button>

                    <button id="btn_remFiltre" runat="server" class="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000;" onserverclick="btn_remFiltre_ServerClick">Retirer filtre</button>

                    <button type="button" runat="server" style="margin-top: 10px; width: 100%; color: #000000;"
                        class="btn btn-success" onserverclick="btn_ajouter_Click">
                        Ajouter Projet</button>

                    <button type="button" runat="server" style="margin-top: 10px;  width: 100%; color: #000000;"
                        class="btn btn-success" onserverclick="btn_men_Click">
                        Générer PDF</button>

                </div>
            </div>

        </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <asp:Table runat="server" ID="Tableau_Projets" CssClass="table" />

</asp:Content>