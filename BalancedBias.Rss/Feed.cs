using System.Collections.Generic;

namespace BalancedBias.Rss
{
    public class NewsCollection
    {
        public List<Feed> Feeds { get; set; }

        public NewsCollection()
        {
            Feeds = new List<Feed>();
        }
    }

    public class Feed
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Item> Items { get; set; }

        public Feed()
        {
            Items = new List<Item>();
        }
    }

    public class Item
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string PublishDate { get; set; }
        public string Description { get; set; }
    }
}
