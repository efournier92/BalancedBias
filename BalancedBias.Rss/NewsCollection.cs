using System.Collections.Generic;

namespace BalancedBias.Rss
{
    public class NewsCollection
    {
        public List<Channel> Channels { get; set; }

        public NewsCollection()
        {
            Channels = new List<Channel>();
        }
    }
}
