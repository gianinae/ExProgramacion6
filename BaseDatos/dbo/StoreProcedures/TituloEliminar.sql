﻿CREATE PROCEDURE [dbo].[TituloEliminar]
@Id_Titulo INT
AS
BEGIN
	SET NOCOUNT ON 
	BEGIN TRANSACTION TRASA
	
	BEGIN TRY
--Metodo
		DELETE FROM Titulos
		WHERE Id_Titulo = @Id_Titulo
--FinMetodo
	COMMIT TRANSACTION TRASA

		SELECT 0 AS CodeError, '' AS MsgError

	END TRY 

	BEGIN CATCH
		SELECT 
			ERROR_NUMBER() AS CodeError
			,ERROR_MESSAGE() AS MsgErrror
	END CATCH


END

