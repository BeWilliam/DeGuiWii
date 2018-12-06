<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FDT_ConsultationAdm.aspx.cs" Inherits="FDT_ConsultationAdm" Theme="FeuilleDeTempsADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Consultation Feuille de temps
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="container">
                <div class="row justify-content-md-center" style="margin-top: 5px;">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_approuver" runat="server" Text="Approuver" Visible="true" OnClick="btn_ajouter_Click" CssClass="btn btn-success" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btn_annuler" runat="server" Text="Annuler" Visible="true" OnClick="btn_annuler_Click" CssClass="btn btn-danger" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="col-xs-1 text-center">
                <h2>Ajouter des feuilles de temps</h2>
            </div>
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Projet</label>
                        <asp:DropDownList runat="server" ID="ddl_Projet" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True" />
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Catégorie</label>
                        <asp:DropDownList runat="server" ID="ddl_Categorie" CssClass="form-control" />
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Dimanche</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_dimanche" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_dimancheCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Lundi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_lundi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_lundiCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Mardi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_mardi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_mardiCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Mercredi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_mercredi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_mercrediCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Jeudi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_jeudi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_jeudiCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Vendredi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_vendredi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_vendrediCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-2">
                        <br />
                        <label for="validationTooltip01">Samedi</label>
                    </div>
                    <div class="col-lg-2">
                        <label for="validationTooltip01">Nombre d'heures</label>
                        <asp:TextBox ID="tb_samedi" runat="server" MaxLength="4" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-8">
                        <label for="validationTooltip01">Commentaire</label>
                        <asp:TextBox ID="tb_samediCommentaire" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>

