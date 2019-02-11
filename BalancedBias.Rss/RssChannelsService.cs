using System;
using System.Linq;
using System.Configuration;
using System.Globalization;
using System.Xml.Linq;
using BalancedBias.Common.Config;

namespace BalancedBias.Rss
{
    public class RssChannelsService
    {
        public static void PersistNewArticles()
        {
            var config = ConfigurationManager.GetSection("rssChannelsService") as RssChannelsServiceSection;
            var allChannels = new NewsCollection();
            if (config == null) return;
            foreach (ChannelElement channel in config.Channels)
            {
                var currentChannel = new Channel
                {
                    Name = channel.Name,
                    Icon = channel.Icon,
                    Template = channel.Template
                };
                var xDoc = XDocument.Load(channel.Url);
                var items = (from x in xDoc.Descendants("item")
                             select new
                             {
                                 title = x.Element("title").Value,
                                 body = x.Element("description").Value,
                                 url = x.Element("link").Value,
                                 pubDate = x.Element("pubDate").Value,
                             }
                        );
                currentChannel.Articles.AddRange(items.Select(i => new Article
                {
                    Channel = channel.Name,
                    Title = i.title,
                    Body = i.body,
                    Url = i.url,
                    PublishDate = DateTime.Parse(i.pubDate).ToString(CultureInfo.InvariantCulture)
                }));
                allChannels.Channels.Add(currentChannel);
                foreach (var currentArticle in currentChannel.Articles)
                {
                    var channelName = currentChannel.Name;
                    var title = currentArticle.Title;
                    var link = currentArticle.Url;
                    var pubDate = currentArticle.PublishDate;
                    var description = currentArticle.Body;
                    if (ChannelsDbService.IsArticleUnique(title))
                    {
                        ChannelsDbService.AddNewArticle(channelName, title, link, pubDate, description);
                    }
                }
            }
        }
    }
}
