using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class Employe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        List<T_Employe> rawListeEmp = BD_CoEco.GetListeEmploye();
        //trié la liste avant insertion
        List<T_Employe> listeEmp = rawListeEmp.OrderBy(o => o.idStatus).ThenBy(o => o.prenom).ThenBy(o => o.nom).ToList();

        if(!IsPostBack)
        {
            loadFonction();
            loadStatut();
            Recherche();
        }
    }


    protected void bt_AjouterEmploye_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterEmploye.aspx");
    }


    protected void btn_GenPDF_ServerClick(object sender, EventArgs e)
    {
        GenPDF();
    }

    private void GenPDF()
    {
        string fileName = Server.MapPath(@"~\Downloadss\RapportEmploye " + DateTime.Now.ToString("ddMMyyyy") + ".pdf");

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

        doc.Add(new Phrase("Rapport par employé"));


        float[] test = { 1,1,1,1 };
        PdfPTable tableau = new PdfPTable(test);

        tableau.SetWidths(new float[] { 0.05f, 0.35f, 0.35f, 0.1f });


        //Formatage du tableau
        for(int i = 0; i < Tableau_Employes.Rows.Count; i++)
        {
            tableau.AddCell(Tableau_Employes.Rows[i].Cells[0].Text);
            tableau.AddCell(Tableau_Employes.Rows[i].Cells[1].Text);
            tableau.AddCell(Tableau_Employes.Rows[i].Cells[2].Text);
            tableau.AddCell(Tableau_Employes.Rows[i].Cells[3].Text);
        }


        doc.Add(tableau); //On ajoute le tableau au document
        doc.Close();

        Response.ContentType = "text/txt";
        string jour = DateTime.Now.ToString("dd");
        string mois = DateTime.Now.ToString("MM");
        string annee = DateTime.Now.ToString("yyyy");

        Response.AppendHeader("Content-Disposition", "attachment; filename=Rapport employé " + jour + "-" + mois + "-" + annee + ".pdf");
        Response.TransmitFile(@"~\Downloadss\RapportEmploye " + DateTime.Now.ToString("ddMMyyyy") + ".pdf");
        Response.End();
    }

    protected void btn_rech_ServerClick(object sender, EventArgs e)
    {
        Recherche();
    }

    private void loadFonction()
    {
        List<T_FonctionEmploye> listeFunc = BD_CoEco.GetListeFontionsEmploye();
        listeFunc = listeFunc.OrderBy(o => o.descript).ToList();
        ddl_fonction.Items.Add(new ListItem("Toutes les fonctions", "-1"));
        foreach (T_FonctionEmploye fonctionEmploye in listeFunc)
        {
            ddl_fonction.Items.Add(new ListItem(fonctionEmploye.descript, fonctionEmploye.idFonctionEmp.ToString()));
        }
    }

    private void loadStatut()
    {
        List<T_StatusEmploye> listeStatEmp = BD_CoEco.GetListeStatusEmploye();
        listeStatEmp.OrderBy(o => o.descript).ToList();
        ddl_Status.Items.Add(new ListItem("Tous les statuts", "-1"));
        foreach (T_StatusEmploye statusEmploye in listeStatEmp)
        {
            ddl_Status.Items.Add(new ListItem(statusEmploye.descript, statusEmploye.idStatusEmp.ToString()));
        }
    }

    private void Recherche()
    {
        List<T_Employe> tousLesEmp = BD_CoEco.GetListeEmploye();
        List<int> rechercheA = new List<int>();
        List<int> rechercheB = new List<int>();
        List<int> rechercheC = new List<int>();
        List<int> rechercheD = new List<int>();

        tousLesEmp.RemoveAt(0); //Retrait de l'admin

        //Recherche sur les prénoms

        if (String.Format("{0}", Request.Form["tbx_prenom"]) != "" && String.Format("{0}", Request.Form["tbx_prenom"]) != null)
        {
            for (int i = 0; i < tousLesEmp.Count; i++)
            {
                if(tousLesEmp[i].prenom.ToLower().Contains(String.Format("{0}", Request.Form["tbx_prenom"]).ToLower()))
                {
                    rechercheA.Add(i);
                }
            }
        }
        else
        {
            for(int i = 0; i < tousLesEmp.Count; i++)
            {
                rechercheA.Add(i);
            }
        }

        //Recherche sur les noms
        if (String.Format("{0}", Request.Form["tbx_nom"]) != "" && String.Format("{0}", Request.Form["tbx_nom"]) != null)
        {
            for (int i = 0; i < tousLesEmp.Count; i++)
            {
                if (tousLesEmp[i].nom.ToLower().Contains(String.Format("{0}", Request.Form["tbx_nom"]).ToLower()))
                {
                    rechercheB.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesEmp.Count; i++)
            {
                rechercheB.Add(i);
            }
        }

        //Recherche sur les fonctions
        if(ddl_fonction.SelectedValue != "-1")
        {
            for (int i = 0; i < tousLesEmp.Count; i++)
            {
                if (ddl_fonction.SelectedValue == tousLesEmp[i].idFonction.ToString())
                {
                    rechercheC.Add(i);
                }
            }
        }
        else
        {
            for(int i = 0; i < tousLesEmp.Count; i++)
            {
                rechercheC.Add(i);
            }
        }


        //Recherche sur les statuts
        if(ddl_Status.SelectedValue != "-1")
        {
            for(int i = 0; i < tousLesEmp.Count; i++)
            {
                if(ddl_Status.SelectedIndex == tousLesEmp[i].idStatus)
                {
                    rechercheD.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < tousLesEmp.Count; i++)
            {
                rechercheD.Add(i);
            }
        }



        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_id = new TableHeaderCell();
        thc_id.Text = "#";
        thc_id.Width = new Unit("25%");
        TableHeaderCell thc_prenom = new TableHeaderCell();
        thc_prenom.Text = "Prénom";
        thc_prenom.Width = new Unit("25%");
        TableHeaderCell thc_Nom = new TableHeaderCell();
        thc_Nom.Text = "Nom";
        thc_Nom.Width = new Unit("25%");
        TableHeaderCell thc_Statut = new TableHeaderCell();
        thc_Statut.Text = "Statut";
        thc_Statut.Width = new Unit("25%");
        thr.Cells.Add(thc_id);
        thr.Cells.Add(thc_prenom);
        thr.Cells.Add(thc_Nom);
        thr.Cells.Add(thc_Statut);
        Tableau_Employes.Rows.Add(thr);



        List<T_Employe> empToShow = new List<T_Employe>();
        
        for (int i = 0; i < tousLesEmp.Count; i++)
        {
            //Tous les projets seront à charger
            bool a = rechercheA.Contains(i);
            bool b = rechercheB.Contains(i);
            bool c = rechercheC.Contains(i);
            bool d = rechercheD.Contains(i);
            if (a && b && c && d)
            {
                empToShow.Add(tousLesEmp[i]); //On affiche les éléments présent dans les 4 listes
            }
        }
        empToShow = empToShow.OrderBy(o => o.prenom).ThenBy(o => o.nom).ToList();
        foreach (T_Employe employe in empToShow)
        {
            ShowEmp(employe);
        }
    }

    private void ShowEmp(T_Employe employe)
    {
        TableRow tr = new TableRow();
        TableCell tc_Id = new TableCell();
        tc_Id.Text = employe.idEmploye.ToString();
        TableCell tc_Prenom = new TableCell();
        HyperLink hl = new HyperLink();
        hl.Text = employe.prenom;
        hl.NavigateUrl = "AjouterEmploye.aspx?id=" + employe.idEmploye.ToString();
        tc_Prenom.Controls.Add(hl);
        //tc_Prenom.Text = employe.prenom;
        TableCell tc_Nom = new TableCell();
        tc_Nom.Text = employe.nom;
        TableCell tc_Statut = new TableCell();
        tc_Statut.Text = BD_CoEco.GetListeStatusEmploye()[employe.idStatus - 1].descript;
        tr.Cells.Add(tc_Id);
        tr.Cells.Add(tc_Prenom);
        tr.Cells.Add(tc_Nom);
        tr.Cells.Add(tc_Statut);
        Tableau_Employes.Rows.Add(tr);

    }

    protected void btn_cancel_ServerClick(object sender, EventArgs e)
    {
        //tbx_prenom.Text = "";
        //tbx_nom.Text = "";
        //ddl_fonction.SelectedIndex = 0;
        //ddl_statut.SelectedIndex = 0;
        Recherche();
    }
}