using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depense : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DDL_TypeDepense.Items.Clear();
        List<T_TypeDepense> typeDepense = BD_CoEco.GetListeTypeDepense();
        foreach(T_TypeDepense type in typeDepense)
        {
            DDL_TypeDepense.Items.Add(type.ToString());
        }
    }
}