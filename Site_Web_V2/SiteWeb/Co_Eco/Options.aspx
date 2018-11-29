<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Options.aspx.cs" Inherits="Options" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="col-md-6 offset-md-3">
        <div class="col-md-auto" style="text-align: center;">
            <h2>Options</h2>

                <section>
        <div id="div_TauxAuto" style="margin-bottom:10px;">
            <asp:Label ID="lbl_TauxAuto" runat="server" Text="Taux kilométrage en auto" />
            <asp:TextBox ID="tbx_TauxAuto" runat="server" />
            <asp:Button ID="btn_ModTauxAuto" runat="server" Text="Modifier" CssClass="btn btn-success" OnClick="btn_ModTauxAuto_Click" style="margin-bottom:5px;" />
        </div>

        <div id="div_TauxCamion">
            <asp:Label ID="lbl_TauxCamion" runat="server" Text="Taux kilomtrag en camion" />
            <asp:TextBox ID="tbx_TauxCamion" runat="server" />
            <asp:Button ID="btn_ModTauxCamion" runat="server" Text="Modifier" CssClass="btn btn-success" OnClick="btn_ModTauxCamion_Click" style="margin-bottom:5px;" />
        </div>
    </section>

        </div>
    </div>



</asp:Content>

