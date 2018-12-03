using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterEmploye : System.Web.UI.Page
{
    string urlParam;  

    protected void Page_Load(object sender, EventArgs e)
    {
        //rendre non visible le statut, car par défaut lorsqu'on ajoute le statut est nécessairement actif

        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        btn_appliquer.Enabled = false;
        btn_modifier.Enabled = false;
        ddl_statut.Enabled = false;

        urlParam = Request.QueryString["id"];

        if (!IsPostBack)
        {
            loadFonction();
            if (urlParam == null)
            {
                loadStatut();
            }
        }

        btn_addEmp.Text = "Ajouter";
        btn_modifier.Text = "Modifier";
        btn_retour.Text = "Retour";
        btn_appliquer.Text = "Appliquer";
    
        if (urlParam != null)
        {
            if (!IsPostBack)
            {
                //ajuster les contrôles pour la page modifications et affichage
                tbx_prenom.Enabled = false;
                tbx_nom.Enabled = false;
                tbx_courriel.Enabled = false;
                tbx_mdp.Enabled = false;
                tbx_pseudo.Enabled = false;
                ddl_fonction.Enabled = false;
                ddl_statut.Enabled = false;
                btn_addEmp.Enabled = false;

                btn_appliquer.Enabled = true;
                btn_appliquer.Enabled = false;
                btn_modifier.Enabled = true;

                //caller la méthode qui affiche l'employés cliqué
                AfficherEmp();
            }
        }          
    }

    private void loadStatut()
    {
        /*-- Partie pour les statuts --*/
        List<T_StatusEmploye> listStatus = BD_CoEco.GetListeStatusEmploye();
        listStatus = listStatus.OrderBy(o => o.descript).ToList();
        foreach (T_StatusEmploye status in listStatus)
        {
            ddl_statut.Items.Add(new ListItem(status.descript, status.idStatusEmp.ToString()));
        }
    }

    private void loadFonction()
    {
        /*-- Partie pour les fonctions --*/
        List<T_FonctionEmploye> listeFonction = BD_CoEco.GetListeFontionsEmploye();
        listeFonction = listeFonction.OrderBy(o => o.descript).ToList();
        foreach (T_FonctionEmploye fonction in listeFonction)
        {
            if (fonction.descript != "Administrateur")
            {
                ddl_fonction.Items.Add(new ListItem(fonction.descript, fonction.idFonctionEmp.ToString()));
            }
        }
    }

    protected void bt_annuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Employe.aspx");
    }

    protected void btn_addEmp_Click(object sender, EventArgs e)
    {
        btn_modifier.Enabled = false;

        //ajouter un employé

        T_Employe newEmp = new T_Employe();
        newEmp.prenom = tbx_prenom.Text;
        newEmp.nom = tbx_nom.Text;
        newEmp.courriel = tbx_courriel.Text;
        newEmp.mdp = tbx_mdp.Text;
        newEmp.idStatus = 1;
        newEmp.idFonction = int.Parse(ddl_fonction.SelectedValue);
        newEmp.loginName = tbx_pseudo.Text;

        BD_CoEco.CreateNewEmploye(newEmp);

        T_EmployeProjet newlien = new T_EmployeProjet();
        newlien.idEmp = newEmp.idEmploye;
        newlien.idPro = 3;
        BD_CoEco.CreateNewEmpAtProject(newlien);


        //faire une gestion d'erreur ici

        Response.Redirect("Employe.aspx");
    }

    protected void AfficherEmp()
    {

        loadStatut();

        List<T_Employe> tousLesEmp = BD_CoEco.GetListeEmploye();

        foreach (T_Employe emp in tousLesEmp)
        {
            if (emp.idEmploye == int.Parse(urlParam))
            {
                tbx_prenom.Text = emp.prenom;
                tbx_nom.Text = emp.nom;
                tbx_courriel.Text = emp.courriel;
                tbx_mdp.Text = emp.mdp;
                tbx_pseudo.Text = emp.loginName;

                if (emp.idFonction == 1) //bureau
                {
                    ddl_fonction.SelectedIndex = 0;
                }
                else if (emp.idFonction == 2)//terrain
                {
                    ddl_fonction.SelectedIndex = 1;
                }
                else //admin
                {
                    ddl_fonction.SelectedIndex = 2;
                }

                if (emp.idStatus == 1) //actif
                {
                    ddl_statut.SelectedIndex = 0;
                }
                else if (emp.idStatus == 2)//inactif
                {
                    ddl_statut.SelectedIndex = 1;
                }

            }
        }
    }

    protected void btn_modEmp_Click(object sender, EventArgs e)
    {

        tbx_prenom.Enabled = true;
        tbx_nom.Enabled = true;
        tbx_courriel.Enabled = true;
        tbx_mdp.Enabled = true;
        tbx_pseudo.Enabled = true;
        ddl_fonction.Enabled = true;
        ddl_statut.Enabled = true;
        btn_modifier.Enabled = false;

        btn_appliquer.Enabled = true;
        btn_appliquer.Enabled = true;
    }

    //modifier l'employé dans la BD
    protected void btn_applyMod_Click(object sender, EventArgs e)
    {
        T_Employe newEmp = new T_Employe();
        
        newEmp.idEmploye = int.Parse(Request.QueryString["id"]);
        newEmp.prenom = tbx_prenom.Text;
        newEmp.nom = tbx_nom.Text;
        newEmp.courriel = tbx_courriel.Text;
        newEmp.mdp = tbx_mdp.Text;
        newEmp.loginName = tbx_pseudo.Text;
        newEmp.idStatus = int.Parse(ddl_statut.SelectedValue);
        newEmp.idFonction = int.Parse(ddl_fonction.SelectedValue);
        newEmp.loginName = tbx_pseudo.Text;
        BD_CoEco.UpdateEmploye(newEmp);

        

        Response.Redirect("Employe.aspx");

    }

    protected void btn_retour_Click(object sender, EventArgs e)
    {
        tbx_prenom.Text = " chargement ";
        tbx_nom.Text = " chargement ";
        Response.Redirect("Employe.aspx");
    }

}