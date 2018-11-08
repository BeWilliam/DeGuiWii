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
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.idStatus).ThenBy(o => o.nom).ToList();

        foreach (T_Projet p_projet in listeProjet)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            tc1.Text = p_projet.idProjet.ToString();

            TableCell tc2 = new TableCell();
            tc2.Text = p_projet.nom;

            TableCell tc3 = new TableCell();
            int? res = p_projet.responsable;

            if (res == null)
            {
                tc3.Text = "Pas de responsable";
            }
            else
            {                               
                BD_CoEco.GetEmpByID((int)res);
                tc3.Text = res.ToString();                                 
            }
            

            TableCell tc4 = new TableCell();
            tc4.Text = listeStatProjet[p_projet.idStatus - 1].descript;

            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
            tr.Cells.Add(tc4);
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