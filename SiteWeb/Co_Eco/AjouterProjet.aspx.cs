using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterProjet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        tbx_dateDebut.Text = DateTime.Now.Date.ToShortDateString();

        List<T_Employe> rawListeEmp = BD_CoEco.GetListeEmploye(true);
        List<T_Employe> listeEmp = rawListeEmp.OrderBy(o => o.ToString()).ToList();

        foreach (T_Employe emp in listeEmp)
        {    
            if (emp.idStatus == 1)
            {
                //Charger le drop down list
                if (emp.idFonction == 1) //Employé de bureau
                {
                    ddl_chef.Items.Add(emp.ToString());
                }

                //Charger la liste des employés
                lst_empOut.Items.Add(emp.ToString());
            }
        }
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }

    protected void btn_addCategorie_Click(object sender, ImageClickEventArgs e)
    {
        Response.Write("<script>");
        Response.Write("window.open('AjouterCategorie.aspx','_blank')");
        Response.Write("</script>");
    }

    protected void btn_annnuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }

    protected void AddEmpPro_Click(object sender, ImageClickEventArgs e)
    {
        if (lst_empOut.SelectedIndex != -1 && lst_empOut.Items.Count != 0)
        {
            lst_empIn.SelectedIndex = -1;
            int selectEmp = lst_empOut.SelectedIndex;
            lst_empIn.Items.Add(lst_empOut.Items[selectEmp]);
            lst_empOut.Items.RemoveAt(selectEmp);
            lst_empOut.SelectedIndex = -1;

            //Trouver une manière de convertir le listbox en une ligne (SANS UNE BOUCLE si possible

        }

    }
    
    protected void RemEmpPro_Click(object sender, ImageClickEventArgs e)
    {
        if (lst_empIn.SelectedIndex != -1 && lst_empIn.Items.Count != 0)
        {
            lst_empOut.SelectedIndex = -1;
            int selectEmp = lst_empIn.SelectedIndex;
            lst_empOut.Items.Add(lst_empIn.Items[selectEmp]);
            lst_empIn.Items.RemoveAt(selectEmp);
            lst_empIn.SelectedIndex = -1;
        }

    }
}