<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterEmploye.aspx.cs" Inherits="AjouterEmploye" Theme="AjouterEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
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
        <button type="button" class="btn btn-success" id="add_emp"  runat="server" onserverclick="btn_addEmp_Click">Ajouter</button>

</asp:Content>

