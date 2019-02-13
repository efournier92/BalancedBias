using BalancedBias.Common.Rss;

namespace ArticleTemplates
{
    /// <inheritdoc />
    /// <summary>
    /// Template for SecondNexus articles
    /// </summary>
    public partial class SecondNexusArticleTemplate : System.Web.UI.UserControl
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
