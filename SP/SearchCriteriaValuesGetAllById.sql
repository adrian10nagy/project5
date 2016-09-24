USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SearchCriteriaValuesGetAllById]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SearchCriteriaValuesGetAllById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[SearchCriteriaValuesGetAllById]
@Id_scr int
AS
BEGIN
	SELECT
		[Id]
      ,[Value]
	  ,[DisplayOrder]
  FROM [dbo].[SearchCriteriaValues]	   
  WHERE Id_scr = @Id_scr
END