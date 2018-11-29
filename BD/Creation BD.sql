/*-Création de la BD-*/
/*-Créée le 24 octobre 2018*/

USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'CoEco_BD')
DROP DATABASE CoEco_BD

CREATE DATABASE CoEco_BD
GO
USE CoEco_BD
GO

/*Table pour les types d'auto*/
CREATE TABLE T_TypeAuto(
	idType INT IDENTITY(1,1),
	descript VARCHAR(50),
	CONSTRAINT pkIdType PRIMARY KEY (idType)
)

/*-Création des tables-*/
/*Table pour les taux de kilometrage*/
CREATE TABLE T_TauxKilo(
	idTaux INT IDENTITY(1,1),
	taux FLOAT(3) NOT NULL,
	ddate DATE,
	idTypeAuto INT NOT NULL,
	/*CONSTRAINT fkIdStatusEmp FOREIGN KEY (idStatus) REFERENCES T_StatusEmploye(idStatusEmp)*/
	CONSTRAINT fkIdTaux PRIMARY KEY(idTaux),
	CONSTRAINT fkIdTypeAuto FOREIGN KEY (idTypeAuto) REFERENCES T_TypeAuto(idType)
)

/*-Table pour les status des employés-*/
CREATE TABLE T_StatusEmploye (
	idStatusEmp INT IDENTITY(1,1),
	descript VARCHAR(10) NOT NULL,
	CONSTRAINT pkNoStatusEmp PRIMARY KEY (idStatusEmp)
)

/*-Table pour les status des catégories-*/
CREATE TABLE  T_StatusCategorie (
	idStatusCat INT IDENTITY (1,1),
	descript VARCHAR(10) NOT NULL,
	CONSTRAINT pkNoStatusCat PRIMARY KEY (idStatusCat)
)

/*-Table pour les status des Projets-*/
CREATE TABLE  T_StatusProjet (
	noStatusPro INT IDENTITY (1,1),
	descript VARCHAR(20) NOT NULL,
	CONSTRAINT pkNoStatusPro PRIMARY KEY (noStatusPro)
)

/*-Table pour les fonctions des employés-*/
CREATE TABLE T_FonctionEmploye(
	idFonctionEmp INT IDENTITY(1,1),
	descript VARCHAR(20),
	CONSTRAINT pkIdFonctionEmp PRIMARY KEY (idFonctionEmp)
)

/*Table pour les types de dépense*/
CREATE TABLE T_TypeDepense(
	idDepense INT IDENTITY(1,1),
	descript VARCHAR(25),
	CONSTRAINT pkIdDepdense PRIMARY KEY(idDepense)
)

/*-Table pour les employés-*/
CREATE TABLE T_Employe(
	idEmploye INT IDENTITY(1,1),
	nom VARCHAR(30) NOT NULL,
	prenom VARCHAR(30) NOT NULL,
	courriel VARCHAR(50),
	loginName VARCHAR(30),
	mdp VARCHAR(30),
	congesMaladie FLOAT(5),
	congesFeries FLOAT(5),
	vacances FLOAT(5),
	heuresAccumuleesOuSansSolde FLOAT(5),
	congesPersonnels FLOAT(5),
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
	responsable INT, /*ID de l'employé qui sera le responsable*/
	dateDebut DATE,
	dateFin DATE ,
	heureAlloue FLOAT(30),
	/*FOREIGN KEY*/
	idStatus INT DEFAULT 1 NOT NULL,
	CONSTRAINT pkIdProjet PRIMARY KEY (idProjet),
	CONSTRAINT fkIdStatusPro FOREIGN KEY (idStatus) REFERENCES T_StatusProjet(noStatusPro)
)

/*-Table pour les catégories-*/
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


/*-Table pour les dépenses-*/
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
	semaine DATE,
	dimanche FLOAT(3),
	lundi FLOAT(3),
	mardi FLOAT(3),
	mercredi FLOAT(3),
	jeudi FLOAT(3),
	vendredi FLOAT(3),
	samedi FLOAT(3), /*À tester*/
	commentaireDimanche VARCHAR(100),
	commentaireLundi VARCHAR(100),
	commentaireMardi VARCHAR(100),
	commentaireMercredi VARCHAR(100),
	commentaireJeudi VARCHAR(100),
	commentaireVendredi VARCHAR(100),
	commentaireSamedi VARCHAR(100),
	approbation BIT DEFAULT 0,
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

