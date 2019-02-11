CREATE TABLE [dbo].[articles] (
	ArticleID int IDENTITY (1,1) NOT NULL,
	CONSTRAINT PK_ArticleID PRIMARY KEY CLUSTERED (ArticleID),
    Channel nvarchar(255) NOT NULL,
    Title nvarchar(400) UNIQUE NOT NULL,
    Body nvarchar(max) NOT NULL,
    Url nvarchar(max) NOT NULL,
    PublishDate nvarchar(255) NOT NULL,
);
