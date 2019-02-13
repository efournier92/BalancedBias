namespace BalancedBias.Common.Rss
{
    /// <summary>
    /// Defines Article class parameters
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Parameter for channel name
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// Parameter for article title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Parameter for article body
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Parameter for article url path
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Parameter for date article was published
        /// </summary>
        public string PublishDate { get; set; }
    }
}
