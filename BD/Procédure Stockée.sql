USE CoEco_BD
GO

/*Proc�dure permettant d'obtenir le total des d�penses pour un projet*/
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




/*Proc�dure permettant de changer l'�tat d'un projet*/
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

/*Proc�dure permettant de changer l'�tat d'une cat�gorie*/
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

/*Proc�dure permettant de changer le status d'un employ�*/


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

--Proc�dure qui retourne le dernier ID de cat�gorie cr�er
CREATE PROCEDURE PS_GetMaxIdCategorie
	@idCat INT OUTPUT
AS
	SELECT @idCat = MAX(idCategorie) FROM T_CategoriePro
GO

/*EXEC PS_ChangerStatusEmp 1,1*/


/*Proc�dure permettant de changer la date de fin d'un projet*/
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

/*Proc�dure permettant d'ajouter un employ� au projet*/
IF OBJECT_ID ( 'PS_GetMaxIdEmpolye', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdEmpolye 
GO

CREATE PROCEDURE PS_GetMaxIdEmpolye
	@idProjet INT OUTPUT
AS
	SELECT @idProjet = MAX(idEmploye) FROM T_Employe
GO

/*Proc�dure permettant d'obtenir l'id du nouveau Employe au projet*/
IF OBJECT_ID ( 'PS_GetMaxIdEmpPro', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdEmpPro 
GO

CREATE PROCEDURE PS_GetMaxIdEmpPro
	@idEmpPro INT OUTPUT
AS
	SELECT @idEmpPro = MAX(idEmpPro) FROM T_EmployeProjet
GO

/*Proc�dure permettant de d�terminer le plus gros id de feuille de temps*/
IF OBJECT_ID ( 'PS_GetMaxIdFeuilleTemps', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdFeuilleTemps 
GO

CREATE PROCEDURE PS_GetMaxIdFeuilleTemps
	@idFeuilleTemps INT OUTPUT
AS
	SELECT @idFeuilleTemps = MAX(idFeuilleDeTemps) FROM T_FeuilleDeTemps
GO


/*Proc�dure permettant d'ajouter un employ� */
IF OBJECT_ID ( 'PS_GetMaxIdProjet', 'P' ) IS NOT NULL 
    DROP PROCEDURE PS_GetMaxIdProjet 
GO

CREATE PROCEDURE PS_GetMaxIdProjet
	@idProjet INT OUTPUT
AS
	SELECT @idProjet = MAX(idProjet) FROM T_Projet
GO