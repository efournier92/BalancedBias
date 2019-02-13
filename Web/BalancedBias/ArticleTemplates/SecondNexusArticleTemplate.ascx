<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SecondNexusArticleTemplate.ascx.cs" Inherits="ArticleTemplates.SecondNexusArticleTemplate" %>

<link rel="stylesheet" type="text/css" href="<%= PathToStyles %>" />

<div class="second-nexus article-card card m-2">
    <div class="second-nexus card-body">
        <h6 class="second-nexus card-subtitle mb-2"><%=ArticleTemplate.PublishDate%></h6>
        <h5 class="second-nexus card-title"><%=ArticleTemplate.Title%></h5>
        <a href="<%=ArticleTemplate.Url%>" class="second-nexus card-url">Read More</a>
    </div>
</div>
