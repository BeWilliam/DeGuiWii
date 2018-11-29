﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AjoutBanqueHeure : System.Web.UI.Page
{
    string idEmp;
    T_Employe emp;
    protected void Page_Load(object sender, EventArgs e)
    {

        idEmp = Request.QueryString["id"];
        emp = BD_CoEco.GetEmpByID(int.Parse(idEmp));

        if (emp.congesFeries!=null)
        {
            tb_congesFeries.Text = emp.congesFeries.ToString();
        }
        if (emp.congesMaladie != null)
        {
            tb_congesMaladie.Text = emp.congesMaladie.ToString();
        }
        if (emp.congesPersonnels != null)
        {
            tb_congesPersonnels.Text = emp.congesPersonnels.ToString();
        }
        if (emp.heuresAccumuleesOuSansSolde != null)
        {
            tb_heuresAccumuleesOuSansSolde.Text = emp.heuresAccumuleesOuSansSolde.ToString();
        }
        if (emp.vacances != null)
        {
            tb_vacances.Text = emp.vacances.ToString();
        }

    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        if (tb_congesFeries.Text != "")
        {
            emp.congesFeries = float.Parse(tb_congesFeries.Text);
        }
        else
        {
            emp.congesFeries = 0;
        }
        if (tb_congesMaladie.Text != "")
        {
            emp.congesMaladie = float.Parse(tb_congesMaladie.Text);
        }
        else
        {
            emp.congesMaladie = 0;
        }
        if (tb_congesPersonnels.Text != "")
        {
            emp.congesPersonnels = float.Parse(tb_congesPersonnels.Text);
        }
        else
        {
            emp.congesPersonnels = 0;
        }
        if (tb_heuresAccumuleesOuSansSolde.Text != "")
        {
            emp.heuresAccumuleesOuSansSolde = float.Parse(tb_heuresAccumuleesOuSansSolde.Text);
        }
        else
        {
            emp.heuresAccumuleesOuSansSolde = 0;
        }
        if (tb_vacances.Text != "")
        {
            emp.vacances = float.Parse(tb_vacances.Text);
        }
        else
        {
            emp.vacances = 0;
        }

        BD_CoEco.UpdateEmploye(emp);
        Response.Redirect("BanqueHeureAdmin.aspx");
    }

    protected void btn_annuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("BanqueHeureAdmin.aspx");
    }
}