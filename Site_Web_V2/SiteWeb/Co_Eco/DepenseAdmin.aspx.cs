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
        TableHeaderCell thc_note = new TableHeaderCell();
        thc_note.Text = "Note";
        thc_note.Width = new Unit("20%");
        TableHeaderCell thc_montant = new TableHeaderCell();
        thc_montant.Text = "Montant";
        thc_montant.Width = new Unit("20%");
        TableHeaderCell thc_Autorize = new TableHeaderCell();
        thc_Autorize.Text = "Aprouvé";
        thc_Autorize.Width = new Unit("20%");
        thr.Cells.Add(thc_id);
        thr.Cells.Add(thc_IdPro);
        thr.Cells.Add(thc_note);
        thr.Cells.Add(thc_montant);
        thr.Cells.Add(thc_Autorize);
        tableauDepense.Rows.Add(thr);

        foreach (T_Depense depense in listeDepense)
        {
            loadOneLine(depense);
        }
    }

    private void loadOneLine(T_Depense p_toAdd)
    {
        TableRow tr = new TableRow();
        TableCell tc_id = new TableCell();
        tc_id.Text = p_toAdd.idDepense.ToString();
        TableCell tc_idpro = new TableCell();
        tc_idpro.Text = BD_CoEco.GetProByID(p_toAdd.idProjet).nom;

        TableCell tc_note = new TableCell();
        if (p_toAdd.descript != null)
            tc_note.Text = p_toAdd.descript.ToString();
        else
            tc_note.Text = " - ";

        TableCell tc_montant = new TableCell();
        tc_montant.Text = string.Format("{0:C}", p_toAdd.montant);

        /*Partie de la croix*/
        TableCell tc_autorize = new TableCell();
        Button check = new Button();
        check.Text = tc_autorize.Text;
        if (tc_autorize.Text == "False")
            check.CssClass = "glyphicon glyphicon-remove";
        else
            check.CssClass = "glyphicon glyphicon-ok";

        tc_autorize.Controls.Add(check);


        tr.Cells.Add(tc_id);
        tr.Cells.Add(tc_idpro);
        tr.Cells.Add(tc_note);
        tr.Cells.Add(tc_montant);
        tr.Cells.Add(tc_autorize);
        tableauDepense.Rows.Add(tr);
    }
}