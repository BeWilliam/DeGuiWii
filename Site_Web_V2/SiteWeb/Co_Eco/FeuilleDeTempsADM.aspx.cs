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

        List<T_Projet> lstPro = BD_CoEco.GetListeProjet();
        foreach (T_Projet projet in lstPro)
        {
            int nbCatCount = 0;
            if (BD_CoEco.GetFDTByProject(projet.idProjet).Count != 0)
            {
                Panel pnl_projet = new Panel();
                panel_Contenu.Controls.Add(pnl_projet);

                Label lbl_projet = new Label();
                lbl_projet.Text = "<h3>" + projet.nom + "</h3>";
                pnl_projet.Controls.Add(lbl_projet);

                List<T_CategoriePro> lstCat = BD_CoEco.GetListeCategorie(projet);
                foreach (T_CategoriePro categorie in lstCat)
                {
                    Panel pnl_categorie = new Panel();
                    pnl_projet.Controls.Add(pnl_categorie);

                    Label lbl_categorie = new Label();
                    lbl_categorie.Text = "<h5>" + categorie.descript + "</h5>";
                    pnl_categorie.Controls.Add(lbl_categorie);

                    Table tb = new Table();
                    tb.CssClass = "table";
                    TableHeaderRow thr = new TableHeaderRow();
                    TableHeaderCell thc_emp = new TableHeaderCell();
                    thc_emp.Width = new Unit("33%");
                    thc_emp.Text = "Employé";
                    thr.Cells.Add(thc_emp);
                    TableHeaderCell thc_heures = new TableHeaderCell();
                    thc_heures.Text = "Heures";
                    thc_heures.Width = new Unit("33%");
                    thr.Cells.Add(thc_heures);
                    TableHeaderCell thc_app = new TableHeaderCell();
                    thc_app.Text = "Approuver";
                    thr.Cells.Add(thc_app);
                    thc_app.Width = new Unit("33%");
                    tb.Rows.Add(thr);
                    pnl_categorie.Controls.Add(tb);

                    List<T_FeuilleDeTemps> lstFdt = BD_CoEco.GetFDTByProject(projet.idProjet);

                    int fdtCount = 0;
                    float heuresTot = 0;
                    foreach (T_FeuilleDeTemps feuilleDeTemps in lstFdt)
                    {
                        int annee = int.Parse(tbx_Semaine.Text.Split('-')[0]);
                        int semaine = int.Parse(tbx_Semaine.Text.Split('-')[1].Remove(0, 1));
                        if (feuilleDeTemps.idCategorie == categorie.idCategorie && semaine == Utilitaires.GetWeek((DateTime)feuilleDeTemps.semaine) && annee == feuilleDeTemps.semaine.Value.Year)
                        {
                            fdtCount++;
                            nbCatCount++;
                            Panel panel_fdt = new Panel();
                            pnl_categorie.Controls.Add(panel_fdt);

                            T_Employe emp = BD_CoEco.GetEmpByID(feuilleDeTemps.idEmp);

                            Table tab = new Table();
                            tab.CssClass = "table";
                            TableRow tr = new TableRow();

                            //Partie pour les noms
                            TableCell tc_nom = new TableCell();
                            tc_nom.Width = new Unit("33%");
                            HyperLink hl = new HyperLink();
                            hl.Text = emp.prenom + " " + emp.nom;
                            hl.NavigateUrl = "FDT_ConsultationAdm.aspx?idFDT=" + feuilleDeTemps.idFeuilleDeTemps.ToString();
                            tc_nom.Controls.Add(hl);
                            tr.Cells.Add(tc_nom);



                            TableCell tc_FDT = new TableCell();
                            tc_FDT.Width = new Unit("33%");
                            tc_FDT.Text = Utilitaires.GetHeureFDT(feuilleDeTemps.idFeuilleDeTemps).ToString();
                            tr.Cells.Add(tc_FDT);

                            heuresTot += Utilitaires.GetHeureFDT(feuilleDeTemps.idFeuilleDeTemps);

                            TableCell tc_app = new TableCell();
                            tc_app.Width = new Unit("33%");
                            CheckBox cbx_app = new CheckBox();
                            cbx_app.AutoPostBack = true;
                            cbx_app.ID = "cbx_App-" + feuilleDeTemps.idFeuilleDeTemps;
                            cbx_app.Checked = (bool)feuilleDeTemps.approbation;
                            cbx_app.CheckedChanged += cbx_pressed;
                            tc_app.Controls.Add(cbx_app);
                            tr.Cells.Add(tc_app);


                            tab.Rows.Add(tr);
                            panel_fdt.Controls.Add(tab);
                        }
                    }

                    if(fdtCount == 0)
                    {
                        pnl_projet.Controls.Remove(pnl_categorie);
                    }
                    else
                    {
                        //Ajouter total
                        Table tb_footer = new Table();
                        tb_footer.CssClass = "table";
                        TableFooterRow tfr = new TableFooterRow();
                        TableCell tc_titre = new TableCell();
                        tc_titre.Width = new Unit("33%");
                        tc_titre.Text = "<strong>Total</strong>";
                        tfr.Cells.Add(tc_titre);
                        TableCell tc_total = new TableCell();
                        tc_total.Width = new Unit("33%");
                        tc_total.ColumnSpan = 2;
                        tc_total.Text = "<strong>" + heuresTot.ToString() + "</strong>";
                        tfr.Cells.Add(tc_total);
                        TableCell tc_vide = new TableCell();
                        tc_vide.Width = new Unit("33%");
                        tc_vide.Text = "";
                        tfr.Cells.Add(tc_vide);
                        tb_footer.Rows.Add(tfr);
                        pnl_categorie.Controls.Add(tb_footer);
                    }
                }
                if (nbCatCount == 0)
                {
                    panel_Contenu.Controls.Remove(pnl_projet);
                }
            }
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

