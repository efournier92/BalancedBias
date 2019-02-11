using BalancedBias.Rss;

namespace ArticleTemplates
{
    /// <inheritdoc />
    /// <summary>
    /// Template for FoxNews articles
    /// </summary>
    public partial class FoxNewsArticleTemplate : System.Web.UI.UserControl
    {
        /// <summary>
        /// ArticleTemplate property of type Article
        /// </summary>
        public Article ArticleTemplate { get; set; }
    }
}
