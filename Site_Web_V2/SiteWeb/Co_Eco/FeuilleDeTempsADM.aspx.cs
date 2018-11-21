using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;


public partial class FeuilleDeTempsADM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //First load
            tbx_Semaine.Text = DateTime.Today.Year + "-W" + getWeek(DateTime.Today);
            load();
        }

    }

    private int getWeek(DateTime input)
    {
        //Ref : https://social.msdn.microsoft.com/Forums/vstudio/en-US/6768f963-a568-468f-a0a5-b8841e13ffcd/c-display-week-of-the-year-in-a-label?forum=winforms
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(input);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            input = input.AddDays(3);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(input, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
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
            int fdtNumSem = getWeek((DateTime)fdt.semaine);
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
        TableHeaderCell thc_Approuve = new TableHeaderCell();
        thc_Approuve.Text = "Approuvé";

        thr.Cells.Add(thc_nom);
        thr.Cells.Add(thc_Approuve);
        tab_emp.Rows.Add(thr);


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
            TableCell tc_Confirm = new TableCell();
            CheckBox cbx_confirm = new CheckBox();
            cbx_confirm.Checked = (bool)fdt[i].approbation;
            cbx_confirm.CssClass = "fdt_ADM";
            tc_Confirm.Controls.Add(cbx_confirm);
            tr.Cells.Add(tc_Confirm);
            tab_emp.Rows.Add(tr);
        }

    }


    protected void btn_App_Click(object sender, EventArgs e)
    {
        // System.Diagnostics.Debug.WriteLine(tab_emp.Rows[0].Cells[1].Controls[0]);
        load();
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    private static void enre()
    {
        System.Diagnostics.Debug.WriteLine("yay");


    }

}