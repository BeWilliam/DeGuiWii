using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depense : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> ecritureEntete = new List<string>();
        ecritureEntete.Add("Description");
        ecritureEntete.Add("Montant");
        ecritureEntete.Add("Date");

        TableRow entete = new TableRow();
        for (int i = 0; i < ecritureEntete.Count; i++)
        {
            TableCell colone = new TableCell();
            colone.Controls.Add(new LiteralControl(ecritureEntete[i]));
            entete.Cells.Add(colone);
        }
        TableDepenses.Rows.Add(entete);

        // Generate rows and cells.           
        int numrows = 3;
        int numcells = 3;
        for (int j = 0; j < numrows; j++)
        {
            TableRow ligne = new TableRow();
            for (int i = 0; i < numcells; i++)
            {
                TableCell colone = new TableCell();
                if (i == 0)
                {
                    // Créer une liste déroulante dans chaque cellule projet
                    //------PROJET---------
                    DropDownList ddl_Projet = new DropDownList();
                    ddl_Projet.ID = "ddlProjet";
                    ddl_Projet.DataSource = ecritureEntete;
                    ddl_Projet.DataBind();

                    colone.Controls.Add(ddl_Projet);
                    //------Catégorie---------
                    DropDownList ddl_Categorie = new DropDownList();
                    ddl_Categorie.ID = "ddlCategorie";
                    ddl_Categorie.DataSource = ecritureEntete;
                    ddl_Categorie.DataBind();
                    colone.Controls.Add(ddl_Categorie);
                    ddl_Categorie.Visible = false;
                    //---------Événement changer item sélectionner DDL----------
                    //ddl_Projet.TextChanged += new System.EventHandler();
                }
                //else if (i == numcells - 1)
                //{
                //    TextBox tbCommentaire = new TextBox();
                //    tbCommentaire.ID = "tbCommentaire";
                //    tbCommentaire.TextMode = TextBoxMode.MultiLine;
                //    colone.Controls.Add(tbCommentaire);
                //}
                else
                {
                    TextBox tbHeure = new TextBox();
                    tbHeure.ID = "tbHeures";

                    colone.Controls.Add(tbHeure);
                }

                ligne.Cells.Add(colone);
            }
            TableDepenses.Rows.Add(ligne);
        }
    }
}