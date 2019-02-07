USE [BalancedBias]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[add_new_article]
    @Channel nvarchar(50),
    @Title nvarchar(max),
    @Body nvarchar(max),
    @Url nvarchar(max),
    @PublishDate nvarchar(50)
AS

INSERT INTO [dbo].[articles] (Channel, Title, Body, Url, PublishDate)
VALUES(@Channel, @Title, @Body, @Url, @PublishDate)
