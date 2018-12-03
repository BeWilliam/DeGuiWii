using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BanqueHeureEmp : System.Web.UI.Page
{
    int idEmp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        HeaderTableau();
        idEmp = int.Parse(Session["idEmp"].ToString());
        T_Employe emp = BD_CoEco.GetEmpByID(idEmp);
        float nbHeures = 0;

        float maladie = 0;
        float feries = 0;
        float vacances = 0;
        float hrsAcc = 0;
        float personnel = 0;

        List<T_FeuilleDeTemps> hrs = BD_CoEco.GetListeFeuilleDeTemps();
        foreach (T_FeuilleDeTemps fdt in hrs)
        {
            if (fdt.idEmp == idEmp)
            {
                if (fdt.idCategorie == 191)
                {
                    maladie += Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
                else if (fdt.idCategorie == 192)
                {
                    feries += Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
                else if (fdt.idCategorie == 193)
                {
                    vacances += Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);

                }
                else if (fdt.idCategorie == 194)
                {
                    hrsAcc += Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
                else if (fdt.idCategorie == 255)
                {
                    personnel += Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
            }
        }

        if (emp.congesFeries != null)
        {
            ShowEmp(feries,(float)emp.congesFeries,"Heures congées fériés");
            nbHeures += (float)emp.congesFeries;
        }
        else
        {
            ShowEmp(feries, 0, "Heures congées fériés");
        }
        if (emp.congesMaladie != null)
        {
            ShowEmp(maladie, (float)emp.congesMaladie, "Heures congées maladie");
            nbHeures += (float)emp.congesMaladie;
        }
        else
        {
            ShowEmp(maladie, 0, "Heures congées maladie");
        }
        if (emp.congesPersonnels != null)
        {
            ShowEmp(personnel, (float)emp.congesPersonnels, "Heures congées Personnels");
            nbHeures += (float)emp.congesPersonnels;
        }
        else
        {
            ShowEmp(personnel, 0, "Heures congées Personnels");
        }
        if (emp.heuresAccumuleesOuSansSolde != null)
        {
            ShowEmp(hrsAcc, (float)emp.heuresAccumuleesOuSansSolde, "Heures accumulées ou sans solde");
            nbHeures += (float)emp.heuresAccumuleesOuSansSolde;
        }
        else
        {
            ShowEmp(hrsAcc, 0, "Heures accumulées ou sans solde");
        }
        if (emp.vacances != null)
        {
            ShowEmp(hrsAcc, (float)emp.vacances, "Heures vacances");
            nbHeures += (float)emp.vacances;
        }
        else
        {
            ShowEmp(hrsAcc, 0, "Heures vacances");
        }

        TableRow tr = new TableRow();
        TableCell tc_nomConge = new TableCell();

        tc_nomConge.Text = "<strong>Total</strong>";

        TableCell tc_HrsPrises = new TableCell();
        float HrsAuTotal = (maladie + feries + vacances + hrsAcc + personnel);
        tc_HrsPrises.Text = "<strong>" + HrsAuTotal.ToString() + "</strong>";


        TableCell tc_HrsTotal = new TableCell();
        
        tc_HrsTotal.Text = "<strong>" + nbHeures.ToString() + "</strong>";

        TableCell tc_HrsRestantes = new TableCell();
        tc_HrsRestantes.Text = "<strong>" + (nbHeures - HrsAuTotal).ToString() + "</strong>";

        tr.Cells.Add(tc_nomConge);
        tr.Cells.Add(tc_HrsPrises);
        tr.Cells.Add(tc_HrsTotal);
        tr.Cells.Add(tc_HrsRestantes);
        Tableau_BanqueDheures.Rows.Add(tr);

    }
    void HeaderTableau()
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc_Conges = new TableHeaderCell();
        thc_Conges.Text = "Congés";
        thc_Conges.Width = new Unit("25%");
        TableHeaderCell thc_HrsPrises = new TableHeaderCell();
        thc_HrsPrises.Text = "Heures utilisées";
        thc_HrsPrises.Width = new Unit("25%");
        TableHeaderCell thc_HrsTotal = new TableHeaderCell();
        thc_HrsTotal.Text = "Heures au total";
        thc_HrsTotal.Width = new Unit("25%");
        TableHeaderCell thc_HrsRestantes = new TableHeaderCell();
        thc_HrsRestantes.Text = "Heures restantes";
        thc_HrsRestantes.Width = new Unit("25%");

        thr.Cells.Add(thc_Conges);
        thr.Cells.Add(thc_HrsPrises);
        thr.Cells.Add(thc_HrsTotal);
        thr.Cells.Add(thc_HrsRestantes);
        thr.ID = "thr_ID";
        Tableau_BanqueDheures.Rows.Add(thr);
    }
    private void ShowEmp(float p_congesPris, float p_total, string congeRectifie)
    {
        TableRow tr = new TableRow();
        TableCell tc_nomConge = new TableCell();

        tc_nomConge.Text = congeRectifie;
        
        TableCell tc_HrsPrises = new TableCell();
        tc_HrsPrises.Text = p_congesPris.ToString();


        TableCell tc_HrsTotal = new TableCell();
        tc_HrsTotal.Text = p_total.ToString();


        TableCell tc_HrsRestantes = new TableCell();
        tc_HrsRestantes.Text = (p_total - p_congesPris).ToString();

        tr.Cells.Add(tc_nomConge);
        tr.Cells.Add(tc_HrsPrises);
        tr.Cells.Add(tc_HrsTotal);
        tr.Cells.Add(tc_HrsRestantes);
        Tableau_BanqueDheures.Rows.Add(tr);

    }

}