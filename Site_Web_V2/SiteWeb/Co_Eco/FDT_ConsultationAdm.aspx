<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FDT_ConsultationAdm.aspx.cs" Inherits="FDT_ConsultationAdm" Theme="FeuilleDeTempsADM"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Consultation Feuille de temps
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">
    <asp:table runat="server" id="tab_FDT" cssclass="table" />

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
                <asp:button runat="server" id="btn_approuver" cssclass="btn btn-success" onclick="btn_approuver_Click" text="Approuver" />
        </div>
    </div>

</asp:Content>

