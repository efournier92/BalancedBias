using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using BalancedBias.Common.Config;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Feeds;
using BalancedBias.Common.Infrastructure;

public partial class Dashboard : System.Web.UI.Page
{
    //private readonly IConfigurationVariablesService _configurationVariablesService;
    private readonly IAppConfigReader _appConfigReader;
    public string globalStylesUrl;

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
        PopulateRssFeed();
        //public string path = mediaBasePath;s
    }

    private void PopulateRssFeed()
    {
        //string rssFeedUrl = ConfigurationManager.AppSettings["RssFeedUrl"];
        var rssFeedUrl = "https://abcnews.go.com/abcnews/topstories";
        var feeds = new List<Feeds>();
        var xDoc = XDocument.Load(rssFeedUrl);
        var items = (from x in xDoc.Descendants("item")
            select new
            {
                title = x.Element("title").Value,
                link = x.Element("link").Value,
                pubDate = x.Element("pubDate").Value,
                description = x.Element("description").Value
            });
        if (items != null)
        {
            feeds.AddRange(items.Select(i => new Feeds
            {
                Title = i.title,
                Link = i.link,
                PublishDate = i.pubDate,
                Description = i.description
            }));
        }
        gvRss.DataSource = feeds;
        gvRss.DataBind();
    }
}