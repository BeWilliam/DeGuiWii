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
    int idFdt;
    List<T_Projet> projetsDeLemploye;
    List<T_CategoriePro> ListeCategorie;
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
        idFdt = int.Parse(Request.QueryString["idFdt"]);
        if (!IsPostBack)
        {
            

            

            if (idFdt != -1)
            {
                modifFdt(idFdt);
            }
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
            fdt.commentaireDimanche = tb_dimancheCommentaire.Text;


        }
        else
        {
            fdt.commentaireDimanche = null;
        }
        if (tb_lundiCommentaire.Text != "")
        {
            fdt.commentaireLundi = tb_lundiCommentaire.Text;
        }
        else
        {
            fdt.commentaireLundi = null;
        }
        if (tb_mardiCommentaire.Text != "")
        {
            fdt.commentaireMardi = tb_mardiCommentaire.Text;
        }
        else
        {
            fdt.commentaireMardi = null;
        }
        if (tb_mercrediCommentaire.Text != "")
        {
            fdt.commentaireMercredi = tb_mercrediCommentaire.Text;
        }
        else
        {
            fdt.commentaireMercredi = null;
        }
        if (tb_jeudiCommentaire.Text != "")
        {
            fdt.commentaireJeudi = tb_jeudiCommentaire.Text;
        }
        else
        {
            fdt.commentaireJeudi = null;
        }
        if (tb_vendrediCommentaire.Text != "")
        {
            fdt.commentaireVendredi = tb_vendrediCommentaire.Text;
        }
        else
        {
            fdt.commentaireVendredi = null;
        }
        if (tb_samediCommentaire.Text != "")
        {
            fdt.commentaireSamedi = tb_samediCommentaire.Text;
        }
        else
        {
            fdt.commentaireSamedi = null;
        }

        fdt.approbation = false;
        
        //Modif
        if (idFdt != -1)
        {
            fdt.idFeuilleDeTemps = idFdt;
            BD_CoEco.UpdateFeuilleDeTemps(fdt);
        }
        //Ajout
        else
        {
            BD_CoEco.CreateNewFeuilleDeTemps(fdt);
        }

        Response.Redirect("FeuilleDeTemps.aspx");
    }

    void modifFdt(int p_id)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(p_id);

        if (fdt.dimanche != null)
        {
            tb_dimanche.Text = fdt.dimanche.ToString();
        }
        if (fdt.lundi != null)
        {
            tb_lundi.Text = fdt.lundi.ToString();
        }
        if (fdt.mardi != null)
        {
            tb_mardi.Text = fdt.mardi.ToString();
        }
        if (fdt.mercredi != null)
        {
            tb_mercredi.Text = fdt.mercredi.ToString();

        }

        if (fdt.jeudi != null)
        {
            tb_jeudi.Text = fdt.jeudi.ToString();
        }
        if (fdt.vendredi != null)
        {
            tb_vendredi.Text = fdt.vendredi.ToString();
        }

        if (fdt.samedi != null)
        {
            tb_samedi.Text = fdt.samedi.ToString();
        }
        //--COM
        if (fdt.commentaireDimanche != null)
        {
            tb_dimancheCommentaire.Text = fdt.commentaireDimanche.ToString();
        }
        if (fdt.commentaireLundi != null)
        {
            tb_lundiCommentaire.Text = fdt.commentaireLundi.ToString();
        }
        if (fdt.commentaireMardi != null)
        {
            tb_mardiCommentaire.Text = fdt.commentaireMardi.ToString();
        }
        if (fdt.commentaireMercredi != null)
        {
            tb_mercrediCommentaire.Text = fdt.commentaireMercredi.ToString();

        }

        if (fdt.commentaireJeudi != null)
        {
            tb_jeudiCommentaire.Text = fdt.commentaireJeudi.ToString();
        }
        if (fdt.commentaireVendredi != null)
        {
            tb_vendrediCommentaire.Text = fdt.commentaireVendredi.ToString();
        }

        if (fdt.commentaireSamedi != null)
        {
            tb_samediCommentaire.Text = fdt.commentaireSamedi.ToString();
        }

        ddl_Projet.SelectedValue = BD_CoEco.GetCatByID(fdt.idCategorie).idProjet.ToString();
        List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_Projet.SelectedValue)));
        listCat = listCat.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listCat)
        {
            ddl_Categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
        }
        ddl_Categorie.SelectedValue = fdt.idCategorie.ToString();
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