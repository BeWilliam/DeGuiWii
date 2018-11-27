using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class FeuilleDeTempsADM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //First load
            tbx_Semaine.Text = DateTime.Today.Year + "-W" + Utilitaires.GetWeek(DateTime.Today);
            load();
        }

    }


    protected void tbx_Semaine_TextChanged(object sender, EventArgs e)
    {
        load();
    }

    private void load()
    {
        List<T_Projet> lst_Pro = BD_CoEco.GetListeProjet();
        lst_Pro = lst_Pro.OrderBy(o => o.nom).ToList();

        foreach (T_Projet pro in lst_Pro)
        {
            Panel pnlPro = new Panel();
            panel_Contenu.Controls.Add(pnlPro);
            //Pour chaque projet
            Label lbl_Pro = new Label();
            lbl_Pro.Text = "<h3>" + pro.nom + "</h3>";

            pnlPro.Controls.Add(lbl_Pro); //Ajout du nom du projet

            

            List<T_CategoriePro> lst_CatPro = BD_CoEco.GetListeCategorie(pro);

            foreach (T_CategoriePro catpro in lst_CatPro)
            {
                Panel pnl_Cat = new Panel();
                pnlPro.Controls.Add(pnl_Cat);

                //Pour chaque catégorie
                Label lbl_cat = new Label();
                lbl_cat.Text = "<h6>" + catpro.descript + "</h6>";
                pnl_Cat.Controls.Add(lbl_cat);

                foreach (T_FeuilleDeTemps fdt in BD_CoEco.GetListeFeuilleDeTemps())
                {
                    //Pour chaque feuille de temps
                    
                    try
                    {
                        int annee = int.Parse(tbx_Semaine.Text.Split('-')[0]);
                        int semaine = int.Parse(tbx_Semaine.Text.Split('-')[1].Remove(0, 1));
                        if (semaine == Utilitaires.GetWeek((DateTime)fdt.semaine) && annee == fdt.semaine.Value.Year) //Si c'est la bonne semaine
                        {
                            if(catpro.idProjet == pro.idProjet) //Si c'est le bon projet
                            {
                                if (fdt.idCategorie == catpro.idCategorie) //Si c'est la bonne catégorie
                                {
                                    Panel panel_fdt = new Panel();
                                    pnl_Cat.Controls.Add(panel_fdt);
                                    Table tab = new Table();

                                    T_Employe emp = BD_CoEco.GetEmpByID(fdt.idEmp);

                                    Label lbl_emp = new Label();
                                    lbl_emp.Text = emp.prenom + " " + emp.nom;
                                    panel_fdt.Controls.Add(lbl_emp);
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {

                    }
                }

            }

            remEmptyPro(pnlPro);

        }
    }


    private void remEmptyPro(Panel p_CheckPnl)
    {
        try
        {
            if (p_CheckPnl.Controls[1].Controls.Count == 1)
            {
                panel_Contenu.Controls.Remove(p_CheckPnl);
            }
            else
            {
                //On a minimum une feuille de temps pour le projet
                for(int i = 1; i < p_CheckPnl.Controls.Count; i++)
                {
                    //p_CheckPnl.Controls[i].Controls
                    if(p_CheckPnl.Controls[i].Controls.Count == 1)
                    {
                        p_CheckPnl.Controls.Remove(p_CheckPnl.Controls[i]);
                    }
                }
            }
        }
        catch
        {
            panel_Contenu.Controls.Remove(p_CheckPnl);
        }
        
    }

    //private void remEmptyCat(Panel p_checkPnl)
    //{
    //    if(p_checkPnl.Controls.Count == 1)
    //    {
    //        pa
    //    }
    //}

}

