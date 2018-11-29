using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BanqueHeureAdmin : System.Web.UI.Page
{

    DateTime debutAnnee = new DateTime(1900, 01, 01);
    DateTime finAnnee = new DateTime(1900, 12, 31);


    protected void Page_Load(object sender, EventArgs e)
    {
        header();

        List<T_Employe> rawListeEmp = BD_CoEco.GetListeEmploye();
        //trié la liste avant insertion
        rawListeEmp = rawListeEmp.OrderBy(o => o.idStatus).ThenBy(o => o.prenom).ThenBy(o => o.nom).ToList();
        List<T_Employe> listEmpBureau = new List<T_Employe>();

        foreach (T_Employe emp in rawListeEmp)
        {
            if (emp.idFonction == 1)
            {
                listEmpBureau.Add(emp);
                ShowEmp(emp);
            }
        }
    }
    void header()
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc_Nom = new TableHeaderCell();
        thc_Nom.Text = "Nom";
        thc_Nom.Width = new Unit("25%");
        TableHeaderCell heuresDepensee = new TableHeaderCell();
        heuresDepensee.Text = "Heures dépensées";
        heuresDepensee.Width = new Unit("25%");
        TableHeaderCell BanqueHeure = new TableHeaderCell();
        BanqueHeure.Text = "Banque d'heure";
        BanqueHeure.Width = new Unit("25%");


        thr.Cells.Add(thc_Nom);
        thr.Cells.Add(heuresDepensee);
        thr.Cells.Add(BanqueHeure);
        thr.ID = "thr_ID";
        Tableau_Employes.Rows.Add(thr);
    }

    private void ShowEmp(T_Employe employe)
    {
        TableRow tr = new TableRow();
        TableCell tc_Nom = new TableCell();
        HyperLink hl = new HyperLink();
        hl.Text = employe.prenom + " " + employe.nom;
        hl.NavigateUrl = "AjoutBanqueHeure.aspx?id=" + employe.idEmploye.ToString();
        tc_Nom.Controls.Add(hl);
        //tc_Prenom.Text = employe.prenom;
        TableCell tc_heuresDepensee = new TableCell();
        tc_heuresDepensee.Text = listeHeure(employe.idEmploye).ToString();
        TableCell tc_banqueHeure = new TableCell();
        tc_banqueHeure.Text = (employe.congesFeries+employe.congesMaladie+employe.congesPersonnels+employe.heuresAccumuleesOuSansSolde+employe.vacances).ToString();
        tr.Cells.Add(tc_Nom);
        tr.Cells.Add(tc_heuresDepensee);
        tr.Cells.Add(tc_banqueHeure);
        Tableau_Employes.Rows.Add(tr);

    }
    
    private int listeHeure(int p_idEmp)
    {
        int nbHeure = 0;
        List<T_FeuilleDeTemps> hrs = BD_CoEco.GetListeFeuilleDeTemps();
        foreach (T_FeuilleDeTemps fdt in hrs)
        {
            if (fdt.idEmp == p_idEmp)
            {
                if (fdt.idCategorie == 191 || fdt.idCategorie == 192 || fdt.idCategorie == 193 || fdt.idCategorie == 194 || fdt.idCategorie == 255)
                {
                    nbHeure += (int)Utilitaires.GetHeureFDT(fdt.idFeuilleDeTemps);
                }
            }
        }
        return nbHeure;
    }
}