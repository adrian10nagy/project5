USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[SearchCriteriaGetAll]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[SearchCriteriaGetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[SearchCriteriaGetAll]
AS
BEGIN
	SELECT
		[Id]
      ,[Name]
      ,[NameToDisplay]
      ,[ChoseType]
	  ,[DisplayOrder]
  FROM [dbo].[SearchCriterias]	   
END	