USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[CompanyGetById]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[CompanyGetById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[CompanyGetById]
@Id int
AS
BEGIN
	SELECT
		[Id]
      ,[Name]
      ,[Email]
      ,[Phone]
      ,[Id_cnt]
      ,[Address]
  FROM [dbo].[Companies]
  WHERE [Id] = @id
END	