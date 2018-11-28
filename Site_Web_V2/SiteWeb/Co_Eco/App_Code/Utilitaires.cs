using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

/// <summary>
/// Description résumée de Utilitaires
/// </summary>
public class Utilitaires
{
    public static int GetWeek(DateTime input)
    {
        //Ref : https://social.msdn.microsoft.com/Forums/vstudio/en-US/6768f963-a568-468f-a0a5-b8841e13ffcd/c-display-week-of-the-year-in-a-label?forum=winforms
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(input);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            input = input.AddDays(3);
        }

        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(input, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public static string GetDayOfWeekName(int id)
    {
        string[] weekDay = new string[7];
        weekDay[0] = "Dimanche";
        weekDay[1] = "Lundi";
        weekDay[2] = "Mardi";
        weekDay[3] = "Mercredi";
        weekDay[4] = "Jeudi";
        weekDay[5] = "Vendredi";
        weekDay[6] = "Samedi";
        return weekDay[id];
    }

    public static float GetHeureFDT(int idFDT)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(idFDT);
        float somme = 0;
        somme += (float)fdt.dimanche;
        somme += (float)fdt.lundi;
        somme += (float)fdt.mardi;
        somme += (float)fdt.mercredi;
        somme += (float)fdt.jeudi;
        somme += (float)fdt.vendredi;
        somme += (float)fdt.samedi;
        return somme;
    }

    public static float GetHeuresByDay(int idDay, int idFDT)
    {
        T_FeuilleDeTemps fdt = BD_CoEco.GetFeuilleDeTempsById(idFDT);
        float? rtnValue = 0;
        switch (idDay)
        {
            case 0:
                rtnValue = fdt.dimanche;
                break;
            case 1:
                rtnValue = fdt.lundi;
                break;
            case 2:
                rtnValue = fdt.mardi;
                break;
            case 3:
                rtnValue = fdt.mercredi;
                break;
            case 4:
                rtnValue = fdt.jeudi;
                break;
            case 5:
                rtnValue = fdt.vendredi;
                break;
            case 6:
                rtnValue = fdt.samedi;
                break;
        }

        return (float)rtnValue;
    }

    public static List<T_Projet> GetListeProjetsTri(string p_nom, string p_idRep, string p_id_Stat, string p_descript)
    {
        List<T_Projet> listeProjet = BD_CoEco.GetListeProjet();
        List<T_Projet> researchA = new List<T_Projet>();
        List<T_Projet> researchB = new List<T_Projet>();
        List<T_Projet> researchC = new List<T_Projet>();
        List<T_Projet> researchD = new List<T_Projet>();

        string nom = p_nom;
        string idRep = p_idRep;
        string idStat = p_id_Stat;
        string descript = p_descript;

        if (nom == null)
            nom = "";
        if (idRep == null || idRep == "-1")
            idRep = "";
        if (idStat == null || idStat == "-1")
            idStat = "";
        if (descript == null)
            descript = "";

        for (int i = 0; i < listeProjet.Count; i++)
        {
            if(listeProjet[i].nom != null)
                if (listeProjet[i].nom.ToLower().Contains(nom.ToLower()))
                {
                    researchA.Add(listeProjet[i]);
                }
            if(listeProjet[i].responsable.ToString().Contains(idRep))
            {
                researchB.Add(listeProjet[i]);
            }
            if (listeProjet[i].idStatus.ToString().Contains(idStat))
            {
                researchC.Add(listeProjet[i]);
            }
            if(listeProjet[i].descript != null)
                if (listeProjet[i].descript.ToLower().Contains(descript.ToLower()))
                {
                    researchD.Add(listeProjet[i]);
                }
        }

        List<T_Projet> result_A = CompareList(researchA, researchB);
        List<T_Projet> result_B = CompareList(researchC, researchD);

        return CompareList(result_A, result_B);

    }


    public static List<T_Projet> CompareList(List<T_Projet> A, List<T_Projet> B)
    {
        List<T_Projet> rtnList = new List<T_Projet>();

        for (int i = 0; i < A.Count; i++)
        {
            for (int j = 0; j < B.Count; j++)
            {
                if(A[i].idProjet == B[j].idProjet)
                {
                    rtnList.Add(A[i]);
                }
            }
        }
        return rtnList;
    }

}