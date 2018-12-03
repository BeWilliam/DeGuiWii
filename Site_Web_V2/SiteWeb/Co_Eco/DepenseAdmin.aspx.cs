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
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
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

            float total = 0;

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
                    if (((DateTime)depense.ddate) != null)
                        tc_date.Text = String.Format("{0:d}", ((DateTime)depense.ddate));
                    else
                        tc_date.Text = "";
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

                    total += (float)depense.montant;
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

                    total += kilometrage.nbKilo * BD_CoEco.GetTauxKiloById(kilometrage.idTaux).taux;
                }

                if(pnl_projet.Controls.Count == 2)
                {
                    pnl_master.Controls.Remove(pnl_projet);
                }
            }

            Table tb = new Table();
            tb.CssClass = "table";
            TableRow tr_F = new TableRow();
            TableCell tc_emptyCell = new TableCell();
            tc_emptyCell.Width = new Unit("25%");
            tc_emptyCell.Text = "<strong>Total</strong>";
            tc_emptyCell.ColumnSpan = 2;
            tr_F.Cells.Add(tc_emptyCell);
            TableCell tc_total = new TableCell();
            tc_total.Width = new Unit("75%");
            tc_total.ColumnSpan = 2;
            tc_total.Text = string.Format("{0:c}", total);
            tr_F.Cells.Add(tc_total);
            tb.Rows.Add(tr_F);
            pnl_projet.Controls.Add(tb);

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

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterDepenses.aspx");
    }

    protected void btn_AllApp_Click(object sender, EventArgs e)
    {
        //1 = Dep, 2 = Kilo

        List<CheckBox> allControls = new List<CheckBox>();
        GetControlList<CheckBox>(Page.Controls, allControls);
        foreach (var childControl in allControls)
        {
            CheckBox cbx = ((CheckBox)childControl); //On fait apparaitre visuellement les modifs, c'est obligatoire pour une raison que j'ignore
            cbx.Checked = true;
            char[] idString = cbx.ID.ToArray();
            int type = int.Parse(idString[idString.Length - 1].ToString());

            int id = int.Parse(childControl.ID.Split('-')[1]);
            if (type == 1)
            {
                //Dep
                BD_CoEco.ApprouverDepenseByID(id, true);
            }
            else
            {
                BD_CoEco.ApprouverKilometrageById(id, true);
            }

        }
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