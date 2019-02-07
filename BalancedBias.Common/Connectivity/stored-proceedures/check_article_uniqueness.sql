USE [BalancedBias]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[check_article_uniqueness]
    @Title nvarchar(50)
AS

declare @return nvarchar;

set @return  = (SELECT COUNT(*) 
                    FROM [articles]
                    WHERE Title = @Title
				);
return @return;