/*Insertion des infos pour le status des employés*/
INSERT INTO T_StatusEmploye(descript) VALUES ('Actif')
INSERT INTO T_StatusEmploye(descript) VALUES ('Inactif')


/*Insertion des infos pour le status des catégories*/
INSERT INTO T_StatusCategorie(descript) VALUES ('Actif')
INSERT INTO T_StatusCategorie(descript) VALUES ('Inactif')


/*Insertion des infos pour le status des projets*/
INSERT INTO T_StatusProjet(descript) VALUES ('En cours')
INSERT INTO T_StatusProjet(descript) VALUES ('Terminé')
INSERT INTO T_StatusProjet(descript) VALUES ('Archivé')
INSERT INTO T_StatusProjet(descript) VALUES ('En construction')

/*Insertion des fonctions que les employés peuvent avoir*/
INSERT INTO T_FonctionEmploye(descript) VALUES ('Employé de bureau')
INSERT INTO T_FonctionEmploye(descript) VALUES ('Employé de terrain')
INSERT INTO T_FonctionEmploye(descript) VALUES ('Administrateur')


/*Insertion des types de dépense*/
INSERT INTO T_TypeDepense (descript) VALUES ('Hebergement')
INSERT INTO T_TypeDepense (descript) VALUES ('Repas')
INSERT INTO T_TypeDepense (descript) VALUES ('Stationnements')
INSERT INTO T_TypeDepense (descript) VALUES ('Autre')

/*Insertion des Types d'autos*/
INSERT INTO T_TypeAuto (descript) VALUES ('Auto')
INSERT INTO T_TypeAuto (descript) VALUES ('Camion')

/*Insertion de l'employé Administrateur*/
INSERT INTO T_Employe(idFonction, idStatus, mdp, nom, prenom, loginName) VALUES (3, 1, 'mobius', ' ', 'admin', 'admin')


INSERT INTO T_TauxKilo(ddate, taux, idTypeAuto) VALUES ('2018-01-01', 0.43, 1) /*AUTO*/
INSERT INTO T_TauxKilo(ddate, taux, idTypeAuto) VALUES ('2018-01-01', 0.43, 2) /*CAMION*/


/*Insertion des procédures stockées*/

USE CoEco_BD
GO

