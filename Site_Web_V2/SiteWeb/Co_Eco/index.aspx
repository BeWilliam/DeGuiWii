<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Connexion à Co-éco</title>

    <link href="App_Themes/Default/bootstrap.css" rel="stylesheet" />
    <link href="App_Themes/Connexion/form-signin.css" rel="stylesheet" />

</head>
<body class="text-center">

    <form class="" runat="server">

        <img class="mb-4" src="App_Themes/Connexion/Image/Sprite.ico" alt="" width="300" height="180" />

        <h1 class="h3 mb-3 font-weight-normal">Connexion</h1>

        <asp:Label ID="username" runat="server" Text="Nom d'utilisateur"></asp:Label>
        <asp:TextBox ID="tbx_username" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="mdp" runat="server" Text="Mot de passe"></asp:Label>
        <asp:TextBox ID="tbx_mdp" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="checkbox mb-3">

        </div>
        <asp:Button ID="btn_connexion" runat="server" OnClick="Connexion_click" Text="Connexion" CssClass="btn btn-lg btn-success btn-block" style="color:#000000"  />
        <p class="mt-5 mb-3 text-muted">Développé par l'équipe DeGuiWii (Denis Thériault, Guillaume Gagnon et William Lemieux)</p>
    </form>










   <%-- <header>

        <nav class="navbar navbar-expand-lg navbar-light bg-light accordion" id="nav">
            <a class="navbar-brand" href="#" id="coeco">Co-Éco</a>
        </nav>

        <img src="App_Themes/Connexion/Image/logo_v2.jpg" class="logo_connexion" alt="LOGO_COECO" />
    </header>

    <form runat="server" class="textbox_zone">

        <asp:TextBox ID="tbx_username" runat="server" placeHolder="Utilisateur"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbx_mdp" runat="server" placeholder="Mot de passe" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btn_connexion" runat="server" Text="Connexion" BackColor="#53b34f" BorderStyle="Outset" OnClick="Connexion_click" />
    </form>

    <footer>

        <p>Développé par l'équipe DeGuiWii (Denis Thériault, Guillaume Gagnon et William Lemieux)</p>

    </footer>--%>

    <script src="Js/Js1.js"></script>
    <script src="Js/Js2.js"></script>
    <script src="Js/Js3.js"></script>

</body>
</html>
