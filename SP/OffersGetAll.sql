use project5

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OffersGetAll]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[OffersGetAll]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Adrian Nagy
-- Create date: 02/07/2016
-- Description:	Gets all Offers base on its id
-- =============================================
CREATE PROCEDURE [dbo].[OffersGetAll]
AS
BEGIN
	
SELECT [Id]
      ,[Id_Prd]
      ,[Id_Typ]
      ,[Title]
      ,[Description]
      ,[Created]
      ,[Flags]
      ,[Price]
  FROM [dbo].[Offers]
  where Flags = 0
END