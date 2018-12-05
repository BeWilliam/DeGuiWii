<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjoutBanqueHeure.aspx.cs" Inherits="AjoutBanqueHeure" %>

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
                        <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="true" OnClick="btn_ajouter_Click" CssClass="btn btn-success" Style="margin-top: 10px; width: 100%; color: white;" />
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btn_annuler" runat="server" Text="Annuler" Visible="true" OnClick="btn_annuler_Click" CssClass="btn btn-danger" Style="margin-top: 10px; width: 100%; color: white;" />
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
                        <label for="validationTooltip01">Congés Fériés</label>

                        <asp:TextBox ID="tb_congesFeries" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Congés Maladie</label>

                        <asp:TextBox ID="tb_congesMaladie" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row justify-content-md-center">
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Congés Personnels</label>

                        <asp:TextBox ID="tb_congesPersonnels" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-lg-6">
                        <label for="validationTooltip01">Heures Accumulées Ou Sans Solde</label>

                        <asp:TextBox ID="tb_heuresAccumuleesOuSansSolde" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-md-6" style="text-align: left;">
                <label for="validationTooltip01">Vacances</label>

                <asp:TextBox ID="tb_vacances" runat="server" CssClass="form-control" ></asp:TextBox>

            </div>
        </div>
    </div>



</asp:Content>

