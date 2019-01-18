using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BalancedBias.Common.Config.Sections;

namespace BalancedBias.Rss
{
    public class RssService
    {
        private static readonly RssServiceSection _rssServiceSection = new RssServiceSection();

        RssService()
        {

        }

        public static Feed GetAllFeeds()
        {
            var allFeeds = _rssServiceSection.Feeds;
            Console.Write(allFeeds);
            return new Feed();
            //var rssFeedUrl = RssServiceSection;
            //var feeds = new List<Feed>();
            //var xDoc = XDocument.Load(rssFeedUrl);
            //var items = (from x in xDoc.Descendants("item")
            //             select new
            //             {
            //                 title = x.Element("title").Value,
            //                 link = x.Element("link").Value,
            //                 pubDate = x.Element("pubDate").Value,
            //                 description = x.Element("description").Value
            //             });
            //if (items != null)
            //{
            //    feeds.AddRange(items.Select(i => new Feeds
            //    {
            //        Title = i.title,
            //        Link = i.link,
            //        PublishDate = i.pubDate,
            //        Description = i.description
            //    }));
            //}
            //gvRss.DataSource = feeds;
            //gvRss.DataBind();


        }
    }
}