/*Procédure permettant d'obtenir le total des dépenses pour un projet*/
IF OBJECT_ID ( 'PS_DepenseProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_DepenseProjet 
GO


CREATE PROCEDURE PS_DepenseProjet
	@idProjet INT,
	@total SMALLMONEY OUTPUT
AS
	SELECT @total = SUM(montant) FROM T_Depense
	WHERE idProjet = @idProjet

GO


DECLARE @idProjet INT
SET @idProjet = 1
DECLARE @total SMALLMONEY

EXEC PS_DepenseProjet
@idProjet,
@total = @total OUTPUT

SELECT @total




/*Procédure permettant de changer l'état d'un projet*/
IF OBJECT_ID ( 'PS_ChangerEtatProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerEtatProjet 
GO

CREATE PROCEDURE PS_ChangerEtatProjet
	@idProjet INT,
	@idStatus INT
AS
	UPDATE T_Projet
	SET idStatus = @idStatus
	WHERE idProjet = @idProjet

GO

/*EXEC PS_ChangerEtatProjet 1, 1*/

/*Procédure permettant de changer l'état d'une catégorie*/
IF OBJECT_ID ( 'PS_ChangerEtatCategorie', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerEtatCategorie 
GO

CREATE PROCEDURE PS_ChangerEtatCategorie
	@idCategorie INT,
	@idStatusCat INT
AS
	UPDATE T_CategoriePro
	SET idStatusCat = @idStatusCat
	WHERE idCategorie = @idCategorie

GO

/*EXEC PS_ChangerEtatCategorie 1, 1*/

/*Procédure permettant de changer le status d'un employé*/


IF OBJECT_ID ( 'PS_ChangerStatusEmp', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerStatusEmp 
GO

CREATE PROCEDURE PS_ChangerStatusEmp
	@idEmploye INT,
	@idStatus INT
AS
	UPDATE T_Employe
	SET idStatus = @idStatus
	WHERE idEmploye = @idEmploye
GO

--Procédure qui retourne le dernier ID de catégorie créer
CREATE PROCEDURE PS_GetMaxIdCategorie
	@idCat INT OUTPUT
AS
	SELECT @idCat = MAX(idCategorie) FROM T_CategoriePro
GO

/*EXEC PS_ChangerStatusEmp 1,1*/


/*Procédure permettant de changer la date de fin d'un projet*/
IF OBJECT_ID ( 'PS_ChangerDateFinProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerDateFinProjet 
GO

CREATE PROCEDURE PS_ChangerDateFinProjet
	@idProjet INT,
	@ddateFin DATE
AS
	UPDATE T_Projet
	SET dateFin = @ddateFin
	WHERE idProjet = @idProjet
GO

/*Procédure permettant d'ajouter un employé au projet*/
IF OBJECT_ID ( 'PS_GetMaxIdEmpolye', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdEmpolye 
GO

CREATE PROCEDURE PS_GetMaxIdEmpolye
	@idProjet INT OUTPUT
AS
	SELECT @idProjet = MAX(idEmploye) FROM T_Employe
GO

/*Procédure permettant d'obtenir l'id du nouveau Employe au projet*/
IF OBJECT_ID ( 'PS_GetMaxIdEmpPro', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdEmpPro 
GO

CREATE PROCEDURE PS_GetMaxIdEmpPro
	@idEmpPro INT OUTPUT
AS
	SELECT @idEmpPro = MAX(idEmpPro) FROM T_EmployeProjet
GO

/*Procédure permettant de déterminer le plus gros id de feuille de temps*/
IF OBJECT_ID ( 'PS_GetMaxIdFeuilleTemps', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdFeuilleTemps 
GO

CREATE PROCEDURE PS_GetMaxIdFeuilleTemps
	@idFeuilleTemps INT OUTPUT
AS
	SELECT @idFeuilleTemps = MAX(idFeuilleDeTemps) FROM T_FeuilleDeTemps
GO


/*Procédure permettant d'ajouter un employé */
IF OBJECT_ID ( 'PS_GetMaxIdProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdProjet 
GO

CREATE PROCEDURE PS_GetMaxIdProjet
	@idProjet INT OUTPUT
AS
	SELECT @idProjet = MAX(idProjet) FROM T_Projet
GO




/*IMPORTATION DES VIELLES DONNÉES*/
/*Importation employé*/
INSERT INTO T_Employe(nom, prenom, idStatus, courriel, idFonction) VALUES 
( 'Lizotte',  'Pierre', 2,  '', 1),
( 'Vachon',  'Sophie', 1,  'sophie_vachon@hotmail.com', 2),
( 'Gaumond',  'Suzanne', 1,  'suzanneg5@hotmail.com', 1),
( 'Guignard',  'Stéphane', 1,  'sguignard1973@gmail.com', 1),
( 'Malenfant',  'Karine', 2,  'makari@hotmail.com', 1),
( 'Dubé',  'Jean-Yves', 2,  '', 1),
( 'Malenfant-Gamache',  'Pascale', 2,  'pascalemalenfant@hotmail.com', 1),
( 'Beaudoin',  'Anne-Marie', 2,  'zanon80@hotmail.com', 1),
( 'Bergeron',  'Luce', 2,  'caracterre@videotron.ca', 1),
( 'Beaulieu',  'Renaud', 2,  'renaud-beaulieu@hotmail.com', 1),
( 'Nadeau',  'Caroline', 2,  'nadeau.caroline@videotron.ca', 1),
( 'Gagné',  'Pierre', 2,  '', 1),
( 'Bouchard',  'Patrice', 2,  '', 1),
( 'Martin',  'Johanne', 2,  '', 1),
( 'OUELLET',  'Samuel', 2,  'sam_revolution@hotmail.com', 1),
( 'SAMSON',  'Diane', 2,  'didi_samy@hotmail.com', 1),
( 'ROSS',  'Stéphanie', 2,  'hurricane856@hotmail.com', 1),
( 'DESJARDINS',  'François', 2,  'frank1955@hotmail.com', 1),
( 'Hamm',  'François', 2,  'francoishamm@gmail.com', 1),
( 'Avard',  'Catherine', 2,  'cat_avard@yahoo.ca', 1),
( 'HUDON',  'Tristan', 2,  'dias_hp2@hotmail.com', 1),
( 'LAVALLÉE-CHOUINARD',  'Catherine', 2,  'catherinelavallee_c@hotmail.com', 1),
( 'BARTHELL-MAILHOT',  'Olivier', 2,  'oli_cuisineqc@hotmail.com', 1),
( 'PELLETIER',  'Simon', 2,  'smnplltr@gmail.com', 1),
( 'GENDRON-MACIAS',  'Gabriel', 2,  'allo-28boby@hotmail.com', 1),
( 'Lévesque',  'Gaston', 1,  'glevesque1945@hotmail.com', 1),
( 'Jeghers',  'Erik', 2,  'e.jeghers@gmail.com', 1),
( 'Leblanc',  'Anne', 2,  'anneleblanc@live.ca', 1),
( 'Fouchard',  'Benjamin', 2,  'fouchard.benjamin@courrier.uqam.ca', 1),
( 'Naud Véronneau',  'Francis', 2,  'fnv_1@hotmail.com', 1),
( 'Beauchemin',  'Véronique', 2,  'vbeauchemin@yahoo.fr', 1),
( 'Lapointe',  'Vicky', 2,  'lapointe.vicky@videotron.ca', 1),
( 'LALANDE ',  'Dominique', 1,  '', 1),
( 'PLANTE',  'Catherine', 2,  '', 1),
( 'RIOUX',  'Geneviève', 2,  '', 1),
( 'Culhuac',  'Katja', 1,  'katja.culhuac@usherbrooke.ca', 1),
( 'Beaulieu',  'Michel', 2,  '', 1),
( 'Fournier',  'Anne-Frédérique', 2,  'titeanne_90@hotmail.com', 1),
( 'GRANGER',  'Marion', 2,  'stage@co-eco.org', 1),
( 'Sévigny',  'Kathleen', 2,  'tii-kath@hotmail.com', 1),
( 'Lévesque',  'Jocelyn', 1,  'camporignal@mail.com', 1),
( 'Gagnon',  'Catherine', 2,  'cgagnon@cyclonemarketing.ca', 1),
( 'Chartrand',  'Ian', 2,  'ianchartrand1@gmail.com', 1),
( 'Ouellet',  'Guillaume', 2,  '', 1),
( 'Daigle',  'Aline', 1,  'aline.daigle@hotmail.ca', 1),
( 'Vallerand',  'Charles-Olivier', 2,  'paradys53@outlook.com', 1),
( 'Côté',  'Marie-Joëlle', 2,  'marie-joelle.cote@uqtr.ca', 1),
( 'Lavoie',  'Marjorie', 2,  'marjo.lavoie@hotmail.fr', 1),
( 'BRAZEAU',  'Nicolas', 2,  'nbrazeau@ruralys.org', 1),
( 'Bélanger',  'Ève-Marie', 2,  'charlie980@live.ca', 1),
( 'Dumais',  'Josée-Ann', 2,  'joseeann.dumais@hotmail.com', 1),
( 'Soucy',  'Gabriel', 2,  'gabriel@aildukamouraska.com', 1),
( 'Vanier',  'Jean-Louis', 1,  'lou2055@live.ca', 1),
( 'Beaulieu',  'Martin', 2,  '', 1),
( 'Gendron',  'François', 2,  'casagendron@gmai.com', 1),
( 'Boulet-Thuotte',  'Valérie', 1,  'valerieb.thuotte@gmail.com', 1),
( 'Briand',  'Stéfany', 1,  'stefybriand@gmail.com', 1),
( 'Guillemette',  'Rémy', 1,  'avalanche_007@hotmail.com', 1),
( 'Hébert Tardif',  'Noélie', 1,  'noelie.hebert.tardif@gmail.com', 1),
( 'Bélanger',  'François', 2,  'fbelanger391@gmail.com', 1),
( 'Pelletier Labelle',  'Maxime', 1,  'maximepelletierlabelle@gmail.com', 1),
( 'Paradis',  'André', 1,  'andreparadis@bell.net', 1),
( 'Dufaut',  'Peggy', 1,  'peggycathia@gmail.com', 1)


/*Importation des projets*/
INSERT INTO T_Projet(idProjet, nom, descript, dateDebut, dateFin, idStatus) VALUES
(43,  'RECYC-QUÉBEC - Trousses',  'Prrojet trousses',  '2009-11-02',  '2010-03-31', 2),
(42,  'RECYC-QUÉBEC - RDD',  '',  '2009-07-01',  '', 2),
(32,  'Ville de La Pocatière',  'Plan de communication et sensibilisation',  '',  '', 1),
(33,  'Écocentres',  '',  '',  '', 1),
(39,  'RECYC-QUÉBEC - 3RV au travail',  'Projet 3RV au travail',  '2009-05-01',  '', 2),
(31,  'Campagne ISE',  '',  '',  '', 1),
(30,  'Événements écoresponsables',  'Favoriser la tenue',  '2008-10-24',  '2009-10-24', 2),
(29,  'Administration',  '',  '',  '', 1),
(26,  'RECYC - QUÉBEC - Mini-collecte',  'Mini-collecte',  '2008-11-01',  '2009-06-30', 2),
(27,  'Projet EAU 2008',  'Sensibilisation ',  '',  '', 2),
(28,  'Offres de service',  '',  '',  '', 1),
(37,  'Projet EAU 2009',  'Sensibilisation ',  '',  '', 2),
(25,  'SQRD 2009-12',  '',  '',  '', 2),
(36,  'Suivi PGMR Témiscouata',  '',  '',  '', 2),
(18,  'Suivi PGMR Rivière-du-Loup',  'Coordination du PGMR de la MRC de Rivière-de-Loup',  '',  '', 1),
(20,  'Suivi PGMR des Basques',  '',  '',  '', 1),
(48,  'RECYC-Québec 2010-11 (02) - ABC du compostage',  'Préparer des formations sur le composatage dans les écoles',  '2010-03-01',  '', 2),
(34,  'ERE',  'Projets g',  '',  '', 1),
(19,  'Suivi PGMR Kamouraska',  '',  '',  '', 1),
(44,  'Ville de Rivière-du-Loup',  'Conseillère deux jours semaine à la ville de Rivière-du-Loup',  '2010-01-10',  '2010-12-31', 2),
(45,  'RECYC-QUÉBEC - ICI conférence (04)',  '',  '2010-01-20',  '2010-03-31', 2),
(46,  'CAMPUS Rivière-du-Loup - FAQDD',  'Projet Rivière-du-Loup Ville étudiante (subvention FAQDD)',  '2010-03-01',  '2012-02-01', 2),
(47,  'IGA - Écomunicipalité RDL ',  '',  '',  '', 2),
(38,  'Vacances et congés',  '',  '',  '', 1),
(49,  'IGA - Écomunicipalités Co-éco',  'projets subventionnés par IGA',  '',  '', 2),
(50,  'Suivi PGMR Rivière-du-Loup - 3e voie,  mun. rurales','',  '',  '', 1),
(51,  'ITA - La Pocatière',  'Cégep vert',  '',  '', 2),
(52,  'RECYC-QUÉBEC - TIC',  'projet de récupération des TIC pour les ICI',  '',  '', 2),
(53,  'Peinture Boomerang',  '',  '',  '', 1),
(41,  'IGA - ',  '',  '2009-05-18',  '2009-12-31', 2),
(56,  'RECYC-QUÉBEC - Le compost à la mode de chez vous!',  '',  '',  '', 2),
(55,  'RURALYS',  '',  '',  '', 1),
(62,  'Collecte qui carbure!',  'Projet campagne de sensibilisation collecte 3e voie!',  '',  '', 1),
(57,  'Projet PART',  'Projet Pratiques innovantes de sensibilisation au tri à la source des matières résiduelles',  '',  '', 2),
(58,  'CLIMAT MUNICIPALITÉ Kamouraska',  '',  '',  '', 2),
(59,  'RÉUTILISATION',  '',  '',  '', 2),
(61,  'RÉVISION PGMR',  '',  '',  '', 1),
(63,  'ERE-Kamouraska',  '',  '2016-01-01',  '', 1),
(64,  'ERE-Basques',  '',  '2016-01-01',  '', 1),
(65,  'ÉCOCHANTIER',  'Début du projet 1er novembre 2016 (date à laquelle on commence à inscrire des heures)',  '',  '', 1),
(66,  'ECONOMIE CIRCULAIRE',  'Projet subventionné - temps inscrit à compter du 15 septembre - faire la différence entre RQ regroupement et DEC - Canada\r\n',  '2016-09-01',  '', 2),
(67,  'Superbac',  'Projet en collaboration avec la Comm. scolaire de Kamouraska-Rivière-du-Loup inscrit dans le projet CquiC en 2016\r\nContrat avec comm. scol. pour 2017 et 2018\r\nTAUX 70 $ de lheure',  '2001-01-17',  '2030-06-18', 1),
(68,  'RIDT - ERE et communication',  '',  '',  '', 1)


/*Insertion des Catégories*/
INSERT INTO T_CategoriePro(idCategorie, idProjet, descript, idStatusCat) VALUES
(196,  29,  'Ressources humaines', 1),
(189,  20,  'Réunions Comités', 1),
(191,  38,  'Congés maladie', 1),
(188,  20,  'CA Récupération des Basques', 1),
(187,  36,  'R&D', 1),
(186,  18,  'R&D', 1),
(185,  19,  'R&D', 1),
(184,  20,  'R&D', 1),
(183,  37,  'Projet EAU', 1),
(182,  37,  'Gestion administrative', 1),
(181,  36,  'Gestion des matières résiduelles', 1),
(180,  36,  'Comppostage', 1),
(178,  28,  'Projets spéciaux', 1),
(177,  28,  'Service conseil', 1),
(172,  33,  'Recherche', 1),
(228,  41,  'IGA - volet administration', 1),
(190,  33,  'Matériaux patrimoniaux - Moulin', 1),
(233,  42,  'Projet RDD', 1),
(158,  34,  'ICI', 1),
(141,  19,  'MRC de Kamouraska', 1),
(140,  34,  'Communications-bulletins', 1),
(138,  34,  'Administration générale et prêt de bacs', 1),
(135,  32,  'Administration', 1),
(134,  33,  'Gestion administrative', 1),
(133,  33,  'Écocentre Dégelis', 1),
(132,  33,  'Gestion administrative', 1),
(131,  33,  'Accueil et gestion quotidienne', 1),
(130,  33,  'Écocentre St-Pascal', 1),
(129,  33,  'Gestion administrative', 1),
(127,  33,  'Écocentre St-Alexandre', 1),
(128,  33,  'Accueil et gestion quotidienne', 1),
(126,  33,  'Gestion administrative', 1),
(125,  33,  'Accueil et gestion quotidienne', 1),
(124,  33,  'Écocentre RDL', 1),
(123,  33,  'Accueil et gestion quotidienne', 1),
(122,  33,  'Gestion administrative', 1),
(121,  33,  'Écocentre La Pocatière', 1),
(120,  32,  'Sensibilisation', 1),
(193,  38,  'Vacances', 1),
(232,  34,  'Mini-collecte', 1),
(117,  32,  'Plan de communication', 1),
(116,  18,  'Écocentres satellites', 1),
(195,  34,  'Formations', 1),
(101,  30,  'Gestion administrative', 1),
(102,  30,  'Projets', 1),
(100,  25,  'Gestion administrative', 1),
(99,  25,  'SQRD - projet', 1),
(98,  27,  'Gestion administrative', 1),
(97,  27,  'Trois-Pistoles', 1),
(96,  27,  'Rivière-du-Loup', 1),
(95,  27,  'Saint-Pascal', 1),
(94,  28,  'Formations', 1),
(93,  26,  'Mini-collecte gestion administrative', 1),
(92,  26,  'Projet mini-collecte', 1),
(90,  29,  'Administration générale', 1),
(110,  19,  'Statistiques', 1),
(192,  38,  'Congés fériés', 1),
(169,  33,  'Recherche', 1),
(157,  29,  'Comptabilité', 1),
(160,  29,  'Réaction', 1),
(235,  29,  'Stage', 1),
(79,  20,  'Calendriers des collectes', 1),
(78,  20,  'Compostage', 1),
(76,  20,  'achat de bacs', 1),
(77,  20,  'Tournée des ICI', 1),
(75,  20,  'Délégation des compétences', 1),
(74,  20,  'Devis appel doffres', 1),
(73,  20,  'Regroupement des collectes', 1),
(179,  18,  'Compostage et projet LIsle-Verte', 1),
(167,  33,  'Accueil et gestion quotidienne', 1),
(241,  44,  'Rivière-du-Loup', 1),
(242,  45,  'Projet - ICI', 1),
(243,  45,  'Administration - projet ICI', 1),
(244,  46,  'Administration FAQDD', 1),
(245,  46,  'Projet', 1),
(166,  29,  'Réunion déquipe', 1),
(248,  47,  'projet', 1),
(249,  47,  'administration', 1),
(168,  33,  'Recherche', 1),
(161,  34,  'Rédaction et corr.', 1),
(170,  33,  'Recherche', 1),
(171,  33,  'Recherche', 1),
(256,  48,  'ABC compostage - projet', 1),
(257,  48,  'ABC compostage - administration', 1),
(108,  31,  'Campagne ISÉ - administration', 1),
(109,  31,  'Campagne ISÉ - Projet', 1),
(65,  18,  'Projet pilote et méthanisation', 1),
(262,  49,  'Projet - barils deau de pluie', 1),
(263,  49,  'Projet conteneurs maritimes', 1),
(264,  50,  'PGMR 3e voie - mun. rurales', 1),
(265,  51,  'Projet', 1),
(266,  52,  'Projet TIC ', 1),
(267,  44,  'Rivière-du-Loup en suppl�ment', 1),
(114,  18,  'Statistiques', 1),
(269,  44,  'Rivière-du-Loup - déplacements', 1),
(270,  53,  'Vente de peinture et administration', 1),
(194,  38,  'Heures accumulées ou sans solde', 1),
(272,  55,  'Paysages Notre-Dame-du-Portage', 1),
(273,  55,  'Paysages parc éolien Témiscouata', 1),
(274,  55,  'Paysages Chaudière-Appalaches', 1),
(275,  55,  'Table des paysages BSL', 1),
(276,  55,  'Verger', 1),
(277,  55,  'Site web et réseaux sociaux', 1),
(278,  55,  'Petits patrimoines', 1),
(279,  55,  'Archéo Musée national des beaux-arts', 1),
(280,  55,  'Archéo Pointe de RDL', 1),
(281,  55,  'Archéo Maison Louis-Bertrand', 1),
(282,  55,  'Administration', 1),
(283,  55,  'Membership', 1),
(284,  55,  'AUTRES', 1),
(285,  56,  'projet', 1),
(111,  19,  'Gestion des matières organiques', 1),
(115,  18,  'Gestion des matières résiduelles', 1),
(197,  34,  'Kiosques', 1),
(198,  20,  'Récupération contenants peinture vides', 1),
(199,  39,  '3RV au travail - volet projet', 1),
(200,  39,  '3 RV au travail - volet administration', 1),
(201,  33,  'PROJET RÉUTILISATION (écomeubles)', 1),
(234,  42,  'Projet RDD - administration', 1),
(231,  32,  'Collecte qui carbure! ICI', 1),
(230,  32,  'Service conseil', 1),
(229,  41,  'IGA - volet projet', 1),
(236,  43,  'Gestion administrative', 1),
(237,  43,  'Projet', 1),
(238,  20,  'Tâches générales', 1),
(268,  28,  'SÉMER - projet sp�cial', 1),
(240,  18,  'Collecte à 3 voies - IGA', 1),
(246,  39,  '3RV au travail volet Site Web', 1),
(250,  33,  'Écocentre St-Hubert', 1),
(251,  33,  'Accueil et gestion quotidienne', 1),
(253,  33,  'Gestion administrative', 1),
(254,  33,  'Recherche', 1),
(255,  38,  'Congés personnels', 1),
(258,  18,  'PGMR - projets divers', 1),
(259,  28,  'Écocentre Notre-Dame-du-Portage', 1),
(260,  33,  'Écocentres RDL - général', 1),
(261,  33,  'Ecocentres Kamouraska - général', 1),
(271,  33,  'Écocentre - ligne info', 1),
(286,  28,  'Gestion de leau', 1),
(287,  28,  'Saint-Mathieu', 1),
(288,  28,  'RIEDSM - projet spécial', 1),
(289,  28,  'Dégelis', 1),
(290,  28,  'Projet Réseau-Environnement - VIlle de RDL', 1),
(291,  55,  'Paysages Portneuf', 1),
(292,  28,  'Saint-Pascal', 1),
(293,  57,  'Projet PART', 1),
(294,  28,  'SADC des Basques', 1),
(295,  28,  'SADC de RDL', 1),
(296,  58,  'Supervion et coordination', 1),
(297,  58,  'Logistique', 1),
(298,  58,  'Collecte et traitement données', 1),
(299,  58,  'Visites municipalités', 1),
(300,  28,  'SADC de Kamouraska', 1),
(301,  26,  '', 1),
(302,  59,  'réutilisation', 1),
(304,  55,  'Ruralys Nouvelles', 1),
(305,  55,  'Développement de projets/Subventions', 1),
(313,  55,  'Paysages Kamouraska MCC', 1),
(308,  55,  'Marketing/Outils promo.', 1),
(309,  55,  'Offre de services', 1),
(317,  28,  'Rivière-du-Loup 2013', 1),
(316,  55,  'Supra-locaux paysages', 1),
(315,  28,  'INNERGEX', 1),
(314,  55,  'Paysages Rivière-Ouelle', 1),
(318,  28,  'MRC de LIslet', 1),
(319,  28,  'Etude ', 1),
(320,  28,  'Projet pilote', 1),
(321,  61,  'Général', 1),
(322,  61,  'Kamouraska', 1),
(323,  61,  'Rivière-du-Loup', 1),
(324,  61,  'Basques', 1),
(325,  55,  'Paysages éoliens', 1),
(326,  55,  'Paysages MRC Memphrémagog', 1),
(327,  33,  'Ecocentres Kamouraska - matériel informatique', 1),
(328,  33,  'Ecocentres Kamouraska - halocarbures', 1),
(329,  33,  'Ecocentres RDL - matériel informatique', 1),
(330,  33,  'Écocentres RDL - halocarbures', 1),
(331,  61,  'LIslet', 1),
(332,  34,  'Collecte qui carbure! 2014 sensibilisation', 1),
(333,  62,  'MRC de Kamouraska', 1),
(334,  62,  'MRC de Rivière-du-Loup', 1),
(335,  62,  'MRC des Basques', 1),
(336,  62,  'Général', 1),
(337,  62,  'MRC de la Mitis', 1),
(338,  62,  'MRC de la Matapédia', 1),
(339,  55,  'Développement de marché', 1),
(340,  55,  'Ateliers de formation en patrimoine', 1),
(341,  55,  'Communication', 1),
(342,  62,  'Admin. et coordo.', 1),
(343,  62,  'Médias traditionnels', 1),
(344,  62,  'Médias sociaux et Internet', 1),
(345,  62,  'Ligne info', 1),
(346,  62,  'Capsules vidéos', 1),
(347,  62,  'ICI trousse', 1),
(348,  62,  'ICI service conseil', 1),
(349,  62,  'Kiosques et séances dinfo', 1),
(350,  62,  'Affiche', 1),
(351,  62,  'Dépliant - écoles', 1),
(352,  62,  'Médias traditionnels', 1),
(353,  62,  'ICI service conseil', 1),
(354,  62,  'Kiosques', 1),
(355,  62,  'Médias traditionnels', 1),
(356,  62,  'ICI service conseil', 1),
(357,  62,  'Kiosques', 1),
(358,  62,  'Médias traditionnels', 1),
(359,  62,  'Kiosques', 1),
(360,  62,  'ICI service conseil', 1),
(361,  28,  'ECONOMIE CIRCULAIRE', 1),
(372,  34,  'La Mitis', 1),
(373,  34,  'La Mataédia', 1),
(374,  62,  'Ville de La Pocatière', 1),
(375,  62,  'ICI service conseil', 1),
(368,  34,  'Calendriers général', 1),
(369,  34,  'Kamouraska', 1),
(370,  34,  'Rivière-du-Loup', 1),
(371,  34,  'Les Basques', 1),
(376,  62,  'Ville de Rivière-du-Loup', 1),
(377,  62,  'ICI service conseil', 1),
(396,  62,  'Tournée des écoles', 1),
(379,  62,  'Tournée des écoles', 1),
(380,  62,  'Patrouille verte', 1),
(381,  62,  'Patrouille verte', 1),
(382,  63,  'CHOX', 1),
(383,  63,  'Serv. conseil ICI', 1),
(384,  64,  'FACTURABLE Serv. conseil ICI ', 1),
(385,  64,  'Formations et kiosques', 1),
(386,  28,  'Recyc-Québec - regroupement', 1),
(387,  65,  'Administration et gestion', 1),
(388,  66,  'RQ-1 regroupement', 1),
(389,  66,  'DEC - Canada', 1),
(390,  66,  'RQ-2 - Recyc-Québec', 1),
(392,  62,  'Tournée des écoles', 1),
(394,  62,  'Projet écoaction', 1),
(395,  67,  'Superbac', 1),
(397,  29,  'Réseautage et veille', 1),
(398,  65,  'travail sur le terrain Kamouraska', 1),
(399,  65,  'Sensibilisation-visites', 1),
(400,  65,  'Communication-Boutique-Publicité', 1),
(401,  65,  'Sensibilisation-promotion', 1),
(402,  18,  'Ecocentre Cacouna - construction', 1),
(403,  18,  'Ecocentre Rivière-du-Loup - réaménagement', 1),
(404,  65,  'Travail sur le terrain Rivière-du-Loup', 1),
(405,  65,  'Plan daffaire', 1),
(406,  68,  'Gestion', 1),
(407,  68,  'ERE et communication', 1),
(408,  65,  'Mesures de suivis et résultats', 1),
(409,  20,  'FCM - TI', 1)

--Insertion de QUELQUES feuilles de temps
UPDATE T_Employe
SET loginName = LOWER(prenom)
WHERE prenom <> 'admin'
