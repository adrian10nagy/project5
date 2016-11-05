USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[ProductTypesGetAll]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[ProductTypesGetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[ProductTypesGetAll]
AS
BEGIN
	
SELECT [Id]
      ,[TypeName]
      ,[Id_ctg]
  FROM [dbo].[ProductTypes]

END