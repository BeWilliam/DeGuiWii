﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FeuilleDeTemps.aspx.cs" Inherits="FeuilleDeTemps" Theme="FeuilleDeTemps"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_titre_nav" Runat="Server">
    Feuilles de temps 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server" ClientIDMode="Inherit">
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <asp:table ID="t_feuilleTemps" runat="server" style="width:75%" CssClass="tableau_feuille">
      <asp:TableRow>
        <asp:TableHeaderCell ID="thc_Projet" style="width:11%">Projet</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Dimanche" style="width:11%">Dimanche</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Lundi" style="width:11%">Lundi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mardi" style="width:11%">Mardi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Mercredi" style="width:11%">Mercredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Jeudi" style="width:11%">Jeudi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Vendredi" style="width:11%">Vendredi</asp:TableHeaderCell>
        <asp:TableHeaderCell ID="Samedi" style="width:11%">Samedi</asp:TableHeaderCell>
        <asp:TableHeaderCell style="width:11%">Commentaires</asp:TableHeaderCell>
      </asp:TableRow>
      <asp:TableRow>
          <asp:TableCell>
              <asp:DropDownList ID="DropDownList1" runat="server" CssClass="ddl_projet"></asp:DropDownList>
              <asp:DropDownList ID="DropDownList2" runat="server" CssClass="ddl_categorie"></asp:DropDownList>

          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox1" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label1" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox2" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label7" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox3" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label2" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox4" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label3" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox5" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label4" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox6" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label5" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox7" runat="server" CssClass="tbx_h"></asp:TextBox>
              <asp:Label ID="Label6" runat="server" Text="H"></asp:Label>
          </asp:TableCell>
          <asp:TableCell>
              <asp:TextBox ID="TextBox8" runat="server" CssClass="tbx_h"></asp:TextBox>
          </asp:TableCell>

      </asp:TableRow>

    </asp:table>

    <div class="div_bouton">
            <asp:Button ID="btn_ajouter" runat="server" Text="Ajouter" class="btn_ajouterTemps" BackColor="#53b34f" Font-Size="18px"/>
    </div>
    </asp:Content>