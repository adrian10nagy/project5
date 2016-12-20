USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[CompanyGetAll]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[CompanyGetAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[CompanyGetAll]
AS
BEGIN
	SELECT
		[Id]
      ,[Name]
      ,[Email]
      ,[Phone]
      ,[Id_cnt]
      ,[Address]
      ,[AddressXML]
  FROM [dbo].[Companies]
END	