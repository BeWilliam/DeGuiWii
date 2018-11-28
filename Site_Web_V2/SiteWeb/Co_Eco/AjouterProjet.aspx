<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterProjet.aspx.cs" Inherits="AjouterProjet" Theme="AjouterProjet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="row">
        <div class="col-md-6 offset-md-3">

            <div class="container">

                <div class="row justify-content-md-center" style="margin-top: 5px;">

                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_addProject" runat="server" Text="Ajouter" OnClick="btn_addProject_Click" Style="color: #000000;"></asp:Button>
                    </div>

                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_modifier" runat="server" Text="Modifier" OnClick="btn_modifier_Click" Style="color: #000000;"></asp:Button>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_apply" runat="server" Text="Appliquer" OnClick="btn_apply_Click" Style="color: #000000;"></asp:Button>
                    </div>

                    <div class="col-lg-2">
                        <asp:Button type="button" formnovalidate CssClass="btn btn-danger" ID="btn_retour" runat="server" Text="Retour" OnClick="btn_retour_Click" Style="color: #000000;"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="col-md-auto" style="text-align: center; float: left;">
                <h2>Projet</h2>

                <label for="validationTooltip01">Nom du projet</label>
                <asp:TextBox ID="tbx_nom" runat="server" CssClass="form-control" placeholder="Ex : Création d'un site web"></asp:TextBox>
            </div>
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Responsable de projet</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_responsable" AutoPostBack="True" />
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Nombre d'heure alloué</label>
                        <asp:TextBox ID="tbx_heure" runat="server" CssClass="form-control" placeholder="Ex : 40"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Date de début</label>
                        <asp:TextBox ID="dateDebut" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="col-lg-6">
                        <label for="validationTooltip01">Date de fin</label>
                        <asp:TextBox ID="dateFin" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-md-auto" style="text-align: center; float: left;">
                <label for="validationTooltip01">Description du projet</label>
                <asp:TextBox ID="tbx_projet" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-auto" style="text-align: center; float: left;">
                <label for="validationTooltip01">Statut du projet</label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" AutoPostBack="True" />
            </div>



            <div class="container">
                <div class="row justify-content-md-center">

                    <asp:DropDownList ID="ddl_employe" runat="server" CssClass="form-control"></asp:DropDownList>
                    <asp:Button ID="btn_lieEmp" runat="server" CssClass="btn btn-primary" Text="Ajouter" />

                    <div class="col-xl-5">
                        <label for="validationTooltip01">Liste d'employés</label>
                        <asp:ListBox runat="server" CssClass="form-control" ID="lst_employe" Style="height: 200px;"></asp:ListBox>
                    </div>

                    <div class="col-lg-1" style="margin-top: 10%; margin-left: 25px; margin-right: 25px;">
                        <asp:Button ID="btn_ajouter" runat="server" Text=">" CssClass="btn btn-primary" OnClick="btn_ajouter_Click" Style="margin-bottom: 5px;" />
                        <asp:Button ID="btn_retirer" runat="server" Text="<" CssClass="btn btn-primary" OnClick="btn_retirer_Click" />
                    </div>

                    <div class="col-lg-5">
                        <label for="validationTooltip01">Liste d'employés liées au projets</label>
                        <asp:ListBox runat="server" CssClass="form-control" ID="lst_employeAjouter" Style="height: 200px;"></asp:ListBox>
                    </div>

                </div>
            </div>

            <div class="col-md-auto" style="text-align: center; float: left;">
                <h2>Catégories</h2>

            </div>
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6" style="text-align: center; float: left; text-align: center;">
                        <asp:Table ID="tableau_categorie" runat="server" CssClass="table" Style="float: right;">
                        </asp:Table>
                    </div>
                </div>
            </div>

        </div>
    </div>




</asp:Content>

