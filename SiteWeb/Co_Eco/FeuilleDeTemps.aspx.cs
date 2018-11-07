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
    List<T_Projet> ListeProjet;
    List<T_CategoriePro> ListeCategorie;
    DateTime date;
    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuilleDeTemps = BD.T_FeuilleDeTemps;

        ListeProjet = BD_CoEco.GetListeProjet();
        ListeCategorie = BD_CoEco.GetListeCategorie();

        listeFeuilleDeTemps = tableFeuilleDeTemps.ToList();

        BD.Dispose();
        //----------HEADER du tableau-----------
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
    }
    Label ajoutLabel()
    {
        Label lh = new Label();
        lh.Text = "H";
        return lh;
    }

    //-------------Calendrier--------
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        date = getFirstDayOfWeek(Calendar1.SelectedDate);
        

        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 1:
                    thr.Cells[i].Text = "Dimanche " + (date.Day);
                    break;
                case 2:
                    thr.Cells[i].Text = "Lundi " + (date.AddDays(1).Day);
                    break;
                case 3:
                    thr.Cells[i].Text = "Mardi " + (date.AddDays(2).Day);
                    break;
                case 4:
                    thr.Cells[i].Text = "Mercredi " + (date.AddDays(3).Day);
                    break;
                case 5:
                    thr.Cells[i].Text = "Jeudi " + (date.AddDays(4).Day);
                    break;
                case 6:
                    thr.Cells[i].Text = "Vendredi " + (date.AddDays(5).Day);
                    break;
                case 7:
                    thr.Cells[i].Text = "Samedi " + (date.AddDays(6).Day);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
        ajouterEnregistrement(date);
    }
    //-----Donne la premiere journée de la semaine (Dimanche)
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
    //---------On regarde si l'enregistrement fait partit de la semaine sélectionnée
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
    //--------regroupe les enregistrements des feuille de temps en catégories-------------
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

    //------------Ajouter les colones des feuilles de temps---------
    void ajouterRows(List<T_FeuilleDeTemps> p_listeFeuille)
    {

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        DropDownList ddl_Projet = new DropDownList();
        //ddl_Projet.ID = "ddl_Projet";
        ddl_Projet.CssClass = "ddl_projet";
        //ddl_Projet.DataSource = ListeProjet;

        //ddl_Projet.DataBind();

        DropDownList ddl_Categorie = new DropDownList();
        //ddl_Categorie.ID = "ddl_Categorie";
        ddl_Categorie.CssClass = "ddl_categorie";
        //ddl_Categorie.DataSource = ListeCategorie;
        //ddl_Categorie.DataBind();
        foreach (T_CategoriePro categorie in ListeCategorie)
        {
            
            if (categorie.idCategorie == p_listeFeuille[0].idCategorie)
            {
                
                foreach (T_Projet projet in ListeProjet)
                {
                    ddl_Projet.Items.Add(projet.nom);
                    if (projet.idProjet == categorie.idProjet)
                    {
                        ddl_Categorie.Items.Add(categorie.descript);
                        ddl_Projet.SelectedItem.Text = projet.nom;
                    }
                }
                ddl_Categorie.SelectedItem.Text = categorie.descript;
                ddl_Projet.Enabled = false;
                break;
            }
        }
        

        tc1.Controls.Add(ddl_Projet);
        tc1.Controls.Add(ddl_Categorie);

        TableCell tc2 = new TableCell();
        TextBox tbDim = new TextBox();
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

        
        //----------Mettre les enregistrements des feuilles de temps dans la bonne journée de la semaine
        foreach (T_FeuilleDeTemps feuilleTemps in p_listeFeuille)
        {

            DateTime dt = feuilleTemps.ddate.Value;
            int caseSwitch = dt.Day - date.Day;

            switch (caseSwitch)
            {
                case 0:
                    tbDim.Text = feuilleTemps.temps.ToString();
                    break;
                case 1:
                    tbLun.Text = feuilleTemps.temps.ToString();
                    break;
                case 2:
                    tbMar.Text = feuilleTemps.temps.ToString();
                    break;
                case 3:
                    tbMer.Text = feuilleTemps.temps.ToString();
                    break;
                case 4:
                    tbJeu.Text = feuilleTemps.temps.ToString();
                    break;
                case 5:
                    tbVen.Text = feuilleTemps.temps.ToString();
                    break;
                case 6:
                    tbSam.Text = feuilleTemps.temps.ToString();
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
        }

    }

    //------------------BOUTON----------------------
    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        btn_ajouter.Enabled = false;

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        DropDownList ddl_Projet = new DropDownList();

        ddl_Projet.CssClass = "ddl_projet";

        DropDownList ddl_Categorie = new DropDownList();

        ddl_Categorie.CssClass = "ddl_categorie";

        foreach (T_Projet projet in ListeProjet)
        {
            ddl_Projet.Items.Add(projet.nom);
        }


        tc1.Controls.Add(ddl_Projet);
        tc1.Controls.Add(ddl_Categorie);

        TableCell tc2 = new TableCell();
        TextBox tbDim = new TextBox();
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

        btn_confirmer.Enabled = true;
    }

    protected void btn_confirmer_Click(object sender, EventArgs e)
    {
        btn_confirmer.Enabled = false;



        btn_ajouter.Enabled = true;
    }
}