use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductInsert]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[ProductInsert]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <09.26.2015>

-- =============================================
CREATE PROCEDURE [dbo].[ProductInsert]
	@name nvarchar(200),
	@productTypeId int
AS
BEGIN
	SET NOCOUNT ON;

	begin
		Insert into Products(
	   [Name]
	  ,[Id_PrdType])
	values(
		@name,
		@productTypeId)

	end
END