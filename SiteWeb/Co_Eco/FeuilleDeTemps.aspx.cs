using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class FeuilleDeTemps : System.Web.UI.Page
{
    TableHeaderRow thr;
    List<T_FeuilleDeTemps> listeFeuilleDeTemps;
    List<T_FeuilleDeTemps> enregistrements;
    DateTime date;
    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuilleDeTemps = BD.T_FeuilleDeTemps;
        
        listeFeuilleDeTemps = tableFeuilleDeTemps.ToList();

        BD.Dispose();

        thr = new TableHeaderRow();
        TableHeaderCell thc_Projet = new TableHeaderCell();
        thc_Projet.Width = Unit.Percentage(11);
        thc_Projet.Text = "Projet";
        TableHeaderCell thc_Dimanche = new TableHeaderCell();
        thc_Dimanche.Width = Unit.Percentage(11);
        thc_Dimanche.Text = "Dimanche ";
        TableHeaderCell thc_Lundi = new TableHeaderCell();
        thc_Lundi.Width = Unit.Percentage(11);
        thc_Lundi.Text = "Lundi ";
        TableHeaderCell thc_Mardi = new TableHeaderCell();
        thc_Mardi.Width = Unit.Percentage(11);
        thc_Mardi.Text = "Mardi ";
        TableHeaderCell thc_Mercredi = new TableHeaderCell();
        thc_Mercredi.Width = Unit.Percentage(11);
        thc_Mercredi.Text = "Mercredi ";
        TableHeaderCell thc_Jeudi = new TableHeaderCell();
        thc_Jeudi.Width = Unit.Percentage(11);
        thc_Jeudi.Text = "Jeudi ";
        TableHeaderCell thc_Vendredi = new TableHeaderCell();
        thc_Vendredi.Width = Unit.Percentage(11);
        thc_Vendredi.Text = "Vendredi ";
        TableHeaderCell thc_Samedi = new TableHeaderCell();
        thc_Samedi.Width = Unit.Percentage(11);
        thc_Samedi.Text = "Samedi ";
        TableHeaderCell thc_Commentaires = new TableHeaderCell();
        thc_Commentaires.Width = Unit.Percentage(11);
        thc_Commentaires.Text = "Commentaires";

        thr.Cells.Add(thc_Projet);
        thr.Cells.Add(thc_Dimanche);
        thr.Cells.Add(thc_Lundi);
        thr.Cells.Add(thc_Mardi);
        thr.Cells.Add(thc_Mercredi);
        thr.Cells.Add(thc_Jeudi);
        thr.Cells.Add(thc_Vendredi);
        thr.Cells.Add(thc_Samedi);
        thr.Cells.Add(thc_Commentaires);
        t_feuilleTemps.Rows.Add(thr);

        //int i = 0;
        //foreach (T_FeuilleDeTemps p_feuilleDeTemps in listeFeuilleDeTemps)
        //{
            //TableRow tr = new TableRow();
            //TableCell tc1 = new TableCell();
            //DropDownList ddl_Projet = new DropDownList();
            ////ddl_Projet.ID = "ddl_Projet";
            //ddl_Projet.CssClass = "ddl_projet";
            ////ddl_Projet.DataSource = ecritureEntete;
            //ddl_Projet.DataBind();

            //DropDownList ddl_Categorie = new DropDownList();
            ////ddl_Categorie.ID = "ddl_Categorie";
            //ddl_Categorie.CssClass = "ddl_categorie";
            ////ddl_Projet.DataSource = ecritureEntete;
            //ddl_Categorie.DataBind();

            //tc1.Controls.Add(ddl_Projet);
            //tc1.Controls.Add(ddl_Categorie);

            //TableCell tc2 = new TableCell();
            //TextBox tbDim = new TextBox();
            ////tbDim.ID = "tbDim";
            //tbDim.CssClass = "tbx_h";
            //tc2.Controls.Add(tbDim);
            //tc2.Controls.Add(ajoutLabel());
            //TableCell tc3 = new TableCell();
            //TextBox tbLun = new TextBox();
            ////tbLun.ID = "tbLun";
            //tbLun.CssClass = "tbx_h";
            //tc3.Controls.Add(tbLun);
            //tc3.Controls.Add(ajoutLabel());
            //TableCell tc4 = new TableCell();
            //TextBox tbMar = new TextBox();
            ////tbMar.ID = "tbMar";
            //tbMar.CssClass = "tbx_h";
            //tc4.Controls.Add(tbMar);
            //tc4.Controls.Add(ajoutLabel());
            //TableCell tc5 = new TableCell();
            //TextBox tbMer = new TextBox();
            ////tbMer.ID = "tbMer";
            //tbMer.CssClass = "tbx_h";
            //tc5.Controls.Add(tbMer);
            //tc5.Controls.Add(ajoutLabel());
            //TableCell tc6 = new TableCell();
            //TextBox tbJeu = new TextBox();
            ////tbJeu.ID = "tbJeu";
            //tbJeu.CssClass = "tbx_h";
            //tc6.Controls.Add(tbJeu);
            //tc6.Controls.Add(ajoutLabel());
            //TableCell tc7 = new TableCell();
            //TextBox tbVen = new TextBox();
            ////tbVen.ID = "tbVen";
            //tbVen.CssClass = "tbx_h";
            //tc7.Controls.Add(tbVen);
            //tc7.Controls.Add(ajoutLabel());
            //TableCell tc8 = new TableCell();
            //TextBox tbSam = new TextBox();
            ////tbSam.ID = "tbSam";
            //tbSam.CssClass = "tbx_h";
            //tc8.Controls.Add(tbSam);
            //tc8.Controls.Add(ajoutLabel());
            //TableCell tc9 = new TableCell();
            //TextBox tbCommmentaire = new TextBox();
            ////tbCommmentaire.ID = "tbCommmentaire";
            //tbCommmentaire.TextMode = TextBoxMode.MultiLine;
            //tc9.Controls.Add(tbCommmentaire);
           

            //tr.Cells.Add(tc1);
            //tr.Cells.Add(tc2);
            //tr.Cells.Add(tc3);
            //    tr.Cells.Add(tc4);
            //    tr.Cells.Add(tc5);
            //    tr.Cells.Add(tc6);
            //    tr.Cells.Add(tc7);
            //    tr.Cells.Add(tc8);
            //    tr.Cells.Add(tc9);
            //t_feuilleTemps.Rows.Add(tr);
        //    i++;
        //}
        //BD.Dispose();
        //i = 0;
    }
    Label ajoutLabel()
    {
        Label lh = new Label();
        lh.Text = "H";
        return lh;
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

        date = getFirstDayOfWeek(Calendar1.SelectedDate);
        int semaine = date.Day;

        for (int i = 0; i < 8; i++)
        {
            if (i!=0)
            {
                thr.Cells[i].Text += semaine + i - 1;
            }
            
        }
        ajouterEnregistrement(date);
    }

    public DateTime getFirstDayOfWeek(DateTime dateToCheck)
    {
        DateTime dt = new DateTime();
        for (int i = 0; i < 7; i++)
        {
            if (dateToCheck.AddDays(-i).DayOfWeek == 0)
            {
                dt = dateToCheck.AddDays(-i);
            }
        }
        return dt;
    }

    void ajouterEnregistrement(DateTime dt)
    {
        //List<string> projets = new List<string>();
        enregistrements = new List<T_FeuilleDeTemps>();
        foreach (T_FeuilleDeTemps feuilleDeTemps in listeFeuilleDeTemps)
        {
            if (feuilleDeTemps.ddate >= dt && feuilleDeTemps.ddate <= dt.AddDays(7))
            {
                enregistrements.Add(feuilleDeTemps);
            }
        }
        ajouterCategories();
    }

    void ajouterCategories()
    {
        List<int> projets = new List<int>();
        foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
        {
            projets.Add(FeuilleTemps.idCategorie);
        }
        projets = projets.Distinct().ToList<int>();
        List<T_FeuilleDeTemps> temp;
        for (int i = 0; i < projets.Count; i++)
        {
            temp = new List<T_FeuilleDeTemps>();
            foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
            {
                if (projets[i] == FeuilleTemps.idCategorie)
                {
                    temp.Add(FeuilleTemps);
                }
            }
            ajouterRows(temp);
        }
    }
    void ajouterRows(List<T_FeuilleDeTemps> p_listeFeuille)
    {

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        DropDownList ddl_Projet = new DropDownList();
        //ddl_Projet.ID = "ddl_Projet";
        ddl_Projet.CssClass = "ddl_projet";
        //ddl_Projet.DataSource = ecritureEntete;
        ddl_Projet.DataBind();

        DropDownList ddl_Categorie = new DropDownList();
        //ddl_Categorie.ID = "ddl_Categorie";
        ddl_Categorie.CssClass = "ddl_categorie";
        //ddl_Projet.DataSource = ecritureEntete;
        //ddl_Categorie.DataBind();

        tc1.Controls.Add(ddl_Projet);
        tc1.Controls.Add(ddl_Categorie);

        TableCell tc2 = new TableCell();
        TextBox tbDim = new TextBox();
        //------------******************---------
        tbDim.Text = p_listeFeuille[0].temps.ToString();
        //tbDim.ID = "tbDim";
        tbDim.CssClass = "tbx_h";
        tc2.Controls.Add(tbDim);
        tc2.Controls.Add(ajoutLabel());
        TableCell tc3 = new TableCell();
        TextBox tbLun = new TextBox();
        //tbLun.ID = "tbLun";
        tbLun.CssClass = "tbx_h";
        tc3.Controls.Add(tbLun);
        tc3.Controls.Add(ajoutLabel());
        TableCell tc4 = new TableCell();
        TextBox tbMar = new TextBox();
        //tbMar.ID = "tbMar";
        tbMar.CssClass = "tbx_h";
        tc4.Controls.Add(tbMar);
        tc4.Controls.Add(ajoutLabel());
        TableCell tc5 = new TableCell();
        TextBox tbMer = new TextBox();
        //tbMer.ID = "tbMer";
        tbMer.CssClass = "tbx_h";
        tc5.Controls.Add(tbMer);
        tc5.Controls.Add(ajoutLabel());
        TableCell tc6 = new TableCell();
        TextBox tbJeu = new TextBox();
        //tbJeu.ID = "tbJeu";
        tbJeu.CssClass = "tbx_h";
        tc6.Controls.Add(tbJeu);
        tc6.Controls.Add(ajoutLabel());
        TableCell tc7 = new TableCell();
        TextBox tbVen = new TextBox();
        //tbVen.ID = "tbVen";
        tbVen.CssClass = "tbx_h";
        tc7.Controls.Add(tbVen);
        tc7.Controls.Add(ajoutLabel());
        TableCell tc8 = new TableCell();
        TextBox tbSam = new TextBox();
        //tbSam.ID = "tbSam";
        tbSam.CssClass = "tbx_h";
        tc8.Controls.Add(tbSam);
        tc8.Controls.Add(ajoutLabel());
        TableCell tc9 = new TableCell();
        TextBox tbCommmentaire = new TextBox();
        //tbCommmentaire.ID = "tbCommmentaire";
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

        foreach (T_FeuilleDeTemps feuilleTemps in p_listeFeuille)
        {
            
        }

    }

}