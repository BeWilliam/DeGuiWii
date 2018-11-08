<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Categorie.aspx.cs" Inherits="Categorie" Theme="Categorie"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_title" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_left" Runat="Server">


</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cph_contenu" Runat="Server">

    <form runat="server">

        <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_projet" />

    </form>
</asp:Content>

