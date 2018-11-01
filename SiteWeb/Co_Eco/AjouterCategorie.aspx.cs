using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterCategorie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<T_Projet> listPro = BD_CoEco.GetListeProjet();
        foreach (T_Projet projet in listPro)
        {
            ddl_projet.Items.Add(projet.ToString());
        }
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