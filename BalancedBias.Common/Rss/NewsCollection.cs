using System.Collections.Generic;

namespace BalancedBias.Common.Rss
{
    /// <summary>
    /// Collection of RSS channels with article details
    /// </summary>
    public class NewsCollection
    {
        /// <summary>
        /// List of all channels specified in rssChannelsService configuration
        /// </summary>
        public List<Channel> Channels { get; set; }

        /// <summary>
        /// Returns a new list of channels for NewsCollection
        /// </summary>
        public NewsCollection()
        {
            Channels = new List<Channel>();
        }
    }
}
