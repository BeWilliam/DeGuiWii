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
    /// Méthode permettant obtenir la liste des employés au projet. Retourne tous les emp au projet par défaut
    /// </summary>
    /// <param name="p_Inactif">Si ce flag est mit à True, retourne seulement les employé au projet actifs</param>
    /// <returns></returns>
    public static List<T_EmployeProjet> GetListeEmpPro(bool p_Actifs = false)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_EmployeProjet> tableEmpPro = BD.T_EmployeProjet;
        List<T_EmployeProjet> listeEmpPro = tableEmpPro.ToList();
        List<T_EmployeProjet> rtnList = listeEmpPro;

        if (p_Actifs == true)
        {
            rtnList = new List<T_EmployeProjet>();
            foreach (T_EmployeProjet emppro in listeEmpPro)
            {
                    rtnList.Add(emppro);
            }
        }
        BD.Dispose();
        return rtnList;
    }

    /// <summary>
    /// Méthode permettant obtenir la liste des nouveaux projets.
    /// </summary>
    /// <param name="p_Inactif">Si ce flag est mit à True, retourne seulement les projets actifs</param>
    /// <returns></returns>
    public static List<T_Projet> GetListeNewProjet()
    {
        DateTime today = DateTime.Now;

        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Projet> tableProjet = BD.T_Projet;

        List<T_Projet> listeProjet = tableProjet.ToList();
        List<T_Projet> rtnList = listeProjet;
    
        rtnList = new List<T_Projet>();

        foreach (T_Projet pro in listeProjet)
        {
            if (pro.idStatus == 1)
            {
                if (pro.dateDebut >= today.AddDays(-30))
                {
                    rtnList.Add(pro);
                }  
            }
        }
        BD.Dispose();
        return rtnList;
    }


    /// <summary>
    /// Méthode permettant obtenir la liste des dépenses. Retourne tous les dépenses par défaut
    /// </summary>
    /// <returns></returns>
    public static List<T_Depense> GetListeDepenseEmp(int idEmploye)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Depense> tableDepense = BD.T_Depense;
        List<T_Depense> listeDepense = tableDepense.ToList();
        List<T_Depense> rtnList = listeDepense;

            rtnList = new List<T_Depense>();
            foreach (T_Depense dep in listeDepense)
            {
                if (dep.idEmp == idEmploye)
                {
                    rtnList.Add(dep);
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
        //else
        //{
        //throw new Exception("Id correspondant à aucun employé existant");
        //}
        return null;

    }

    /// <summary>
    /// Méthode permettant d'obtenir une catégoeie selon l'ID fourni. Throw une exception si pas trouvé
    /// </summary>
    /// <param name="id">L'id de la catégorie</param>
    /// <returns></returns>
    public static T_CategoriePro GetCatByID(int id)
    {
        List<T_CategoriePro> listeCat = GetListeCategorie();

        bool trouve = false;
        int i = -1;
        while (i < listeCat.Count - 1 && !trouve)
        {
            i++;
            if (listeCat[i].idCategorie == id)
            {
                trouve = true;
            }
        }
        if (trouve)
        {
            return listeCat[i];
        }
        else
        {
            throw new Exception("Id correspondant à aucune catégorie existante");
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
        while (i + 1 < listeProjet.Count && !trouve)
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
        return null;
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
        if(maxID == null)
        {
            maxID = 1;
        }
        p_projet.idProjet = (int)maxID;

        BD.T_Projet.InsertOnSubmit(p_projet);
        BD.SubmitChanges();
        BD.Dispose();
    }

    public static int? getNewIdProject()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdProjet(ref maxID);
        maxID++;
        return maxID;
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

    public static void CreateNewEmpAtProject(T_EmployeProjet p_emp)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        int? maxID = 0;
        BD.PS_GetMaxIdEmpPro(ref maxID);
        maxID++;
        p_emp.idEmpPro = (int)maxID;

        BD.T_EmployeProjet.InsertOnSubmit(p_emp);
        BD.SubmitChanges();
        BD.Dispose();
    }

    public static void UpdateEmploye(T_Employe p_employe)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();

        T_Employe newEmp = BD.T_Employe.Single(e => e.idEmploye == p_employe.idEmploye);

        newEmp.prenom = p_employe.prenom;
        newEmp.nom = p_employe.nom;
        newEmp.courriel = p_employe.courriel;
        newEmp.mdp = p_employe.mdp;
        newEmp.idFonction = p_employe.idFonction;
        newEmp.idStatus = p_employe.idStatus;
        newEmp.loginName = p_employe.loginName;

        newEmp.congesFeries = p_employe.congesFeries;
        newEmp.congesMaladie = p_employe.congesMaladie;
        newEmp.congesPersonnels = p_employe.congesPersonnels;
        newEmp.heuresAccumuleesOuSansSolde = p_employe.heuresAccumuleesOuSansSolde;
        newEmp.vacances = p_employe.vacances;

        BD.SubmitChanges();
        BD.Dispose();
    }

    public static void UpdateProjet(T_Projet p_projet)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();

        T_Projet newProjet = BD.T_Projet.Single(p => p.idProjet == p_projet.idProjet);

        newProjet.nom = p_projet.nom;
        newProjet.idStatus = p_projet.idStatus;
        newProjet.heureAlloue = p_projet.heureAlloue;
        newProjet.responsable = p_projet.responsable;
        newProjet.descript = p_projet.descript;
        newProjet.dateDebut = p_projet.dateDebut;
        newProjet.dateFin = p_projet.dateFin;

        BD.SubmitChanges();
        BD.Dispose();
    }

    public static void UpdateFeuilleDeTemps(T_FeuilleDeTemps p_fdt)
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();

        T_FeuilleDeTemps newFdt = BD.T_FeuilleDeTemps.Single(p => p.idFeuilleDeTemps == p_fdt.idFeuilleDeTemps);

        newFdt.idFeuilleDeTemps = p_fdt.idFeuilleDeTemps;
        newFdt.idEmp = p_fdt.idEmp;
        newFdt.idCategorie = p_fdt.idCategorie;
        newFdt.dimanche = p_fdt.dimanche;
        newFdt.lundi = p_fdt.lundi;
        newFdt.mardi = p_fdt.mardi;
        newFdt.mercredi = p_fdt.mercredi;
        newFdt.jeudi = p_fdt.jeudi;
        newFdt.vendredi = p_fdt.vendredi;
        newFdt.samedi = p_fdt.samedi;
        newFdt.commentaireDimanche = p_fdt.commentaireDimanche;
        newFdt.commentaireLundi = p_fdt.commentaireLundi;
        newFdt.commentaireMardi = p_fdt.commentaireMardi;
        newFdt.commentaireMercredi = p_fdt.commentaireMercredi;
        newFdt.commentaireJeudi = p_fdt.commentaireJeudi;
        newFdt.commentaireVendredi = p_fdt.commentaireVendredi;
        newFdt.commentaireSamedi = p_fdt.commentaireSamedi;
        newFdt.approbation = p_fdt.approbation;

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
        if(maxID == null)
        {
            maxID = 1;
        }

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

    public static List<T_FeuilleDeTemps> GetListeFeuilleDeTemps()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        Table<T_FeuilleDeTemps> tableFeuilleDeTemps = bd.T_FeuilleDeTemps;
        List<T_FeuilleDeTemps> listFeuilleDeTemps = tableFeuilleDeTemps.ToList();
        bd.Dispose();
        return listFeuilleDeTemps;
    }

    public static void AddDepense(T_Depense p_newDep)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        bd.T_Depense.InsertOnSubmit(p_newDep);
        bd.SubmitChanges();
        bd.Dispose();
    }

    public static T_Depense GetDepenseById(int id)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Depense t = bd.T_Depense.Single(f => f.idDepense == id);
        bd.Dispose();
        return t;
    }

    public static List<T_Projet> GetProjectByEmp(T_Employe emp)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();

        List<T_Projet> listeProjet = new List<T_Projet>();
        List<T_EmployeProjet> listeEmpProjet = bd.T_EmployeProjet.ToList();

        foreach (T_EmployeProjet employeProjet in listeEmpProjet)
        {
            if(employeProjet.idEmp == emp.idEmploye)
            {
                listeProjet.Add(GetProByID(employeProjet.idPro));
            }
        }

        return listeProjet;
    }

    public static T_Employe GetNewEmp()
    {
        return null;
    }

    public static void UpdateDepense(T_Depense depense)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Depense depenseToMod = bd.T_Depense.Single(p => p.idDepense == depense.idDepense);

        depenseToMod.idProjet = depense.idProjet;
        //depenseToMod.idCategorie = depense.idCategorie;
        depenseToMod.idType = depense.idType;
        depenseToMod.descript = depense.descript;
        depenseToMod.montant = depense.montant;
        depenseToMod.ddate = depense.ddate;
        depenseToMod.idEmp = depenseToMod.idEmp;
        depenseToMod.aprobation = depense.aprobation;

        bd.SubmitChanges();
        bd.Dispose();
    }

    public static T_FeuilleDeTemps GetFeuilleDeTempsById(int id)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_FeuilleDeTemps fdt = bd.T_FeuilleDeTemps.Single(f => f.idFeuilleDeTemps == id);
        bd.Dispose();
        return fdt;
    }

    public static T_StatusProjet GetStatusProjetById(int id)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_StatusProjet statpro = bd.T_StatusProjet.Single(o => o.noStatusPro == id);
        bd.Dispose();
        return statpro;

    }

    public static float banqueHeuresProj(T_Projet proj)
    {
        float banqueHeure = 0;

        List<T_CategoriePro> listCat = GetListeCategorie(proj);
        List<T_FeuilleDeTemps> listeFdt = GetListeFeuilleDeTemps();

        foreach (T_FeuilleDeTemps fdt in listeFdt)
        {
            foreach (T_CategoriePro cat in listCat)
            {
                if (cat.idCategorie == fdt.idCategorie)
                {
                    if (fdt.dimanche!=null)
                    {
                        banqueHeure += (float)fdt.dimanche;
                    }
                    if (fdt.lundi != null)
                    {
                        banqueHeure += (float)fdt.lundi;
                    }
                    if (fdt.mardi != null)
                    {
                        banqueHeure += (float)fdt.mardi;
                    }
                    if (fdt.mercredi != null)
                    {
                        banqueHeure += (float)fdt.mercredi;
                    }
                    if (fdt.jeudi != null)
                    {
                        banqueHeure += (float)fdt.jeudi;
                    }
                    if (fdt.vendredi != null)
                    {
                        banqueHeure += (float)fdt.vendredi;
                    }
                    if (fdt.samedi != null)
                    {
                        banqueHeure += (float)fdt.samedi;
                    }
                }
            }
        }

        return banqueHeure;
    }

    public static float GetTauxKiloAuto()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        List<T_TauxKilo> listeTauxKilo = bd.T_TauxKilo.Where(o => o.idTypeAuto == 1).OrderBy(o => o.idTaux).ToList();
        bd.Dispose();
        return listeTauxKilo[listeTauxKilo.Count - 1].taux;
    }

    public static float GetTauxKiloCamion()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        List<T_TauxKilo> listeTauxKilo = bd.T_TauxKilo.Where(o => o.idTypeAuto == 2).OrderBy(o => o.idTaux).ToList();
        bd.Dispose();
        return listeTauxKilo[listeTauxKilo.Count - 1].taux;
    }

    /// <summary>
    /// Ajoute un nouveau taux
    /// </summary>
    /// <param name="newTaux">nouveau taux</param>
    /// <param name="type">1 = Auto, 2 = Camion</param>
    public static void AddTauxKilo(float newTaux, int type)
    {
        T_TauxKilo tauxKilo = new T_TauxKilo();
        tauxKilo.taux = newTaux;
        tauxKilo.ddate = DateTime.Today;
        tauxKilo.idTypeAuto = type;

        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        bd.T_TauxKilo.InsertOnSubmit(tauxKilo);
        bd.SubmitChanges();
        bd.Dispose();
    }

    public static List<T_TypeAuto> GetListTypesVehicules()
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        List<T_TypeAuto> rtnList = bd.T_TypeAuto.ToList();
        bd.Dispose();
        return rtnList;
    }


    public static int GetIdTauxKilo(int type)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        List<T_TauxKilo> listeTauxKilo = bd.T_TauxKilo.Where(o => o.idTypeAuto == type).OrderBy(o => o.idTaux).ToList();
        bd.Dispose();
        return listeTauxKilo[listeTauxKilo.Count - 1].idTaux;
    }

    public static void AjouterDepKilometrage(T_Kilometrage km)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        bd.T_Kilometrage.InsertOnSubmit(km);
        bd.SubmitChanges();
        bd.Dispose();
    }

    public static T_TauxKilo GetTauxKiloById(int id)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_TauxKilo tauxKilo = bd.T_TauxKilo.Single(o => o.idTaux == id);
        bd.Dispose();
        return tauxKilo;
    }

    public static T_Kilometrage GetKiloById(int id)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Kilometrage kilo = bd.T_Kilometrage.Single(o => o.idKilo == id);
        bd.Dispose();
        return kilo;
    }

    public static void UpdateKilometrage(T_Kilometrage newkilo)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Kilometrage oldkilo = bd.T_Kilometrage.Single(o => o.idKilo == newkilo.idKilo);

        //oldkilo.idKilo = newkilo.idTaux;
        oldkilo.nbKilo = newkilo.nbKilo;
        oldkilo.commentaire = newkilo.commentaire;
        oldkilo.ddate = newkilo.ddate;
        oldkilo.approbation = newkilo.approbation;
        oldkilo.idTaux = newkilo.idTaux;
        oldkilo.idEmp = newkilo.idEmp;
        oldkilo.idPro = newkilo.idPro;


        bd.SubmitChanges();
        bd.Dispose();
    }

    public static void ApprouverDepenseByID(int id, bool etat)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Depense dep = bd.T_Depense.Single(f => f.idDepense == id);
        dep.aprobation = etat;
        bd.SubmitChanges();
        bd.Dispose();
    }

    public static void ApprouverKilometrageById(int id, bool etat)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Kilometrage kilo = bd.T_Kilometrage.Single(f => f.idKilo == id);
        kilo.approbation = etat;
        bd.SubmitChanges();
        bd.Dispose();
    }

    public static List<T_FeuilleDeTemps> GetFDTByProject(int idPro)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_Projet projet = bd.T_Projet.Single(f => f.idProjet == idPro);
        List<T_CategoriePro> lstCategories = GetListeCategorie(projet);
        List<T_FeuilleDeTemps> lstFDT = GetListeFeuilleDeTemps();

        List<T_FeuilleDeTemps> rtnList = new List<T_FeuilleDeTemps>();

        foreach (T_CategoriePro cat in lstCategories)
        {
            foreach (T_FeuilleDeTemps fdt in lstFDT)
            {
                if (fdt.idCategorie == cat.idCategorie)
                {
                    rtnList.Add(fdt);
                }
            }
        }

        return rtnList;
    }

    public static void ChangeStatusCategorie(int id, int etat)
    {
        CoEco_BDDataContext bd = new CoEco_BDDataContext();
        T_CategoriePro cat = bd.T_CategoriePro.Single(f => f.idCategorie == id);

        cat.idStatusCat = etat;
        bd.SubmitChanges();
        bd.Dispose();

    }
}