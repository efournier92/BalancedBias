<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FoxNewsArticleTemplate.ascx.cs" Inherits="ArticleTemplates.FoxNewsArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="fox-news article-card card m-2">
    <div class="fox-news card-body">
        <h5 class="fox-news card-title"><%=ArticleTemplate.Title%></h5>
        <h6 class="fox-news card-subtitle mb-2"><%=ArticleTemplate.PublishDate%></h6>
        <p class="fox-news card-text"><%=ArticleTemplate.Body%></p>
        <a href="<%=ArticleTemplate.Url%>" class="fox-news card-url">Read More</a>
    </div>
</div>
