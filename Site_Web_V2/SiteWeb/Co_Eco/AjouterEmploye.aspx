<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterEmploye.aspx.cs" Inherits="AjouterEmploye" Theme="AjouterEmploye" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="container">
                <div class="row justify-content-md-center" style="margin-top: 5px;">
                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_addEmp" runat="server" OnClick="btn_addEmp_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_modifier" runat="server" OnClick="btn_modEmp_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-success" ID="btn_appliquer" runat="server" OnClick="btn_applyMod_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button type="button" CssClass="btn btn-danger" ID="btn_retour" runat="server" OnClick="btn_retour_Click" Style="margin-top: 10px; width: 100%; color: #000000;"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="col-xs-1 text-center">
                <h2>Employé</h2>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Prénom*</label>
                        <asp:TextBox ID="tbx_prenom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Nom*</label>
                        <asp:TextBox ID="tbx_nom" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Mot de passe</label>
                        <asp:TextBox ID="tbx_mdp" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Nom de connexion</label>
                        <asp:TextBox ID="tbx_pseudo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-md-auto" style="text-align: center;">
                <label for="validationTooltip01">Courriel</label>
                <asp:TextBox ID="tbx_courriel" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Fonction*</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_fonction" />
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Statut</label>
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_statut" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

