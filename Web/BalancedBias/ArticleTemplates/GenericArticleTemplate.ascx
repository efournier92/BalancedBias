<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GenericArticleTemplate.ascx.cs" Inherits="ArticleTemplates.GenericArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="generic-article article-card card m-2">
    <div class="card-body">
        <h5 class="card-title"><%=ArticleTemplate.Title%></h5>
        <h6 class="card-subtitle mb-2 text-muted"><%=ArticleTemplate.PublishDate%></h6>
        <p class="card-text"><%=ArticleTemplate.Body%></p>
        <a href="<%=ArticleTemplate.Url%>" class="card-url">Read More</a>
    </div>
</div>
