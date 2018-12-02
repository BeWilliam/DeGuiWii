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
            div_FeuilleDeTemps.Visible = true;
            div_FeuilleDeTempsADM.Visible = false;
            div_projet.Visible = true;
            div_Employe.Visible = false;
            div_depense.Visible = true;
            div_DepenseADM.Visible = false;
            div_Options.Visible = false;
        }
        if (Session["fonction"].ToString() == "2")
        {
            //Terrain
            div_FeuilleDeTemps.Visible = true;
            div_FeuilleDeTempsADM.Visible = false;
            div_projet.Visible = false;
            div_Employe.Visible = false;
            div_depense.Visible = true;
            div_DepenseADM.Visible = false;
            div_Options.Visible = false;
        }
        if (Session["fonction"].ToString() == "3")
        {
            //Admin
            div_FeuilleDeTemps.Visible = false;
            div_FeuilleDeTempsADM.Visible = true;
            div_projet.Visible = true;
            div_Employe.Visible = true;
            div_depense.Visible = false;
            div_DepenseADM.Visible = true;
            div_Options.Visible = true;
        }
    }

    protected void btn_Deco_ServerClick(object sender, EventArgs e)
    {
        Session["username"] = null;
        Session["password"] = null;
        Session["fonction"] = null;
        Session["idEmp"] = null;
        Response.Redirect("index.aspx");
    }
}
