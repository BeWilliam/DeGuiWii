/*-Cr�ation de la BD-*/
/*-Cr��e le 24 octobre 2018*/

USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CoEco_BD')
DROP DATABASE CoEco_BD

CREATE DATABASE CoEco_BD
GO
USE CoEco_BD
GO

/*-Cr�ation des tables-*/
/*Table pour les taux de kilometrage*/
CREATE TABLE T_TauxKilo(
	idTaux INT IDENTITY(1,1),
	taux FLOAT(3) NOT NULL,
	ddate DATE,
	CONSTRAINT fkIdTaux PRIMARY KEY(idTaux)
)

/*-Table pour les status des employ�s-*/
CREATE TABLE T_StatusEmploye (
	idStatusEmp INT IDENTITY(1,1),
	descript VARCHAR(10) NOT NULL,
	CONSTRAINT pkNoStatusEmp PRIMARY KEY (idStatusEmp)
)

/*-Table pour les status des cat�gories-*/
CREATE TABLE  T_StatusCategorie (
	idStatusCat INT IDENTITY (1,1),
	descript VARCHAR(10) NOT NULL,
	CONSTRAINT pkNoStatusCat PRIMARY KEY (idStatusCat)
)

/*-Table pour les status des Projets-*/
CREATE TABLE  T_StatusProjet (
	noStatusPro INT IDENTITY (1,1),
	descript VARCHAR(10) NOT NULL,
	CONSTRAINT pkNoStatusPro PRIMARY KEY (noStatusPro)
)

/*-Table pour les fonctions des employ�s-*/
CREATE TABLE T_FonctionEmploye(
	idFonctionEmp INT IDENTITY(1,1),
	descript VARCHAR(20),
	CONSTRAINT pkIdFonctionEmp PRIMARY KEY (idFonctionEmp)
)

/*Table pour les types de d�pense*/
CREATE TABLE T_TypeDepense(
	idDepense INT IDENTITY(1,1),
	descript VARCHAR(25),
	CONSTRAINT pkIdDepdense PRIMARY KEY(idDepense)
)

/*-Table pour les employ�s-*/
CREATE TABLE T_Employe(
	idEmploye INT IDENTITY(1,1),
	nom VARCHAR(30) NOT NULL,
	prenom VARCHAR(30) NOT NULL,
	courriel VARCHAR(50),
	mdp VARCHAR(30),
	/*Foreign key*/
	idStatus INT DEFAULT 1 NOT NULL,
	idFonction INT NOT NULL,
	CONSTRAINT pkIdEmploye PRIMARY KEY (idEmploye),
	CONSTRAINT fkIdStatusEmp FOREIGN KEY (idStatus) REFERENCES T_StatusEmploye(idStatusEmp),
	CONSTRAINT frIdFonctionEmp FOREIGN KEY (idFonction) REFERENCES T_FonctionEmploye(idFonctionEmp)
)


/*-Table pour les projets-*/
CREATE TABLE T_Projet(
	idProjet INT,
	nom VARCHAR(100) NOT NULL,
	descript VARCHAR(500),
	responsable INT, /*ID de l'employ� qui sera le responsable*/
	dateDebut DATE,
	dateFin DATE ,
	/*FOREIGN KEY*/
	idStatus INT DEFAULT 1 NOT NULL,
	CONSTRAINT pkIdProjet PRIMARY KEY (idProjet),
	CONSTRAINT fkIdStatusPro FOREIGN KEY (idStatus) REFERENCES T_StatusProjet(noStatusPro)
)

/*-Table pour les cat�gories-*/
CREATE TABLE T_CategoriePro(
	idCategorie INT,
	descript VARCHAR(50) NOT NULL,
	/*FOREIGN KEY*/
	idProjet INT NOT NULL,
	idStatusCat INT DEFAULT 1 NOT NULL,
	CONSTRAINT pkIdCategorie PRIMARY KEY(idCategorie),
	CONSTRAINT fkIdProjetCat FOREIGN KEY (idProjet) REFERENCES T_Projet(idProjet),
	CONSTRAINT fkIdStatusCat FOREIGN KEY(idStatusCat) REFERENCES T_StatusCategorie(idStatusCat)
)


