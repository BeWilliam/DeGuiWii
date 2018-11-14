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
            if (listeEmp[i].idFonction != 3)
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
                if (emp.idStatus == 1)
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
                if (pro.idStatus == 1)
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
        if (p_projet != null)
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
    /// Méthode permettant d'obtenir les status des catégories
    /// </summary>
    /// <returns>Liste des status possibles des catégories</returns>
    public static List<T_StatusCategorie> GetListeStatusCategorie()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_StatusCategorie> tableStatus = BD.T_StatusCategorie;
        List<T_StatusCategorie> listeStatus = tableStatus.ToList();
        BD.Dispose();
        return listeStatus;
    }

    /// <summary>
    /// Méthode permettant d'obtenir les status des employés
    /// </summary>
    /// <returns>Liste des status possibles des employés</returns>
    public static List<T_StatusEmploye> GetListeStatusEmploye()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_StatusEmploye> tableStatus = BD.T_StatusEmploye;
        List<T_StatusEmploye> listeStatus = tableStatus.ToList();
        BD.Dispose();
        return listeStatus;
    }

    /// <summary>
    /// Méthode permettant d'obtenir les fonctions des employés
    /// </summary>
    /// <returns>Liste des fonctions possibles des employés</returns>
    public static List<T_FonctionEmploye> GetListeFontionsEmploye()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_FonctionEmploye> tableFonction = BD.T_FonctionEmploye;
        List<T_FonctionEmploye> listeFonctions = tableFonction.ToList();
        BD.Dispose();
        return listeFonctions;
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
        while (i < listeEmp.Count -1 && !trouve)
        {
            i++;
            if (listeEmp[i].idEmploye == id)
            {
                trouve = true;
            }
        }
        if (trouve)
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

    public static void CreateNewCategorie(T_CategoriePro p_categorie)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdCategorie(ref maxID);
        maxID++;
        p_categorie.idCategorie = (int)maxID;

        BD.T_CategoriePro.InsertOnSubmit(p_categorie);
        BD.SubmitChanges();
        BD.Dispose();
    }

    public static List<T_Employe> GetEmpByProject(T_Projet p_projet)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_EmployeProjet> tableEmpPro = bd.T_EmployeProjet;
        List<T_EmployeProjet> listEmpPro = tableEmpPro.ToList(); //Tous les liens entre employés et projets

        List<T_EmployeProjet> resultRech = new List<T_EmployeProjet>(); //Liste de retour

        foreach (T_EmployeProjet employeProjet in listEmpPro)
        {
            if (employeProjet.idPro == p_projet.idProjet) //S'il est dans la liste
            {
                resultRech.Add(employeProjet);
            }
        }

        List<T_Employe> listEmp = GetListeEmploye(true);
        List<T_Employe> rtnList = new List<T_Employe>();
        foreach (T_EmployeProjet employeProjet in resultRech)
        {
            foreach (T_Employe employe in listEmp)
            {
                if (employeProjet.idEmp == employe.idEmploye)
                {
                    rtnList.Add(employe);
                }
            }
        }

        bd.Dispose();
        return rtnList;
    }
    public static void CreateNewFeuilleDeTemps(T_FeuilleDeTemps p_feuilleDeTemps)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdFeuilleTemps(ref maxID);
        maxID++;
        p_feuilleDeTemps.idFeuilleDeTemps = (int)maxID;

        BD.T_FeuilleDeTemps.InsertOnSubmit(p_feuilleDeTemps);
        BD.SubmitChanges();
        BD.Dispose();
    }

    /*
    public static List<T_FeuilleDeTemps> GetFeuilleDeTempsByProjet(T_Projet p_projet)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuille = bd.T_FeuilleDeTemps;
        List<T_FeuilleDeTemps> listFeuille = tableFeuille.ToList();

        List<T_CategoriePro> listeCat = GetListeCategorie(p_projet);

        List<T_FeuilleDeTemps> rtnList = new List<T_FeuilleDeTemps>();
        foreach (T_FeuilleDeTemps feuilleDeTemps in listFeuille)
        {
            //Get les feuilles de temps. Elle s'obtienne de catégorie (idProjet)
        }
    }
    */

    public static List<T_Depense> GetListeDepense()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_Depense> tableDepense = bd.T_Depense;
        List<T_Depense> listeDepense = tableDepense.ToList();
        bd.Dispose();
        return listeDepense;
    }

    public static List<T_Kilometrage> GetListeKilometrage()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_Kilometrage> tableKilo = bd.T_Kilometrage;
        List<T_Kilometrage> listeKilo = tableKilo.ToList();
        bd.Dispose();
        return listeKilo;
    }

    public static T_TauxKilo GetTauxKilo()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_TauxKilo> tableTauxKilo = bd.T_TauxKilo;
        List<T_TauxKilo> listTauxKilo = tableTauxKilo.ToList();
        bd.Dispose();
        if (listTauxKilo.Count != 0)
            return listTauxKilo[listTauxKilo.Count - 1];
        else
            throw new Exception("Aucun taux de kilométrage");
    }

    public static void ChangeTauxKilo(float p_newValue)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        float newValue = p_newValue;
        bd.PS_ChangerTauxKilo(newValue);
        bd.Dispose();
    }

    public static List<T_FeuilleDeTemps> GetListeFeuilleDeTemps()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuilleDeTemps = bd.T_FeuilleDeTemps;
        List<T_FeuilleDeTemps> listFeuilleDeTemps = tableFeuilleDeTemps.ToList();
        bd.Dispose();
        return listFeuilleDeTemps;
    }
}