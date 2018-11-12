using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Connexion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(IsPostBack)
        //{
            Session["username"] = tbx_username.Text;
            Session["password"] = tbx_mdp.Text;
            Test.Text = Session.SessionID;
        //}
    }

    protected void Connexion_click(object sender, EventArgs e)
    {
        Session["username"] = tbx_username.Text;
        Test.Text = Session.SessionID;

        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();

        int i = -1;
        while (i < listeEmp.Count)
        {
            i++;
        }



        Response.Redirect("Menu.aspx");
    }

}