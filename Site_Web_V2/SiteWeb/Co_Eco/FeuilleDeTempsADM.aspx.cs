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
            //load();
        }
        load();
    }


    protected void tbx_Semaine_TextChanged(object sender, EventArgs e)
    {
        load();
    }

    private void load()
    {
        panel_Contenu.Controls.Clear();
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
                lbl_cat.Text = "<h5>" + catpro.descript + "</h5>";
                pnl_Cat.Controls.Add(lbl_cat);

                Table tb = new Table();
                tb.CssClass = "table";
                TableHeaderRow thr = new TableHeaderRow();
                TableHeaderCell thc_nom = new TableHeaderCell();
                thc_nom.Text = "Employé";
                thc_nom.Width = new Unit("33%");

                TableHeaderCell thc_heures = new TableHeaderCell();
                thc_heures.Text = "Heures";
                thc_heures.Width = new Unit("33%");
                TableHeaderCell thc_app = new TableHeaderCell();
                thc_app.Text = "Approuver";
                thc_app.Width = new Unit("33%");
                thr.Cells.Add(thc_nom);
                thr.Cells.Add(thc_heures);
                thr.Cells.Add(thc_app);
                tb.Rows.Add(thr);
                pnl_Cat.Controls.Add(tb);


                foreach (T_FeuilleDeTemps fdt in BD_CoEco.GetListeFeuilleDeTemps())
                {
                    //Pour chaque feuille de temps
                    if(catpro.idCategorie == pro.idProjet && fdt.idCategorie == catpro.idCategorie)
                    {
                        try
                        {
                            int annee = int.Parse(tbx_Semaine.Text.Split('-')[0]);
                            int semaine = int.Parse(tbx_Semaine.Text.Split('-')[1].Remove(0, 1));
                            if (semaine == Utilitaires.GetWeek((DateTime)fdt.semaine) && annee == fdt.semaine.Value.Year) //Si c'est la bonne semaine
                            {
                                Panel panel_fdt = new Panel();
                                pnl_Cat.Controls.Add(panel_fdt);

                                T_Employe emp = BD_CoEco.GetEmpByID(fdt.idEmp);

                                Table tab = new Table();
                                tab.CssClass = "table";
                                TableRow tr = new TableRow();

                                //Partie pour les noms
                                TableCell tc_nom = new TableCell();
                                tc_nom.Width = new Unit("33%");
                                HyperLink hl = new HyperLink();
                                hl.Text = emp.prenom + " " + emp.nom;
                                hl.NavigateUrl = "FDT_ConsultationAdm.aspx?idFDT=" + fdt.idFeuilleDeTemps.ToString();
                                tc_nom.Controls.Add(hl);
                                tr.Cells.Add(tc_nom);



                                TableCell tc_FDT = new TableCell();
                                tc_FDT.Width = new Unit("33%");
                                tc_FDT.Text = Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps).ToString();
                                tr.Cells.Add(tc_FDT);
                                TableCell tc_app = new TableCell();
                                tc_app.Width = new Unit("33%");
                                CheckBox cbx_app = new CheckBox();
                                cbx_app.AutoPostBack = true;
                                cbx_app.ID = "cbx_App-" + fdt.idFeuilleDeTemps;
                                cbx_app.Checked = (bool)fdt.approbation;
                                cbx_app.CheckedChanged += cbx_pressed;
                                tc_app.Controls.Add(cbx_app);
                                tr.Cells.Add(tc_app);


                                tab.Rows.Add(tr);
                                panel_fdt.Controls.Add(tab);
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    
                }

            }

            remEmptyPro(pnlPro);

        }
    }


    private void remEmptyPro(Panel p_CheckPnl)
    {
        int nbElements = 2;
        try
        {
            if (p_CheckPnl.Controls[1].Controls.Count == nbElements)
            {
                panel_Contenu.Controls.Remove(p_CheckPnl);
            }
            else
            {
                //On a minimum une feuille de temps pour le projet
                for(int i = 1; i < p_CheckPnl.Controls.Count; i++)
                {
                    //p_CheckPnl.Controls[i].Controls
                    if(p_CheckPnl.Controls[i].Controls.Count == nbElements)
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

    public void cbx_pressed(object sender, EventArgs e)
    {
        CheckBox cbxCheck = (CheckBox)sender;
        int idFDT = int.Parse(cbxCheck.ID.Split('-')[1]); //On get l'ID de la feuille de temps sélectionné
        //cbxCheck.Checked = true; //Va se faire check au rechargement de la page de toute façon
        appFDTById(idFDT, cbxCheck.Checked);
    }


    protected void btn_AllApp_Click(object sender, EventArgs e)
    {
        List<CheckBox> allControls = new List<CheckBox>();
        GetControlList<CheckBox>(Page.Controls, allControls);
        foreach (var childControl in allControls)
        {
            ((CheckBox)childControl).Checked = true; //On fait apparaitre visuellement les modifs, c'est obligatoire pour une raison que j'ignore
            int idFDT = int.Parse(childControl.ID.Split('-')[1]);
            appFDTById(idFDT, true);
        }
    }

    private void appFDTById(int p_idFDT, bool check)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(p_idFDT);
        fdt.approbation = check;
        BD_CoEco.UpdateFeuilleDeTemps(fdt);
    }


    //Références https://stackoverflow.com/questions/7362482/get-all-web-controls-of-a-specific-type-on-a-page
    private void GetControlList<T>(ControlCollection controlCollection, List<T> resultCollection) where T : Control
    {
        foreach (Control control in controlCollection)
        {
            //if (control.GetType() == typeof(T))
            if (control is T) // This is cleaner
                resultCollection.Add((T)control);

            if (control.HasControls())
                GetControlList(control.Controls, resultCollection);
        }
    }
}

