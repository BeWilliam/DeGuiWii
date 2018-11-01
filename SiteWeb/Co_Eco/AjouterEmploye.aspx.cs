using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterEmploye : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void bt_annuler_Click(object sender, EventArgs e)
    {
        Response.Redirect("Employe.aspx");
    }

    protected void bt_ajouter_Click(object sender, EventArgs e)
    {
        //ajouter un employé

        //connexion à la BD
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;

        int fonction = 0;

        if (ddl_fonction.SelectedValue == "Employé de bureau")
        {
            fonction = 1;
        }
        if (ddl_fonction.SelectedValue == "Employé de terrain")
        {
            fonction = 2;
        }
        if (ddl_fonction.SelectedValue == "Administrateur")
        {
            fonction = 3;
        }

        T_Employe newEmp = new T_Employe();
        newEmp.prenom = tb_prenom.Text;
        newEmp.nom = tb_nom.Text;
        newEmp.courriel = tb_courriel.Text;
        newEmp.idStatus = 1;
        newEmp.idFonction = fonction;  

        //1 bureau
        //2 terrain
        //3 admin


        Response.Redirect("Employe.aspx");
    }
}