<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GenericArticleTemplate.ascx.cs" Inherits="GenericArticleTemplates" %>

<div class="card m-2" style="width: 400px">
    <div class="card-body">
        <h5 class="card-title"><%=ArticleTemplate.Title%></h5>
        <h6 class="card-subtitle mb-2 text-muted"><%=ArticleTemplate.PublishDate%></h6>
        <p class="card-text"><%=ArticleTemplate.Body%></p>
        <a href="<%=ArticleTemplate.Url%>" class="card-url">Read More</a>
    </div>
</div>
