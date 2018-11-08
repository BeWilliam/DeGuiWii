using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depense : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if(!IsPostBack)
        {
            DDL_TypeDepense.Items.Clear();
            List<T_TypeDepense> typeDepense = BD_CoEco.GetListeTypeDepense();
            typeDepense = typeDepense.OrderBy(o => o.descript).ToList();
            foreach (T_TypeDepense type in typeDepense)
            {
                DDL_TypeDepense.Items.Add(type.descript);
            }

            List<T_Projet> listeProjet = BD_CoEco.GetListeProjet();
            listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
            foreach (T_Projet projet in listeProjet)
            {

            }
        }
    }

    protected void bt_ajouterDepense_ServerClick(object sender, EventArgs e)
    {
        DropDownList projects = new DropDownList();
        

        List<T_Projet> listeProjet = BD_CoEco.GetListeProjet();
        listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listeProjet)
        {
            projects.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }



        //Ajouter une ligne au tableau
        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        //tc1.Controls.Add()

        //TableDepenses.Rows.Add(tr);


    }
}