using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjouterCategorie : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("Categorie.aspx");
    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Categorie.aspx");
    }
}