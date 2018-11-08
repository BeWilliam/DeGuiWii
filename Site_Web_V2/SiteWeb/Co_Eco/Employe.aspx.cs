using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class Employe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;
        List<T_Employe> rawListeEmp = tableEmp.ToList();
        //trié la liste avant insertion
        List<T_Employe> listeEmp = rawListeEmp.OrderBy(o => o.idStatus).ThenBy(o => o.prenom).ThenBy(o => o.nom).ToList();

        foreach (T_Employe emp in listeEmp)
        {      

            if (emp.prenom != "Admin")
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                TableCell tc2 = new TableCell();
                TableCell tc3 = new TableCell();
                TableCell tc4 = new TableCell();

                HyperLink hl = new HyperLink();
                hl.NavigateUrl = "AjouterEmploye.aspx";

                tc1.Text = emp.idEmploye.ToString();
                tc2.Text = emp.prenom;
                tc3.Text = emp.nom;
                tc4.Text = emp.idStatus.ToString();

                if (tc4.Text == "1")
                {
                    tc4.Text = "Actif";
                }
                else
                {
                    tc4.Text = "Inactif";
                }

                tr.Cells.Add(tc1);
                tr.Cells.Add(tc2);
                tr.Cells.Add(tc3);
                tr.Cells.Add(tc4);

                //Actif
                Tableau_Employes.Rows.Add(tr);
                
            }

            //hl.Text = emp.ToString();
            //hl.CssClass = "hl_employe";
            //tc3.Controls.Add(hl);



        }

        BD.Dispose();
    }


    protected void bt_AjouterEmploye_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterEmploye.aspx");
    }
}