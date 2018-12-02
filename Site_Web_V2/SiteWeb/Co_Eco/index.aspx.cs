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
        Session["username"] = tbx_username.Text;
        Session["password"] = tbx_mdp.Text;
        message_erreur.Visible = false;
    }

    protected void Connexion_click(object sender, EventArgs e)
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();

        if(tbx_username.Text != null && tbx_username.Text != "")
        {
            int i = 0;
            bool trouve = false;
            while (!trouve && i < listeEmp.Count) //Peut planter si 0 employé
            {
                if (listeEmp[i].loginName == tbx_username.Text)
                {
                    trouve = true;
                }
                if(!trouve)
                    i++;
            }
            if (trouve)
            {
                if(listeEmp[i].mdp == null)
                {
                    if(tbx_mdp.Text == "")
                    {
                        //Alors on co
                        Connect(BD_CoEco.GetEmpByID(listeEmp[i].idEmploye));
                    }
                    else
                    {
                        tbx_mdp.Text = "";
                        tbx_username.Text = "";
                    }
                }
                else
                {
                    //Il y a un mot de passe
                    if(listeEmp[i].mdp == tbx_mdp.Text)
                    {
                        //Alors on co
                        Connect(BD_CoEco.GetEmpByID(listeEmp[i].idEmploye));
                    }
                    else 
                    {
                        tbx_mdp.Text = "";
                        tbx_username.Text = "";
                        

                    }
                }
            }
            else //si l'usager n'est pas trouvé
            {
                tbx_mdp.Text = "";
                tbx_username.Text = "";
                message_erreur.Visible = true;
            }
        }
    }

    private void Connect(T_Employe employe)
    {
        Session["username"] = employe.loginName;
        Session["password"] = employe.mdp;
        Session["fonction"] = employe.idFonction;
        Session["idEmp"] = employe.idEmploye;

        if (employe.idFonction != 3)
            Response.Redirect("FeuilleDeTemps.aspx");
        else
            Response.Redirect("FeuilleDeTempsADM.aspx");
    }
}