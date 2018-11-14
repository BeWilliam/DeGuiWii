using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depenses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //First Load
            loadDllProjet();
            loadDdlCat();
            loadTypeDepense();
            //Ddate.Value = DateTime.Now.ToString();
        }
    }
    
    private void loadDllProjet()
    {
        ddl_projet.Items.Clear();
        List<T_Projet> listeProjet = BD_CoEco.GetListeProjet(true);
        listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listeProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }
    private void loadDdlCat()
    {
        ddL_categorie.Items.Clear();
        List<T_CategoriePro> listeCategorie = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_projet.SelectedValue)));
        listeCategorie = listeCategorie.OrderBy(o => o.descript).ToList();
        foreach (T_CategoriePro categoriePro in listeCategorie)
        {
            ddL_categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
        }
    }

    private void loadTypeDepense()
    {
        ddl_typeDepense.Items.Clear();
        List<T_TypeDepense> listeTypeDepense = BD_CoEco.GetListeTypeDepense();
        listeTypeDepense = listeTypeDepense.OrderBy(o => o.descript).ToList();
        foreach (T_TypeDepense typeDepense in listeTypeDepense)
        {
            ddl_typeDepense.Items.Add(new ListItem(typeDepense.descript, typeDepense.idDepense.ToString()));
        }
    }


    protected void ddl_projet_SelectedIndexChanged(object sender, EventArgs e)
    {
        loadDdlCat();
    }



    protected void btn_ok_ServerClick(object sender, EventArgs e)
    {
        T_Depense newDep = new T_Depense();
        newDep.montant = decimal.Parse(tbx_montant.Text);
        newDep.descript = tbx_description.Text;
        newDep.ddate = DateTime.Parse(Ddate.Value);
        newDep.idType = int.Parse(ddl_typeDepense.SelectedValue);
        newDep.idProjet = int.Parse(ddl_projet.SelectedValue);
        newDep.idCategorie = int.Parse(ddL_categorie.SelectedValue);
        newDep.idEmp = int.Parse(Session["idEmp"].ToString());
        newDep.aprobation = false;
        BD_CoEco.AddDepense(newDep);

        Response.Redirect("AjouterDepenses.aspx");
    }
}