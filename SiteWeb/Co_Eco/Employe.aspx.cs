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
        List<T_Employe> listeEmp = rawListeEmp.OrderBy(o => o.ToString()).ToList();

        foreach (T_Employe emp in listeEmp)
        {
            TableRow tr = new TableRow();
            TableCell tc = new TableCell();

            HyperLink hl = new HyperLink();
            hl.NavigateUrl = "AjouterEmploye.aspx";
            hl.Text = emp.ToString();
            hl.CssClass = "hl_employe";
            tc.Controls.Add(hl);
            
            tr.Cells.Add(tc);

            if (emp.idStatus == 1)
            {
                //Actif
                EmpActif.Rows.Add(tr);
            }
            else
            {
                //Inactif
                EmpInactif.Rows.Add(tr);
            }
        }

        BD.Dispose();
    }


    protected void bt_AjouterEmploye_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterEmploye.aspx");
    }
}