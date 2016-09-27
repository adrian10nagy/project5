use [project5]
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItemInsert]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[OrderItemInsert]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Adrian,Nagy>
-- Create date: <10.26.2015>
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[OrderItemInsert]
	@i_offerId int,
	@i_orderId int,
	@i_flags int,
	@i_price int,
	@i_Quantity int
AS
BEGIN
	SET NOCOUNT ON;
	
	begin
		Insert into OrderItem(
	   [id_order]
      ,[Id_Offer]
      ,[Quantity]
      ,[Price]
      ,[Flags])
	values(
		@i_orderId,
		@i_offerId,
		@i_Quantity,
		@i_price,
		@i_flags
	)

	end
END