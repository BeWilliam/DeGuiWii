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
        
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmploye = BD.T_Employe;
        List<T_Employe> listeEmp = tableEmploye.ToList();

        foreach(T_Employe emp in listeEmp)
        {
            //Charger le drop down list
            ddl_chef.Items.Add(emp.ToString());
            //Charger la liste des employés
            lst_empOut.Items.Add(emp.ToString());
        }
        BD.Dispose();
    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }


    protected void AddEmpPro_Click(object sender, ImageClickEventArgs e)
    {
        if(lst_empOut.SelectedIndex != -1)
        {
            lst_empIn.SelectedIndex = -1;
            int selectEmp = lst_empOut.SelectedIndex;
            lst_empIn.Items.Add(lst_empOut.Items[selectEmp]);
            lst_empOut.Items.RemoveAt(selectEmp);
            lst_empOut.SelectedIndex = -1;
        }
        
    }
}