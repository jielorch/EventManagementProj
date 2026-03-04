
SET QUOTED_IDENTIFIER ON;

IF OBJECT_ID(N'org.GetEventCategories', N'P') IS NOT NULL
	DROP PROCEDURE org.GetEventCategories
GO
	
	GO
	CREATE PROCEDURE org.GetEventCategories
		 
	AS
		BEGIN
			SET NOCOUNT ON;

			 SELECT * FROM [org].[EventCategories]
		END;
GO