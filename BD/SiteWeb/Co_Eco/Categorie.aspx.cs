using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categorie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterCategorie.aspx");
    }
}