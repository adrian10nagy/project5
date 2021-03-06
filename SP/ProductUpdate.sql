use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OfferUpdate]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[OfferUpdate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <09.26.2015>

-- =============================================
CREATE PROCEDURE [dbo].[OfferUpdate]
	@id int,
	@title nvarchar(300),
	@description nvarchar(500),
	@TypeId int,
	@companyId int,
	@price int,
	@ProductId int
AS
BEGIN
	SET NOCOUNT ON;

	begin
		Update Offers
		SET
	   [Id_Prd] = @ProductId
      ,[Id_Typ] = @TypeId
      ,[Title] = @title
      ,[Description] = @description
      ,[Price] = @price
      ,[Id_Cpy] = @companyId
	   WHERE 
	   [Id] = @id

	end
END