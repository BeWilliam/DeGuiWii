using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;

public partial class AjouterProjet : System.Web.UI.Page
{

    string urlParam;
    List<T_Employe> listEmp = new List<T_Employe>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["fonction"] == null)
        {
            Response.Redirect("index.aspx");
        }

        urlParam = Request.QueryString["id"];

        btn_modifier.Enabled = true;
        btn_apply.Enabled = false;

        loadCat();

        if (!IsPostBack)
        {
            loadResponsable();
            loadStatut();
            afficherEmpLst();
            btn_lieEmp.Visible = false;
            ddl_employe.Visible = false;
            lst_employeAjouter2.Visible = false;
            lbl_listeEmp2.Visible = false;
            lbl_nom.Visible = false;
            tbx_cat.Visible = false;
            btn_ajouterCategorie.Visible = false;
            titreC.Visible = false;
            btn_lieEmp.Enabled = false;
            btn_ajouterCategorie.Enabled = false;
            tbx_cat.Enabled = false;
            lst_employeAjouter2.Enabled = false;
            btn_modifier.Enabled = false;
        }

        if (urlParam != null)
        {
            btn_apply.Visible = true;
            btn_apply.Enabled = false;
            lst_employe.Visible = false;
            btn_retirer.Visible = false;
            btn_ajouter.Visible = false;
            btn_lieEmp.Visible = true;
            ddl_employe.Visible = true;
            lbl_listeEmp.Visible = false;
            lbl_listeEmpA.Visible = false;
            lst_employeAjouter.Visible = false;
            lst_employeAjouter2.Visible = true;
            lbl_listeEmp2.Visible = true;
            lbl_nom.Visible = true;
            tbx_cat.Visible = true;
            btn_ajouterCategorie.Visible = true;
            titreC.Visible = true;
            btn_modifier.Enabled = true;

            if (!IsPostBack)
            {
                afficherProject();
                loadCat();
                loadEmploye();
                btn_addProject.Enabled = false;

                btn_apply.Visible = true;
                btn_apply.Enabled = false;
                btn_ajouter.Enabled = false;
                btn_retirer.Enabled = false;
                btn_modifier.Visible = true;
                tbx_nom.Enabled = false;
                tbx_heure.Enabled = false;
                tbx_projet.Enabled = false;
                ddl_responsable.Enabled = false;
                ddl_employe.Enabled = false;
                ddl_statut.Enabled = false;
                dateDebut.Enabled = false;
                dateFin.Enabled = false;
                lst_employe.Enabled = false;
                lst_employeAjouter.Enabled = false;
                btn_lieEmp.Enabled = false;
                btn_ajouterCategorie.Enabled = false;

             
            }
        }       
    }

    private void afficherProject()
    {
        listEmp = new List<T_Employe>();

        List<T_Projet> tousLesProjet = BD_CoEco.GetListeProjet();
        List<T_Employe> tousLesEmp = new List<T_Employe>();

        foreach (T_Projet projet in tousLesProjet)
        {
            if (projet.idProjet == int.Parse(urlParam))
            {
                tbx_nom.Text = projet.nom;
                tbx_projet.Text = projet.descript;
                if (projet.responsable != null)
                {
                    if (projet.responsable != -1)
                        ddl_responsable.SelectedValue = BD_CoEco.GetEmpByID((int)projet.responsable).idEmploye.ToString();
                    else
                        ddl_responsable.SelectedValue = "1";
                }
                tbx_heure.Text = projet.heureAlloue.ToString();
                dateDebut.Text = String.Format("{0:yyyy-MM-dd}", projet.dateDebut);
                dateFin.Text = String.Format("{0:yyyy-MM-dd}", projet.dateFin);

                ddl_statut.SelectedValue = projet.idStatus.ToString();

                List<T_EmployeProjet> tousLesEmpInPro = BD_CoEco.GetListeEmpPro();

                foreach (T_EmployeProjet empPro in tousLesEmpInPro)
                {
                    if (empPro.idPro == projet.idProjet)
                    {
                        lst_employeAjouter2.Items.Add(new ListItem(BD_CoEco.GetEmpByID(empPro.idEmp).prenom + " " + BD_CoEco.GetEmpByID(empPro.idEmp).nom, BD_CoEco.GetEmpByID(empPro.idEmp).idEmploye.ToString()));

                        T_Employe newEmp = new T_Employe();
                        newEmp.idEmploye = BD_CoEco.GetEmpByID(empPro.idEmp).idEmploye;
                        listEmp.Add(newEmp);
                    }
                }
            }
        }
    }

    protected void btn_addProject_Click(object sender, EventArgs e)
    {

        T_Projet monProjet = new T_Projet();
        List <T_Employe> listeEmpAuProjet = new List<T_Employe>();

        monProjet.nom = tbx_nom.Text;
        if(tbx_projet.Text != "")
            monProjet.descript = tbx_projet.Text;
        monProjet.responsable = int.Parse(ddl_responsable.SelectedValue);
        if(tbx_heure.Text != "")
            monProjet.heureAlloue = int.Parse(tbx_heure.Text);
        if(dateDebut.Text != "")
            monProjet.dateDebut = DateTime.Parse(dateDebut.Text.ToString());
        if(dateFin.Text != "")
            monProjet.dateFin = DateTime.Parse(dateFin.Text.ToString());
        monProjet.idStatus = int.Parse(ddl_statut.SelectedValue);

        BD_CoEco.CreateNewProjet(monProjet);

        for (int i = 0; i < lst_employeAjouter.Items.Count; i++)
        {
            T_Employe emp = BD_CoEco.GetEmpByID(int.Parse(lst_employeAjouter.Items[i].Value));
            listeEmpAuProjet.Add(emp);
        }

        for (int i = 0; i < listeEmpAuProjet.Count; i++)
        {
            T_EmployeProjet empPro = new T_EmployeProjet();
            empPro.idEmp = listeEmpAuProjet[i].idEmploye;
            empPro.idPro = (int)BD_CoEco.getNewIdProject() - 1;
            BD_CoEco.CreateNewEmpAtProject(empPro);
        }

        Response.Redirect("Projet.aspx");
    }

    private void loadResponsable()
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeResponsable = new List<T_Employe>();
        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction == 1 || employe.idStatus == 1) //Employé de bureau
            {
                listeResponsable.Add(employe);
            }
        }
        listeResponsable = listeResponsable.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        ddl_responsable.Items.Add(new ListItem("Aucun responsable", "-1"));
        foreach (T_Employe responsable in listeResponsable)
        {
            ddl_responsable.Items.Add(new ListItem(responsable.prenom + " " + responsable.nom, responsable.idEmploye.ToString()));
        }
    }

    private void loadEmploye()
    {
        ddl_employe.Items.Clear();
        List<T_Employe> listEmp = BD_CoEco.GetListeEmploye(true);
        List<T_Employe> list = new List<T_Employe>();

        for (int i = 0; i < lst_employeAjouter2.Items.Count; i++)
        {
            list.Add(BD_CoEco.GetEmpByID(int.Parse(lst_employeAjouter2.Items[i].Value)));
        }

        for (int i = 0; i < listEmp.Count; i++)
        {
            for (int e = 0; e < list.Count; e++)
            {
                if (listEmp[i].idEmploye == list[e].idEmploye)
                {
                    listEmp.RemoveAt(i);
                }
            }
        }

        listEmp = listEmp.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        foreach (T_Employe emp in listEmp)
        {
            ddl_employe.Items.Add(new ListItem(emp.prenom + " " + emp.nom, emp.idEmploye.ToString()));
        }
    }

    private void loadStatut()
    {
        List<T_StatusProjet> listeStatusProjet = BD_CoEco.GetListeStatusProjet();
        listeStatusProjet = listeStatusProjet.OrderBy(o => o.descript).ToList();
        foreach (T_StatusProjet statut in listeStatusProjet)
        {
            ddl_statut.Items.Add(new ListItem(statut.descript, statut.noStatusPro.ToString()));
        }
        ddl_statut.SelectedValue = "1";
    }

    protected void btn_retour_Click(object sender, EventArgs e)
    {
        Response.Redirect("Projet.aspx");
    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {

        T_Projet monProjet = new T_Projet();

        monProjet.idProjet = int.Parse(Request.QueryString["id"]);

        monProjet.nom = tbx_nom.Text;
        if(tbx_projet.Text != "")
            monProjet.descript = tbx_projet.Text;
        if(tbx_heure.Text != "")
            monProjet.heureAlloue = float.Parse(tbx_heure.Text);
        monProjet.idStatus = int.Parse(ddl_statut.SelectedValue);
        if(ddl_responsable.SelectedValue != "-1")
            monProjet.responsable = int.Parse(ddl_responsable.SelectedValue);
        if(dateDebut.Text != "")
            monProjet.dateDebut = DateTime.Parse(dateDebut.Text.ToString());
        if(dateFin.Text != "")
            monProjet.dateFin = DateTime.Parse(dateFin.Text.ToString());

        BD_CoEco.UpdateProjet(monProjet);

        ajouterEmpLie();

        Response.Redirect("Projet.aspx");

    }

    protected void btn_modifier_Click(object sender, EventArgs e)
    {
        tbx_nom.Enabled = true;
        tbx_heure.Enabled = true;
        tbx_projet.Enabled = true;
        ddl_responsable.Enabled = true;
        ddl_employe.Enabled = true;
        ddl_statut.Enabled = true;
        dateDebut.Enabled = true;
        dateFin.Enabled = true;
        lst_employe.Enabled = true;
        lst_employeAjouter2.Enabled = true;
        btn_lieEmp.Enabled = true;
        btn_apply.Visible = true;
        btn_apply.Enabled = true;
        btn_lieEmp.Enabled = true;
        btn_ajouterCategorie.Enabled = true;
        tbx_cat.Enabled = true;
        btn_modifier.Enabled = false;
        loadCat();
    }

    private void afficherEmpLst()
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeEmploye = new List<T_Employe>();

        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction != 3) //Employé de bureau
            {
                listeEmploye.Add(employe);

            }
        }

        listeEmploye = listeEmploye.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        foreach (T_Employe emp in listeEmploye)
        {
            lst_employe.Items.Add(new ListItem(emp.prenom + " " + emp.nom, emp.idEmploye.ToString()));
        }

    }

    private void ajouterEmp(int idRetirer)
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeEmploye = new List<T_Employe>();

        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction != 3 && employe.idEmploye == idRetirer) //Employé de bureau
            {
                listeEmploye.Add(employe);

            }
        }

        listeEmploye = listeEmploye.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();
        foreach (T_Employe emp in listeEmploye)
        {
            lst_employeAjouter.Items.Add(new ListItem(emp.prenom + " " + emp.nom, emp.idEmploye.ToString()));
        }

    }

    private void ajouterEmp2(int idAjouter)
    {
        List<T_Employe> listeEmploye = new List<T_Employe>();

    }

    private void retirerEmp(int idRetirer)
    {
        List<T_Employe> listeEmp = BD_CoEco.GetListeEmploye();
        List<T_Employe> listeEmploye = new List<T_Employe>();

        foreach (T_Employe employe in listeEmp)
        {
            if (employe.idFonction == 1 && employe.idEmploye == idRetirer) //Employé de bureau
            {
                listeEmploye.Add(employe);
            }
        }

        listeEmploye = listeEmploye.OrderBy(o => o.prenom).ThenBy(o => o.prenom).ToList();

        foreach (T_Employe emp in listeEmploye)
        {
            lst_employe.Items.Add(new ListItem(emp.prenom + " " + emp.nom, emp.idEmploye.ToString()));
        }

    }

    protected void btn_ajouter_Click(object sender, EventArgs e)
    {
        int empId = int.Parse(lst_employe.SelectedValue);
        int indexEmp = lst_employe.SelectedIndex;

        lst_employe.Items.RemoveAt(indexEmp);

        ajouterEmp(empId);
        btn_modifier.Enabled = false;
    }

    private void ajouterEmpMod()
    {
        int empId = int.Parse(Request.QueryString["cph_contenu_lst_employe.SelectedValue"]);
    }

    protected void btn_retirer_Click(object sender, EventArgs e)
    {
        T_Employe employeSelected = new T_Employe();
        int empId = int.Parse(lst_employeAjouter.SelectedValue);
        int indexEmp = lst_employeAjouter.SelectedIndex;

        lst_employeAjouter.Items.RemoveAt(indexEmp);

        T_Employe empP = BD_CoEco.GetEmpByID(empId);

        retirerEmp(empId);
        btn_modifier.Enabled = false;
    }

    private void loadCat()
    {
        if (urlParam != null)
        {
            tableau_categorie.Rows.Clear();
            List<T_CategoriePro> listCat = BD_CoEco.GetListeCategorie(BD_CoEco.GetProByID(int.Parse(Request.QueryString["id"])));
            listCat = listCat.OrderBy(o => o.descript).ToList();
            foreach (T_CategoriePro categoriePro in listCat)
            {
                if (categoriePro.idStatusCat == 1)
                {
                    TableRow tr = new TableRow();
                    TableCell tc1 = new TableCell();
                    TableCell tc2 = new TableCell();
                    //pas terminer
                    LinkButton btn = new LinkButton();
                    btn.ID = "btn_Cat-" + categoriePro.idCategorie;
                    btn.CssClass = "fas fa-trash - alt";
                    btn.Click += RemCat;

                    tc2.Controls.Add(btn);
                    tc1.Text = categoriePro.descript;
                    tr.Cells.Add(tc1);
                    tr.Cells.Add(tc2);
                    tableau_categorie.Rows.Add(tr);
                }
            }
        }
    }

    private void RemCat(object sender, EventArgs e)
    {
        btn_modifier.Enabled = true;
        LinkButton btn = (LinkButton)sender;
        int idCat = int.Parse(btn.ID.Split('-')[1]);
        BD_CoEco.ChangeStatusCategorie(idCat, 2);
        loadCat();
    }


    protected void btn_lieEmp_Click(object sender, EventArgs e)
    {
        btn_lieEmp.Enabled = true;
        btn_apply.Enabled = true;
        int empId = int.Parse(ddl_employe.SelectedValue);
        int indexEmp = ddl_employe.SelectedIndex;

        T_Employe emp = BD_CoEco.GetEmpByID(empId);

        ddl_employe.Items.RemoveAt(indexEmp);
        lst_employeAjouter2.Items.Add(new ListItem(emp.prenom + " " + emp.nom, emp.idEmploye.ToString()));
        btn_modifier.Enabled = false;
    }

    private void ajouterEmpLie()
    {
        List<T_Employe> listeEmpAuProjet = new List<T_Employe>();
        T_Projet monProjet = new T_Projet();
        monProjet.idProjet = int.Parse(Request.QueryString["id"]);

        List<T_Employe> listEmpPro = BD_CoEco.GetEmpByProject(monProjet);
        List<int> listId = new List<int>();

        foreach (T_Employe EmpPro in listEmpPro)
        {
            listId.Add(EmpPro.idEmploye);
        }
            for (int i = 0; i < lst_employeAjouter2.Items.Count; i++)
            {
            if (listId.Count > i)
            {
                if (listId[i] != int.Parse(lst_employeAjouter2.Items[i].Value))
                {
                    T_Employe emp = BD_CoEco.GetEmpByID(int.Parse(lst_employeAjouter2.Items[i].Value));
                    listeEmpAuProjet.Add(emp);
                }
            }
            else
            {
                T_Employe emp = BD_CoEco.GetEmpByID(int.Parse(lst_employeAjouter2.Items[i].Value));
                listeEmpAuProjet.Add(emp);
            }
                
            }

        for (int i = 0; i < listeEmpAuProjet.Count; i++)
        {   
            T_EmployeProjet empPro = new T_EmployeProjet();
            empPro.idEmp = listeEmpAuProjet[i].idEmploye;
            empPro.idPro = monProjet.idProjet;
            BD_CoEco.CreateNewEmpAtProject(empPro);
        }
    }

    protected void btn_ajouterCategorie_Click(object sender, EventArgs e)
    {
        btn_apply.Enabled = true;
        TableRow tr = new TableRow();
        TableCell tc1 = new TableCell();
        TableCell tc2 = new TableCell();
        tc2.CssClass = "fas fa-trash";

        tc1.Text = tbx_cat.Text;

        tr.Cells.Add(tc1);
        tr.Cells.Add(tc2);
        tableau_categorie.Rows.Add(tr);
        CreateCat();
        loadCat();
        btn_modifier.Enabled = false;
        tbx_cat.Text = "";
    }

    private void CreateCat()
    {
        T_CategoriePro newCat = new T_CategoriePro();
        newCat.descript = tbx_cat.Text;
        newCat.idStatusCat = 1;
        newCat.idProjet = int.Parse(Request.QueryString["id"]);
        BD_CoEco.CreateNewCategorie(newCat);
    }
}