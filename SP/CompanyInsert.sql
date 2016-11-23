use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompanyInsert]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[CompanyInsert]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <09.26.2015>

-- =============================================
CREATE PROCEDURE [dbo].[CompanyInsert]
	@name nvarchar(200),
	@phone nvarchar(100),
	@email nvarchar(100),
	@address nvarchar(100),
	@joinDate datetime,
	@Id_County int
AS
BEGIN
	SET NOCOUNT ON;

	begin
		Insert into Companies(
	   [Name]
      ,[Join_Date]
      ,[Email]
      ,[Phone]
      ,[Id_cnt]
	  ,[Address])
	values(
		@name,
		@joinDate,
		@email,
		@phone,
		@Id_County,
		@address)

	end
END