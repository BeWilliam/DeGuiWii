using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem; //Anti problème

public partial class Projet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        List<T_StatusProjet> listeStatProjet = BD_CoEco.GetListeStatusProjet();
        List<T_Projet> rawListeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.idStatus).ThenBy(o => o.nom).ToList();

        if(!IsPostBack)
        {
            loadResponsable();
            loadStatut();
        }

        rech(); //Pour être sur d'être uniforme

    }

    protected void btn_addProject_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterProjet.aspx");
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterCategorie.aspx");

    }

    protected void btn_men_Click(object sender, EventArgs e)
    {
        //Bouton pour les rappors PDFs
        GenerateRapport();
    }

    private void GenerateRapport()
    {
        string fileName = Server.MapPath(@"~\Downloadss\RapportProjet " + DateTime.Now.ToString("ddMMyyyy") + ".pdf");

        DirectoryInfo dossierDownloadSvr = new DirectoryInfo(Server.MapPath(@"~\Downloadss\"));
        foreach (FileInfo file in dossierDownloadSvr.GetFiles())
        {
            file.Delete();
        }

        //Sources
        //https://www.c-sharpcorner.com/article/create-a-pdf-file-and-download-using-Asp-Net-mvc/
        //https://dotnet.developpez.com/articles/itextsharp/

        Document doc = new Document();
        doc.SetMargins(3f, 3f, 3f, 3f); //Marges du PDF
        PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create, FileAccess.Write));
        doc.Open();

        doc.Add(new Phrase("Rapport par Projet"));


        float[] test = {1, 1, 100000};
        PdfPTable tableau = new PdfPTable(test);

        tableau.SetWidths(new float[] { 0.1f, 0.8f, 0.2f });


        //Formatage du tableau

        for (int i = 0; i < Tableau_Projets.Rows.Count; i++) //Lignes
        {
            tableau.AddCell(Tableau_Projets.Rows[i].Cells[0].Text); //ID
            tableau.AddCell(Tableau_Projets.Rows[i].Cells[1].Text); //NOM
            tableau.AddCell(Tableau_Projets.Rows[i].Cells[3].Text); //STATUS
        }



        doc.Add(tableau); //On ajoute le tableau au document
        doc.Close();

        Response.ContentType = "text/txt";
        string jour = DateTime.Now.ToString("dd");
        string mois = DateTime.Now.ToString("MM");
        string annee = DateTime.Now.ToString("yyyy");

        Response.AppendHeader("Content-Disposition", "attachment; filename=Rapport Projet " + jour + "-" + mois + "-" + annee + ".pdf");
        Response.TransmitFile(@"~\Downloadss\RapportProjet " + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
        Response.End();
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterProjet.aspx");
    }

    private void loadResponsable()
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeResponsable = new List<T_Employe>();
        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction == 1) //Employé de bureau
            {
                listeResponsable.Add(employe);

            }
        }
        listeResponsable = listeResponsable.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        DDL_Responsable.Items.Add(new ListItem("Tous les responsables", "-1"));
        foreach (T_Employe responsable in listeResponsable)
        {
            DDL_Responsable.Items.Add(new ListItem(responsable.prenom + " " + responsable.nom, responsable.idEmploye.ToString()));
        }
    }

    private void loadStatut()
    {
        List<T_StatusProjet> listeStatusProjet = BD_CoEco.GetListeStatusProjet();
        listeStatusProjet = listeStatusProjet.OrderBy(o => o.descript).ToList();
        DDL_Status.Items.Add(new ListItem("Tous les statuts", "-1"));
        foreach (T_StatusProjet statut in listeStatusProjet)
        {
            DDL_Status.Items.Add(new ListItem(statut.descript, statut.noStatusPro.ToString()));
        }
    }

    protected void btn_recherche_ServerClick(object sender, EventArgs e)
    {
        rech();
    }

    private void rech()
    {
        List<T_Projet> tousLesProjets = BD_CoEco.GetListeProjet();
        List<int> rechercheA = new List<int>();
        List<int> rechercheB = new List<int>();
        List<int> rechercheC = new List<int>();
        List<int> rechercheD = new List<int>();

        //Recherche sur le nom

        if (String.Format("{0}", Request.Form["tbx_nom"]) != null && String.Format("{0}", Request.Form["tbx_nom"]) != "")
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].nom.ToLower().Contains(String.Format("{0}", Request.Form["tbx_nom"]).ToLower()))
                {
                    rechercheA.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                rechercheA.Add(i);
            }
        }

        //Recherche responsable

        if (DDL_Responsable.SelectedValue != "-1") //Se serait toutes les catégories
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].responsable == int.Parse(DDL_Responsable.SelectedValue))
                {
                    rechercheB.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                rechercheB.Add(i);
            }
        }

        //Recherche Statuts

        if (DDL_Status.SelectedValue != "-1") //Se serait toutes les catégories
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].idStatus == int.Parse(DDL_Status.SelectedValue))
                {
                    rechercheC.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                rechercheC.Add(i);
            }
        }


        //Recherche description

        if (String.Format("{0}", Request.Form["tbx_descript"]) != null && String.Format("{0}", Request.Form["tbx_descript"]) != "")
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].descript != null)
                {
                    if (tousLesProjets[i].descript.ToLower().Contains(String.Format("{0}", Request.Form["tbx_descript"]).ToLower()))
                    {
                        rechercheD.Add(i);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                rechercheD.Add(i);
            }
        }

        Tableau_Projets.Rows.Clear();
        //Traitement de chaque cas fait, donc effectuer la recherche

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_ID = new TableHeaderCell();
        thc_ID.Text = "#";
        thc_ID.Width = new Unit("25%");
        TableHeaderCell thc_Projet = new TableHeaderCell();
        thc_Projet.Text = "Nom du projet";
        thc_Projet.Width = new Unit("25%");
        TableHeaderCell thc_responsable = new TableHeaderCell();
        thc_responsable.Text = "Chef de projet";
        thc_responsable.Width = new Unit("25%");
        TableHeaderCell thc_statut = new TableHeaderCell();
        thc_statut.Text = "Statut";
        thc_statut.Width = new Unit("25%");
        thr.Cells.Add(thc_ID);
        thr.Cells.Add(thc_Projet);
        thr.Cells.Add(thc_responsable);
        thr.Cells.Add(thc_statut);
        Tableau_Projets.Rows.Add(thr);

        List<T_Projet> projectToShow = new List<T_Projet>();

        for (int i = 0; i < tousLesProjets.Count; i++)
        {
            //Tous les projets seront à charger
            bool a = rechercheA.Contains(i);
            bool b = rechercheB.Contains(i);
            bool c = rechercheC.Contains(i);
            bool d = rechercheD.Contains(i);
            if (a && b && c && d)
            {
                projectToShow.Add(tousLesProjets[i]); //On affiche les éléments présent dans les 4 listes
            }
        }

        projectToShow = projectToShow.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in projectToShow)
        {
            showResult(projet.idProjet);
        }
    }

    private void showResult(int id_Pro)
    {
        T_Projet projet = BD_CoEco.GetProByID(id_Pro);

        TableRow tr = new TableRow();

        TableCell cId = new TableCell();
        cId.Text = id_Pro.ToString();

        TableCell cNom = new TableCell();
        //cNom.Text = projet.nom;
        HyperLink hl = new HyperLink();
        hl.Text = projet.nom;
        hl.NavigateUrl = "AjouterProjet.aspx?id=" + projet.idProjet.ToString();
        cNom.Controls.Add(hl);

        TableCell cChef = new TableCell();
        if(projet.responsable == null || projet.responsable == 0)
        {
            cChef.Text = " - ";
        }
        else
        {
            T_Employe responsable = BD_CoEco.GetEmpByID((int)projet.responsable);
            cChef.Text = responsable.prenom + " " + responsable.nom;
        }
        //tc4.Text = listeStatProjet[p_projet.idStatus - 1].descript;
        TableCell cStatut = new TableCell();
        cStatut.Text = BD_CoEco.GetListeStatusProjet()[projet.idStatus - 1].descript;

        tr.Cells.Add(cId);
        tr.Cells.Add(cNom);
        tr.Cells.Add(cChef);
        tr.Cells.Add(cStatut);
        Tableau_Projets.Rows.Add(tr);
    }

    protected void btn_remFiltre_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }
}