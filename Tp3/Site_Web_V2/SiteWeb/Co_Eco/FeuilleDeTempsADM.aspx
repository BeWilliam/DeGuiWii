<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTempsADM.aspx.cs" Inherits="FeuilleDeTempsADM" Theme="FeuilleDeTempsADM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Feuille de temps
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">


            <div class="col-md-6 offset-md-3">
                <div class="col-md-auto" style="text-align: center;">
                    <h2>Feuilles de temps</h2>

                    <label for="validationTooltip01">Choisir la semaine</label>
                    <asp:TextBox TextMode="Week" CssClass="form-control" runat="server" ID="tbx_Semaine" OnTextChanged="tbx_Semaine_TextChanged" AutoPostBack="true" style="text-align:center; margin-bottom:10px;"/>
                            <asp:Button runat="server" ID="btn_AllApp" Text="Tout approuver" CssClass="btn btn-success" OnClick="btn_AllApp_Click" style="margin-bottom:10px;" />
                </div>

            </div>


            <asp:Panel runat="server" ID="panel_Contenu">
        </asp:Panel>





</asp:Content>
