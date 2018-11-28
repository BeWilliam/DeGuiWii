USE CoEco_BD
GO

/*Insertion de base pour débug*/
INSERT INTO T_Projet(idProjet, nom) VALUES (1, 'Projet de débug')
INSERT INTO T_Projet(idProjet, nom) VALUES (2, 'Projet du swag')

INSERT INTO T_Projet(idProjet, nom, responsable) VALUES (410, 'ProjetDebug', 65)

INSERT INTO T_CategoriePro(idCategorie, idProjet, descript) VALUES (1, 1, 'Categorie Bidon')
INSERT INTO T_CategoriePro(idCategorie, idProjet, descript) VALUES (2, 1, 'DEBUGAGE dappliaction')
INSERT INTO T_CategoriePro(idCategorie, idProjet, descript) VALUES (3, 2, 'Vacances')
INSERT INTO T_CategoriePro(idCategorie, idProjet, descript) VALUES (4, 2, 'Congé')

INSERT INTO T_Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Gagnon','Guillaume')
INSERT INTO T_Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Lemieux','William')
INSERT INTO T_Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Thériault','Denis')

INSERT INTO T_Depense(idType, idProjet, idEmp, montant, aprobation) VALUES (1,1,1,20, 1)
INSERT INTO T_Depense(idType, idProjet, idEmp, montant) VALUES (1,1,2,30)
INSERT INTO T_Depense(idType, idProjet, idEmp, montant, aprobation) VALUES (2,2,3,10, 0)

INSERT INTO T_Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (1,1,1,1,133,'Commentaire')
INSERT INTO T_Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (2,1,1,1,100,'LPO - RDL')
INSERT INTO T_Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (3,1,1,2,50,'SMB-QC')

INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (1,1,2.5,2.5,2.5,2.5,2.5,2.5,2.5, 'Débugage', GETDATE())
INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (1,2,5,5,5,5,5,5,5, 'Débugage', GETDATE())
INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (1,3,2,2,2,2,2,2,2, 'Débugage', GETDATE())
INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (1,4,2,2,5,5,5,2.5,2.5, 'Débugage', GETDATE())
INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (1,5,2,2,5,5,5,2.5,2.5, 'Débugage', GETDATE())
INSERT INTO T_FeuilleDeTemps(idCategorie, idEmp, dimanche, lundi, mardi, mercredi, jeudi, vendredi,samedi, commentaireDimanche, semaine) VALUES (135,4,2,2,5,5,5,2.5,2.5, 'Débugage', GETDATE())

INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (1,2)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (2,2)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (3,1)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (2,1)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (1,2)

INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (4,3)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (4,4)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (4,5)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (7,3)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (7,1)
INSERT INTO T_EmployeProjet(idEmp, idPro) VALUES (7,2)