using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ApprouveFDT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Si un usager normal rentre dans l'URL cette page, on le "kick"
        if (Session["fonction"].ToString() != "3")
        {
            Response.Redirect("Menu.aspx");
        }

        //if(!IsPostBack)
        //{
            string idFDT = Request.QueryString["idFTD"];
            if(idFDT == null || idFDT == "")
            {
                Response.Redirect("FeuilleDeTempsADM.aspx"); 
            }
            loadTable();

            T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(int.Parse(idFDT));
            if(fdt.approbation == true)
            {
                btn_app.Text = "Désapprouver";
            }
            else
            {
                btn_app.Text = "Approuver";
            }
        //}
    }

    private void loadTable()
    {
        TableHeaderRow thr = new TableHeaderRow();
        TableRow tr = new TableRow();
        string[] weekDay = new string[7];
        weekDay[0] = "Dimanche";
        weekDay[1] = "Lundi";
        weekDay[2] = "Mardi";
        weekDay[3] = "Mercredi";
        weekDay[4] = "Jeudi";
        weekDay[5] = "Vendredi";
        weekDay[6] = "Samedi";

        for (int i = 0; i < weekDay.Length; i++)
        {
            TableHeaderCell thc_day = new TableHeaderCell();
            thc_day.Text = weekDay[i];
            thc_day.Width = new Unit("14%");
            thr.Cells.Add(thc_day);
            TableCell tc_day = new TableCell();
            TextBox tbx = new TextBox();
            tbx.ID = "tbx_Day" + i;
            tbx.Text = GetTimeByDay(i).ToString();
            tbx.Width = new Unit("50%");
            tc_day.Controls.Add(tbx);
            tr.Cells.Add(tc_day);
        }
        tab_FDT.Rows.Add(thr);
        tab_FDT.Rows.Add(tr);

    }

    private float GetTimeByDay(int day)
    {
        float temps = 0;
        switch (day)
        {
            case 0:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).dimanche;
                break;
            case 1:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).lundi;
                break;
            case 2:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).mardi;
                break;
            case 3:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).mercredi;
                break;
            case 4:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).jeudi;
                break;
            case 5:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).vendredi;
                break;
            case 6:
                temps = (float)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFTD"])).samedi;
                break;
        }
        return temps;
    }

    protected void btn_app_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < 7; i++)
        {
            ((TextBox)tab_FDT.Rows[1].Cells[i].Controls[0]).Text = "TEST";
        }
    }
}