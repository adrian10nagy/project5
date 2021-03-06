USE [project5]
GO
IF  EXISTS (SELECT 1 FROM SYS.OBJECTS WHERE OBJECT_ID = OBJECT_ID(N'[dbo].[OfferGetById]') AND TYPE IN (N'P', N'PC'))
	DROP PROCEDURE [dbo].[OfferGetById]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================

CREATE PROCEDURE [dbo].[OfferGetById]
@Id int
AS
BEGIN
	SELECT
		O.[Id]
      ,O.[Id_Prd]
      ,O.[Title]
      ,O.[Description]
      ,O.[Created]
      ,O.[Price]
      ,O.[Id_cty]
	  ,O.[Id_Typ]
	  ,O.[Id_Prd]
  FROM [dbo].[Offers] O
  WHERE [Id_Prd] = @Id
END