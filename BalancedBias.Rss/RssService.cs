using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;
using BalancedBias.Common.Config.Sections;

namespace BalancedBias.Rss
{
    public class RssService
    {
        public static NewsCollection GetFeeds()
        {
            var config = ConfigurationManager.GetSection("rssService") as RssServiceSection;
            var allFeeds = new NewsCollection();
            if (config == null) return allFeeds;
            foreach (FeedElement feed in config.Feeds)
            {
                var currentFeed = new Feed();
                var xDoc = XDocument.Load(feed.Url);
                var items = (from x in xDoc.Descendants("item")
                    select new
                    {
                        title = x.Element("title").Value,
                        link = x.Element("link").Value,
                        pubDate = x.Element("pubDate").Value,
                        description = x.Element("description").Value,
                    });
                currentFeed.Items = new List<Item>();
                currentFeed.Items.AddRange(items.Select(i => new Item
                {
                    Title = i.title ?? "",
                    Link = i.link ?? "",
                    PublishDate = i.pubDate ?? "",
                    Description = i.description ?? "",
                }));
                allFeeds.Feeds.Add(currentFeed);
            }

            return allFeeds;

        }
    }
}
