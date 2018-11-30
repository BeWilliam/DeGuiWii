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
        if (!IsPostBack)
        {
            idEmp = int.Parse(Session["idEmp"].ToString());
        }

        T_Employe emp = BD_CoEco.GetEmpByID(idEmp);

        if (emp.congesFeries != null)
        {
            tb_congesFeriesTotal.Text = emp.congesFeries.ToString();
        }
        if (emp.congesMaladie != null)
        {
            tb_congeMaladieTotal.Text = emp.congesMaladie.ToString();
        }
        if (emp.congesPersonnels != null)
        {
            tb_congesPersonnelsTotal.Text = emp.congesPersonnels.ToString();
        }
        if (emp.heuresAccumuleesOuSansSolde != null)
        {
            tb_hrsAccTotal.Text = emp.heuresAccumuleesOuSansSolde.ToString();
        }
        if (emp.vacances != null)
        {
            tb_vacancesTotal.Text = emp.vacances.ToString();
        }

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
                if(fdt.idCategorie == 191)
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
                    hrsAcc+= Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
                else if (fdt.idCategorie == 255)
                {
                    personnel+=Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
            }
        }
        tb_congeMaladiePris.Text = maladie.ToString();
        tb_congesFeriesPris.Text = feries.ToString();
        tb_vacancesPris.Text = vacances.ToString();
        tb_hrsAccPris.Text = hrsAcc.ToString();
        tb_congesPersonnelsPris.Text = personnel.ToString();

    }

    
}