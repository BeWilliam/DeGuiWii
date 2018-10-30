USE CoEco_BD
GO

/*Insertion de base pour débug*/
INSERT INTO Projet(idProjet, nom) VALUES (1, 'Projet de débug')
INSERT INTO Projet(idProjet, nom) VALUES (2, 'Projet du swag')
INSERT INTO CategoriePro(idProjet, descript) VALUES (1, 'Categorie Bidon')
INSERT INTO CategoriePro(idProjet, descript) VALUES (1, 'DEBUGAGE dappliaction')
INSERT INTO CategoriePro(idProjet, descript) VALUES (2, 'Vacances')
INSERT INTO CategoriePro(idProjet, descript) VALUES (2, 'Congé')

INSERT INTO Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Gagnon','Guillaume')
INSERT INTO Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Lemieux','William')
INSERT INTO Employe(idFonction, idStatus, nom, prenom) VALUES (1,1,'Thériault','Denis')

INSERT INTO Depense(idType, idProjet, idEmp, montant) VALUES (1,1,1,20)
INSERT INTO Depense(idType, idProjet, idEmp, montant) VALUES (1,1,2,30)
INSERT INTO Depense(idType, idProjet, idEmp, montant) VALUES (2,2,3,10)

INSERT INTO Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (1,1,1,1,133,'Commentaire')
INSERT INTO Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (2,1,1,1,100,'LPO - RDL')
INSERT INTO Kilometrage(idEmp, idPro, idCat, idTaux, nbKilo, commentaire) VALUES (3,1,1,2,50,'SMB-QC')

INSERT INTO FeuilleDeTemps(idCategorie, idEmp, temps, note, ddate) VALUES (1,1,2.5, 'Débugage', GETDATE())
INSERT INTO FeuilleDeTemps(idCategorie, idEmp, temps, note, ddate) VALUES (3,2,5, 'Débugage', GETDATE())
INSERT INTO FeuilleDeTemps(idCategorie, idEmp, temps, note, ddate) VALUES (4,3,2.5, '1', GETDATE())
INSERT INTO FeuilleDeTemps(idCategorie, idEmp, temps, note, ddate) VALUES (2,2,8, '2', GETDATE())
INSERT INTO FeuilleDeTemps(idCategorie, idEmp, temps, note, ddate) VALUES (1,3,7.5, '3', GETDATE())

INSERT INTO EmployeProjet(idEmp, idPro) VALUES (1,2)
INSERT INTO EmployeProjet(idEmp, idPro) VALUES (2,2)
INSERT INTO EmployeProjet(idEmp, idPro) VALUES (3,1)
INSERT INTO EmployeProjet(idEmp, idPro) VALUES (2,1)
INSERT INTO EmployeProjet(idEmp, idPro) VALUES (1,2)
