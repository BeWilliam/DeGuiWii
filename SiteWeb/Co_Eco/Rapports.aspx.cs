using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rapports : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbx_DateFin.Text = DateTime.Now.Date.ToShortDateString();

        if(!this.IsPostBack)
        {
            loadProjects();
            loadCheckBoxList();
            loadCat();
        }
    }


    private void loadProjects()
    {
        /*-- Partie pour les projets --*/
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet(true);
        listProjet = listProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listProjet)
        {
            ddl_Projets.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
        ddl_Categorie.Items.Add(new ListItem("Toutes les catégories", "-1"));


    }
    private void loadCheckBoxList()
    {
        T_Projet proActu = BD_CoEco.GetProByID(int.Parse(ddl_Projets.SelectedValue));
        cbl_Employe.Items.Clear();
        List<T_Employe> listEmp = BD_CoEco.GetEmpByProject(proActu);
        listEmp = listEmp.OrderBy(o => o.prenom).ThenBy(o => o.nom).ToList();
        foreach (T_Employe employe in listEmp)
        {
            cbl_Employe.Items.Add(new ListItem(employe.ToString(), employe.idEmploye.ToString()));
        }
    }


    protected void ddl_Projets_LoadCat(object sender, EventArgs e)
    {
        loadCat();
        loadCheckBoxList();
    }

    private void loadCat()
    {
        /*-- Partie pour les Catégories --*/
        ddl_Categorie.Items.Clear();
        ddl_Categorie.Items.Add(new ListItem("Toutes les catégories", "-1"));
        List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_Projets.SelectedValue)));
        listCat = listCat.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listCat)
        {
            ddl_Categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
        }
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        loadCat();
        loadCheckBoxList();
    }
}