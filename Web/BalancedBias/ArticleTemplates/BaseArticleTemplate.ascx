<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BaseArticleTemplate.ascx.cs" Inherits="BaseArticleTemplates" %>
<%--<%@ Control Language="C#" ClassName="generic" %>--%>
<%@ Register TagPrefix="BalancedBias" TagName="GenericArticleTemplate" Src="~/ArticleTemplates/GenericArticleTemplate.ascx" %>
<%@ Register TagPrefix="BalancedBias" TagName="TrumpArticleTemplate" Src="~/ArticleTemplates/TrumpArticleTemplate.ascx" %>

<BalancedBias:GenericArticleTemplate runat="server" ID="GenericArticleTemplate1"/>
<BalancedBias:TrumpArticleTemplate runat="server" ID="TrumpArticleTemplate"/>
