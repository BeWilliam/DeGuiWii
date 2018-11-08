using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Categorie : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        tbx_cat.Visible = false;
        btn_conf.Visible = false;
        add_cat.Visible = true;

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
        foreach (T_Projet projet in listProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }



    protected void ddl_projet_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadCat();
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
        
        tbx_cat.Visible = true;

        add_cat.Visible = false;

        btn_conf.Visible = true;
    }

    protected void btn_Conf_Click(object sender, EventArgs e)
    {

        loadCat();

    }
}