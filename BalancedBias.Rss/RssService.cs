using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Xml.Linq;
using BalancedBias.Common.Config;

namespace BalancedBias.Rss
{
    public class RssService
    {
        public static NewsCollection GetChannels()
        {
            var config = ConfigurationManager.GetSection("rssService") as RssServiceSection;
            var allChannels = new NewsCollection();
            if (config == null) return allChannels;
            foreach (ChannelElement channel in config.Channels)
            {
                var currentChannel = new Channel
                {
                    Name = channel.Name,
                    Icon = channel.Icon
                };
                var xDoc = XDocument.Load(channel.Url);
                var items = (from x in xDoc.Descendants("item")
                    select new
                    {
                        title = x.Element("title").Value,
                        link = x.Element("link").Value,
                        pubDate = x.Element("pubDate").Value,
                        description = x.Element("description").Value,
                    });
                currentChannel.Articles = new List<Article>();
                currentChannel.Articles.AddRange(items.Select(i => new Article
                {
                    Title = i.title ?? "",
                    Url = i.link ?? "",
                    PublishDate = i.pubDate ?? "",
                    Body = i.description ?? "",
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
            return allChannels;
        }
    }
}
