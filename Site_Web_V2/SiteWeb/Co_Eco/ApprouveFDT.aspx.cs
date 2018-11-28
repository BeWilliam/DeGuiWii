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

        T_Employe emp = BD_CoEco.GetEmpByID(BD_CoEco.GetFeuilleDeTempsById(int.Parse(idFDT)).idEmp);
        lbl_nomEmp.Text = emp.prenom + " " + emp.nom;

        DateTime ddate = (DateTime)BD_CoEco.GetFeuilleDeTempsById(int.Parse(idFDT)).semaine;
        lbl_idSem.Text = "Semaine #" + Utilitaires.GetWeek(ddate).ToString() + " de l'année " + ddate.Year.ToString();
    }

    private void loadTable()
    {
        TableHeaderRow thr = new TableHeaderRow();
        TableRow tr = new TableRow();
        

        for (int i = 0; i < 7; i++)
        {
            TableHeaderCell thc_day = new TableHeaderCell();
            thc_day.Text = Utilitaires.GetDayOfWeekName(i);
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
        int idFDT = int.Parse(Request.QueryString["idFTD"]);
        T_FeuilleDeTemps newFDT = new T_FeuilleDeTemps();
        T_FeuilleDeTemps oldFDT = BD_CoEco.GetFeuilleDeTempsById(idFDT);
        newFDT.idFeuilleDeTemps = idFDT;
        //((TextBox)tab_FDT.Rows[1].Cells[i].Controls[0]).Text = "TEST";

        newFDT.dimanche = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[0].Controls[0]).Text);
        newFDT.lundi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[1].Controls[0]).Text);
        newFDT.mardi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[2].Controls[0]).Text);
        newFDT.mercredi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[3].Controls[0]).Text);
        newFDT.jeudi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[4].Controls[0]).Text);
        newFDT.vendredi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[5].Controls[0]).Text);
        newFDT.samedi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[6].Controls[0]).Text);

        //newFDT.note = oldFDT.note;
        newFDT.semaine = oldFDT.semaine;
        newFDT.approbation = true; //à changer
        newFDT.idCategorie = oldFDT.idCategorie;
        newFDT.idEmp = oldFDT.idEmp;

        BD_CoEco.UpdateFeuilleDeTemps(newFDT);
        Response.Redirect("FeuilleDeTempsADM.aspx");

    }

    protected void btn_retour_Click(object sender, EventArgs e)
    {
        Response.Redirect("FeuilleDeTempsADM.aspx");
    }
}