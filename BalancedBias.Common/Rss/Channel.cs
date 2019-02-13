using System.Collections.Generic;

namespace BalancedBias.Common.Rss
{
    /// <summary>
    /// Defines Channel class parameters
    /// </summary>
    public class Channel
    {
        /// <summary>
        /// Parameter for channel name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameter for channel icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Parameter for name of channel template
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// Parameter for list of channel articles
        /// </summary>
        public List<Article> Articles { get; set; }

        /// <summary>
        /// Instantiates new list of channel articles
        /// </summary>
        public Channel()
        {
            Articles = new List<Article>();
        }
    }
}
