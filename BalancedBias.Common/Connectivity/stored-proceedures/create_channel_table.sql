CREATE TABLE [dbo].[articles] (
	ArticleID int IDENTITY (1,1) NOT NULL,
	CONSTRAINT PK_ArticleID PRIMARY KEY CLUSTERED (ArticleID),
    Channel nvarchar(max),
    Title nvarchar(max),
    Body nvarchar(max),
    Url nvarchar(max),
    PublishDate nvarchar(255),
);
