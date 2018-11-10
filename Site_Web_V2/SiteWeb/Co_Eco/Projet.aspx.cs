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

            //tableau.AddCell();
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

    
}