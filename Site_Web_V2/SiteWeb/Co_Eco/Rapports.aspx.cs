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

public partial class Rapports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        tbx_DateFin.Text = DateTime.Now.Date.ToShortDateString();

        if (!this.IsPostBack)
        {
            loadProjects();
            loadCheckBoxList();
            loadCat();
        }
    }

    private void loadProjects()
    {
        /*-- Partie pour les projets --*/
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet(true);
        listProjet = listProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listProjet)
        {
            ddl_Projets.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
        ddl_Categorie.Items.Add(new ListItem("Toutes les catégories", "-1"));


    }
    private void loadCheckBoxList()
    {
        T_Projet proActu = BD_CoEco.GetProByID(int.Parse(ddl_Projets.SelectedValue));
        cbl_Employe.Items.Clear();
        List<T_Employe> listEmp = BD_CoEco.GetEmpByProject(proActu);
        listEmp = listEmp.OrderBy(o => o.prenom).ThenBy(o => o.nom).ToList();
        foreach (T_Employe employe in listEmp)
        {
            cbl_Employe.Items.Add(new ListItem(employe.prenom + " " + employe.nom, employe.idEmploye.ToString()));
        }
    }


    private void loadCat()
    {
        /*-- Partie pour les Catégories --*/
        ddl_Categorie.Items.Clear();
        ddl_Categorie.Items.Add(new ListItem("Toutes les catégories", "-1"));
        List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_Projets.SelectedValue)));
        listCat = listCat.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listCat)
        {
            ddl_Categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
        }
    }

    protected void ddl_Projets_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCat();
        loadCheckBoxList();
    }


    protected void btn_PDF_Click(object sender, EventArgs e)
    {
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


        float[] test = { 1, 1, 100000 };
        PdfPTable tableau = new PdfPTable(test);

        tableau.SetWidths(new float[] { 0.1f, 0.8f, 0.2f });


        //Formatage du tableau

        //for (int i = 0; i < Tableau_Projets.Rows.Count; i++) //Lignes
        //{
            
        //}



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



    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}