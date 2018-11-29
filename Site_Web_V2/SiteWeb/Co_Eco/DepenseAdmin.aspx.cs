using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DepenseAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //Au premier chargement
            //loadDepense();
        }
        load();
    }

    private void load()
    {
        List<T_Projet> lstProjet = BD_CoEco.GetListeProjet();
        lstProjet = lstProjet.OrderBy(o => o.descript).ToList();

        List<T_Depense> lstDep = BD_CoEco.GetListeDepense();
        List<T_Kilometrage> lstKm = BD_CoEco.GetListeKilometrage();

        foreach (T_Projet projet in lstProjet)
        {
            Panel pnl_projet = new Panel();
            pnl_master.Controls.Add(pnl_projet);

            Label lbl_NomProjet = new Label();
            lbl_NomProjet.Text = "<h3>" + projet.nom + "</h3>";
            pnl_projet.Controls.Add(lbl_NomProjet);

            Table tbHeader = new Table();
            tbHeader.CssClass = "table";
            TableHeaderRow thr = new TableHeaderRow();
            TableHeaderCell thc_Emp = new TableHeaderCell();
            thc_Emp.Text = "Employé";
            thc_Emp.Width = new Unit("25%");
            thr.Cells.Add(thc_Emp);
            TableHeaderCell thc_date = new TableHeaderCell();
            thc_date.Text = "Date";
            thc_date.Width = new Unit("25%");
            thr.Cells.Add(thc_date);
            TableHeaderCell thc_montant = new TableHeaderCell();
            thc_montant.Text = "Montant";
            thc_montant.Width = new Unit("25%");
            thr.Cells.Add(thc_montant);
            TableHeaderCell thc_app = new TableHeaderCell();
            thc_app.Text = "Approuvé";
            thc_app.Width = new Unit("25%");
            thr.Cells.Add(thc_app);
            tbHeader.Rows.Add(thr);
            pnl_projet.Controls.Add(tbHeader);

            foreach (T_Depense depense in lstDep)
            {
                if(depense.idProjet == projet.idProjet)
                {
                    Panel pnl_dep = new Panel();
                    pnl_projet.Controls.Add(pnl_dep);

                    T_Employe emp = BD_CoEco.GetEmpByID(depense.idEmp);

                    Table tbRow = new Table();
                    tbRow.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_nom = new TableCell();
                    HyperLink hl = new HyperLink();
                    hl.Width = new Unit("25%");
                    hl.Text = emp.prenom + " " + emp.nom;
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + depense.idDepense + "&Type=1";
                    tc_nom.Controls.Add(hl);
                    tr.Cells.Add(tc_nom);
                    TableCell tc_date = new TableCell();
                    tc_date.Text = String.Format("{0:d}", ((DateTime)depense.ddate));
                    tc_date.Width = new Unit("25%");
                    tr.Cells.Add(tc_date);
                    TableCell tc_montant = new TableCell();
                    float tot = (float)depense.montant * 100; tot = (float)Math.Round(tot); tot /= 100;
                    tc_montant.Text = string.Format("{0:c}", tot);
                    tc_montant.Width = new Unit("25%");
                    tr.Cells.Add(tc_montant);
                    TableCell tc_app = new TableCell();
                    tc_app.Width = new Unit("25%");
                    CheckBox cbx_app = new CheckBox();
                    cbx_app.CheckedChanged += ApprouverDep;
                    cbx_app.AutoPostBack = true;
                    cbx_app.ID = "cbx_app-" + depense.idDepense + "-1";
                    if (depense.aprobation == null)
                        cbx_app.Checked = false;
                    else
                        cbx_app.Checked = (bool)depense.aprobation;
                    tc_app.Controls.Add(cbx_app);
                    tr.Cells.Add(tc_app);
                    tbRow.Rows.Add(tr);
                    pnl_dep.Controls.Add(tbRow);
                }
            }

            foreach (T_Kilometrage kilometrage in lstKm)
            {
                if(kilometrage.idPro == projet.idProjet)
                {
                    Panel pnl_kilo = new Panel();
                    pnl_projet.Controls.Add(pnl_kilo);

                    T_Employe emp = BD_CoEco.GetEmpByID(kilometrage.idEmp);

                    Table tbrow = new Table();
                    tbrow.CssClass = "table";
                    TableRow tr = new TableRow();
                    TableCell tc_emp = new TableCell();
                    HyperLink hl = new HyperLink();
                    hl.Text = emp.prenom + " " + emp.nom;
                    hl.NavigateUrl = "AjouterDepenses.aspx?id=" + kilometrage.idKilo + "&Type=2";
                    tc_emp.Width = new Unit("25%");
                    tc_emp.Controls.Add(hl);
                    tr.Cells.Add(tc_emp);
                    TableCell tc_date = new TableCell();
                    tc_date.Text = string.Format("{0:d}", kilometrage.ddate);
                    tc_date.Width = new Unit("25%");
                    tr.Cells.Add(tc_date);
                    TableCell tc_montant = new TableCell();
                    tc_montant.Width = new Unit("25%");
                    float tot = kilometrage.nbKilo * BD_CoEco.GetTauxKiloById(kilometrage.idTaux).taux;
                    tot *= 100; tot = (float)Math.Round(tot); tot /= 100;
                    tc_montant.Text = string.Format("{0:c}", tot);
                    tr.Cells.Add(tc_montant);
                    TableCell tc_app = new TableCell();
                    CheckBox cbx_app = new CheckBox();
                    cbx_app.CheckedChanged += ApprouverDep;
                    cbx_app.AutoPostBack = true;
                    cbx_app.ID = "cbx_app-" + kilometrage.idKilo + "-2";
                    if (kilometrage.approbation == null)
                        cbx_app.Checked = false;
                    else
                        cbx_app.Checked = (bool)kilometrage.approbation;
                    tc_app.Controls.Add(cbx_app);
                    tr.Cells.Add(tc_app);
                    tbHeader.Rows.Add(tr);
                    pnl_kilo.Controls.Add(tbrow);
                }

                if(pnl_projet.Controls.Count == 2)
                {
                    pnl_master.Controls.Remove(pnl_projet);
                }
            }

        }

    }


    public void ApprouverDep(object sender, EventArgs e)
    {
        CheckBox cbx_toApp = (CheckBox)sender;
        int id = int.Parse(cbx_toApp.ID.Split('-')[1]);
        int type = int.Parse(cbx_toApp.ID.Split('-')[2]);

        if(type == 1)
        {
            //Depense
            T_Depense dep = BD_CoEco.GetDepenseById(id);
            dep.aprobation = cbx_toApp.Checked;
            BD_CoEco.UpdateDepense(dep);
        }
        else
        {
            T_Kilometrage kilo = BD_CoEco.GetKiloById(id);
            kilo.approbation = cbx_toApp.Checked;
            BD_CoEco.UpdateKilometrage(kilo);
        }
    }









    //private void loadDepense()
    //{
    //    List<T_Depense> listeDepense = BD_CoEco.GetListeDepense();

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
    //    tableauDepense.Rows.Add(thr);

    //    decimal total = 0;
    //    foreach (T_Depense depense in listeDepense)
    //    {
    //        loadOneLine(depense);
    //        total += (decimal)depense.montant;
    //    }

    //    TableFooterRow tfr = new TableFooterRow();
    //    TableCell tc_empty = new TableCell();
    //    tc_empty.ColumnSpan = 3;
    //    TableCell tc_total = new TableCell();
    //    tc_total.ColumnSpan = 2;
    //    tc_total.Text = "Total : " + string.Format("{0:C}", total);
    //    tfr.Cells.Add(tc_empty);
    //    tfr.Cells.Add(tc_total);
    //    tableauDepense.Rows.Add(tfr);
    //}

    //private void loadOneLine(T_Depense p_toAdd)
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
    //    tableauDepense.Rows.Add(tr);
    //}

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterDepenses.aspx");
    }
}