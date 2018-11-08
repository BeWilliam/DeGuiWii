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


/*Procédure permettant de changer le taux de kilometrage*/
IF OBJECT_ID ( 'PS_ChangerTauxKilo', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerTauxKilo 
GO

CREATE PROCEDURE PS_ChangerTauxKilo
	@newValue FLOAT(3)
AS
	INSERT INTO T_TauxKilo(taux, ddate)  VALUES (@newValue, GETDATE())

GO

/*EXEC PS_ChangerTauxKilo 0.44*/


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

/*DECLARE @ddate DATE
SET @ddate = GETDATE()
EXEC PS_ChangerDateFinProjet 1, @ddate*/



/*Procédure permettant d'ajouter des projets*/


/*REPACE ICI CHOSE*/
/*
IF OBJECT_ID ( 'PS_ChangerDateFinProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_ChangerDateFinProjet 
GO

CREATE PROCEDURE PS_AjouterProjets
	@nom VARCHAR(100),
	@descript VARCHAR(500),
	@responsable INT, /*ID de l'employé qui sera le responsable*/
	@dateDebut DATE,
	@dateFin DATE ,
	@idStatus INT
AS
DECLARE @maximum AS INT
Set @maximum = SELECT MAX(idProjet) FROM Projet



INSERT INTO Projet(nom, descript, responsable, dateDebut, dateFin, idStatus) VALUES (@nom, @descript, @responsable, @dateDebut, @dateFin, @idStatus) 

GO*/


/*Procédure permettant d'ajouter un employé au projet*/
IF OBJECT_ID ( 'PS_GetMaxIdEmpolye', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdEmpolye 
GO

CREATE PROCEDURE PS_GetMaxIdEmpolye
	@idProjet INT OUTPUT
AS
	SELECT @idProjet = MAX(idEmploye) FROM T_Employe
GO

/*Procédure permettant de déterminer le plus gros id de feuille de temps*/
IF OBJECT_ID ( 'PS_GetMaxIdFeuilleTemps', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdFeuilleTemps 
GO

CREATE PROCEDURE PS_GetMaxIdFeuilleTemps
	@idFeuilleTemps INT OUTPUT
AS
	SELECT @idFeuilleTemps = MAX(idCategorie) FROM T_FeuilleDeTemps
GO