using System;
using BalancedBias.Rss;

public partial class GenericArticleTemplates : System.Web.UI.UserControl
{
    public Article ArticleTemplate { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        Console.Write(ArticleTemplate);
    }
}