using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;

public class BD_CoEco
{
    public static List<T_Employe> GetListeEmploye()
    {
        CoEco_BDDataContext BD = new CoEco_BDDataContext();
        Table<T_Employe> tableEmp = BD.T_Employe;
        List<T_Employe> listeEmp = tableEmp.ToList();

        return listeEmp;
    }
}