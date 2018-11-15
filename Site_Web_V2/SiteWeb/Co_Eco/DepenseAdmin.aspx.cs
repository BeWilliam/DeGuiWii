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
            loadDepense();
        }
    }

    private void loadDepense()
    {
        List<T_Depense> listeDepense = BD_CoEco.GetListeDepense();

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_id = new TableHeaderCell();
        thc_id.Text = "#";
        thc_id.Width = new Unit("20%");
        TableHeaderCell thc_IdPro = new TableHeaderCell();
        thc_IdPro.Text = "Nom Projet";
        thc_IdPro.Width = new Unit("20%");
        TableHeaderCell thc_emp = new TableHeaderCell();
        thc_emp.Text = "Employé";
        thc_emp.Width = new Unit("20%");
        TableHeaderCell thc_montant = new TableHeaderCell();
        thc_montant.Text = "Montant";
        thc_montant.Width = new Unit("20%");
        TableHeaderCell thc_Autorize = new TableHeaderCell();
        thc_Autorize.Text = "Aprouvé";
        thc_Autorize.Width = new Unit("20%");
        thr.Cells.Add(thc_id);
        thr.Cells.Add(thc_IdPro);
        thr.Cells.Add(thc_emp);
        thr.Cells.Add(thc_montant);
        thr.Cells.Add(thc_Autorize);
        tableauDepense.Rows.Add(thr);

        decimal total = 0;
        foreach (T_Depense depense in listeDepense)
        {
            loadOneLine(depense);
            total += (decimal)depense.montant;
        }

        TableFooterRow tfr = new TableFooterRow();
        TableCell tc_empty = new TableCell();
        tc_empty.ColumnSpan = 3;
        TableCell tc_total = new TableCell();
        tc_total.ColumnSpan = 2;
        tc_total.Text = "Total : " + string.Format("{0:C}", total);
        tfr.Cells.Add(tc_empty);
        tfr.Cells.Add(tc_total);
        tableauDepense.Rows.Add(tfr);
    }

    private void loadOneLine(T_Depense p_toAdd)
    {
        TableRow tr = new TableRow();
        TableCell tc_id = new TableCell();
        tc_id.Text = p_toAdd.idDepense.ToString();
        TableCell tc_idpro = new TableCell();
        HyperLink hl = new HyperLink();
        hl.Text = BD_CoEco.GetProByID(p_toAdd.idProjet).nom;
        hl.NavigateUrl = "AjouterDepenses.aspx?id=" + p_toAdd.idDepense.ToString();
        tc_idpro.Controls.Add(hl);
        TableCell tc_prenom = new TableCell();
        T_Employe employe = BD_CoEco.GetEmpByID(p_toAdd.idEmp);
        tc_prenom.Text = employe.prenom + " " + employe.nom;

        TableCell tc_montant = new TableCell();
        tc_montant.Text = string.Format("{0:C}", p_toAdd.montant);

        /*Partie de la croix*/
        TableCell tc_autorize = new TableCell();
        Image check = new Image();
        check.Width = new Unit(25, UnitType.Pixel);
        check.Height = new Unit(25, UnitType.Pixel);
        if (p_toAdd.aprobation == true)
            check.ImageUrl = @"~/App_Themes/Depenses/Images/ok.png";
        else if (p_toAdd.aprobation == false)
            check.ImageUrl = @"~/App_Themes/Depenses/Images/remove.png";
        else
            check.ImageUrl = @"~/App_Themes/Depenses/Images/no.png";

        tc_autorize.Controls.Add(check);


        tr.Cells.Add(tc_id);
        tr.Cells.Add(tc_idpro);
        tr.Cells.Add(tc_prenom);
        tr.Cells.Add(tc_montant);
        tr.Cells.Add(tc_autorize);
        tableauDepense.Rows.Add(tr);
    }
}