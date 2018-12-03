using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FDT_ConsultationAdm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Session["fonction"].ToString() != "3")
        {
            Response.Redirect("FeuilleDeTemps.aspx");
        }
        string id = Request.QueryString["idFDT"];
        if(id == null)
        {
            Response.Redirect("FeuilleDeTempsAdm.aspx");
        }

        if (!IsPostBack)
        {

        }
        loadTable(int.Parse(id));
        btn_approuver.Enabled = !(bool)BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFDT"].ToString())).approbation;
    }

    private void loadTable(int id)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(id);
        T_Employe emp = BD_CoEco.GetEmpByID(fdt.idEmp);

        TableHeaderRow thr = new TableHeaderRow();
        TableHeaderCell thc_nom = new TableHeaderCell();
        thc_nom.Width = new Unit("20%");
        thc_nom.Text = "Nom";
        thr.Cells.Add(thc_nom);
        
        TableRow tr = new TableRow();
        TableCell tc_nom = new TableCell();
        tc_nom.Text = emp.prenom + " " + emp.nom;
        tr.Cells.Add(tc_nom);

        for (int i = 0; i < 7; i++)
        {
            TableHeaderCell thc = new TableHeaderCell();
            thc.Text = Utilitaires.GetDayOfWeekName(i);
            thr.Cells.Add(thc);

            TableCell tc = new TableCell();
            TextBox tbx_heures = new TextBox();
            tbx_heures.CssClass = "form-control";
            tbx_heures.ID = "tbx_heures";
            tbx_heures.Text = Utilitaires.GetHeuresByDay(i,fdt.idFeuilleDeTemps).ToString();

            TextBox tbx_note = new TextBox();
            tbx_note.CssClass = "form-control";
            tbx_note.TextMode = TextBoxMode.MultiLine;
            tbx_note.Height = new Unit("100px");
            tbx_note.Text = Utilitaires.GetNoteByDay(i, fdt.idFeuilleDeTemps);

            tc.Controls.Add(tbx_heures);
            tc.Controls.Add(tbx_note);
            tr.Cells.Add(tc);
        }

        tab_FDT.Rows.Add(thr);
        tab_FDT.Rows.Add(tr);
    }

    protected void btn_approuver_Click(object sender, EventArgs e)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(int.Parse(Request.QueryString["idFDT"].ToString()));
        fdt.approbation = true;

        //Première row
        if(((TextBox)tab_FDT.Rows[1].Cells[1].Controls[0]).Text != "")
            fdt.dimanche = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[1].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[2].Controls[0]).Text != "")
            fdt.lundi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[2].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[3].Controls[0]).Text != "")
            fdt.mardi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[3].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[4].Controls[0]).Text != "")
            fdt.mercredi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[4].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[5].Controls[0]).Text != "")
            fdt.jeudi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[5].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[6].Controls[0]).Text != "")
            fdt.vendredi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[6].Controls[0]).Text);
        if (((TextBox)tab_FDT.Rows[1].Cells[7].Controls[0]).Text != "")
            fdt.samedi = float.Parse(((TextBox)tab_FDT.Rows[1].Cells[7].Controls[0]).Text);
        //Deuxième row
        if (((TextBox)tab_FDT.Rows[1].Cells[1].Controls[1]).Text != "")
            fdt.commentaireDimanche = ((TextBox)tab_FDT.Rows[1].Cells[1].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[2].Controls[1]).Text != "")
            fdt.commentaireLundi = ((TextBox)tab_FDT.Rows[1].Cells[2].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[3].Controls[1]).Text != "")
            fdt.commentaireMardi = ((TextBox)tab_FDT.Rows[1].Cells[3].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[4].Controls[1]).Text != "")
            fdt.commentaireMercredi = ((TextBox)tab_FDT.Rows[1].Cells[4].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[5].Controls[1]).Text != "")
            fdt.commentaireJeudi= ((TextBox)tab_FDT.Rows[1].Cells[5].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[6].Controls[1]).Text != "")
            fdt.commentaireVendredi = ((TextBox)tab_FDT.Rows[1].Cells[6].Controls[1]).Text;
        if (((TextBox)tab_FDT.Rows[1].Cells[7].Controls[1]).Text != "")
            fdt.commentaireSamedi = ((TextBox)tab_FDT.Rows[1].Cells[7].Controls[1]).Text;


        BD_CoEco.UpdateFeuilleDeTemps(fdt);
        btn_approuver.Enabled = false;
    }
}