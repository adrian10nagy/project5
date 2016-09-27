use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrdersInsert]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[OrdersInsert]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <09.26.2015>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[OrdersInsert]
	@i_userId int,
	@i_created datetime,
	@i_City nvarchar(100),
	@i_County int,
	@i_Address nvarchar(600),
	@i_OrderFlags int,
	@i_DeliveryNotes nvarchar(600)
AS
BEGIN
	SET NOCOUNT ON;

	begin
		Insert into Orders(
	   [Id_User]
      ,[Created]
      ,[Id_Cty]
      ,[City]
      ,[Address]
      ,[DeliveryNotes]
      ,[Flags])
	values(
		@i_userId,
		@i_created,
		@i_County,
		@i_City,
		@i_Address,
		@i_DeliveryNotes,
		@i_OrderFlags)

	end
END