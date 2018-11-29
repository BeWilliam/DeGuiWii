using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepenseEMP : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

        }
        LoadTousProjets();

        ////Session["idEmp"].ToString()

        //if (!IsPostBack)
        //{
        //    loadDepenseEmp();
        //}
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterDepenses.aspx");
    }

    private void LoadTousProjets()
    {
        pnl_Main.Controls.Clear();
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet();

        foreach (T_Projet projet in listProjet)
        {
            Panel pnl_Projet = new Panel();
            pnl_Main.Controls.Add(pnl_Projet);

            Label lbl_NomProjet = new Label();
            lbl_NomProjet.Text = "<h3>" + projet.nom + "</h3>";
            pnl_Projet.Controls.Add(lbl_NomProjet);

            Table tbTitre = new Table();
            tbTitre.CssClass = "table";
            TableHeaderRow thr = new TableHeaderRow();
            TableHeaderCell thc_nom = new TableHeaderCell();
            thc_nom.Text = "Nom";
            thc_nom.Width = new Unit("33%");
            thr.Cells.Add(thc_nom);
            TableHeaderCell thc_Montant = new TableHeaderCell();
            thc_Montant.Width = new Unit("33%");
            thc_Montant.Text = "Montant";
            thr.Cells.Add(thc_Montant);
            TableHeaderCell thc_Appr = new TableHeaderCell();
            thc_Appr.Width = new Unit("33%");
            thc_Appr.Text = "Approuvé";
            thr.Cells.Add(thc_Appr);
            tbTitre.Rows.Add(thr);
            pnl_Projet.Controls.Add(tbTitre);


            List<T_Depense> lstDep = BD_CoEco.GetListeDepense();
            foreach (T_Depense dep in lstDep)
            {
                if(dep.idProjet == projet.idProjet)
                {
                    Panel pnl_depenses = new Panel();
                    pnl_Projet.Controls.Add(pnl_depenses);

                    T_Employe emp = BD_CoEco.GetEmpByID(dep.idEmp);
                    Table tb = new Table();
                    tb.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_nom = new TableCell();
                    tc_nom.Width = new Unit("33%");
                    HyperLink hl = new HyperLink();
                    hl.Text = emp.prenom + " " + emp.nom;
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + dep.idDepense.ToString() + "&Type=1";
                    tc_nom.Controls.Add(hl);
                    tr.Cells.Add(tc_nom);
                    TableCell tc_total = new TableCell();
                    tc_total.Width = new Unit("33%");
                    float tot = (float)dep.montant;
                    tot *= 100; tot = (float)Math.Round(tot); tot /= 100;
                    tc_total.Text = string.Format("{0:c}", tot);
                    tr.Cells.Add(tc_total);

                    TableCell tc_App = new TableCell();
                    tc_App.Width = new Unit("33%");
                    Panel pnl_App = new Panel();
                    if (dep.aprobation == true)
                        pnl_App.CssClass = "fas fa-check";
                    else if (dep.aprobation == false)
                        pnl_App.CssClass = "fas fa-times";
                    else
                        pnl_App.CssClass = "fas fa-question";
                    tc_App.Controls.Add(pnl_App);
                    tr.Cells.Add(tc_App);

                    tb.Rows.Add(tr);
                    pnl_depenses.Controls.Add(tb);
                }

            }

            List<T_Kilometrage> lstKm = BD_CoEco.GetListeKilometrage();
            foreach (T_Kilometrage km in lstKm)
            {
                Panel pnl_Kilo = new Panel();
                pnl_Projet.Controls.Add(pnl_Kilo);

                if (km.idPro == projet.idProjet)
                {
                    T_Employe emp = BD_CoEco.GetEmpByID(km.idEmp);
                    Table tb = new Table();
                    tb.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_nom = new TableCell();
                    tc_nom.Width = new Unit("33%");
                    HyperLink hl = new HyperLink();
                    hl.Text = emp.prenom + " " + emp.nom;
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + km.idKilo.ToString() + "&Type=2";
                    tc_nom.Controls.Add(hl);
                    tr.Cells.Add(tc_nom);

                    TableCell tc_montant = new TableCell();
                    tc_montant.Width = new Unit("33%");
                    float total = km.nbKilo * BD_CoEco.GetTauxKiloById(km.idTaux).taux;
                    total *= 100; total = (float)Math.Round(total); total /= 100;
                    tc_montant.Text = string.Format("{0:c}", total);
                    tr.Cells.Add(tc_montant);

                    TableCell tc_appr = new TableCell();
                    tc_appr.Width = new Unit("33%");
                    Panel pnl_App = new Panel();
                    //if (km.approbation == true)
                   //     pnl_App.CssClass = "fas fa-check";
                   // else if (km.approbation == false)
                   //     pnl_App.CssClass = "fas fa-times";
                  //  else
                        pnl_App.CssClass = "fas fa-question";
                    tc_appr.Controls.Add(pnl_App);
                    tr.Cells.Add(tc_appr);

                    tb.Rows.Add(tr);
                    pnl_Kilo.Controls.Add(tb);
                }
            }
        }
    }











    //private void loadDepenseEmp()
    //{

    //    List<T_Depense> listeDepense = BD_CoEco.GetListeDepenseEmp(int.Parse(Session["idEmp"].ToString()));

    //    TableHeaderRow thr = new TableHeaderRow();
    //    TableHeaderCell thc_id = new TableHeaderCell();
    //    thc_id.Text = "#";
    //    thc_id.Width = new Unit("20%");

    //    TableHeaderCell thc_IdPro = new TableHeaderCell();
    //    thc_IdPro.Text = "Nom Projet";
    //    thc_IdPro.Width = new Unit("20%");

    //    TableHeaderCell thc_emp = new TableHeaderCell();
    //    thc_emp.Text = "Employé";
    //    thc_emp.Width = new Unit("20%");

    //    TableHeaderCell thc_montant = new TableHeaderCell();
    //    thc_montant.Text = "Montant";
    //    thc_montant.Width = new Unit("20%");

    //    TableHeaderCell thc_Autorize = new TableHeaderCell();
    //    thc_Autorize.Text = "Aprouvé";
    //    thc_Autorize.Width = new Unit("20%");


    //    thr.Cells.Add(thc_id);
    //    thr.Cells.Add(thc_IdPro);
    //    thr.Cells.Add(thc_emp);
    //    thr.Cells.Add(thc_montant);
    //    thr.Cells.Add(thc_Autorize);
    //    table_depense.Rows.Add(thr);


    //    foreach (T_Depense depense in listeDepense)
    //    {
    //        RemplirTable(depense);
    //    }
    //}

    //private void RemplirTable(T_Depense p_toAdd)
    //{
    //    TableRow tr = new TableRow();
    //    TableCell tc_id = new TableCell();
    //    tc_id.Text = p_toAdd.idDepense.ToString();
    //    TableCell tc_idpro = new TableCell();
    //    HyperLink hl = new HyperLink();
    //    hl.Text = BD_CoEco.GetProByID(p_toAdd.idProjet).nom;
    //    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + p_toAdd.idDepense.ToString();
    //    tc_idpro.Controls.Add(hl);
    //    TableCell tc_prenom = new TableCell();
    //    T_Employe employe = BD_CoEco.GetEmpByID(p_toAdd.idEmp);
    //    tc_prenom.Text = employe.prenom + " " + employe.nom;

    //    TableCell tc_montant = new TableCell();
    //    tc_montant.Text = string.Format("{0:C}", p_toAdd.montant);

    //    /*Partie de la croix*/
    //    TableCell tc_autorize = new TableCell();
    //    Panel check = new Panel();
    //    check.Width = new Unit(25, UnitType.Pixel);
    //    check.Height = new Unit(25, UnitType.Pixel);
    //    if (p_toAdd.aprobation == true)
    //        check.CssClass = "fas fa-check";
    //    else if (p_toAdd.aprobation == false)
    //        check.CssClass = "fas fa-times";
    //    else
    //        check.CssClass = "fas fa-question";

    //    tc_autorize.Controls.Add(check);


    //    tr.Cells.Add(tc_id);
    //    tr.Cells.Add(tc_idpro);
    //    tr.Cells.Add(tc_prenom);
    //    tr.Cells.Add(tc_montant);
    //    tr.Cells.Add(tc_autorize);
    //    table_depense.Rows.Add(tr);
    //}
}