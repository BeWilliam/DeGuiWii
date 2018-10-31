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
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Projet> tableProjet = BD.T_Projet;
        Table<T_StatusProjet> tableStatProjet = BD.T_StatusProjet;
        List<T_Projet> listeProjet = tableProjet.ToList();
        List<T_StatusProjet> listeStatProjet = tableStatProjet.ToList();

        foreach(T_Projet p_projet in listeProjet)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            tc1.Text = p_projet.nom;
            TableCell tc2 = new TableCell();

            tc2.Text = listeStatProjet[p_projet.idStatus - 1].descript;

            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            Tableau_Projets.Rows.Add(tr);
        }

        foreach(T_StatusProjet sp in listeStatProjet)
        {
            DDL_Etat.Items.Add(sp.descript);
        }

    }

    protected void btn_addProject_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterProjet.aspx");
    }
}