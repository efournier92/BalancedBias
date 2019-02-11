using System;
using System.Globalization;
using System.Linq;
using System.Web.UI.WebControls;
using BalancedBias.Common.Config;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Infrastructure;
using BalancedBias.Rss;

public partial class Dashboard : System.Web.UI.Page
{
    public string MediaBasePath;

    public Dashboard()
        : this(DependencyResolverGateway.Resolve<IAppConfigReader>())
    {

    }

    private Dashboard(IAppConfigReader appConfigReader)
    {
        MediaBasePath = appConfigReader.AppConfigToString(AppSettingKeys.MediaBasePath);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        var todaysDate = DateTime.Today.ToString(CultureInfo.InvariantCulture).Split(null)[0];
        datesDropDown.Text = todaysDate;
        var allChannels = ChannelsDbService.GetChannelsFromDbByDate(todaysDate);
        BindAllChannels(allChannels);

        var allDates = ChannelsDbService.GetUniqueArticleDates().OrderByDescending(date => date);
        datesDropDown.DataSource = allDates;
        datesDropDown.DataBind();
    }

    protected void SearchArticlesByDate(object sender, EventArgs e)
    {
        var date = datesDropDown.Text;
        var allChannels = ChannelsDbService.GetChannelsFromDbByDate(date);
        BindAllChannels(allChannels);
    }
     
    private void BindAllChannels(NewsCollection allChannels)
    {
        RssChannelsService.PersistNewArticles();
        gvRss.DataSource = allChannels.Channels;
        gvRss.DataBind();
    }

    protected void OnArticleDataBound(object sender, RepeaterItemEventArgs e)
    {
        var article = (Article)e.Item.DataItem;
        var channel = article.Channel;
        var template = RssChannelsServiceSection.GetTemplateByChannelName(channel);
        var articleTemplateControl = (dynamic)Page.LoadControl("~/ArticleTemplates/" + template + ".ascx");
        var placeholder = e.Item.FindControl("ArticlePlaceHolder") as PlaceHolder;

        articleTemplateControl.ArticleTemplate = (Article)e.Item.DataItem;
        if (placeholder != null) placeholder.Controls.Add(articleTemplateControl);
    }
}
