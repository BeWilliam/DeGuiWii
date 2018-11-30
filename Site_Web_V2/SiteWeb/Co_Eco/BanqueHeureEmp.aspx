<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BanqueHeureEmp.aspx.cs" Inherits="BanqueHeureEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Congés</label>
            </div>
        <div class="col-md-2">
            <label for="validationTooltip01">Congés Pris</label>
            </div>
        <div class="col-md-2">
            <label for="validationTooltip01">Congés total</label>
            </div>
        </div>
            <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Congés fériés</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congesFeriesPris" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congesFeriesTotal" runat="server"></asp:TextBox>

            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Congés Maladie</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congeMaladiePris" runat="server" MaxLength="4"  CssClass="col-sm-4"></asp:TextBox>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congeMaladieTotal" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Congés Personnel</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congesPersonnelsPris" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_congesPersonnelsTotal" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

            <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Heures accumulées ou sans solde</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_hrsAccPris" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_hrsAccTotal" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

                <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Vacances</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_vacancesPris" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_vacancesTotal" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

</asp:Content>

