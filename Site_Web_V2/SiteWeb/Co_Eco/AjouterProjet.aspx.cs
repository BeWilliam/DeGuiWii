using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterProjet : System.Web.UI.Page
{

    string urlParam;


    protected void Page_Load(object sender, EventArgs e)
    {
        urlParam = Request.QueryString["id"];

        loadResponsable();
        loadStatut();

        if (urlParam != null)
        {
            
        }
        
        
    }

    protected void btn_addProject_Click(object sender, EventArgs e)
    {
        //connexion à la BD
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Projet> tableEmp = BD.T_Projet;

        T_Projet monProjet = new T_Projet();

        monProjet.nom = tbx_nom.Value;
        monProjet.descript = tbx_projet.Value;
        monProjet.responsable = int.Parse(ddl_responsable.SelectedValue);
    }

    private void loadResponsable()
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeResponsable = new List<T_Employe>();
        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction == 1) //Employé de bureau
            {
                listeResponsable.Add(employe);

            }
        }
        listeResponsable = listeResponsable.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        ddl_responsable.Items.Add(new ListItem("Tous les responsables", "-1"));
        foreach (T_Employe responsable in listeResponsable)
        {
            ddl_responsable.Items.Add(new ListItem(responsable.prenom + " " + responsable.nom, responsable.idEmploye.ToString()));
        }
    }

    private void loadStatut()
    {
        List<T_StatusProjet> listeStatusProjet = BD_CoEco.GetListeStatusProjet();
        listeStatusProjet = listeStatusProjet.OrderBy(o => o.descript).ToList();
        ddl_statut.Items.Add(new ListItem("Tous les statuts", "-1"));
        foreach (T_StatusProjet statut in listeStatusProjet)
        {
            ddl_statut.Items.Add(new ListItem(statut.descript, statut.noStatusPro.ToString()));
        }
    }
}