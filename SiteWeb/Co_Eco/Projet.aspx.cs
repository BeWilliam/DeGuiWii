using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class Projet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<T_StatusProjet> listeStatProjet = BD_CoEco.GetListeStatusProjet();
        List<T_Projet> rawListeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.ToString()).ToList();

        for (int i = 0; i < listeProjet.Count; i++)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            HyperLink hl = new HyperLink();
            
            hl.NavigateUrl = "AjouterProjet.aspx"; //La solution doit venir de la.
            hl.Text = listeProjet[i].nom;
            hl.CssClass = ""; //Ajouter une class CSS au besoin
            hl.ID = "#" + i;
            tc1.Controls.Add(hl);

            TableCell tc2 = new TableCell();
            tc2.Text = listeStatProjet[listeProjet[i].idStatus - 1].descript;

            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            Tableau_Projets.Rows.Add(tr);
        }
    }

    protected void btn_addProject_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterProjet.aspx");
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterCategorie.aspx");
    }
}