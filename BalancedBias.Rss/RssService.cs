using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BalancedBias.Common.Config.Sections;
using BalancedBias.Common.Feed;

namespace BalancedBias.Rss
{
    public class RssService
    {
        //private static readonly RssServiceSection _rssServiceSection = new RssServiceSection();
        //public static FeedRetrieverSection _rssServiceSection =
        //    ConfigurationManager.GetSection("feedRetriever") as FeedRetrieverSection;
        private static readonly FeedRetrieverSection RssServiceSection =
            ConfigurationManager.GetSection("feedRetriever") as FeedRetrieverSection;

        public static FeedElementCollection GetAllFeeds()
        {
            return RssServiceSection.Feeds;
        }

        public static NewsCollection GetFeeds()
        {
            //var _Confcig = ConfigurationManager.GetSection("feedRetriever") as FeedRetrieverSection;
            //foreach (FeedElement feedEl in _Config.Feeds)
            //{
            //    // make request
            //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(feedEl.Url);
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //    if (response.StatusCode == HttpStatusCode.OK)
            //    {
            //        string feedData = String.Empty;

            //        using (StreamReader reader =
            //            new StreamReader(response.GetResponseStream()))
            //        {
            //            feedData = reader.ReadToEnd();
            //        }
            //    }
            //}
            var _Config = ConfigurationManager.GetSection("feedRetriever") as FeedRetrieverSection;
            var allFeeds = new NewsCollection();
            foreach (FeedElement feed in _Config.Feeds)
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

        //string rssFeedUrl = ConfigurationManager.AppSettings["RssFeedUrl"];


        //public static void GetFeeds()
        //{
        //    var feeds = new List<Feed>();
        //    foreach (FeedElement feedEl in _Config.Feeds)x
        //    {
        //        // make request
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(feedEl.Url);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            string feedData = String.Empty;

        //            using (StreamReader reader =
        //                new StreamReader(response.GetResponseStream()))
        //            {
        //                feedData = reader.ReadToEnd();
        //            }
        //        }wd
        //    }
        //}

        //public static void GetFeeds()
        //{
        //    foreach (FeedElement feed in _Config.Feeds)
        //    {
        //        var feeds = new List<Feed>();

        //        var rssFeedUrl = feed.Url;
        //        // make request
        //        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(feedEl.Url);
        //        //HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //        var xDoc = XDocument.Load(rssFeedUrl);
        //        var items = (from x in xDoc.Descendants("item")
        //                     select new
        //                     {
        //                         title = x.Element("title").Value,
        //                         link = x.Element("link").Value,
        //                         pubDate = x.Element("pubDate").Value,
        //                         description = x.Element("description").Value
        //                     });
        //        if (items != null)
        //        {
        //            feeds.AddRange(items.Select(i => new Feed
        //            {
        //                Title = i.title,
        //                Link = i.link,
        //                PublishDate = i.pubDate,
        //                Description = i.description
        //            }));
        //        }
        //        //gvRss.DataSource = feeds;
        //        //gvRss.DataBind();
        //    }
        //}
    }
}



//public static Feed GetAllFeeds()
//{
//    FeedRetrieverSection config = ConfigurationManager.GetSection("feeds") as FeedRetrieverSection;

//    var allFeeds = _rssServiceSection.Feeds;
//    Console.Write(allFeeds);
//    return new Feed();
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


//}
//}
