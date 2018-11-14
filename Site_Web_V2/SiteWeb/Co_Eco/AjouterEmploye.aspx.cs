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
        sec_statut.Visible = false;

        btn_appliquer.Visible = false;

        urlParam = Request.QueryString["id"];

        loadFonction();

        if (urlParam != null)
        {
            //ajuster les contrôles pour la page modifications et affichage
            tbx_prenom.Disabled = true;
            tbx_nom.Disabled = true;
            tbx_courriel.Disabled = true;
            tbx_mdp.Disabled = true;
            ddl_fonction.Enabled = false;
            ddl_statut.Enabled = false;
            add_emp.Visible = false;
            sec_statut.Visible = true;

            btn_appliquer.Visible = true;
            btn_appliquer.Disabled = true;

            //caller la méthode qui affiche l'employés cliqué
            AfficherEmp();
            
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
        //ajouter un employé

        //connexion à la BD
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;

        T_Employe newEmp = new T_Employe();
        newEmp.prenom = String.Format("{0}", Request.Form["tbx_prenom"]);
        newEmp.nom = String.Format("{0}", Request.Form["tbx_nom"]);
        newEmp.courriel = String.Format("{0}", Request.Form["tbx_courriel"]);
        newEmp.mdp = String.Format("{0}", Request.Form["tbx_mdp"]);
        newEmp.idStatus = 1;
        newEmp.idFonction = int.Parse(ddl_fonction.SelectedValue);

        BD_CoEco.CreateNewEmploye(newEmp);

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
                tbx_prenom.Value = emp.prenom;
                tbx_nom.Value = emp.nom;
                tbx_courriel.Value = emp.courriel;
                tbx_mdp.Value = emp.mdp;               

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
        tbx_prenom.Disabled = false;
        tbx_nom.Disabled = false;
        tbx_courriel.Disabled = false;
        tbx_mdp.Disabled = false;
        ddl_fonction.Enabled = true;
        ddl_statut.Enabled = true;
        btn_modifier.Disabled = true;

        btn_appliquer.Disabled = false;
    }

    //modifier l'employé dans la BD
    protected void btn_applyMod_Click(object sender, EventArgs e)
    {
        T_Employe newEmp = new T_Employe();

        newEmp.idEmploye = int.Parse(Request.QueryString["id"]);
        newEmp.prenom = String.Format("{0}", Request.Form["tbx_prenom"]);
        newEmp.nom = String.Format("{0}", Request.Form["tbx_nom"]);
        newEmp.courriel = String.Format("{0}", Request.Form["tbx_courriel"]);
        newEmp.mdp = String.Format("{0}", Request.Form["tbx_mdp"]);
        newEmp.idStatus = int.Parse(ddl_statut.SelectedValue);
        newEmp.idFonction = int.Parse(ddl_fonction.SelectedValue);
        

        BD_CoEco.UpdateEmploye(newEmp);
    }

    protected void btn_retour_Click(object sender, EventArgs e)
    {

    }
}