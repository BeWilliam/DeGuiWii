<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjoutBanqueHeure.aspx.cs" Inherits="AjoutBanqueHeure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md">

        <div class="col-md-4">
            <label for="validationTooltip01">Congés Fériés</label>
            <asp:TextBox ID="tb_congesFeries" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="validationTooltip01">Congés Maladie</label>
            <asp:TextBox ID="tb_congesMaladie" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="validationTooltip01">Congés Personnels</label>
            <asp:TextBox ID="tb_congesPersonnels" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="validationTooltip01">Heures Accumulées Ou Sans Solde</label>
            <asp:TextBox ID="tb_heuresAccumuleesOuSansSolde" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label for="validationTooltip01">Vacances</label>
            <asp:TextBox ID="tb_vacances" runat="server"></asp:TextBox>
        </div>

    </div>

</asp:Content>

