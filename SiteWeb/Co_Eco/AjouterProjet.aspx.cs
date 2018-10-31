using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjouterProjet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbx_dateDebut.Text = DateTime.Now.Date.ToShortDateString();
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('AjouterCategorie.aspx','_blank')");
        Response.Write("</script>");
    }

    protected void btn_annnuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }
}