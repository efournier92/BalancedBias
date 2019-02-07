USE [BalancedBias]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[get_articles_by_date_and_channel]
    @Channel nvarchar(255),
    @Date nvarchar(255)
AS

SELECT Channel, Title, Body, Url, PublishDate
FROM [articles]
WHERE (
	Channel = @Channel AND
	PublishDate LIKE '%' + @Date + '%'
)
