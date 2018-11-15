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

        btn_modifier.Visible = false;
        btn_apply.Visible = false;

        if (!IsPostBack)
        {
            loadResponsable();
            loadStatut();
        }

        if (urlParam != null)
        {
            btn_apply.Visible = true;
            btn_apply.Enabled = true;

            if (!IsPostBack)
            {
                afficherProject();

                btn_addProject.Visible = false;

                btn_apply.Visible = true;
                btn_apply.Enabled = false;

                btn_modifier.Visible = true;
                tbx_nom.Enabled = false;
                tbx_heure.Enabled = false;
                tbx_projet.Enabled = false;
                ddl_responsable.Enabled = false;
                ddl_statut.Enabled = false;
                dateDebut.Enabled = false;
                dateFin.Enabled = false;    
             
            }
        }       
    }

    private void afficherProject()
    {
        List<T_Projet> tousLesProjet = BD_CoEco.GetListeProjet();

        foreach (T_Projet projet in tousLesProjet)
        {
            if (projet.idProjet == int.Parse(urlParam))
            {
                tbx_nom.Text = projet.nom;
                tbx_projet.Text = projet.descript;
                if (projet.responsable != null)
                {
                    ddl_responsable.SelectedValue = BD_CoEco.GetEmpByID((int)projet.responsable).idEmploye.ToString();
                }
                tbx_heure.Text = projet.heureAlloue.ToString();
                //dateDebut.Text = DateTime.Today.ToString("yyyy-MM-dd");
                dateDebut.Text = String.Format("{0:yyyy-MM-dd}", projet.dateDebut);
                dateFin.Text = String.Format("{0:yyyy-MM-dd}", projet.dateFin);

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

        T_Projet monProjet = new T_Projet();

        monProjet.nom = tbx_nom.Text;
        monProjet.descript = tbx_projet.Text;
        monProjet.responsable = int.Parse(ddl_responsable.SelectedValue);
        monProjet.heureAlloue = int.Parse(tbx_heure.Text);
        monProjet.dateDebut = DateTime.Parse(dateDebut.Text.ToString());
        monProjet.dateFin = DateTime.Parse(dateFin.Text.ToString());
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

    protected void btn_retour_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {

        T_Projet monProjet = new T_Projet();

        monProjet.idProjet = int.Parse(Request.QueryString["id"]);
        monProjet.nom = tbx_nom.Text;
        monProjet.descript = tbx_projet.Text;
        monProjet.heureAlloue = Double.Parse(tbx_heure.Text);
        monProjet.idStatus = int.Parse(ddl_statut.SelectedValue);
        monProjet.responsable = int.Parse(ddl_responsable.SelectedValue);
        monProjet.dateDebut = DateTime.Parse(dateDebut.Text.ToString());
        monProjet.dateFin = DateTime.Parse(dateFin.Text.ToString());


        BD_CoEco.UpdateProjet(monProjet);

        Response.Redirect("Projet.aspx");

    }

    protected void btn_modifier_Click(object sender, EventArgs e)
    {
        tbx_nom.Enabled = true;
        tbx_heure.Enabled = true;
        tbx_projet.Enabled = true;
        ddl_responsable.Enabled = true;
        ddl_statut.Enabled = true;
        dateDebut.Enabled = true;
        dateFin.Enabled = true;

        btn_apply.Visible = true;
        btn_apply.Enabled = true;
    }
}