using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Options : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        if (Session["fonction"].ToString() == "3")
        {
            if (!IsPostBack)
            {
                tbx_TauxAuto.Text = string.Format("{0:c}", BD_CoEco.GetTauxKiloAuto());
                tbx_TauxCamion.Text = string.Format("{0:c}", BD_CoEco.GetTauxKiloCamion());
                tbx_TauxAuto.Enabled = false;
                tbx_TauxCamion.Enabled = false;
            }
        }
        else
        {
            //PAS LOGIN EN ADMIN, ON KICK
            Response.Redirect("FeuilleDeTemps.aspx");
        }
        
    }

    protected void btn_ModTauxAuto_Click(object sender, EventArgs e)
    {
        //Modifier le taux Auto
        if(btn_ModTauxAuto.Text == "Modifier")
        {
            tbx_TauxAuto.Enabled = true;
            btn_ModTauxAuto.Text = "Enregistrer";
        }
        else
        {
            tbx_TauxAuto.Enabled = false;
            btn_ModTauxAuto.Text = "Modifier";
            //Enregistrer le tout
            string text = tbx_TauxAuto.Text;
            text = text.Trim(' ', '$');

            BD_CoEco.AddTauxKilo(float.Parse(text), 1);
        }
    }

    protected void btn_ModTauxCamion_Click(object sender, EventArgs e)
    {
        //Modifier le taux camion
        if (btn_ModTauxCamion.Text == "Modifier")
        {
            tbx_TauxCamion.Enabled = true;
            btn_ModTauxCamion.Text = "Enregistrer";
        }
        else
        {
            tbx_TauxCamion.Enabled = false;
            btn_ModTauxCamion.Text = "Modifier";
            //Enregistrer le tout
            string text = tbx_TauxCamion.Text;
            text = text.Trim(' ', '$');

            BD_CoEco.AddTauxKilo(float.Parse(text), 2);
        }
    }
}