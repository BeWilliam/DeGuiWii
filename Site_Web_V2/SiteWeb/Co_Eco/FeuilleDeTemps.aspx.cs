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
    int idCat;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
        }
        else
        {
            CoEco_BDDataContext BD = new CoEco_BDDataContext();


            ListeProjet = BD_CoEco.GetListeProjet();
            ListeCategorie = BD_CoEco.GetListeCategorie();

            listeFeuilleDeTemps = BD_CoEco.GetListeFeuilleDeTemps();

            BD.Dispose();
        }

        tr_ajout.Visible = false;
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        if (btn_ajouter.Visible == true)
        {
            date = getFirstDayOfWeek(Calendar1.SelectedDate);
            Dimanche.Text = "Dimanche " + (date.Day);
            Lundi.Text = "Lundi " + (date.AddDays(1).Day);
            Mardi.Text = "Mardi " + (date.AddDays(2).Day);
            Mercredi.Text = "Mercredi " + (date.AddDays(3).Day);
            Jeudi.Text = "Jeudi " + (date.AddDays(4).Day);
            Vendredi.Text = "Vendredi " + (date.AddDays(5).Day);
            Samedi.Text = "Samedi " + (date.AddDays(6).Day);

            ajouterEnregistrement(date);
        }
        else
        {
            tr_ajout.Visible = true;
            btn_confirmer.Visible = true;
            btn_annuler.Visible = true;
            btn_ajouter.Visible = false;
        }
        
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
        /*enregistrements = new List<T_FeuilleDeTemps>();*/
        if (listeFeuilleDeTemps != null)
        {
            foreach (T_FeuilleDeTemps feuilleDeTemps in listeFeuilleDeTemps)
            {
               
                if (getFirstDayOfWeek((DateTime)feuilleDeTemps.semaine) == dt)
                {
                    ajouterRows(feuilleDeTemps);
                }
            }
            //ajouterCategories();
        }
        
    }
    //--------regroupe les enregistrements des feuille de temps en catégories-------------
    //void ajouterCategories()
    //{
    //    List<int> projets = new List<int>();
    //    foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
    //    {
    //        projets.Add(FeuilleTemps.idCategorie);
    //    }
    //    projets = projets.Distinct().ToList<int>();
    //    List<T_FeuilleDeTemps> temp;
    //    for (int i = 0; i < projets.Count; i++)
    //    {
    //        temp = new List<T_FeuilleDeTemps>();
    //        foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
    //        {
    //            if (projets[i] == FeuilleTemps.idCategorie)
    //            {
    //                temp.Add(FeuilleTemps);
    //            }
    //        }
    //        //ajouterRows(temp);
    //    }
    //}

    void ajouterRows(T_FeuilleDeTemps p_fdt)
    {

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        DropDownList ddl_Projet = new DropDownList();
        ddl_Projet.CssClass = "ddl_projet";

        DropDownList ddl_Categorie = new DropDownList();
        ddl_Categorie.CssClass = "ddl_categorie";

        foreach (T_CategoriePro categorie in ListeCategorie)
        {

            if (categorie.idCategorie == p_fdt.idCategorie)
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
        if (p_fdt.dimanche != null)
        {
            tbDim.Text = p_fdt.dimanche.ToString();
        }
        tbDim.CssClass = "tbx_h";
        tc2.Controls.Add(tbDim);
        tc2.Controls.Add(ajoutLabel());
        TableCell tc3 = new TableCell();
        TextBox tbLun = new TextBox();
        if (p_fdt.lundi != null)
        {
            tbLun.Text = p_fdt.lundi.ToString();
        }
        //tbLun.ID = "tbLun";
        tbLun.CssClass = "tbx_h";
        tc3.Controls.Add(tbLun);
        tc3.Controls.Add(ajoutLabel());
        TableCell tc4 = new TableCell();
        TextBox tbMar = new TextBox();
        if (p_fdt.mardi != null)
        {
            tbMar.Text = p_fdt.mardi.ToString();
        }
        //tbMar.ID = "tbMar";
        tbMar.CssClass = "tbx_h";
        tc4.Controls.Add(tbMar);
        tc4.Controls.Add(ajoutLabel());
        TableCell tc5 = new TableCell();
        TextBox tbMer = new TextBox();
        if (p_fdt.mercredi != null)
        {
            tbMer.Text = p_fdt.mercredi.ToString();
        }
        //tbMer.ID = "tbMer";
        tbMer.CssClass = "tbx_h";
        tc5.Controls.Add(tbMer);
        tc5.Controls.Add(ajoutLabel());
        TableCell tc6 = new TableCell();
        TextBox tbJeu = new TextBox();
        if (p_fdt.jeudi != null)
        {
            tbJeu.Text = p_fdt.jeudi.ToString();
        }
        //tbJeu.ID = "tbJeu";
        tbJeu.CssClass = "tbx_h";
        tc6.Controls.Add(tbJeu);
        tc6.Controls.Add(ajoutLabel());
        TableCell tc7 = new TableCell();
        TextBox tbVen = new TextBox();
        if (p_fdt.vendredi != null)
        {
            tbVen.Text = p_fdt.vendredi.ToString();
        }
        //tbVen.ID = "tbVen";
        tbVen.CssClass = "tbx_h";
        tc7.Controls.Add(tbVen);
        tc7.Controls.Add(ajoutLabel());
        TableCell tc8 = new TableCell();
        TextBox tbSam = new TextBox();
        if (p_fdt.samedi != null)
        {
            tbSam.Text = p_fdt.samedi.ToString();
        }
        //tbSam.ID = "tbSam";
        tbSam.CssClass = "tbx_h";
        tc8.Controls.Add(tbSam);
        tc8.Controls.Add(ajoutLabel());
        TableCell tc9 = new TableCell();
        TextBox tbCommmentaire = new TextBox();
        if (p_fdt.note != null)
        {
            tbCommmentaire.Text = p_fdt.note.ToString();
        }
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
    }
    Label ajoutLabel()
    {
        Label lh = new Label();
        lh.Text = "H";
        return lh;
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        tr_ajout.Visible = true;
        btn_confirmer.Visible = true;
        btn_annuler.Visible = true;
        btn_ajouter.Visible = false;
    }

    protected void btn_confirmer_Click(object sender, EventArgs e)
    {
        tr_ajout.Visible = false;
        btn_confirmer.Visible = false;
        btn_annuler.Visible = false;
        btn_ajouter.Visible = true;

        if (getFirstDayOfWeek(Calendar1.SelectedDate) != null)
        {
            //if (Session["idEmp"].ToString() != null)
            //{ 

                //ajouter une feuille de temps
                //connexion à la BD
                CoEco_BDDataContext BD = new CoEco_BDDataContext();

            listeFeuilleDeTemps = BD_CoEco.GetListeFeuilleDeTemps();

            T_FeuilleDeTemps newFdt = new T_FeuilleDeTemps();
            //----------A MODIFIER---------
            //string nomCat = ddl_Categorie.SelectedItem.Text;

            //foreach (T_CategoriePro cat in ListeCategorie)
            //{
            //    if (cat.descript == nomCat)
            //    {
            //        idCat = cat.idCategorie;
            //    }
            //}
            //newFdt.idCategorie = idCat;

            newFdt.idCategorie = 3;
            
            newFdt.idEmp = int.Parse(Session["idEmp"].ToString());
            

            if (tb_dimanche.Text != "")
            {
                newFdt.dimanche = float.Parse(tb_dimanche.Text);
            }
            if (tb_lundi.Text != "")
            {
                newFdt.lundi = float.Parse(tb_lundi.Text);
            }
            if (tb_mardi.Text != "")
            {
                newFdt.mardi = float.Parse(tb_mardi.Text);
            }
            if (tb_mercredi.Text != "")
            {
                newFdt.mercredi = float.Parse(tb_mercredi.Text);
            }
            if (tb_jeudi.Text != "")
            {
                newFdt.jeudi = float.Parse(tb_jeudi.Text);
            }
            if (tb_vendredi.Text != "")
            {
                newFdt.vendredi = float.Parse(tb_vendredi.Text);
            }
            if (tb_samedi.Text != "")
            {
                newFdt.samedi = float.Parse(tb_samedi.Text);
            }

            if (tb_commentaire.Text != "")
            {
                newFdt.note = tb_commentaire.Text;
            }


            date = getFirstDayOfWeek(Calendar1.SelectedDate);

            newFdt.semaine = date;

            BD_CoEco.CreateNewFeuilleDeTemps(newFdt);
            listeFeuilleDeTemps = BD_CoEco.GetListeFeuilleDeTemps();
            BD.Dispose();


            ajouterEnregistrement(date);
        //}
        //else
        //{
        //        lb_erreur.Text += "idemp est null";
        //}
        }
        else
        {
            lb_erreur.Text += "Aucune date sélectionnée";
        }
    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        tr_ajout.Visible = false;
        btn_confirmer.Visible = false;
        btn_annuler.Visible = false;
        btn_ajouter.Visible = true;
    }
}