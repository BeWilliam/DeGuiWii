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
        string param = Request.QueryString["id"];
        int id = int.Parse(param);

        //tbx

    }

}