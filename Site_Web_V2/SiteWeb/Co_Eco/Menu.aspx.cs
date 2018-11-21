using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNewProject();
    }

    private void LoadNewProject()
    {
        List<T_Projet> listeJewProjets = BD_CoEco.GetListeNewProjet();

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_id = new TableHeaderCell();
        thc_id.Text = "#";
        thc_id.Width = new Unit("20%");

        TableHeaderCell thc_IdPro = new TableHeaderCell();
        thc_IdPro.Text = "Nom Projet";
        thc_IdPro.Width = new Unit("20%");

        TableHeaderCell thc_descript = new TableHeaderCell();
        thc_descript.Text = "Description";
        thc_descript.Width = new Unit("60%");


        thr.Cells.Add(thc_id);
        thr.Cells.Add(thc_IdPro);
        thr.Cells.Add(thc_descript);
        Tableau_NewProjects.Rows.Add(thr);

        foreach (T_Projet projet in listeJewProjets)
        {
            LoadInsert(projet);
        }
    }

    private void LoadInsert(T_Projet p_projet)
    {
        TableRow tr = new TableRow();
        TableCell tc_id = new TableCell();
        tc_id.Text = p_projet.idProjet.ToString();

        TableCell tc_nom = new TableCell();
        tc_nom.Text = p_projet.nom;

        TableCell tc_descript = new TableCell();
        tc_descript.Text = p_projet.descript;

        tr.Cells.Add(tc_id);
        tr.Cells.Add(tc_nom);
        tr.Cells.Add(tc_descript);

        Tableau_NewProjects.Rows.Add(tr);

    }

}