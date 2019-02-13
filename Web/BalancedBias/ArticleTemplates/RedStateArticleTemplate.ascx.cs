using BalancedBias.Common.Rss;

namespace ArticleTemplates
{
    /// <summary>
    /// Template for RedState articles
    /// </summary>
    public partial class RedStateArticleTemplate : System.Web.UI.UserControl
    {
        /// <summary>
        /// ArticleTemplate property of type Article
        /// </summary>
        public Article ArticleTemplate { get; set; }

        /// <summary>
        /// Path to template-specific stylesheet
        /// </summary>
        public string PathToStyles { get; set; }
    }
}
