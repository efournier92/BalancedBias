using System;
using BalancedBias.Common.Config;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Infrastructure;
using BalancedBias.Rss;

public partial class Dashboard : System.Web.UI.Page
{
    private readonly IAppConfigReader _appConfigReader;
    public string GlobalStylesUrl;

    public Dashboard()
        : this(DependencyResolverGateway.Resolve<IAppConfigReader>())
    { }

    private Dashboard(IAppConfigReader appConfigReader)
    {
        _appConfigReader = appConfigReader;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var mediaBasePath = _appConfigReader.AppConfigToString(AppSettingKeys.MediaBasePath);
        GlobalStylesUrl = mediaBasePath + "css/globalStyles.css";
        var allFeeds = RssService.GetFeeds();
        gvRss.DataSource = allFeeds.Feeds;
        gvRss.DataBind();
    }
}