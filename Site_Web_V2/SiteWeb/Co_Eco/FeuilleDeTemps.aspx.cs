using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class FeuilleDeTemps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuilleDeTemps = BD.T_FeuilleDeTemps;
        
        List<T_FeuilleDeTemps> listeFeuilleDeTemps = tableFeuilleDeTemps.ToList();

        
        

        int i = 0;
        foreach (T_FeuilleDeTemps p_feuilleDeTemps in listeFeuilleDeTemps)
        {
            if (p_feuilleDeTemps.idEmp == 67)
            {

            }
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();
            DropDownList ddl_Projet = new DropDownList();
            ddl_Projet.ID = "ddl_Projet";
            ddl_Projet.CssClass = "ddl_projet";
            //ddl_Projet.DataSource = ecritureEntete;
            ddl_Projet.DataBind();

            DropDownList ddl_Categorie = new DropDownList();
            ddl_Categorie.ID = "ddl_Categorie";
            ddl_Categorie.CssClass = "ddl_categorie";
            //ddl_Projet.DataSource = ecritureEntete;
            ddl_Categorie.DataBind();

            tc1.Controls.Add(ddl_Projet);
            tc1.Controls.Add(ddl_Categorie);

            TableCell tc2 = new TableCell();
            TextBox tbDim = new TextBox();
            tbDim.ID = "tbDim";
            tbDim.CssClass = "tbx_h";
            tc2.Controls.Add(tbDim);
            tc2.Controls.Add(ajoutLabel());
            TableCell tc3 = new TableCell();
            TextBox tbLun = new TextBox();
            tbLun.ID = "tbLun";
            tbLun.CssClass = "tbx_h";
            tc3.Controls.Add(tbLun);
            tc3.Controls.Add(ajoutLabel());
            TableCell tc4 = new TableCell();
            TextBox tbMar = new TextBox();
            tbMar.ID = "tbMar";
            tbMar.CssClass = "tbx_h";
            tc4.Controls.Add(tbMar);
            tc4.Controls.Add(ajoutLabel());
            TableCell tc5 = new TableCell();
            TextBox tbMer = new TextBox();
            tbMer.ID = "tbMer";
            tbMer.CssClass = "tbx_h";
            tc5.Controls.Add(tbMer);
            tc5.Controls.Add(ajoutLabel());
            TableCell tc6 = new TableCell();
            TextBox tbJeu = new TextBox();
            tbJeu.ID = "tbJeu";
            tbJeu.CssClass = "tbx_h";
            tc6.Controls.Add(tbJeu);
            tc6.Controls.Add(ajoutLabel());
            TableCell tc7 = new TableCell();
            TextBox tbVen = new TextBox();
            tbVen.ID = "tbVen";
            tbVen.CssClass = "tbx_h";
            tc7.Controls.Add(tbVen);
            tc7.Controls.Add(ajoutLabel());
            TableCell tc8 = new TableCell();
            TextBox tbSam = new TextBox();
            tbSam.ID = "tbSam";
            tbSam.CssClass = "tbx_h";
            tc8.Controls.Add(tbSam);
            tc8.Controls.Add(ajoutLabel());
            TableCell tc9 = new TableCell();
            TextBox tbCommmentaire = new TextBox();
            tbCommmentaire.ID = "tbCommmentaire";
            tbCommmentaire.TextMode = TextBoxMode.MultiLine;
            tc9.Controls.Add(tbCommmentaire);
           

            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);
                tr.Cells.Add(tc5);
                tr.Cells.Add(tc6);
                tr.Cells.Add(tc7);
                tr.Cells.Add(tc8);
                tr.Cells.Add(tc9);
            t_feuilleTemps.Rows.Add(tr);
            i++;
        }
        BD.Dispose();
        i = 0;
    }
    Label ajoutLabel()
    {
        Label lh = new Label();
        lh.Text = "H";
        return lh;
    }
    
}