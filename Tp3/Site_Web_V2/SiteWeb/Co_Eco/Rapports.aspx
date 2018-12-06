<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Rapports.aspx.cs" Inherits="Rapports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
    Rapports
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" runat="Server">
    <%--<asp:Button runat="server" type="button" ID="btn_apply" class="btn btn-success" OnClick="btn_apply_Click" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Appliquer"></asp:Button>--%>

    <asp:Button ID="Button1" CssClass="btn btn-success" runat="server" Style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" Text="Générer PDF"></asp:Button>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Date début</label>
            <asp:TextBox ID="tbx_dateDebut" runat="server" CssClass="form-control" placeHolder="ex: 2018-01-22"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Date Fin</label>
            <asp:TextBox ID="tbx_DateFin" runat="server" CssClass="form-control" placeHolder="ex: 2018-01-22"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Projets</label>
            <asp:DropDownList runat="server" ID="ddl_Projets" CssClass="form-control" OnSelectedIndexChanged="ddl_Projets_SelectedIndexChanged" AutoPostBack="true" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Catégories</label>
            <asp:DropDownList runat="server" ID="ddl_Categorie" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Employés</label>
            <asp:CheckBoxList runat="server" ID="cbl_Employe" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Description</label>
            <asp:TextBox ID="tbx_notes" runat="server" CssClass="form-control"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>


</asp:Content>

