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
	SELECT @total = SUM(montant) FROM Depense
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
	INSERT INTO TauxKilo(taux, ddate)  VALUES (@newValue, GETDATE())

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
	UPDATE Projet
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
	UPDATE CategoriePro
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
	UPDATE Employe
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
	UPDATE Projet
	SET dateFin = @ddateFin
	WHERE idProjet = @idProjet
GO

/*DECLARE @ddate DATE
SET @ddate = GETDATE()
EXEC PS_ChangerDateFinProjet 1, @ddate*/
