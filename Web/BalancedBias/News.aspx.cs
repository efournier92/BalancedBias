using System;
using BalancedBias.Common.Config;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Infrastructure;
using BalancedBias.Rss;

public partial class Dashboard : System.Web.UI.Page
{
    private static IAppConfigReader _appConfigReader;
    public string MediaBasePath;

    public Dashboard()
        : this(DependencyResolverGateway.Resolve<IAppConfigReader>())
    {

    }

    private Dashboard(IAppConfigReader appConfigReader)
    {
        _appConfigReader = appConfigReader;
        MediaBasePath = _appConfigReader.AppConfigToString(AppSettingKeys.MediaBasePath);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var allChannels = RssService.GetChannels();
        gvRss.DataSource = allChannels.Channels;
        gvRss.DataBind();
    }
}
