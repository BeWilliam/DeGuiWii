using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depenses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btn_modifier.Enabled = false;
        btn_apply.Enabled = false;

        if(!IsPostBack)
        {
            //First Load
            //loadDdlCat();
            btn_approuver.Enabled = false;
            btn_desapprouver.Enabled = false;
            loadTypeDepense();
            loadEmploye();
            loadTypeAuto();

            if(Session["fonction"] == null)
            {
                Response.Redirect("index.aspx");
            }
                



            if (Session["fonction"].ToString() == "3")
            {
                btn_approuver.Visible = true;
                btn_desapprouver.Visible = true;
                loadProjetAdm();
                ddl_employe.Enabled = true;
            }
            else
            {
                loadDllProjet();
            }

            string id = Request.QueryString["id"];
            string type = Request.QueryString["Type"];

            if (id != null && type != null && Session["fonction"].ToString() == "3")
            {
                afficherDepense();
                btn_approuver.Enabled = true;
                btn_desapprouver.Enabled = true;
                btn_modifier.Visible = true;
                btn_ok.Enabled = false;
                ddl_employe.Enabled = true; 

            }
            else if (id != null && type != null)
            {
                afficherDepense();
                btn_cancel.Visible = false;
                btn_modifier.Visible = true;
                btn_ok.Enabled = false;

                if(type == "1")
                {
                    if (BD_CoEco.GetDepenseById(int.Parse(id)).aprobation == null)
                    {
                        btn_modifier.Enabled = true;
                    }
                    else
                        btn_modifier.Enabled = false;
                }
                else
                {
                    if (BD_CoEco.GetKiloById(int.Parse(id)).approbation == null)
                    {
                        btn_modifier.Enabled = true;
                    }
                    else
                        btn_modifier.Enabled = false;
                }
                
            }
            else
            {
                //on suppose que c'est un employé qui est connecté et qui veut ajouter une dépense
                string idEmp = Session["idEmp"].ToString();
                ddl_employe.SelectedValue = Session["idEmp"].ToString();
            }
        }
    }

    private void loadProjetAdm()
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

    private void loadTypeAuto()
    {
        List<T_TypeAuto> ts = BD_CoEco.GetListTypesVehicules();
        
        ts = ts.OrderBy(o => o.descript).ToList();
        foreach (T_TypeAuto auto in ts)
        {
            float taux = 0;
            if(auto.idType == 1)
            {
                taux = BD_CoEco.GetTauxKiloAuto();
            }
            else
            {
                taux = BD_CoEco.GetTauxKiloCamion();
            }
            taux *= 100;
            taux = (float)Math.Round(taux);
            taux /= 100;

            string tauxstring = string.Format("{0:c}", taux);

            ddl_typeVehicule.Items.Add(new ListItem(auto.descript + " - " + tauxstring, auto.idType.ToString()));
        }
    }

    private void afficherDepense()
    {
        ddl_projet.Enabled = false;
        //ddL_categorie.Enabled = false;
        ddl_typeDepense.Enabled = false;
        tbx_description.Enabled = false;
        tbx_description.Enabled = false;
        tbx_montant.Enabled = false;
        Ddate.Enabled = false;
        ddl_employe.Enabled = false;

        string id = Request.QueryString["id"];
        string type = Request.QueryString["Type"];

        if(type == "1")
        {
            T_Depense depense = BD_CoEco.GetDepenseById(int.Parse(id));
            ddl_projet.SelectedValue = depense.idProjet.ToString();

            //loadDdlCat();
            // ddL_categorie.SelectedValue = BD_CoEco.GetCatByID((int)depense.idCategorie).idCategorie.ToString();
            //ddL_categorie.SelectedValue = depense.idCategorie.ToString();
            ddl_typeDepense.SelectedValue = depense.idType.ToString();
            tbx_description.Text = depense.descript;
            tbx_montant.Text = depense.montant.ToString();
            Ddate.Text = string.Format("{0:yyyy-MM-dd}", depense.ddate);
            ddl_employe.SelectedValue = depense.idEmp.ToString();
        }
        else
        {
            T_Kilometrage kilo = BD_CoEco.GetKiloById(int.Parse(id));
            ddl_projet.SelectedValue = kilo.idPro.ToString();
            //loadDdlCat();
            ddl_typeDepense.SelectedValue = "-1";
            tbx_description.Text = kilo.commentaire;
            tbx_montant.Text = kilo.nbKilo.ToString();
            ddl_typeVehicule.SelectedValue = BD_CoEco.GetTauxKiloById(kilo.idTaux).idTypeAuto.ToString();
            div_KM.Visible = true;
            ddl_typeVehicule.Enabled = false;
            lbl_MontantOuKm.InnerText = "Total km";

            Ddate.Text = string.Format("{0:yyyy-MM-dd}", kilo.ddate);
            ddl_employe.SelectedValue = kilo.idEmp.ToString();
        }
    }
    
    private void loadDllProjet()
    {
        ddl_projet.Items.Clear();
        List<T_Projet> listeProjet = BD_CoEco.GetProjectByEmp(BD_CoEco.GetEmpByID(int.Parse(Session["idEmp"].ToString())));
        listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
        ddl_projet.Items.Add(new ListItem("Choisir un projet", "-1"));
        foreach (T_Projet projet in listeProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }
    //private void loadDdlCat()
    //{
    //    ddL_categorie.Items.Clear();
    //    if(ddl_projet.SelectedValue != null && ddl_projet.SelectedIndex != -1)
    //    {
    //        List<T_CategoriePro> listeCategorie = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_projet.SelectedValue)));
    //        listeCategorie = listeCategorie.OrderBy(o => o.descript).ToList();
    //        foreach (T_CategoriePro categoriePro in listeCategorie)
    //        {
    //            ddL_categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
    //        }
    //    }
        
    //}

    private void loadTypeDepense()
    {
        ddl_typeDepense.Items.Clear();
        List<T_TypeDepense> listeTypeDepense = BD_CoEco.GetListeTypeDepense();
        listeTypeDepense = listeTypeDepense.OrderBy(o => o.descript).ToList();

        foreach (T_TypeDepense typeDepense in listeTypeDepense)
        {
            ddl_typeDepense.Items.Add(new ListItem(typeDepense.descript, typeDepense.idDepense.ToString()));
        }
        ddl_typeDepense.Items.Add(new ListItem("Kilométrage", "-1"));

    }

    private void loadEmploye()
    {
        ddl_employe.Items.Clear();
        List<T_Employe> employes = BD_CoEco.GetListeEmploye();
        employes = employes.OrderBy(o => o.prenom).ThenBy(o => o.nom).ToList();
        foreach (T_Employe employe in employes)
        {
            ddl_employe.Items.Add(new ListItem(employe.prenom + " " + employe.nom, employe.idEmploye.ToString()));
        }
    }


    protected void ddl_projet_SelectedIndexChanged(object sender, EventArgs e)
    {
        //loadDdlCat();
        btn_apply.Enabled = false;
    }


    //bouton ajouter en tant qu'Admin
    protected void btn_ok_ServerClick(object sender, EventArgs e)
    {

        if(Session["fonction"].ToString() != "3")
        {
            try
            {
                if(ddl_typeDepense.SelectedValue != "-1")
                {
                    T_Depense newDep = new T_Depense();
                    newDep.montant = decimal.Parse(tbx_montant.Text);
                    newDep.descript = tbx_description.Text;
                    newDep.ddate = DateTime.Parse(Ddate.Text);
                    newDep.idType = int.Parse(ddl_typeDepense.SelectedValue);
                    newDep.idProjet = int.Parse(ddl_projet.SelectedValue);
                    newDep.idEmp = int.Parse(Session["idEmp"].ToString());
                    newDep.aprobation = null;

                    BD_CoEco.AddDepense(newDep);
                }
                else
                {
                    //Kilométrage
                    T_Kilometrage newKilo = new T_Kilometrage();
                    newKilo.nbKilo = float.Parse(tbx_montant.Text);
                    newKilo.commentaire = tbx_description.Text;
                    newKilo.ddate = DateTime.Parse(Ddate.Text);
                    newKilo.idEmp = int.Parse(Session["idEmp"].ToString());
                    newKilo.idPro = int.Parse(ddl_projet.SelectedValue);
                    newKilo.idTaux = BD_CoEco.GetIdTauxKilo(int.Parse(ddl_typeVehicule.SelectedValue));
                    BD_CoEco.AjouterDepKilometrage(newKilo);
                }
                
            }
            catch (Exception ex)
            {

            }

             Response.Redirect("DepenseEMP.aspx");
        }
        else //ajouter une dépense en tant qu'admin
        {
            if (ddl_typeDepense.SelectedValue != "-1")
            {
                T_Depense newDep = new T_Depense();
                if (tbx_montant.Text != "")
                    newDep.montant = decimal.Parse(tbx_montant.Text);
                if (tbx_description.Text != "")
                    newDep.descript = tbx_description.Text;
                if (Ddate.Text != "")
                    newDep.ddate = DateTime.Parse(Ddate.Text);
                newDep.idType = int.Parse(ddl_typeDepense.SelectedValue);
                newDep.idProjet = int.Parse(ddl_projet.SelectedValue);
                //newDep.idCategorie = int.Parse(ddL_categorie.SelectedValue);
                newDep.idEmp = int.Parse(ddl_employe.SelectedValue);
                newDep.aprobation = null;
                BD_CoEco.AddDepense(newDep);
            }
            else
            {
                //Kilométrage
                T_Kilometrage newKilo = new T_Kilometrage();
                if (tbx_montant.Text != "")
                    newKilo.nbKilo = float.Parse(tbx_montant.Text);
                if (tbx_description.Text != "")
                    newKilo.commentaire = tbx_description.Text;
                if (Ddate.Text != "")
                    newKilo.ddate = DateTime.Parse(Ddate.Text);
                newKilo.idEmp = int.Parse(ddl_employe.SelectedValue);
                //Cette partie à retirer / modifier
                newKilo.idPro = int.Parse(ddl_projet.SelectedValue);
                //newKilo.idCat = int.Parse(ddL_categorie.SelectedValue);
                newKilo.idTaux = BD_CoEco.GetIdTauxKilo(int.Parse(ddl_typeVehicule.SelectedValue));
                BD_CoEco.AjouterDepKilometrage(newKilo);
            }
            Response.Redirect("DepenseAdmin.aspx");
        }
    }


    protected void btn_cancel_ServerClick(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null || Session["fonction"].ToString() == "3")
        {
            //On est donc en admin
            Response.Redirect("DepenseAdmin.aspx");
        }
        else
        {
            //Usager régulier
            Response.Redirect("DepenseEMP.aspx");
        }
    }

    //rendre enable les champs pour modifier la dépense
    protected void btn_modifier_Click(object sender, EventArgs e)
    {
        ddl_projet.Enabled = true;
        //ddL_categorie.Enabled = true;
        ddl_typeDepense.Enabled = true;
        tbx_description.Enabled = true;
        tbx_montant.Enabled = true;
        Ddate.Enabled = true;
        ddl_employe.Enabled = true;
        btn_modifier.Enabled = false;
        btn_apply.Enabled = true;
        if(Request.QueryString["Type"].ToString() == "2")
        {
            ddl_typeVehicule.Enabled = true;
            ddl_typeDepense.Enabled = false;
        }

    }

    //appliquer la modification d'une dépense
    protected void btn_apply_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["Type"].ToString() == "1")
        {
            T_Depense newDep = new T_Depense();

            newDep.idDepense = int.Parse(Request.QueryString["id"]);
            newDep.montant = decimal.Parse(tbx_montant.Text);
            newDep.descript = tbx_description.Text;
            newDep.ddate = DateTime.Parse(Ddate.Text);
            newDep.idType = int.Parse(ddl_typeDepense.SelectedValue);
            newDep.idProjet = int.Parse(ddl_projet.SelectedValue);
            //newDep.idCategorie = int.Parse(ddL_categorie.SelectedValue);
            newDep.idEmp = int.Parse(ddl_employe.SelectedValue);
            newDep.aprobation = null;

            BD_CoEco.UpdateDepense(newDep);
        }
        else
        {
            T_Kilometrage kilo = new T_Kilometrage();
            kilo.idKilo = int.Parse(Request.QueryString["id"].ToString());
            kilo.approbation = null;
            kilo.idEmp = int.Parse(ddl_employe.SelectedValue);
            kilo.idPro = int.Parse(ddl_projet.SelectedValue);
            kilo.ddate = DateTime.Parse(Ddate.Text);
            kilo.commentaire = tbx_description.Text;
            kilo.nbKilo = float.Parse(tbx_montant.Text);
            kilo.idTaux = int.Parse(ddl_typeVehicule.SelectedValue);

            BD_CoEco.UpdateKilometrage(kilo);
        }
        

        if (Session["fonction"].ToString() != "3")
        {
            Response.Redirect("DepenseEMP.aspx");
        }
        else
        {
            Response.Redirect("DepenseAdmin.aspx");
        }
        
    }

    protected void btn_approuver_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["Type"].ToString() == "1")
        {
            T_Depense actuDep = BD_CoEco.GetDepenseById(int.Parse(Request.QueryString["id"]));
            actuDep.aprobation = true;
            BD_CoEco.UpdateDepense(actuDep);
            Response.Redirect("DepenseAdmin.aspx");
        }
        else
        {
            T_Kilometrage actuKilo = BD_CoEco.GetKiloById(int.Parse(Request.QueryString["id"]));
            actuKilo.approbation = true;
            BD_CoEco.UpdateKilometrage(actuKilo);
            Response.Redirect("DepenseAdmin.aspx");
        }
        
    }

    protected void btn_desapprouver_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Type"].ToString() == "1")
        {
            T_Depense actuDep = BD_CoEco.GetDepenseById(int.Parse(Request.QueryString["id"]));
            actuDep.aprobation = false;
            BD_CoEco.UpdateDepense(actuDep);
            Response.Redirect("DepenseAdmin.aspx");
        }
        else
        {
            T_Kilometrage actuKilo = BD_CoEco.GetKiloById(int.Parse(Request.QueryString["id"]));
            actuKilo.approbation = false;
            BD_CoEco.UpdateKilometrage(actuKilo);
            Response.Redirect("DepenseAdmin.aspx");
        }
    }

    protected void ddl_typeDepense_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Checker si le kilométrage est sélectionner
        if(ddl_typeDepense.SelectedValue == "-1")
        {
            div_KM.Visible = true;
            lbl_MontantOuKm.InnerText = "Total km";
        }
        else
        {
            div_KM.Visible = false;
            lbl_MontantOuKm.InnerText = "Montant";
        }
    }
}