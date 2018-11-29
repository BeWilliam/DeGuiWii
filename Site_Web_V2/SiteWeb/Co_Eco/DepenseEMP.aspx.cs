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
        LoadTousProjets();
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterDepenses.aspx");
    }

    private void LoadTousProjets()
    {
        pnl_Main.Controls.Clear();
        List<T_Projet> listProjet = BD_CoEco.GetListeProjet();
        listProjet = listProjet.OrderBy(o => o.nom).ToList();

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
            thc_nom.Text = "Date";
            thc_nom.Width = new Unit("25%");
            thr.Cells.Add(thc_nom);
            TableHeaderCell thc_note = new TableHeaderCell();
            thc_note.Text = "Note";
            thc_note.Width = new Unit("25%");
            thr.Cells.Add(thc_note);
            TableHeaderCell thc_Montant = new TableHeaderCell();
            thc_Montant.Width = new Unit("25%");
            thc_Montant.Text = "Montant";
            thr.Cells.Add(thc_Montant);
            TableHeaderCell thc_Appr = new TableHeaderCell();
            thc_Appr.Width = new Unit("25%");
            thc_Appr.Text = "Approuvé";
            thr.Cells.Add(thc_Appr);
            tbTitre.Rows.Add(thr);
            pnl_Projet.Controls.Add(tbTitre);


            List<T_Depense> lstDep = BD_CoEco.GetListeDepense();
            foreach (T_Depense dep in lstDep)
            {
                if(dep.idProjet == projet.idProjet && dep.idEmp == int.Parse(Session["idEmp"].ToString()))
                {
                    Panel pnl_depenses = new Panel();
                    pnl_Projet.Controls.Add(pnl_depenses);

                    T_Employe emp = BD_CoEco.GetEmpByID(dep.idEmp);
                    Table tb = new Table();
                    tb.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_date = new TableCell();
                    tc_date.Width = new Unit("25%");
                    HyperLink hl = new HyperLink();
                    if (dep.ddate == null)
                        hl.Text = " - ";
                    else
                        hl.Text = string.Format("{0:d}", dep.ddate);
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + dep.idDepense.ToString() + "&Type=1";
                    tc_date.Controls.Add(hl);
                    tr.Cells.Add(tc_date);

                    TableCell tc_commentaire = new TableCell();
                    tc_commentaire.Width = new Unit("25%");
                    if (dep.descript == null || dep.descript == "")
                        tc_commentaire.Text = " - ";
                    else
                        tc_commentaire.Text = dep.descript;
                    tr.Cells.Add(tc_commentaire);

                    TableCell tc_total = new TableCell();
                    tc_total.Width = new Unit("25%");
                    float tot = (float)dep.montant;
                    tot *= 100; tot = (float)Math.Round(tot); tot /= 100;
                    tc_total.Text = string.Format("{0:c}", tot);
                    tr.Cells.Add(tc_total);

                    TableCell tc_App = new TableCell();
                    tc_App.Width = new Unit("25%");
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
                if (km.idPro == projet.idProjet && km.idEmp == int.Parse(Session["idEmp"].ToString()))
                {
                    Panel pnl_Kilo = new Panel();
                    pnl_Projet.Controls.Add(pnl_Kilo);

                    pnl_Projet.CssClass = "Test";
                    T_Employe emp = BD_CoEco.GetEmpByID(km.idEmp);
                    Table tb = new Table();
                    tb.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_date = new TableCell();
                    tc_date.Width = new Unit("25%");
                    HyperLink hl = new HyperLink();
                    if (km.ddate == null)
                        hl.Text = "-";
                    else
                        hl.Text = string.Format("{0:d}", km.ddate);
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + km.idKilo.ToString() + "&Type=2";
                    tc_date.Controls.Add(hl);
                    tr.Cells.Add(tc_date);

                    TableCell tc_commentaire = new TableCell();
                    tc_commentaire.Width = new Unit("25%");
                    if (km.commentaire == null || km.commentaire == "")
                        tc_commentaire.Text = "-";
                    else
                        tc_commentaire.Text = km.commentaire;
                    tr.Cells.Add(tc_commentaire);

                    TableCell tc_montant = new TableCell();
                    tc_montant.Width = new Unit("25%");
                    float total = km.nbKilo * BD_CoEco.GetTauxKiloById(km.idTaux).taux;
                    total *= 100; total = (float)Math.Round(total); total /= 100;
                    tc_montant.Text = string.Format("{0:c}", total);
                    tr.Cells.Add(tc_montant);

                    TableCell tc_appr = new TableCell();
                    tc_appr.Width = new Unit("25%");
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

            if(pnl_Projet.Controls.Count <= 2)
            {
                pnl_Main.Controls.Remove(pnl_Projet);
            }
        }
    }
}