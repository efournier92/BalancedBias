<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HuffingtonPostArticleTemplate.ascx.cs" Inherits="ArticleTemplates.HuffingtonPostArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="huffington-post article-card card m-2">
    <div class="huffington-post card-body">
        <h5 class="huffington-post card-title"><%=ArticleTemplate.Title%></h5>
        <h6 class="huffington-post card-subtitle mb-2 text-muted"><%=ArticleTemplate.PublishDate%></h6>
        <p class="huffington-post card-text"><%=ArticleTemplate.Body%></p>
        <a class="huffington-post card-url" href="<%=ArticleTemplate.Url%>">Read More</a>
    </div>
</div>
