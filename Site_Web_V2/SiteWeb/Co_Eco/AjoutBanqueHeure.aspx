<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjoutBanqueHeure.aspx.cs" Inherits="AjoutBanqueHeure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
    
    <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" Visible="true" OnClick="btn_ajouter_Click" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />
    <asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="true" OnClick="btn_annuler_Click" CssClass="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md">

        <div class="col-md-6">
            <label for="validationTooltip01">Congés Fériés</label>
            <div class="col-md-4">
            </div>
            <asp:TextBox ID="tb_congesFeries" runat="server" CssClass="col-sm-4"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="validationTooltip01">Congés Maladie</label>
            <div class="col-md-4">
            </div>
            <asp:TextBox ID="tb_congesMaladie" runat="server" CssClass="col-sm-4"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="validationTooltip01">Congés Personnels</label>
            <div class="col-md-4">
            </div>
            <asp:TextBox ID="tb_congesPersonnels" runat="server" CssClass="col-sm-4"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="validationTooltip01">Heures Accumulées Ou Sans Solde</label>
            <div class="col-md-4">
            </div>
            <asp:TextBox ID="tb_heuresAccumuleesOuSansSolde" runat="server" CssClass="col-sm-4"></asp:TextBox>
        </div>
        <div class="col-md-6">
            <label for="validationTooltip01">Vacances</label>
            <div class="col-md-4">
            </div>
            <asp:TextBox ID="tb_vacances" runat="server" CssClass="col-sm-4"></asp:TextBox>
        </div>

    </div>



</asp:Content>

