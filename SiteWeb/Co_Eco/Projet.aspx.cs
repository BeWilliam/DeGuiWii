using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class Projet : System.Web.UI.Page
{
    List<T_Projet> m_ListeProjet;
    List<T_Employe> m_listEmpBureau;

    protected void Page_Load(object sender, EventArgs e)
    {
        List<T_StatusProjet> listeStatProjet = BD_CoEco.GetListeStatusProjet();
        List<T_Projet> rawListeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.ToString()).ToList();
        m_ListeProjet = listeProjet;

        loadListEmp();
       
        Tableau_Projets.Rows.Clear(); //On clean les résultats
        for (int i = 0; i < listeProjet.Count; i++)
        {
            showData(i); //On affiche tous les projets
        }


        



        if (!this.IsPostBack) //ATTENTION : Premier chargement, loader seulement les choses à faire UNE fois
        {
            List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
            
            DDL_Responsable.Items.Add("Tous");
            for (int i = 0; i < listeEmp.Count; i++)
            {
                if (listeEmp[i].idFonction == 2) //Emp Bureau
                {
                    DDL_Responsable.Items.Add(listeEmp[i].ToString()); //Changer le listBox des responsables
                }
            }
            List<T_StatusProjet> listStatsEmp = BD_CoEco.GetListeStatusProjet();
            DDL_Status.Items.Add("Tous");
            for (int i = 0; i < listeStatProjet.Count; i++)
            {
                DDL_Status.Items.Add(listeStatProjet[i].descript);
            }
        }
    }

    protected void btn_addProject_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterProjet.aspx");
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("AjouterCategorie.aspx");
    }

    protected void btn_recherche_Click(object sender, ImageClickEventArgs e)
    {
        List<int> rechercheA = new List<int>();
        List<int> rechercheB = new List<int>();
        List<int> rechercheC = new List<int>();
        List<int> rechercheD = new List<int>();


        List<T_StatusProjet> listStatsProjet = BD_CoEco.GetListeStatusProjet();

        Tableau_Projets.Rows.Clear();
        string champRech = tbx_rech.Text;
        if(champRech != "")
        {
            List<T_Projet> affList = new List<T_Projet>();
            for (int i = 0; i < m_ListeProjet.Count; i++)
            {
                if(m_ListeProjet[i].nom.ToLower().Contains(champRech.ToLower())) //Nom
                {
                    rechercheA.Add(i);
                }
            }
        }
        else
        {
            for (int i = 0; i < m_ListeProjet.Count; i++)
            {
                rechercheA.Add(i);
            }
        }
        
        //Le 0, c'est tous donc on fait pas de recherche dans ce cas
        if (DDL_Status.SelectedIndex != 0) //Status
        {
            for (int i = 0; i < m_ListeProjet.Count; i++)
            {
                string status = listStatsProjet[m_ListeProjet[i].idStatus - 1].descript;

                if (DDL_Status.SelectedValue.ToLower().Contains(listStatsProjet[m_ListeProjet[i].idStatus - 1].descript.ToLower()))
                {
                    rechercheB.Add(i);
                }
            }
        }
        else
        {
            //Donc "Tous" est sélectioné
            for (int i = 0; i < m_ListeProjet.Count; i++)
            {
                rechercheB.Add(i);
            }
        }

        if(DDL_Responsable.SelectedIndex != 0)//Responsable
        {
            for(int i = 0; i < m_ListeProjet.Count; i++)
            {
                if(m_ListeProjet[i].responsable == m_listEmpBureau[DDL_Responsable.SelectedIndex - 1].idEmploye)
                {
                    rechercheC.Add(i);
                }
            }
        }
        else
        {
            for(int i = 0; i < m_ListeProjet.Count; i++) 
            {
                rechercheC.Add(i);
            }
        }

        if(tbx_descript.Text != "")
        {
            for(int i = 0; i < m_ListeProjet.Count; i++)
            {
                string descript = m_ListeProjet[i].descript;
                if(descript != "" && descript != null)
                {
                    if (descript.ToLower().Contains(tbx_descript.Text.ToLower()))
                    {
                        rechercheD.Add(i);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < m_ListeProjet.Count; i++)
            {
                rechercheD.Add(i);
            }
        }


        //Effectuer la recherche
        for (int i = 0; i < m_ListeProjet.Count; i++)
        {
            //Tous les projets seront loader

            bool a = rechercheA.Contains(i);
            bool b = rechercheB.Contains(i);
            bool c = rechercheC.Contains(i);
            bool d = rechercheD.Contains(i);

            if(a && b && c && d)
            {
                showData(i); //On affiche les éléments présent dans les 4 listes
            }


        }


        
    }

    private void showData(int id)
    {
        
        List<T_StatusProjet> listeStatProjet = BD_CoEco.GetListeStatusProjet();
        List<T_Projet> rawListeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> listeProjet = rawListeProjet.OrderBy(o => o.ToString()).ToList();

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        HyperLink hl = new HyperLink();

        hl.NavigateUrl = "AjouterProjet.aspx"; //La solution doit venir de la.
        hl.Text = listeProjet[id].nom;
        hl.CssClass = ""; //Ajouter une class CSS au besoin
        hl.ID = "#" + id;
        tc1.Controls.Add(hl);

        TableCell tc2 = new TableCell();
        tc2.Text = listeStatProjet[listeProjet[id].idStatus - 1].descript;

        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        Tableau_Projets.Rows.Add(tr);



        //Affichage du nom des colones
        //TableHeaderRow thr = new TableHeaderRow();
        //TableHeaderCell thc1 = new TableHeaderCell();
        //TableHeaderCell thc2 = new TableHeaderCell();
        //thc1.Text = "Nom du projet";
        //thc2.Text = "Status";
        //thr.Cells.Add(thc1);
        //thr.Cells.Add(thc2);
        //Tableau_Projets.Rows.Add(thr);
    }

    private void loadListEmp()
    {
        m_listEmpBureau = new List<T_Employe>();
        List<T_Employe> lstEmp = BD_CoEco.GetListeEmploye();
        for (int i = 0; i < lstEmp.Count; i++)
        {
            if (lstEmp[i].idFonction == 2)
            {
                m_listEmpBureau.Add(lstEmp[i]);
            }
        }
    }

}