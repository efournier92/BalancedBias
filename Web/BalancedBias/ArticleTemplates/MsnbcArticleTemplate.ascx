<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MsnbcArticleTemplate.ascx.cs" Inherits="ArticleTemplates.MsnbcArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="msnbc article-card card m-2">
    <div class="msnbc card-body">
        <h6 class="msnbc card-subtitle mb-2"><%=ArticleTemplate.PublishDate%></h6>
        <h5 class="msnbc card-title">
            <%=ArticleTemplate.Title%>
        </h5>
        <p class="msnbc card-text"><%=ArticleTemplate.Body%></p>
        <a href="<%=ArticleTemplate.Url%>" class="msnbc card-url">Read More</a>
    </div>
</div>
