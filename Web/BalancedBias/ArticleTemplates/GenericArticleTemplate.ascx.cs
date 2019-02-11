using BalancedBias.Rss;

namespace ArticleTemplates
{
    /// <inheritdoc />
    /// <summary>
    /// Default template for any generic articles
    /// </summary>
    public partial class GenericArticleTemplate : System.Web.UI.UserControl
    {
        /// <summary>
        /// ArticleTemplate property of type Article
        /// </summary>
        public Article ArticleTemplate { get; set; }
    }
}
