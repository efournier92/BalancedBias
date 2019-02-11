USE [BalancedBias]
GO
/****** Object:  StoredProcedure [dbo].[get_articles_by_channel]    Script Date: 2/7/2019 11:51:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[get_articles_by_channel]
    @Channel nvarchar(255)
AS

SELECT Channel, Title, Body, Url, PublishDate
FROM [articles]
WHERE (
	Channel = @Channel
)
