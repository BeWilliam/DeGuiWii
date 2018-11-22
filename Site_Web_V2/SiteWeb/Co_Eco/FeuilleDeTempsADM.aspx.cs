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
        string t = tbx_Semaine.Text;

        List<T_FeuilleDeTemps> toutFdt = BD_CoEco.GetListeFeuilleDeTemps();
        List<T_FeuilleDeTemps> semaineFdt = new List<T_FeuilleDeTemps>();

        int annee = int.Parse(t.Split('-')[0]);
        int semaine = int.Parse(t.Split('-')[1].Remove(0, 1));

        foreach (T_FeuilleDeTemps fdt in toutFdt)
        {
            int fdtNumSem = Utilitaires.GetWeek((DateTime)fdt.semaine);
            int fdtAnnee = ((DateTime)fdt.semaine).Year;

            if (fdtAnnee == annee && fdtNumSem == semaine)
            {
                //Il faut donc la montrer
                semaineFdt.Add(fdt);
            }
        }
        semaineFdt = semaineFdt.OrderBy(o => BD_CoEco.GetEmpByID(o.idEmp).prenom).ThenBy(o => BD_CoEco.GetEmpByID(o.idEmp).nom).ToList();
        addTable(semaineFdt);
    }

    private void addTable(List<T_FeuilleDeTemps> fdt)
    {
        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_nom = new TableHeaderCell();
        thc_nom.Text = "Nom employé";
        TableHeaderCell thc_Heures = new TableHeaderCell();
        thc_Heures.Text = "Heures";
        TableHeaderCell thc_Approuve = new TableHeaderCell();
        thc_Approuve.Text = "Approuvé";

        thr.Cells.Add(thc_nom);
        thr.Cells.Add(thc_Heures);
        thr.Cells.Add(thc_Approuve);
        tab_emp.Rows.Add(thr);

        float nbHeures = 0;

        for (int i = 0; i < fdt.Count; i++)
        {
            TableRow tr = new TableRow();
            TableCell tc_nom = new TableCell();
            T_Employe emp = BD_CoEco.GetEmpByID(fdt[i].idEmp);

            HyperLink hl = new HyperLink();
            hl.Text = emp.prenom + " " + emp.nom;
            hl.NavigateUrl = "ApprouveFDT.aspx?idFTD=" + fdt[i].idFeuilleDeTemps;
            tc_nom.Controls.Add(hl);
            tr.Cells.Add(tc_nom);
            TableCell tc_heures = new TableCell();
            tc_heures.Text = Utilitaires.GetHeureFDT(fdt[i].idFeuilleDeTemps).ToString();
            nbHeures += Utilitaires.GetHeureFDT(fdt[i].idFeuilleDeTemps);
            tr.Cells.Add(tc_heures);
            TableCell tc_Confirm = new TableCell();
            CheckBox cbx_confirm = new CheckBox();
            cbx_confirm.Checked = (bool)fdt[i].approbation;
            cbx_confirm.CssClass = "fdt_ADM";
            tc_Confirm.Controls.Add(cbx_confirm);
            tr.Cells.Add(tc_Confirm);
            tab_emp.Rows.Add(tr);
        }

        TableFooterRow tfr = new TableFooterRow();
        TableCell tcNULL = new TableCell();
        tfr.Cells.Add(tcNULL);
        TableCell tcNbH = new TableCell();
        tcNbH.Text = "Total : " + nbHeures.ToString() + "h";
        tcNbH.ColumnSpan = 2;
        tfr.Cells.Add(tcNbH);
        tab_emp.Rows.Add(tfr);
    }


    protected void btn_App_Click(object sender, EventArgs e)
    {
        // System.Diagnostics.Debug.WriteLine(tab_emp.Rows[0].Cells[1].Controls[0]);
        load();
    }

    
}