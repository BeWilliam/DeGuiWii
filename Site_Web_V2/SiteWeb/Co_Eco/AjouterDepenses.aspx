<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjouterDepenses.aspx.cs" Inherits="Depenses" Theme="AjouterDepense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" runat="Server">


    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="container">
                <div class="row justify-content-md-center" style="margin-top: 5px;">

                    <div class="col-lg-2">
                        <asp:Button runat="server" type="button" ID="btn_ok" CssClass="btn btn-success" OnClick="btn_ok_ServerClick" Style="margin-top: 10px; width: 100%; color: white; margin-left: 5px;" Text="Ajouter"></asp:Button>
                    </div>

                    <div class="col-lg-2">
                        <asp:Button runat="server" type="button" ID="btn_apply" CssClass="btn btn-success" OnClick="btn_apply_Click" Style="margin-top: 10px; width: 100%; color: white; margin-left: 5px;" Text="Appliquer"></asp:Button>
                    </div>

                    <div class="col-lg-2">
                        <asp:Button runat="server" type="button" ID="btn_modifier" CssClass="btn btn-success" OnClick="btn_modifier_Click" Style="margin-top: 10px; width: 100%; color: white; margin-left: 5px;" Text="Modifier"></asp:Button>
                    </div>

                    <div class="col-lg-2">
                        <asp:Button runat="server" type="button" ID="btn_cancel" CssClass="btn btn-danger" OnClick="btn_cancel_ServerClick" Style="margin-top: 10px; width: 100%; color: white; margin-left: 5px;" Text="Annuler"></asp:Button>
                    </div>

                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="col-xs-1 text-center">
                <h2>Ajouter une dépense</h2>
            </div>

            <div class="container">
                <div class="col-md-auto" style="text-align: center;">
                    <label for="validationTooltip01">Projet</label>
                    <asp:DropDownList runat="server" ID="ddl_projet" CssClass="form-control" />
                </div>
                <div class="col-md-auto" style="text-align: center;">
                    <label for="validationTooltip01">Type de dépense</label>
                    <asp:DropDownList runat="server" ID="ddl_typeDepense" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_typeDepense_SelectedIndexChanged" />
                </div>
                <div class="col-md-auto" style="text-align: center;">
                    <div class="form-row" id="div_KM" runat="server" visible="false">
                        <label for="validationTooltip01">Type de véhicule</label>
                        <asp:DropDownList runat="server" ID="ddl_typeVehicule" CssClass="form-control" />
                    </div>
                </div>
                <div class="col-md-auto" style="text-align: center;">
                    <label for="validationTooltip01">Description</label>
                    <asp:TextBox ID="tbx_description" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="container">
                    <div class="row justify-content-md-center">
                        <div class="col-lg-6">
                            <label for="validationTooltip01" runat="server" id="lbl_MontantOuKm">Montant</label>
                            <asp:TextBox ID="tbx_montant" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-lg-6">
                            <label for="validationTooltip01">Date</label>
                            <asp:TextBox ID="Ddate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-auto" style="text-align: center;">
                    <label for="validationTooltip01">Employé</label>
                    <asp:DropDownList runat="server" ID="ddl_employe" CssClass="form-control" Enabled="false" />
                </div>

            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6 offset-md-3">
            <div class="container">
                <div class="row justify-content-md-center" style="margin-top: 5px;">
                    <div class="col-lg-2">
                        <asp:Button ID="btn_approuver" runat="server" OnClick="btn_approuver_Click" Visible="false" Text="Approuver" CssClass="btn btn-success" style="width:100%;"/>
                    </div>
                    <div class="col-lg-2">
                        <asp:Button ID="btn_desapprouver" runat="server" OnClick="btn_desapprouver_Click" Visible="false" Text="Désapprouver" CssClass="btn btn-danger" style="width:100%;" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <section>
        <div class="form-row">
            <div class="col-md-4">

                <div class="valid-tooltip">
                </div>
            </div>
        </div>


        <div class="form-row">
            <div class="col-md-4">


                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="col-md-4">
        </div>
        <div class="form-row">
            <div class="col-md-4">

                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row">
            <div class="col-md-4">

                <div class="valid-tooltip">
                </div>
            </div>
        </div>

        <div class="form-row">
            <div class="col-md-4">
            </div>
        </div>

        <div class="form-row">
            <div class="col-md-4">

                <div class="valid-tooltip">
                </div>
            </div>
        </div>




    </section>


</asp:Content>

