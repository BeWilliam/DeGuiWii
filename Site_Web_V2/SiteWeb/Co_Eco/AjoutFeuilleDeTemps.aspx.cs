using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ListItem = System.Web.UI.WebControls.ListItem;

public partial class AjoutFeuilleDeTemps : System.Web.UI.Page
{
    int idEmp;
    List<T_Projet> projetsDeLemploye;
    List<T_CategoriePro> ListeCategorie;
    string urlParamId;
    protected void Page_Load(object sender, EventArgs e)
    {
        //idEmp = int.Parse(Session["idEmp"].ToString());

        //ddl_Projet.Items.Clear();
        //ddl_Categorie.Items.Clear();
        //projetsDeLemploye = BD_CoEco.GetProjectByEmp(BD_CoEco.GetEmpByID(idEmp));

        //foreach (T_Projet proj in projetsDeLemploye)
        //{
        //    ddl_Projet.Items.Add(proj.nom);
        //}
        //ListeCategorie = GetListeCateByProjet(projetsDeLemploye);
        loadDllProjet();
        

        //urlParamId = Request.QueryString["id"];

        if (!IsPostBack)
        {

            ddl_Categorie.Items.Add(new ListItem("Aucune Catégorie", "-1"));
        }
        else
        {
            
        }

    }

    protected void ddl_projet_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDdlCat();
    }

    List<T_CategoriePro> GetListeCateByProjet(List<T_Projet> p_projet)
    {
        List<T_CategoriePro> lc = BD_CoEco.GetListeCategorie();
        List<T_CategoriePro> lcProjet = new List<T_CategoriePro>();

        foreach (T_Projet proj in p_projet)
        {
            foreach (T_CategoriePro cat in lc)
            {
                if (cat.idProjet == proj.idProjet)
                {
                    lcProjet.Add(cat);
                }
            }
        }

        return lcProjet;
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        T_FeuilleDeTemps fdt = new T_FeuilleDeTemps();

        fdt.idCategorie = int.Parse(ddl_Categorie.SelectedValue);

        fdt.idEmp = int.Parse(Session["idEmp"].ToString());

        fdt.idFeuilleDeTemps = int.Parse(urlParamId);
        DateTime date;
        date = DateTime.Parse(Request.QueryString["date"]);
        //date = getFirstDayOfWeek(Calendar1.SelectedDate);

        fdt.semaine = date;


        if (tb_dimanche.Text != "")
        {

            fdt.dimanche = float.Parse(tb_dimanche.Text);
        }
        else
        {
            fdt.dimanche = null;
        }
        string lun = tb_lundi.Text;
        if (lun != "")
        {
            fdt.lundi = float.Parse(lun);
        }
        else
        {
            fdt.lundi = null;
        }
        string mar = tb_mardi.Text;
        if (mar != "")
        {
            fdt.mardi = float.Parse(mar);
        }
        else
        {
            fdt.mardi = null;
        }
        string mer = tb_mercredi.Text;
        if (mer != "")
        {
            fdt.mercredi = float.Parse(mer);
        }
        else
        {
            fdt.mercredi = null;
        }
        string jeu = tb_jeudi.Text;
        if (jeu != "")
        {
            fdt.jeudi = float.Parse(jeu);
        }
        else
        {
            fdt.jeudi = null;
        }
        string ven = tb_vendredi.Text;
        if (ven != "")
        {
            fdt.vendredi = float.Parse(ven);
        }
        else
        {
            fdt.vendredi = null;
        }
        string sam = tb_samedi.Text;
        if (sam != "")
        {
            fdt.samedi = float.Parse(sam);
        }
        else
        {
            fdt.samedi = null;
        }
        //-----------COM
        if (tb_dimancheCommentaire.Text != "")
        {

            
        }
        else
        {
            fdt.dimanche = null;
        }
        if (tb_lundiCommentaire.Text != "")
        {
            fdt.lundi = float.Parse(tb_lundiCommentaire.Text);
        }
        else
        {
            fdt.lundi = null;
        }
        if (tb_mardiCommentaire.Text != "")
        {
            fdt.mardi = float.Parse(tb_mardiCommentaire.Text);
        }
        else
        {
            fdt.mardi = null;
        }
        if (tb_mercrediCommentaire.Text != "")
        {
            fdt.mercredi = float.Parse(tb_mercrediCommentaire.Text);
        }
        else
        {
            fdt.mercredi = null;
        }
        if (tb_jeudiCommentaire.Text != "")
        {
            fdt.jeudi = float.Parse(tb_jeudiCommentaire.Text);
        }
        else
        {
            fdt.jeudi = null;
        }
        if (tb_vendrediCommentaire.Text != "")
        {
            fdt.vendredi = float.Parse(tb_vendrediCommentaire.Text);
        }
        else
        {
            fdt.vendredi = null;
        }
        if (tb_samediCommentaire.Text != "")
        {
            fdt.samedi = float.Parse(tb_samediCommentaire.Text);
        }
        else
        {
            fdt.samedi = null;
        }

        //fdt.approbation = false;
        //BD_CoEco.UpdateFeuilleDeTemps(fdt);
        //clearTextBox();

        //tr_ajout.Visible = false;
        //tr_modif.Visible = false;
        //btn_confirmer.Visible = false;
        //btn_confirmerModif.Visible = false;
        //btn_annuler.Visible = false;
        //btn_ajouter.Visible = true;
        //ajout = true;
        //ajouterEnregistrement(date);

        Response.Redirect("FeuilleDeTemps.aspx");
    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeuilleDeTemps.aspx");
    }
    private void loadDdlCat()
    {
        /*-- Partie pour les Catégories --*/
        ddl_Categorie.Items.Clear();
        string proj = Request.Form["ctl00$cph_contenu$ddl_Projet"];
        List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(proj)));
        listCat = listCat.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listCat)
        {
            ddl_Categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
        }
        ddl_Projet.SelectedValue = listCat[0].idProjet.ToString();

    }
    private void loadDllProjet()
    {
        ddl_Projet.Items.Clear();
        List<T_Projet> listeProjet = BD_CoEco.GetProjectByEmp(BD_CoEco.GetEmpByID(int.Parse(Session["idEmp"].ToString())));
        listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
        ddl_Projet.Items.Add(new ListItem("Choisir un projet", "-1"));
        foreach (T_Projet projet in listeProjet)
        {
            ddl_Projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
        
    }
}