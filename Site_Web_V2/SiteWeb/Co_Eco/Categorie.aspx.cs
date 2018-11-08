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
        loadProjet();
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterCategorie.aspx");
    }

    private void loadProjet()
    {
        /*-- Partie pour les projets --*/
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet(true);
        listProjet = listProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }
}