/*-Table pour les d�penses-*/
CREATE TABLE T_Depense(
	idDepense INT IDENTITY(1,1),
	montant SMALLMONEY,
	descript VARCHAR(50),
	aprobation BIT,
	ddate DATE,
	/*FOREIGN KEY*/
	idType INT NOT NULL,
	idProjet INT NOT NULL,
	idCategorie INT,
	idEmp INT NOT NULL,
	CONSTRAINT fkIdDepense PRIMARY KEY(idDepense),
	CONSTRAINT fkIdTypeDep FOREIGN KEY(idType) REFERENCES T_TypeDepense(idDepense),
	CONSTRAINT fkIdProjetDep FOREIGN KEY(idProjet) REFERENCES T_Projet(idProjet),
	CONSTRAINT fkIdCategorieDep FOREIGN KEY(idCategorie) REFERENCES T_CategoriePro(idCategorie),
	CONSTRAINT fkIdEmpDep FOREIGN KEY(idEmp) REFERENCES T_Employe(idEmploye)

)

/*-Table pour les feuilles de temps-*/
CREATE TABLE T_FeuilleDeTemps(
	idFeuilleDeTemps INT IDENTITY(1,1),
	ddate DATE,
	temps FLOAT(3), /*� tester*/
	note VARCHAR(100),
	/*FOREIGN KEY*/
	idEmp INT NOT NULL,
	idCategorie INT NOT NULL,
	CONSTRAINT fkIdFeuilleDeTemps PRIMARY KEY(idFeuilleDeTemps),
	CONSTRAINT fkIdEmpFeuille FOREIGN KEY (idEmp) REFERENCES T_Employe(idEmploye),
	CONSTRAINT fkIdCategorieFeuille FOREIGN KEY (idCategorie) REFERENCES T_CategoriePro(idCategorie)
)

/*Table pour les kilometrage*/
CREATE TABLE T_Kilometrage(
	idKilo INT IDENTITY(1,1),
	nbKilo FLOAT(3) NOT NULL,
	commentaire VARCHAR(100),
	ddate DATE DEFAULT GETDATE(),
	/*FOREIGN KEY*/
	idTaux INT NOT NULL,
	idEmp INT NOT NULL,
	idPro INT NOT NULL,
	idCat INT NOT NULL,
	CONSTRAINT pkIdKilo PRIMARY KEY(idKilo),
	CONSTRAINT fkIdTauxKilo FOREIGN KEY(idTaux) REFERENCES T_TauxKilo(idTaux),
	CONSTRAINT fkIdEmpKilo FOREIGN KEY(idEmp) REFERENCES T_Employe(idEmploye),
	CONSTRAINT fkIdPro FOREIGN KEY (idPro) REFERENCES T_Projet(idProjet),
	CONSTRAINT FkIdCat FOREIGN KEY(idCat) REFERENCES T_CategoriePro(idCategorie)
)

CREATE TABLE T_EmployeProjet(
	idEmpPro INT IDENTITY(1,1),
	/*FOREIGN KEY*/
	idEmp INT NOT NULL,
	idPro INT NOT NULL,
	CONSTRAINT pkIdEmpPro PRIMARY KEY(idEmpPro),
	CONSTRAINT fkIdEmpEmpPro FOREIGN KEY (idEmp) REFERENCES T_Employe(idEmploye),
	CONSTRAINT fkIdProEmpPro FOREIGN KEY (idPro) REFERENCES T_Projet(idProjet)
)




/*Insertion des informations de base pour le bon fonctionnement de la DB*/

/*Insertion des infos pour le status des employ�s*/
INSERT INTO T_StatusEmploye(descript) VALUES ('Actif')
INSERT INTO T_StatusEmploye(descript) VALUES ('Inactif')


/*Insertion des infos pour le status des cat�gories*/
INSERT INTO T_StatusCategorie(descript) VALUES ('Actif')
INSERT INTO T_StatusCategorie(descript) VALUES ('Inactif')


/*Insertion des infos pour le status des projets*/
INSERT INTO T_StatusProjet(descript) VALUES ('En cours')
INSERT INTO T_StatusProjet(descript) VALUES ('Termin�')
INSERT INTO T_StatusProjet(descript) VALUES ('Archiv�')

/*Insertion des fonctions que les employ�s peuvent avoir*/
INSERT INTO T_FonctionEmploye(descript) VALUES ('Employ� de bureau')
INSERT INTO T_FonctionEmploye(descript) VALUES ('Employ� de terrain')
INSERT INTO T_FonctionEmploye(descript) VALUES ('Administrateur')


/*Insertion des types de d�pense*/
INSERT INTO T_TypeDepense (descript) VALUES ('Hebergement')
INSERT INTO T_TypeDepense (descript) VALUES ('Repas')
INSERT INTO T_TypeDepense (descript) VALUES ('Stationnements')
INSERT INTO T_TypeDepense (descript) VALUES ('Autre')

/*Insertion de l'employ� Administrateur*/
INSERT INTO T_Employe(idFonction, idStatus, mdp, nom, prenom) VALUES (3, 1, 'mobius', ' ', 'Admin')


