<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TrumpTwitterArticleTemplate.ascx.cs" Inherits="ArticleTemplates.TrumpTwitterArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="article-card card m-2">
    <div class="trump-twitter card-body">
        <h6 class="trump-twitter card-subtitle mb-2"><%=ArticleTemplate.PublishDate%></h6>
        <h5 class="card-title"><%=ArticleTemplate.Title%></h5>
        <a href="<%=ArticleTemplate.Url%>" class="card-url">Read More</a>
    </div>
</div>
