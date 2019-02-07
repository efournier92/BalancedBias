USE [BalancedBias]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_all_stored_dates]
AS

SELECT DISTINCT PublishDate
FROM [dbo].[articles]
