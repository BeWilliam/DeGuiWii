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
    List<T_FeuilleDeTemps> enregistrements;
    List<T_Projet> ListeProjet;
    List<T_CategoriePro> ListeCategorie;
    DateTime date;
    int idCat;

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        date = getFirstDayOfWeek(Calendar1.SelectedDate);


        for (int i = 0; i < 8; i++)
        {
            switch (i)
            {
                case 1:
                    thr.Cells[i].Text = "Dimanche " + (date.Day);
                    break;
                case 2:
                    thr.Cells[i].Text = "Lundi " + (date.AddDays(1).Day);
                    break;
                case 3:
                    thr.Cells[i].Text = "Mardi " + (date.AddDays(2).Day);
                    break;
                case 4:
                    thr.Cells[i].Text = "Mercredi " + (date.AddDays(3).Day);
                    break;
                case 5:
                    thr.Cells[i].Text = "Jeudi " + (date.AddDays(4).Day);
                    break;
                case 6:
                    thr.Cells[i].Text = "Vendredi " + (date.AddDays(5).Day);
                    break;
                case 7:
                    thr.Cells[i].Text = "Samedi " + (date.AddDays(6).Day);
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }

        }
        ajouterEnregistrement(date);
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
    void ajouterEnregistrement(DateTime dt)
    {
        //List<string> projets = new List<string>();
        enregistrements = new List<T_FeuilleDeTemps>();
        foreach (T_FeuilleDeTemps feuilleDeTemps in listeFeuilleDeTemps)
        {
            if (feuilleDeTemps.semaine >= dt && feuilleDeTemps.semaine <= dt.AddDays(7))
            {
                enregistrements.Add(feuilleDeTemps);
            }
        }
        ajouterCategories();
    }
    //--------regroupe les enregistrements des feuille de temps en catégories-------------
    void ajouterCategories()
    {
        List<int> projets = new List<int>();
        foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
        {
            projets.Add(FeuilleTemps.idCategorie);
        }
        projets = projets.Distinct().ToList<int>();
        List<T_FeuilleDeTemps> temp;
        for (int i = 0; i < projets.Count; i++)
        {
            temp = new List<T_FeuilleDeTemps>();
            foreach (T_FeuilleDeTemps FeuilleTemps in enregistrements)
            {
                if (projets[i] == FeuilleTemps.idCategorie)
                {
                    temp.Add(FeuilleTemps);
                }
            }
           // ajouterRows(temp);
        }
    }


}