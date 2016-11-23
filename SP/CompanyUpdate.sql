use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyUpdate]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[CompanyUpdate]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <09.26.2015>

-- =============================================
CREATE PROCEDURE [dbo].[CompanyUpdate]
	@id int,
	@name nvarchar(300),
	@phone nvarchar(100),
	@email nvarchar(200),
	@address nvarchar(200),
	@joinDate datetime,
	@Id_County int
AS
BEGIN
	SET NOCOUNT ON;

	begin
		Update Companies
		SET
	   [Name] = @name,
       [Join_Date] = @joinDate,
       [Email] = @email,
       [Address] = @address,
       [Phone] = @phone,
       [Id_cnt] = @Id_County
	   WHERE 
	   [Id] = @id

	end
END