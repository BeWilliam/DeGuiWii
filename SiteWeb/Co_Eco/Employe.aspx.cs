using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void bt_AjouterEmploye_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjouterEmploye.aspx");
    }
}