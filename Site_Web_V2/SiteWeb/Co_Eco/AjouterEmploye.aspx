<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterEmploye.aspx.cs" Inherits="AjouterEmploye" Theme="AjouterEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">

    <button type="button" class="btn btn-success" id="add_emp" name="add_emp" runat="server" onserverclick="btn_addEmp_Click" style="margin-top: 10px; width: 100%; color: #000000;">Ajouter</button>
    <button type="button" class="btn btn-success" id="btn_modifier" name="btn_modifier" runat="server" onserverclick="btn_modEmp_Click" style="margin-top: 10px; width: 100%; color: #000000;">Modifier</button>
    <button type="button" class="btn btn-success" id="btn_appliquer" name="btn_appliquer" runat="server" onserverclick="btn_applyMod_Click" style="margin-top: 10px; width: 100%; color: #000000;">Appliquer</button>
    <button type="button" class="btn btn-danger" id="btn_retour" name="btn_retour" runat="server" onserverclick="btn_retour_Click" style="margin-top: 10px; width: 100%; color: #000000;">Retour</button>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <%--Prénom--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Prénom*</label>
            <input type="text" class="form-control" id="tbx_prenom" name="tbx_prenom" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Nom--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Nom*</label>
            <input type="text" class="form-control" id="tbx_nom" name="tbx_nom" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Courriel--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Courriel</label>
            <input type="text" class="form-control" id="tbx_courriel" name="tbx_courriel" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--MDP--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Mot de passe</label>
            <input type="text" class="form-control" id="tbx_mdp" name="tbx_mdp" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Fonction--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Fonction*</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_fonction" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Statut--%>
    <section id="sec_statut" runat="server">
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Statut</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" />
                <div class="valid-tooltip">
                </div>
            </div>
        </div>
    </section>

</asp:Content>

