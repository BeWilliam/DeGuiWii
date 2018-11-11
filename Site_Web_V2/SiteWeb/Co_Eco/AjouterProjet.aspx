<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
        <%--Nom projet--%>
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Nom du projet</label>
                <input type="text" class="form-control" id="validationTooltip01" placeholder="Ex : Création d'un site web" value="" required>
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <%--Responsable projet--%>
        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Responsable de projet</label>
                <asp:dropdownlist runat="server" cssclass="form-control" id="ddl_responsable" autopostback="True" />                 
            </div>
        </div>

        <%--Nombre d'heure alloué--%>
                <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Nombre d'heure alloué</label>
                <input type="text" class="form-control" id="validationTooltip12" placeholder="Ex : 40" value="" required>
                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <%--Date début--%>
                <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Date de début</label>
                <input id="inputDob" type="date" name="Dob" onchange="sessionStorage.Dob=this.value" style="width:100%"/>
            </div>
        </div>

        <%--Date Fin--%>

                        <div class="form-row">
            <div class="col-md-4 mb-3">
                <label for="validationTooltip01">Date de début</label>
                <input id="inputDob" type="date" name="Dob" onchange="sessionStorage.Dob=this.value" style="width:100%"/>
            </div>
        </div>

        <%--Description--%>
                <div class="form-row">
            <div class="col-md-4 mb-3">
<%--                <label for="validationTooltip01">Nom du projet</label>
                <input type="text" class="form-control" id="validationTooltip15" placeholder="Création d'un site web" value="" required>
                <div class="valid-tooltip">
                </div>--%>
            </div>
        </div>

        <button class="btn btn-primary" type="submit">Ajouter</button>

</asp:Content>

