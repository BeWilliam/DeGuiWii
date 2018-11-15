﻿using System;
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
            loadEmploye();

            string id = Request.QueryString["id"];
            if (id != null)
            {
                T_Depense depense = BD_CoEco.GetDepenseById(int.Parse(id));
                ddl_projet.SelectedValue = depense.idProjet.ToString();
                ddl_projet.Enabled = false;
                ddL_categorie.SelectedValue = depense.idCategorie.ToString();
                ddL_categorie.Enabled = false;
                ddl_typeDepense.SelectedValue = depense.idType.ToString();
                ddl_typeDepense.Enabled = false;    
                tbx_description.Text = depense.descript;
                tbx_description.Enabled = false;
                tbx_montant.Text = depense.montant.ToString();
                tbx_montant.Enabled = false;
                Ddate.Text = string.Format("{0:yyyy-MM-dd}", depense.ddate);
                Ddate.Enabled = false;
                ddl_employe.SelectedValue = depense.idEmp.ToString();
            }
            else
            {
                //on suppose que c'est un employé qui est connecté
                string idEmp = Session["idEmp"].ToString();
                //if (idEmp != null) //On vérifie quand même
                //{
                    ddl_employe.SelectedValue = Session["idEmp"].ToString();
                //}
            }
        }
    }
    
    private void loadDllProjet()
    {
        ddl_projet.Items.Clear();
        List<T_Projet> listeProjet = BD_CoEco.GetProjectByEmp(BD_CoEco.GetEmpByID(int.Parse(Session["idEmp"].ToString())));
        listeProjet = listeProjet.OrderBy(o => o.nom).ToList();
        foreach (T_Projet projet in listeProjet)
        {
            ddl_projet.Items.Add(new ListItem(projet.nom, projet.idProjet.ToString()));
        }
    }
    private void loadDdlCat()
    {
        ddL_categorie.Items.Clear();
        if(ddl_projet.SelectedValue != null && ddl_projet.SelectedIndex != -1)
        {
            List<T_CategoriePro> listeCategorie = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(ddl_projet.SelectedValue)));
            listeCategorie = listeCategorie.OrderBy(o => o.descript).ToList();
            foreach (T_CategoriePro categoriePro in listeCategorie)
            {
                ddL_categorie.Items.Add(new ListItem(categoriePro.descript, categoriePro.idCategorie.ToString()));
            }
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
        loadDdlCat();
    }



    protected void btn_ok_ServerClick(object sender, EventArgs e)
    {
        T_Depense newDep = new T_Depense();
        newDep.montant = decimal.Parse(tbx_montant.Text);
        newDep.descript = tbx_description.Text;
        newDep.ddate = DateTime.Parse(Ddate.Text);
        newDep.idType = int.Parse(ddl_typeDepense.SelectedValue);
        newDep.idProjet = int.Parse(ddl_projet.SelectedValue);
        newDep.idCategorie = int.Parse(ddL_categorie.SelectedValue);
        newDep.idEmp = int.Parse(Session["idEmp"].ToString());
        newDep.aprobation = null;
        BD_CoEco.AddDepense(newDep);

        Response.Redirect("AjouterDepenses.aspx");
    }

    protected void btn_cancel_ServerClick(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"];
        if (id != null)
        {
            //On est donc en admin
            Response.Redirect("DepenseAdmin.aspx");
        }
        else
        {
            //Usager régulier
        }
    }
}