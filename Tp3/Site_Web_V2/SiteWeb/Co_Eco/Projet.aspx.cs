﻿using System;
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
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        List<T_StatusProjet> listeStatProjet = BD_CoEco.GetListeStatusProjet();
        List<T_Projet> rawListeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.idStatus).ThenBy(o => o.nom).ToList();

        if (!IsPostBack)
        {
            int idEmp = int.Parse(Session["idEmp"].ToString());
        
            loadResponsable();
            loadStatut();

            string nom = Request.QueryString["nom"];
            string idRep = Request.QueryString["idRep"];
            string idStat = Request.QueryString["idStat"];
            string descript = Request.QueryString["descript"];

            if (nom != null)
            {
                tbx_nom.Text = nom;
            }
            if (idRep != null)
            {
                DDL_Responsable.SelectedValue = idRep;
            }
            if (idStat != null)
            {
                DDL_Status.SelectedValue = idStat;
            }
            if (descript != null)
            {
                tbx_descript.Text = descript;
            }
            if (idEmp == 1 || idEmp == 3) //si c'est l'admin qui est connecté ou sophie
            {
                rech();
            }
            else
            {
                    loadAllProjetRes();
            }

            //Empêcher l'ajout de projet en tant qu'employé
            if(Session["fonction"].ToString() != "3")
            {
                btn_AddProject.Disabled = true;
            }
        }

    }

    private void loadAllProjetRes()
    {
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet();

        List<int> rechercheA = new List<int>();
        List<int> rechercheB = new List<int>();
        List<int> rechercheC = new List<int>();
        List<int> rechercheD = new List<int>();

        //Recherche sur le nom

        if (tbx_nom.Text != null && tbx_nom.Text != "")
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                if (listProjet[i].nom.ToLower().Contains(tbx_nom.Text.ToLower()))
                {
                    rechercheA.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                rechercheA.Add(i);
            }
        }

        //Recherche responsable

        if (DDL_Responsable.SelectedValue != "-1") //Se serait toutes les catégories
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                if (listProjet[i].responsable == int.Parse(DDL_Responsable.SelectedValue))
                {
                    rechercheB.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                rechercheB.Add(i);
            }
        }

        //Recherche Statuts

        if (DDL_Status.SelectedValue != "-1") //Se serait toutes les catégories
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                if (listProjet[i].idStatus == int.Parse(DDL_Status.SelectedValue))
                {
                    rechercheC.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                rechercheC.Add(i);
            }
        }


        //Recherche description

        if (tbx_descript.Text != null && tbx_descript.Text != "")
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                if (listProjet[i].descript != null)
                {
                    if (listProjet[i].descript.ToLower().Contains(tbx_descript.Text.ToLower()))
                    {
                        rechercheD.Add(i);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < listProjet.Count; i++)
            {
                rechercheD.Add(i);
            }
        }

        Tableau_Projets.Rows.Clear();

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_Projet = new TableHeaderCell();
        thc_Projet.Text = "Nom du projet";
        thc_Projet.Width = new Unit("25%");
        TableHeaderCell thc_responsable = new TableHeaderCell();
        thc_responsable.Text = "Chef de projet";
        thc_responsable.Width = new Unit("25%");
        TableHeaderCell thc_statut = new TableHeaderCell();
        thc_statut.Text = "Statut";
        thc_statut.Width = new Unit("25%");
        thr.Cells.Add(thc_Projet);
        thr.Cells.Add(thc_responsable);
        thr.Cells.Add(thc_statut);
        thr.ID = "thr_ID";
        Tableau_Projets.Rows.Add(thr);

        List<T_Projet> listProjetRes = new List<T_Projet>();

        for (int i = 0; i < listProjetRes.Count; i++)
        {
            //Tous les projets seront à charger
            bool a = rechercheA.Contains(i);
            bool b = rechercheB.Contains(i);
            bool c = rechercheC.Contains(i);
            bool d = rechercheD.Contains(i);
            if (a && b && c && d)
            {
                listProjetRes.Add(listProjetRes[i]); //On affiche les éléments présent dans les 4 listes
            }
        }

        foreach (T_Projet pro in listProjet)
        {
            if (pro.responsable == int.Parse(Session["idEmp"].ToString()))
            {
                listProjetRes.Add(pro);
            }
        }

        listProjetRes = listProjetRes.OrderBy(o => o.nom).ToList();

        foreach (T_Projet pro in listProjetRes)
        {
            showResult(pro.idProjet);
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

        string nom = Request.QueryString["nom"];
        string idRep = Request.QueryString["idRep"];
        string idStat = Request.QueryString["idStat"];
        string descript = Request.QueryString["descript"];
        List<T_Projet> Projets = Utilitaires.GetListeProjetsTri(nom, idRep, idStat, descript);
        Projets = Projets.OrderBy(o => o.nom).ToList();

        //Formatage du tableau

        for (int i = 0; i < Projets.Count; i++) //Lignes
        {
            tableau.AddCell(Projets[i].idProjet.ToString()); //ID
            tableau.AddCell(Projets[i].nom); //NOM
            tableau.AddCell(BD_CoEco.GetStatusProjetById(Projets[i].idStatus).descript); //STATUS
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

        if(File.Exists(fileName))
            File.Delete(fileName);
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
        string nom = "";
        string idrep = "";
        string idStat = "";
        string descript = "";
        if (tbx_nom.Text != "")
        {
            nom = "nom=" + tbx_nom.Text;
        }
        idrep = "idRep=" + DDL_Responsable.SelectedValue;
        idStat = "idStat=" + DDL_Status.SelectedValue;
        if (tbx_descript.Text != "")
        {
            descript = "descript=" + tbx_descript.Text;
        }
        Response.Redirect("Projet.aspx?" + nom + "&" + idrep + "&" + idStat + "&" + descript);
    }

    private void rech()
    {
        List<T_Projet> tousLesProjets = BD_CoEco.GetListeProjet();
        List<int> rechercheA = new List<int>();
        List<int> rechercheB = new List<int>();
        List<int> rechercheC = new List<int>();
        List<int> rechercheD = new List<int>();

        //Recherche sur le nom

        if (tbx_nom.Text != null && tbx_nom.Text != "")
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].nom.ToLower().Contains(tbx_nom.Text.ToLower()))
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

        if (tbx_descript.Text != null && tbx_descript.Text != "")
        {
            for (int i = 0; i < tousLesProjets.Count; i++)
            {
                if (tousLesProjets[i].descript != null)
                {
                    if (tousLesProjets[i].descript.ToLower().Contains(tbx_descript.Text.ToLower()))
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
        TableHeaderCell thc_Projet = new TableHeaderCell();
        thc_Projet.Text = "Nom du projet";
        thc_Projet.Width = new Unit("25%");
        TableHeaderCell thc_responsable = new TableHeaderCell();
        thc_responsable.Text = "Chef de projet";
        thc_responsable.Width = new Unit("25%");
        TableHeaderCell thc_statut = new TableHeaderCell();
        thc_statut.Text = "Statut";
        thc_statut.Width = new Unit("25%");
        thr.Cells.Add(thc_Projet);
        thr.Cells.Add(thc_responsable);
        thr.Cells.Add(thc_statut);
        thr.ID = "thr_ID";
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
            if(projet.responsable != -1)
            {
                T_Employe responsable = BD_CoEco.GetEmpByID((int)projet.responsable);
                cChef.Text = responsable.prenom + " " + responsable.nom;
            }
            else
            {
                cChef.Text = "-";
            }
            
        }
        //tc4.Text = listeStatProjet[p_projet.idStatus - 1].descript;
        TableCell cStatut = new TableCell();
        cStatut.Text = BD_CoEco.GetListeStatusProjet()[projet.idStatus - 1].descript;

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