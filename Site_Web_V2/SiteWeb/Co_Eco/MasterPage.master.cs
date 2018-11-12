using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("index.aspx");
        }
        if(Session["fonction"].ToString() == "1")
        {
            //Bureau
            div_Menu.Visible = true;
            div_FeuilleDeTemps.Visible = true;
            div_projet.Visible = true;
            div_Employe.Visible = false;
            div_categorie.Visible = false;
            div_depense.Visible = true;
            div_Rapports.Visible = false;
        }
        if (Session["fonction"].ToString() == "2")
        {
            //Terrain
            div_Menu.Visible = true;
            div_FeuilleDeTemps.Visible = true;
            div_projet.Visible = false;
            div_Employe.Visible = false;
            div_categorie.Visible = false;
            div_depense.Visible = true;
            div_Rapports.Visible = false;
        }
        if (Session["fonction"].ToString() == "3")
        {
            //Admin
            div_Menu.Visible = true;
            div_FeuilleDeTemps.Visible = true;
            div_projet.Visible = true;
            div_Employe.Visible = true;
            div_categorie.Visible = true;
            div_depense.Visible = true;
            div_Rapports.Visible = true;
        }
    }

    protected void btn_Deco_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
}
