using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class FeuilleDeTemps : System.Web.UI.Page
{

    TableHeaderRow thr;
    List<T_FeuilleDeTemps> listeFeuilleDeTemps;

    List<T_CategoriePro> ListeCategorie;
    List<T_CategoriePro> ListeCatGlobal;
    List<T_Projet> projetsGlobal;
    DateTime date;
    int idCat;
    string urlParamId;

    int idEmp; 

    float totDim;
    float totLun;
    float totMar;
    float totMer;
    float totJeu;
    float totVen;
    float totSam;

    protected void Page_Load(object sender, EventArgs e)
    {

        CoEco_BDDataContext BD = new CoEco_BDDataContext();

        ListeCatGlobal = BD_CoEco.GetListeCategorie();
        projetsGlobal = BD_CoEco.GetListeProjet();
        listeFeuilleDeTemps = BD_CoEco.GetListeFeuilleDeTemps();
        
        BD.Dispose();
        idEmp = int.Parse(Session["idEmp"].ToString());
        if (!IsPostBack)
        {
            //tbx_Semaine.Text = DateTime.Today.Year + "-W" + Utilitaires.GetWeek(DateTime.Today);
        }
        else
        {
            

        }
    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        date = DateTime.ParseExact(tbx_Semaine.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        date = getFirstDayOfWeek(date);
        Dimanche.Text = "Dimanche " + (date.Day);
            Lundi.Text = "Lundi " + (date.AddDays(1).Day);
            Mardi.Text = "Mardi " + (date.AddDays(2).Day);
            Mercredi.Text = "Mercredi " + (date.AddDays(3).Day);
            Jeudi.Text = "Jeudi " + (date.AddDays(4).Day);
            Vendredi.Text = "Vendredi " + (date.AddDays(5).Day);
            Samedi.Text = "Samedi " + (date.AddDays(6).Day);

            ajouterEnregistrement(date);

        btn_ajouter.Visible = true;

    }

    //-----Donne la premiere journée de la semaine (Dimanche)
    public DateTime getFirstDayOfWeek(DateTime dateToCheck)
    {
        DateTime dt = new DateTime();
        for (int i = 0; i < 7; i++)
        {
            if (dateToCheck.AddDays(-i).DayOfWeek == 0)
            {
                dt = dateToCheck.AddDays(-i);
            }
        }
        return dt;
    }
    //---------On regarde si l'enregistrement fait partit de la semaine sélectionnée
    void ajouterEnregistrement(DateTime p_dt)
    {

        if (listeFeuilleDeTemps != null)
        {
            foreach (T_FeuilleDeTemps feuilleDeTemps in listeFeuilleDeTemps)
            {
                if (idEmp != 0)
                {
                    if (feuilleDeTemps.idEmp == idEmp)
                    {
                        if (getFirstDayOfWeek((DateTime)feuilleDeTemps.semaine) == p_dt)
                        {
                            ajouterRows(feuilleDeTemps);
                        }
                    }
                    
                }
                
            }

        }
        ajouterTotal();
        
    }


    void ajouterRows(T_FeuilleDeTemps p_fdt)
    {

        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();

        //TextBox tbProjet = new TextBox();
        //TextBox tbCategorie = new TextBox();

        
        foreach (T_CategoriePro categorie in ListeCatGlobal)
        {
            if (categorie.idCategorie == p_fdt.idCategorie)
            {

                foreach (T_Projet projet in projetsGlobal)
                {
                    if (projet.idProjet == categorie.idProjet)
                    {
                        //tbProjet.Text = projet.nom;
                        tc1.Text += projet.nom;
                    }
                }
                tc1.Text += " <br/> ";
                tc1.Text += categorie.descript;
                //tbCategorie.Text = categorie.descript;
                break;
            }
        }
        
        //tbProjet.CssClass = "col-sm-7";
        //tbProjet.CssClass = "col-sm-7";

        //tbProjet.ReadOnly = true;
        //tbCategorie.ReadOnly = true;

        //tc1.Controls.Add(tbProjet);
        //tc1.Controls.Add(tbCategorie);

        TableCell tc2 = new TableCell();
        tc2.BackColor = System.Drawing.Color.LightGray;
        //TextBox tbDim = new TextBox();
        //tbDim.ID = "tbDim";
        if (p_fdt.dimanche != null)
        {
            //tbDim.Text = p_fdt.dimanche.ToString();
            totDim += (float)p_fdt.dimanche;
            tc2.Text= p_fdt.dimanche.ToString();
            tc2.Text += " H <br/> ";
        }
        //tbDim.CssClass = "col-sm-5";
        //tbDim.ReadOnly = true;
        //tc2.Controls.Add(tbDim);
        
        //tc2.Controls.Add(ajoutLabel());


        TableCell tc3 = new TableCell();
        //TextBox tbLun = new TextBox();
        if (p_fdt.lundi != null)
        {
            //tbLun.Text = p_fdt.lundi.ToString();
            tc3.Text = p_fdt.lundi.ToString();
            totLun += (float)p_fdt.lundi;
            tc3.Text += " H <br/> ";
        }
        //tbLun.ID = "tbLun";
        //tbLun.CssClass = "col-sm-5";
        //tbLun.ReadOnly = true;
        //tc3.Controls.Add(tbLun);
        //tc3.Controls.Add(ajoutLabel());
        
        TableCell tc4 = new TableCell();
        //TextBox tbMar = new TextBox();
        if (p_fdt.mardi != null)
        {
            //tbMar.Text = p_fdt.mardi.ToString();
            tc4.Text= p_fdt.mardi.ToString();
            totMar += (float)p_fdt.mardi;
            tc4.Text += " H <br/> ";
        }
        //tbMar.ID = "tbMar";
        //tbMar.CssClass = "col-sm-5";
        //tbMar.ReadOnly = true;
        //tc4.Controls.Add(tbMar);
        //tc4.Controls.Add(ajoutLabel());
        TableCell tc5 = new TableCell();
        //TextBox tbMer = new TextBox();
        if (p_fdt.mercredi != null)
        {
            //tbMer.Text = p_fdt.mercredi.ToString();
            tc5.Text= p_fdt.mercredi.ToString();
            totMer += (float)p_fdt.mercredi;
            tc5.Text += " H <br/> ";
        }
        //tbMer.ID = "tbMer";
        //tbMer.CssClass = "col-sm-5";
        //tbMer.ReadOnly = true;
        //tc5.Controls.Add(tbMer);
        //tc5.Controls.Add(ajoutLabel());
        TableCell tc6 = new TableCell();
        //TextBox tbJeu = new TextBox();
        if (p_fdt.jeudi != null)
        {
            //tbJeu.Text = p_fdt.jeudi.ToString();
            tc6.Text= p_fdt.jeudi.ToString();
            totJeu += (float)p_fdt.jeudi;
            tc6.Text += " H <br/> ";
        }
        //tbJeu.ID = "tbJeu";
        //tbJeu.CssClass = "col-sm-5";
        //tbJeu.ReadOnly = true;
        //tc6.Controls.Add(tbJeu);
        //tc6.Controls.Add(ajoutLabel());
        TableCell tc7 = new TableCell();
        //TextBox tbVen = new TextBox();
        if (p_fdt.vendredi != null)
        {
            //tbVen.Text = p_fdt.vendredi.ToString();
            tc7.Text = p_fdt.vendredi.ToString();
            totVen += (float)p_fdt.vendredi;
            tc7.Text += " H <br/> ";
        }
        //tbVen.ID = "tbVen";
        //tbVen.CssClass = "col-sm-5";
        //tbVen.ReadOnly = true;
        //tc7.Controls.Add(tbVen);
        //tc7.Controls.Add(ajoutLabel());
        TableCell tc8 = new TableCell();
        tc8.BackColor = System.Drawing.Color.LightGray;
        //TextBox tbSam = new TextBox();
        if (p_fdt.samedi != null)
        {
            //tbSam.Text = p_fdt.samedi.ToString();
            tc8.Text = p_fdt.samedi.ToString();
            totSam += (float)p_fdt.samedi;
            tc8.Text += " H <br/> ";
        }
        //tbSam.ID = "tbSam";
        //tbSam.CssClass = "col-sm-5";
        //tbSam.ReadOnly = true;
        //tc8.Controls.Add(tbSam);
        //tc8.Controls.Add(ajoutLabel());
        //TableCell tc9 = new TableCell();
        //TextBox tbCommmentaire = new TextBox();

        ////tbCommmentaire.ID = "tbCommmentaire";
        //tbCommmentaire.TextMode = TextBoxMode.MultiLine;
        //tbCommmentaire.ReadOnly = true;
        //tc9.Controls.Add(tbCommmentaire);

        //--Com
        //TextBox tbDimCom = new TextBox();
        if (p_fdt.commentaireDimanche != null)
        {
            tc2.Text += p_fdt.commentaireDimanche.ToString();
        }
        //tbDimCom.CssClass = "col-sm";
        //tbDimCom.ReadOnly = true;
        //tc2.Controls.Add(tbDimCom);

        //--Com
        //TextBox tbLunCom = new TextBox();
        if (p_fdt.commentaireLundi != null)
        {
            tc3.Text += p_fdt.commentaireLundi.ToString();
        }
        //tbLunCom.CssClass = "col-sm";
        //tbLunCom.ReadOnly = true;
        //tc3.Controls.Add(tbLunCom);
        //--Com
        //TextBox tbMarCom = new TextBox();
        if (p_fdt.commentaireMardi != null)
        {
            tc4.Text += p_fdt.commentaireMardi.ToString();
        }
        //tbMarCom.CssClass = "col-sm";
        //tbMarCom.ReadOnly = true;
        //tc4.Controls.Add(tbMarCom);
        //--Com
        //TextBox tbMerCom = new TextBox();
        if (p_fdt.commentaireMercredi != null)
        {
            tc5.Text += p_fdt.commentaireMercredi.ToString();
        }
        //tbMerCom.CssClass = "col-sm";
        //tbMerCom.ReadOnly = true;
        //tc5.Controls.Add(tbMerCom);
        //--Com
        //TextBox tbJeuCom = new TextBox();
        if (p_fdt.commentaireJeudi != null)
        {
            tc6.Text += p_fdt.commentaireJeudi.ToString();
        }
        //tbJeuCom.CssClass = "col-sm";
        //tbJeuCom.ReadOnly = true;
        //tc6.Controls.Add(tbJeuCom);
        //--Com
        //TextBox tbVenCom = new TextBox();
        if (p_fdt.commentaireVendredi != null)
        {
            tc7.Text += p_fdt.commentaireVendredi.ToString();
        }
        //tbVenCom.CssClass = "col-sm";
        //tbVenCom.ReadOnly = true;
        //tc7.Controls.Add(tbVenCom);
        //--Com
        //TextBox tbSamCom = new TextBox();
        if (p_fdt.commentaireSamedi != null)
        {
            tc8.Text += p_fdt.commentaireSamedi.ToString();
        }
        //tbSamCom.CssClass = "col-sm";
        //tbSamCom.ReadOnly = true;
        //tc8.Controls.Add(tbSamCom);

        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        tr.Cells.Add(tc3);
        tr.Cells.Add(tc4);
        tr.Cells.Add(tc5);
        tr.Cells.Add(tc6);
        tr.Cells.Add(tc7);
        tr.Cells.Add(tc8);
        //tr.Cells.Add(tc9);

        if (p_fdt.approbation != null && !(bool)p_fdt.approbation)
        {
            TableCell tc10 = new TableCell();
            Button bt_modif = new Button();
            bt_modif.Text = "Modifier";
            bt_modif.PostBackUrl = "~/AjoutFeuilleDeTemps.aspx?date=" + DateTime.ParseExact(tbx_Semaine.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "&idFdt=" + p_fdt.idFeuilleDeTemps.ToString();
           
            
            bt_modif.Click += new EventHandler(this.bt_modifier_Click1);
            //?id = " + employe.idEmploye.ToString();
            tc10.Controls.Add(bt_modif);
            tr.Cells.Add(tc10);
        }

        t_feuilleTemps.Rows.Add(tr);
    }
    //Label ajoutLabel()
    //{
    //    Label lh = new Label();
    //    lh.Text = "H";
    //    return lh;
    //}

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {

        if (DateTime.ParseExact(tbx_Semaine.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) != null)
        {
            Response.Redirect("AjoutFeuilleDeTemps.aspx?date=" + DateTime.ParseExact(tbx_Semaine.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture) + "&idFdt=" + (-1));
           

        }
        else
        {
            //lb_erreur.Text = "Veuillez choisir une date!";
        }
    }

    protected void btn_confirmer_Click(object sender, EventArgs e)
    {

    }

  

    protected void btn_confirmerModif_Click(object sender, EventArgs e)
    {
      

        Response.Redirect("FeuilleDeTemps.aspx");
    }

   

    void ajouterTotal()
    {
        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();

        //Label lb_Total = new Label();
        tc1.Text = "Total";

        //tc1.Controls.Add(lb_Total);

        TableCell tc2 = new TableCell();
        //TextBox tb_dimTot = new TextBox();

        tc2.Text = totDim.ToString() + " H";
        //tb_dimTot.Enabled = false;

        //tb_dimTot.CssClass = "col-sm-5";
        //tc2.Controls.Add(tb_dimTot);
        //tc2.Controls.Add(ajoutLabel());
        TableCell tc3 = new TableCell();
        //TextBox tb_lunTot = new TextBox();

        tc3.Text = totLun.ToString() + " H";
        //tb_lunTot.Enabled = false;

        //tb_lunTot.CssClass = "col-sm-5"; ;
        //tc3.Controls.Add(tb_lunTot);
        //tc3.Controls.Add(ajoutLabel());
        TableCell tc4 = new TableCell();
        //TextBox tb_marTot = new TextBox();

        tc4.Text = totMar.ToString() + " H";
        //tb_marTot.Enabled = false;

        //tb_marTot.CssClass = "col-sm-5"; ;
        //tc4.Controls.Add(tb_marTot);
        //tc4.Controls.Add(ajoutLabel());
        TableCell tc5 = new TableCell();
        //TextBox tb_merTot = new TextBox();

        tc5.Text = totMer.ToString() + " H";
        //tb_merTot.Enabled = false;

        //tb_merTot.CssClass = "col-sm-5"; ;
        //tc5.Controls.Add(tb_merTot);
        //tc5.Controls.Add(ajoutLabel());
        TableCell tc6 = new TableCell();
        //TextBox tb_jeuTot = new TextBox();

        tc6.Text = totJeu.ToString() + " H";
        //tb_jeuTot.Enabled = false;

        //tb_jeuTot.CssClass = "col-sm-5"; ;
        //tc6.Controls.Add(tb_jeuTot);
        //tc6.Controls.Add(ajoutLabel());
        TableCell tc7 = new TableCell();
        //TextBox tb_venTot = new TextBox();

        tc7.Text = totVen.ToString() + " H";
        //tb_venTot.Enabled = false;

        //tb_venTot.CssClass = "col-sm-5"; ;
        //tc7.Controls.Add(tb_venTot);
        //tc7.Controls.Add(ajoutLabel());
        TableCell tc8 = new TableCell();
        //TextBox tb_samTot = new TextBox();

        tc8.Text = totSam.ToString() + " H";
        //tb_samTot.Enabled = false;

        //tb_samTot.CssClass = "col-sm-5";
        //tc8.Controls.Add(tb_samTot);
        //tc8.Controls.Add(ajoutLabel());

        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        tr.Cells.Add(tc3);
        tr.Cells.Add(tc4);
        tr.Cells.Add(tc5);
        tr.Cells.Add(tc6);
        tr.Cells.Add(tc7);
        tr.Cells.Add(tc8);

        t_feuilleTemps.Rows.Add(tr);

    }

    protected void ddl_Projet_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void bt_modifier_Click1(object sender, EventArgs e)
    {

    }

    public static T_CategoriePro GetcategorieByName(string name)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_CategoriePro t = bd.T_CategoriePro.Single(f => f.descript == name);
        bd.Dispose();
        return t;
    }

    protected void btn_AllApp_Click(object sender, EventArgs e)
    {

    }
}