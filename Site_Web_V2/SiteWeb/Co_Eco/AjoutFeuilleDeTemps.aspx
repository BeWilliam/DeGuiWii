<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AjoutFeuilleDeTemps.aspx.cs" Inherits="AjoutFeuilleDeTemps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">
     <asp:Button ID="btn_ajouter" runat="server" Text="Confirmer" Visible="true" OnClick="btn_ajouter_Click" CssClass="btn btn-success" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />
        <asp:Button ID="btn_annuler" runat="server" Text="Annuler"  Visible="true" OnClick="btn_annuler_Click" CssClass="btn btn-danger" style="margin-top: 10px; width: 100%; color: #000000; margin-left: 5px;" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Projet</label>
            <asp:DropDownList runat="server" ID="ddl_Projet" OnSelectedIndexChanged="ddl_projet_SelectedIndexChanged" CssClass="form-control" AutoPostBack="True" />
            
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

        <div class="form-row">
        <div class="col-md-4">
            <label for="validationTooltip01">Catégorie*</label>
            <asp:DropDownList runat="server" ID="ddl_Categorie" CssClass="form-control" />
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

    <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Dimanche</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_dimanche" runat="server" MaxLength="4"  CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label0" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_dimancheCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Lundi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_lundi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_lundiCommentaire" runat="server"></asp:TextBox>

            <div class="valid-tooltip">
            </div>
        </div>
    </div>
        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Mardi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_mardi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_mardiCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Mercredi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_mercredi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_mercrediCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Jeudi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_jeudi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label5" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_jeudiCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Vendredi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_vendredi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_vendrediCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>

        <div class="form-row">
        <div class="col-md-1">
            <label for="validationTooltip01">Samedi</label>
            </div>
            <div class="col-md-2">
            <asp:TextBox ID="tb_samedi" runat="server" MaxLength="4" CssClass="col-sm-4"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="H"></asp:Label>
            </div>
            <div class="col-md-4">
            <label for="validationTooltip01">Commentaire</label>
            <asp:TextBox ID="tb_samediCommentaire" runat="server"></asp:TextBox>
            <div class="valid-tooltip">
            </div>
        </div>
    </div>
</asp:Content>

