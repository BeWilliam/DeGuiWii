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
    string urlParamId;
    //string urlParamDate;

    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();


        ListeProjet = BD_CoEco.GetListeProjet();
        ListeCategorie = BD_CoEco.GetListeCategorie();

        listeFeuilleDeTemps = BD_CoEco.GetListeFeuilleDeTemps();

        BD.Dispose();

        if (!IsPostBack)
        {
            lb_erreur.Text += "PAS un postback";

            //urlParamDate = Request.QueryString["date"];

            //if (urlParamDate != null)
            //{
            //    ajouterEnregistrement(DateTime.Parse(urlParamDate));
            //}
        }
        else
        {

            lb_erreur.Text += "EST un postback";

            

            urlParamId = Request.QueryString["id"];

            if (urlParamId != null)
            {
                modifier(int.Parse(urlParamId));
            }

            

        }

        //tr_ajout.Visible = false;
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
        //else
        //{
        //    tr_ajout.Visible = true;
        //    btn_confirmer.Visible = true;
        //    btn_confirmerModif.Visible = false;
        //    btn_annuler.Visible = true;
        //    btn_ajouter.Visible = false;
        //}
        
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
    void ajouterEnregistrement(DateTime p_dt)
    {
        //List<string> projets = new List<string>();
        /*enregistrements = new List<T_FeuilleDeTemps>();*/
        if (listeFeuilleDeTemps != null)
        {
            foreach (T_FeuilleDeTemps feuilleDeTemps in listeFeuilleDeTemps)
            {
               
                if (getFirstDayOfWeek((DateTime)feuilleDeTemps.semaine) == p_dt)
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
        ddl_Projet.CssClass = "col-sm-8";

        DropDownList ddl_Categorie = new DropDownList();
        ddl_Categorie.CssClass ="col-sm-8";

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
        tc2.BackColor = System.Drawing.Color.LightGray;
        TextBox tbDim = new TextBox();
        //tbDim.ID = "tbDim";
        if (p_fdt.dimanche != null)
        {
            tbDim.Text = p_fdt.dimanche.ToString();
        }
        tbDim.CssClass = "col-sm-7";
        tc2.Controls.Add(tbDim);
        tc2.Controls.Add(ajoutLabel());
        TableCell tc3 = new TableCell();
        TextBox tbLun = new TextBox();
        if (p_fdt.lundi != null)
        {
            tbLun.Text = p_fdt.lundi.ToString();
        }
        //tbLun.ID = "tbLun";
        tbLun.CssClass = "col-sm-7"; ;
        tc3.Controls.Add(tbLun);
        tc3.Controls.Add(ajoutLabel());
        TableCell tc4 = new TableCell();
        TextBox tbMar = new TextBox();
        if (p_fdt.mardi != null)
        {
            tbMar.Text = p_fdt.mardi.ToString();
        }
        //tbMar.ID = "tbMar";
        tbMar.CssClass = "col-sm-7"; ;
        tc4.Controls.Add(tbMar);
        tc4.Controls.Add(ajoutLabel());
        TableCell tc5 = new TableCell();
        TextBox tbMer = new TextBox();
        if (p_fdt.mercredi != null)
        {
            tbMer.Text = p_fdt.mercredi.ToString();
        }
        //tbMer.ID = "tbMer";
        tbMer.CssClass = "col-sm-7"; ;
        tc5.Controls.Add(tbMer);
        tc5.Controls.Add(ajoutLabel());
        TableCell tc6 = new TableCell();
        TextBox tbJeu = new TextBox();
        if (p_fdt.jeudi != null)
        {
            tbJeu.Text = p_fdt.jeudi.ToString();
        }
        //tbJeu.ID = "tbJeu";
        tbJeu.CssClass = "col-sm-7"; ;
        tc6.Controls.Add(tbJeu);
        tc6.Controls.Add(ajoutLabel());
        TableCell tc7 = new TableCell();
        TextBox tbVen = new TextBox();
        if (p_fdt.vendredi != null)
        {
            tbVen.Text = p_fdt.vendredi.ToString();
        }
        //tbVen.ID = "tbVen";
        tbVen.CssClass = "col-sm-7"; ;
        tc7.Controls.Add(tbVen);
        tc7.Controls.Add(ajoutLabel());
        TableCell tc8 = new TableCell();
        tc8.BackColor = System.Drawing.Color.LightGray;
        TextBox tbSam = new TextBox();
        if (p_fdt.samedi != null)
        {
            tbSam.Text = p_fdt.samedi.ToString();
        }
        //tbSam.ID = "tbSam";
        tbSam.CssClass = "col-sm-7";
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

        TableCell tc10 = new TableCell();
        Button bt_modif = new Button();
        bt_modif.Text = "Modifier";
        bt_modif.PostBackUrl = "~/FeuilleDeTemps.aspx?id=" + p_fdt.idFeuilleDeTemps.ToString();
        //?id = " + employe.idEmploye.ToString();
        tc10.Controls.Add(bt_modif);

        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        tr.Cells.Add(tc3);
        tr.Cells.Add(tc4);
        tr.Cells.Add(tc5);
        tr.Cells.Add(tc6);
        tr.Cells.Add(tc7);
        tr.Cells.Add(tc8);
        tr.Cells.Add(tc9);
        tr.Cells.Add(tc10);
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
        btn_confirmerModif.Visible = false;
        btn_annuler.Visible = true;
        btn_ajouter.Visible = false;
    }

    protected void btn_confirmer_Click(object sender, EventArgs e)
    {
        tr_ajout.Visible = false;
        btn_confirmer.Visible = false;
        btn_confirmerModif.Visible = false;
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
        clearTextBox();
    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        tr_ajout.Visible = false;
        btn_confirmer.Visible = false;
        btn_confirmerModif.Visible = false;
        btn_annuler.Visible = false;
        btn_ajouter.Visible = true;
        clearTextBox();
    }

    void modifier(int p_id)
    {
        tr_ajout.Visible = true;
        btn_confirmerModif.Visible = true;
        btn_annuler.Visible = true;
        btn_ajouter.Visible = false;

        foreach (T_FeuilleDeTemps fdt in listeFeuilleDeTemps)
        {
            if (fdt.idFeuilleDeTemps == p_id)
            {
                tb_dimanche.Text = fdt.dimanche.ToString();
                tb_lundi.Text = fdt.lundi.ToString();
                tb_mardi.Text = fdt.mardi.ToString();
                tb_mercredi.Text = fdt.mercredi.ToString();
                tb_jeudi.Text = fdt.jeudi.ToString();
                tb_vendredi.Text = fdt.vendredi.ToString();
                tb_samedi.Text = fdt.samedi.ToString();
                tb_commentaire.Text = fdt.note.ToString();

                break;
            }
        }
    }

    protected void btn_confirmerModif_Click(object sender, EventArgs e)
    {
        T_FeuilleDeTemps fdt = new T_FeuilleDeTemps();

        fdt.idCategorie = 3;

        fdt.idEmp = int.Parse(Session["idEmp"].ToString());

        fdt.idFeuilleDeTemps = int.Parse(urlParamId);

        date = getFirstDayOfWeek(Calendar1.SelectedDate);

        fdt.semaine = date;

        if (tb_dimanche.Text != "")
        {
            //string o = String.Format("{0}", Request.Form["tb_dimanche"]);
            //fdt.dimanche = float.Parse(o);
            
        }
        else
        {
            fdt.dimanche = null;
        }
        if (tb_lundi.Text != "")
        {
            fdt.lundi = float.Parse(tb_lundi.Text);
        }
        else
        {
            fdt.lundi = null;
        }
        if (tb_mardi.Text != "")
        {
            fdt.mardi = float.Parse(tb_mardi.Text);
        }
        else
        {
            fdt.mardi = null;
        }
        if (tb_mercredi.Text != "")
        {
            fdt.mercredi = float.Parse(tb_mercredi.Text);
        }
        else
        {
            fdt.mercredi = null;
        }
        if (tb_jeudi.Text != "")
        {
            fdt.jeudi = float.Parse(tb_jeudi.Text);
        }
        else
        {
            fdt.jeudi = null;
        }
        if (tb_vendredi.Text != "")
        {
            fdt.vendredi = float.Parse(tb_vendredi.Text);
        }
        else
        {
            fdt.vendredi = null;
        }
        if (tb_samedi.Text != "")
        {
            fdt.samedi = float.Parse(tb_samedi.Text);
        }
        else
        {
            fdt.samedi = null;
        }

        if (tb_commentaire.Text != "")
        {
            fdt.note = tb_commentaire.Text;
        }
        else
        {
            fdt.note = null;
        }

        BD_CoEco.UpdateFeuilleDeTemps(fdt);
        clearTextBox();
        tr_ajout.Visible = false;
        btn_confirmer.Visible = false;
        btn_confirmerModif.Visible = false;
        btn_annuler.Visible = false;
        btn_ajouter.Visible = true;
        ajouterEnregistrement(date);
    }

    void clearTextBox()
    {
        ddl_Categorie.Items.Clear();
        ddl_Projet.Items.Clear();

        tb_dimanche.Text = "";
        tb_lundi.Text = "";
        tb_mardi.Text = "";
        tb_mercredi.Text = "";
        tb_jeudi.Text = "";
        tb_vendredi.Text = "";
        tb_samedi.Text = "";
        tb_commentaire.Text = "";
        tr_ajout.Visible = false;
        btn_ajouter.Visible = true;
    }
}