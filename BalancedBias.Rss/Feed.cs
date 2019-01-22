using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedBias.Common.Feed
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
