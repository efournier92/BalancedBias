<%@ Control Language="C#" ClassName="generic" %>
<%@ Register TagPrefix="BalancedBias" TagName="GenericArticleTemplate" Src="~/ArticleTemplates/GenericArticleTemplate.ascx" %>

<div class="card m-2" style="width: 400px">
    <div class="card-body">
        <h5 class="card-title"><%#Eval("Title") %></h5>
        <h6 class="card-subtitle mb-2 text-muted"><%#Eval("PublishDate") %></h6>
        <p class="card-text"><%#Eval("Body") %></p>
        <a href="<%#Eval("Url") %>" class="card-url">Read More</a>
    </div>
</div>
