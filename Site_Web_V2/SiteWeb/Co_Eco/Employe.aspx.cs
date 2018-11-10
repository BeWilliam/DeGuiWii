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
using ListItem = System.Web.UI.WebControls.ListItem; //Anti problème

public partial class Employe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;
        List<T_Employe> rawListeEmp = tableEmp.ToList();
        //trié la liste avant insertion
        List<T_Employe> listeEmp = rawListeEmp.OrderBy(o => o.idStatus).ThenBy(o => o.prenom).ThenBy(o => o.nom).ToList();

        foreach (T_Employe emp in listeEmp)
        {      

            if (emp.prenom != "Admin")
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();

                HyperLink hl = new HyperLink();
                hl.NavigateUrl = "AjouterEmploye.aspx";

                tc1.Text = emp.idEmploye.ToString();
                tc2.Text = emp.prenom;
                tc3.Text = emp.nom;
                tc4.Text = emp.idStatus.ToString();

                if (tc4.Text == "1")
                {
                    tc4.Text = "Actif";
                }
                else
                {
                    tc4.Text = "Inactif";
                }

                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);

                //Actif
                Tableau_Employes.Rows.Add(tr);
                
            }

            //hl.Text = emp.ToString();
            //hl.CssClass = "hl_employe";
            //tc3.Controls.Add(hl);



        }

        BD.Dispose();
    }


    protected void bt_AjouterEmploye_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterEmploye.aspx");
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("Menu.aspx");
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
}