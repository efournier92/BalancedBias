<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RedStateArticleTemplate.ascx.cs" Inherits="ArticleTemplates.RedStateArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="red-state article-card card m-2">
    <div class="red-state card-body">
        <h6 class="red-state card-subtitle mb-2"><%=ArticleTemplate.PublishDate%></h6>
        <h5 class="red-state card-title"><%=ArticleTemplate.Title%></h5>
        <p class="red-state card-text"><%=ArticleTemplate.Body%></p>
        <a href="<%=ArticleTemplate.Url%>" class="card-url">Read More</a>
    </div>
</div>
