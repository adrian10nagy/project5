USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[ProductTypesGetByCategoryId]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[ProductTypesGetByCategoryId]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[ProductTypesGetByCategoryId]
@Id_ctg int
AS
BEGIN
	SELECT
		Id
      ,TypeName
	  FROM ProductTypes
  WHERE Id_ctg = @Id_ctg
END