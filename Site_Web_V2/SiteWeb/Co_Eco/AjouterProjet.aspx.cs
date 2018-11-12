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

        if (!IsPostBack)
        {
            loadResponsable();
            loadStatut();
        }

        if (urlParam != null)
        {
            afficherProject();
        }
        
        
    }

    private void afficherProject()
    {
        List<T_Projet> tousLesProjet = BD_CoEco.GetListeProjet();

        foreach (T_Projet projet in tousLesProjet)
        {
            if (projet.idProjet == int.Parse(urlParam))
            {
                tbx_nom.Value = projet.nom;
                tbx_projet.Value = projet.descript;
                if (projet.responsable != null)
                {
                    ddl_responsable.SelectedValue = BD_CoEco.GetEmpByID((int)projet.responsable).idEmploye.ToString();
                }
                tbx_heure.Value = projet.heureAlloue.ToString();
                dateDebut.Value = projet.dateDebut.ToString();
                dateFin.Value = projet.dateFin.ToString();

                if (projet.idStatus == 1) //en cours
                {
                    ddl_statut.SelectedIndex = 3;
                }
                else if (projet.idStatus == 2) //terminer
                {
                    ddl_statut.SelectedIndex = 4;
                }
                else if (projet.idStatus == 3) //archiver
                {
                    ddl_statut.SelectedIndex = 1;
                }
                else //en construction
                {
                    ddl_statut.SelectedIndex = 2;
                }

            }
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
        monProjet.heureAlloue = int.Parse(tbx_heure.Value);
        monProjet.dateDebut = DateTime.Parse(dateDebut.Value);
        monProjet.dateFin = DateTime.Parse(dateFin.Value);
        monProjet.idStatus = int.Parse(ddl_statut.SelectedValue);

        BD_CoEco.CreateNewProjet(monProjet);

        Response.Redirect("Projet.aspx");
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