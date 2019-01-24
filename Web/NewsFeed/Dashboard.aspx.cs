using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BalancedBias.Common.Config;
using BalancedBias.Common.Config.Sections;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Feed;
using BalancedBias.Common.Infrastructure;
using BalancedBias.Rss;
using Feed = BalancedBias.Common.Feed.Feed;

public partial class Dashboard : System.Web.UI.Page
{
    //private readonly IConfigurationVariablesService _configurationVariablesService;
    private readonly IAppConfigReader _appConfigReader;
    public string globalStylesUrl;
    //private static readonly RssService _rssService = new RssService();

    public Dashboard()
        : this(DependencyResolverGateway.Resolve<IAppConfigReader>())
    { }

    private Dashboard(IAppConfigReader appConfigReader)
    {
        //if (configurationVariablesService == null) throw new ArgumentNullException("configurationVariablesService");
        if (appConfigReader == null) throw new ArgumentNullException("appConfigReader");
        //_configurationVariablesService = configurationVariablesService;
        _appConfigReader = appConfigReader;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var mediaBasePath = _appConfigReader.AppConfigToString(AppSettingKeys.MediaBasePath);
        globalStylesUrl = mediaBasePath + "css/globalStyles.css";
        var allFeeds = RssService.GetFeeds();
        gvRss.DataSource = allFeeds.Feeds;
        gvRss.DataBind();
        //public string path = mediaBasePath;s
    }

    //private void PopulateRssFeed()
    //{
    //    var newsCollection = new NewsCollection();
    //    var allFeed = RssService.GetAllFeeds();
    //    foreach (FeedElement feed in allFeed)
    //    {
    //        var xDoc = XDocument.Load(feed.Url);
    //        var items = (from x in xDoc.Descendants("item")
    //                     select new
    //                     {
    //                         title = x.Element("title").Value ?? "",
    //                         link = x.Element("link").Value ?? "",
    //                         pubDate = x.Element("pubDate").Value ?? "",
    //                         description = x.Element("description").Value ?? "",
    //                     });
    //        if (items != null)
    //        {
    //            Feed.AddRange(items.Select(i => new Feed
    //            {
    //                Title = i.title,
    //                Link = i.link,
    //                //PublishDate = i.pubDate,
    //                Description = i.description
    //            }));
    //        }
    //        gvRss.DataSource = Feed;
    //        gvRss.DataBind();
    //    }
}

        //return Feed;
        ////string rssFeedUrl = ConfigurationManager.AppSettings["RssFeedUrl"];
        //var rssFeedUrl = "https://abcnews.go.com/abcnews/topstories";
        //var Feed = new List<Feed>();
        //var xDoc = XDocument.Load(rssFeedUrl);
        //var items = (from x in xDoc.Descendants("item")
        //    select new
        //    {
        //        title = x.Element("title").Value,
        //        link = x.Element("link").Value,
        //        pubDate = x.Element("pubDate").Value,
        //        description = x.Element("description").Value
        //    });
        //if (items != null)
        //{
        //    Feed.AddRange(items.Select(i => new Feed
        //    {
        //        Title = i.title,
        //        Link = i.link,
        //        PublishDate = i.pubDate,
        //        Description = i.description
        //    }));
        //}
        //gvRss.DataSource = Feed;
        //gvRss.DataBind();
    //}
//}