<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Connexion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Connexion à Co-éco</title>

    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />

</head>
<body>
    <header>
        <img src="App_Themes/Connexion/Image/logo_v2.jpg" class="logo_connexion" alt="LOGO_COECO"/>
    </header>

    <form runat="server" class="textbox_zone">

        <asp:TextBox ID="tbx_username" runat="server" placeHolder="Utilisateur"></asp:TextBox>
        <br />
        <asp:TextBox ID="tbx_mdp" runat="server" placeholder="Mot de passe" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Button ID="btn_connexion" runat="server" Text="Connexion" BackColor="#53b34f" BorderStyle="Outset" OnClick="Connexion_click"/>
    </form>

    <footer>

         <p>Développé par l'équipe DeGuiWii (Denis Thériault, Guillaume Gagnon et William Lemieux)</p>

    </footer>

</body>
</html>
