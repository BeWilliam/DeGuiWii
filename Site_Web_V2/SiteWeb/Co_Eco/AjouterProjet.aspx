<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
    <%--Nom projet--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Nom du projet</label>
            <input type="text" class="form-control" id="tbx_nom" name="tbx_nom" placeholder="Ex : Création d'un site web" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Description projet--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Description du projet</label>
            <input type="text" class="form-control" id="tbx_projet" name="tbx_projet" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Responsable projet--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Responsable de projet</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_responsable" AutoPostBack="True" />
        </div>
    </div>

    <%--Nombre d'heure alloué--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Nombre d'heure alloué</label>
            <input type="text" class="form-control" id="tbx_heure" name="tbx_heure" placeholder="Ex : 40" value="" required runat="server">
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <%--Date début--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Date de début</label>
            <input id="dateDebut" type="date" name="dateDebut" onchange="sessionStorage.Dob=this.value" style="width: 100%" runat="server"/>
        </div>
    </div>

    <%--Date Fin--%>

    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Date de début</label>
            <input id="dateFin" type="date" name="dateFin" onchange="sessionStorage.Dob=this.value" style="width: 100%" runat="server"/>
        </div>
    </div>

    <%--Statut--%>
    <div class="form-row">
        <div class="col-md-4 mb-3">
            <label for="validationTooltip01">Statut du projet</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" AutoPostBack="True" />
        </div>
    </div>

    <button class="btn btn-primary" type="submit" runat="server" id="btn_addProject" onserverclick="btn_addProject_Click" >Ajouter</button>

</asp:Content>

