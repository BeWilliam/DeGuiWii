using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;


public partial class Categorie : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null || Session["username"] == "")
        {
            Response.Redirect("index.aspx");
        }

        btn_conf.Visible = false;
        btn_addCat.Disabled = true;
        
        ddl_statut.Visible = false;

        if (!this.IsPostBack)
        {
            loadProjet();
        }
    }

    private void loadProjet()
    {
        /*-- Partie pour les projets --*/
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet(true);
        listProjet = listProjet.OrderBy(o => o.nom).ToList();
        ddl_projet.Items.Add(new ListItem("Choisir un projet", "-1"));
        foreach (T_Projet projet in listProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }

    private void loadStatus()
    {
        /*-- Partie pour les statuts --*/
        List<T_StatusCategorie> listStatus = BD_CoEco.GetListeStatusCategorie();
        listStatus = listStatus.OrderBy(o => o.descript).ToList();      
        foreach (T_StatusCategorie status in listStatus)
        {
            ddl_statut.Items.Add(new ListItem(status.descript, status.idStatusCat.ToString()));
        }
    }


    protected void ddl_projet_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_projet.SelectedValue != "-1")
        {
            loadCat();
            btn_addCat.Disabled = false;
        }
        
    }

    private void loadCat()
    {
        List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_projet.SelectedValue)));
        listCat = listCat.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listCat)
        {
            TableRow tr = new TableRow();
            TableCell tc1 = new TableCell();

            tc1.Text = categoriePro.descript;

            tr.Cells.Add(tc1);

            Tableau_Categorie.Rows.Add(tr);
        }
    }

    protected void btn_addCat_Click(object sender, EventArgs e)
    {
        
        //tbx_cat.Visible = true;

        
        ddl_statut.Visible = true;

  
        if (ddl_statut.Items.Count <= 0)
        {
            loadStatus();
        }

        

       // add_cat.Visible = false;

        btn_conf.Visible = true;
    }

    protected void btn_Conf_Click(object sender, EventArgs e)
    {

        //connexion à la BD
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_CategoriePro> tableEmp = BD.T_CategoriePro;

        T_CategoriePro newCat = new T_CategoriePro();
        //newCat.descript = tbx_cat.Text;

        if (ddl_statut.SelectedValue == "Actif")
        {
            newCat.idStatusCat = 1;
        }
        else
        {
            newCat.idStatusCat = 2;
        }

        newCat.idProjet = int.Parse(ddl_projet.SelectedValue);

        BD_CoEco.CreateNewCategorie(newCat);

        loadCat();

    }
}