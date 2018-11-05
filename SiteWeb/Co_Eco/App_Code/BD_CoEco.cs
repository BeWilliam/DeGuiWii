using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

public class BD_CoEco
{
    /// <summary>
    /// Méthode obtenant tous les employés
    /// </summary>
    /// <param name="p_Actifs">Si ce flag est actif, retourne seulement les employés actifs</param>
    /// <returns></returns>
    public static List<T_Employe> GetListeEmploye(bool p_Actifs = false)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;
        List<T_Employe> listeEmp = tableEmp.ToList();
        List<T_Employe> rtnList = listeEmp;
        //Enlever les admins
        List<T_Employe> listeFiltre = new List<T_Employe>();
        for (int i = 0; i < listeEmp.Count; i++)
        {
            if(listeEmp[i].idFonction != 3)
            {
                listeFiltre.Add(listeEmp[i]);
            }
        }
        listeEmp = listeFiltre;

        if (p_Actifs)
        {
            rtnList = new List<T_Employe>();
            foreach (T_Employe emp in listeEmp)
            {
                if(emp.idStatus == 1)
                {
                    rtnList.Add(emp);
                }
            }
        }
        BD.Dispose();

        return rtnList;
    }

    /// <summary>
    /// Méthode permettant obtenir la liste des projets. Retourne tous les projets par défaut
    /// </summary>
    /// <param name="p_Inactif">Si ce flag est mit à True, retourne seulement les projets actifs</param>
    /// <returns></returns>
    public static List<T_Projet> GetListeProjet(bool p_Actifs = false)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Projet> tableProjet = BD.T_Projet;
        List<T_Projet> listeProjet = tableProjet.ToList();
        List<T_Projet> rtnList = listeProjet;
        if (p_Actifs == true)
        {
            rtnList = new List<T_Projet>();
            foreach (T_Projet pro in listeProjet)
            {
                if(pro.idStatus == 1)
                {
                    rtnList.Add(pro);
                }
            }
        }
        BD.Dispose();
        return rtnList;
    }

    /// <summary>
    /// Méthode permettant d'obtenir les catégories pour un projet en particulié
    /// </summary>
    /// <param name="p_projet">Projet dont on veut savoir les catégories</param>
    /// <returns>La liste des catégories associés au projet</returns>
    public static List<T_CategoriePro> GetListeCategorie(T_Projet p_projet = null)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_CategoriePro> tableCategorie = BD.T_CategoriePro;
        List<T_CategoriePro> listeCategorie = tableCategorie.ToList();
        List<T_CategoriePro> rtnLst = new List<T_CategoriePro>();
        if(p_projet != null)
        {
            foreach (T_CategoriePro cat in listeCategorie)
            {
                if (cat.idProjet == p_projet.idProjet)
                {
                    rtnLst.Add(cat);
                }
            }
        }
        else
        {
            rtnLst = listeCategorie;
        }
        
        BD.Dispose();
        return rtnLst;
    }

    /// <summary>
    /// Méthode permettant d'obtenir les status des projets
    /// </summary>
    /// <returns>Liste des status possibles des projets</returns>
    public static List<T_StatusProjet> GetListeStatusProjet()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_StatusProjet> tableStatus = BD.T_StatusProjet;
        List<T_StatusProjet> listeStatus = tableStatus.ToList();
        BD.Dispose();
        return listeStatus;
    }

    /// <summary>
    /// Méthode permettant d'obtenir un employé selon l'ID fourni. Throw une exception si pas trouvé
    /// </summary>
    /// <param name="id">L'id de l'employé</param>
    /// <returns></returns>
    public static T_Employe GetEmpByID(int id)
    {
        List<T_Employe> listeEmp = GetListeEmploye();

        bool trouve = false;
        int i = -1;
        while(i < listeEmp.Count && !trouve)
        {
            i++;
            if (listeEmp[i].idEmploye == id)
            {
                trouve = true;
            }
        }
        if(trouve)
        {
            return listeEmp[i];
        }
        else
        {
            throw new Exception("Id correspondant à aucun employé existant");
        }

    }

    /// <summary>
    /// Méthode permettant d'obtenir un projet selon l'ID fourni. Throw une exception si pas trouvé
    /// </summary>
    /// <param name="id">L'id du projet dont on veut obtenir les infos</param>
    /// <returns>Le projet en question</returns>
    public static T_Projet GetProByID(int id)
    {
        List<T_Projet> listeProjet = GetListeProjet();

        bool trouve = false;
        int i = -1;
        while (i < listeProjet.Count && !trouve)
        {
            i++;
            if (listeProjet[i].idProjet == id)
            {
                trouve = true;
            }
        }
        if (trouve)
        {
            return listeProjet[i];
        }
        else
        {
            throw new Exception("Id correspondant à aucun projet existant");
        }
    }

    public static List<T_TypeDepense> GetListeTypeDepense()
    {

        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_TypeDepense> tableTypeDepense = BD.T_TypeDepense;
        List<T_TypeDepense> listeTypeDepense = tableTypeDepense.ToList();
        BD.Dispose();
        return listeTypeDepense;
    }

    public static void CreateNewProjet(T_Projet p_projet)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdProjet(ref maxID);
        maxID++;
        p_projet.idProjet = (int)maxID;

        BD.T_Projet.InsertOnSubmit(p_projet);
        BD.SubmitChanges();
        BD.Dispose();
    }

    public static void CreateNewEmploye(T_Employe p_employe)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdEmpolye(ref maxID);
        maxID++;
        p_employe.idEmploye = (int)maxID;

        BD.T_Employe.InsertOnSubmit(p_employe);
        BD.SubmitChanges();
        BD.Dispose();
    }

}