<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Projet.aspx.cs" Inherits="Projet" Theme="Projet" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_left" Runat="Server">
        <div class="btn-group-vertical">
        <button type="button" class="btn btn-light" id="btn_menu">Ajouter Projet</button>
        <button type="button" class="btn btn-light" id="btn_men">Générer PDF</button>  

    </div>
    </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

        <asp:table runat="server" id="Tableau_Projets" CssClass="table">
      <asp:TableRow>
        <asp:TableHeaderCell style="width:25%">#</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:25%">Nom du projet</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:25%">Chef de projet</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:25%">Statut</asp:TableHeaderCell>
      </asp:TableRow>
    </asp:table>


    </asp:Content>
