using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalancedBias.Common.Config;
using BalancedBias.Common.Constants;
using BalancedBias.Common.Infrastructure;
using BalancedBias.Rss;

public partial class Dashboard : System.Web.UI.Page
{
    private static IAppConfigReader _appConfigReader;
    public string MediaBasePath;
    public DropDownList DatesDropDown = new DropDownList();

    public Dashboard()
        : this(DependencyResolverGateway.Resolve<IAppConfigReader>())
    {

    }

    private Dashboard(IAppConfigReader appConfigReader)
    {
        _appConfigReader = appConfigReader;
        MediaBasePath = _appConfigReader.AppConfigToString(AppSettingKeys.MediaBasePath);
    }

    public object TemplateType { get; set; }
    public PlaceHolder Placeholder1 = new PlaceHolder();

    protected void Page_Load(object sender, EventArgs e)
    {
        TemplateType = "TemplateGeneric";

        if (!Page.IsPostBack)
        {
            var todaysDate = DateTime.Today.ToString(CultureInfo.InvariantCulture).Split(null)[0];
            datesDropDown.Text = todaysDate;
            var allChannels = ChannelsDbService.GetChannelsFromDbByDate(todaysDate);
            BindAllChannels(allChannels);

            var allDates = ChannelsDbService.GetUniqueArticleDates().OrderByDescending(date => date);
            datesDropDown.DataSource = allDates;
            datesDropDown.DataBind();
        }
    }

    protected void SearchArticlesByDate(object sender, EventArgs e)
    {
        var date = datesDropDown.Text;
        var allChannels = ChannelsDbService.GetChannelsFromDbByDate(date);
        BindAllChannels(allChannels);
    }
     
    private void BindAllChannels(NewsCollection allChannels)
    {
        RssService.PersistNewArticles();
        gvRss.DataSource = allChannels.Channels;
        gvRss.DataBind();
    }

    protected void OnArticleDataBound(object sender, RepeaterItemEventArgs e)
    {
        var ucSimpleControl = LoadControl("~/ArticleTemplates/GenericArticleTemplate.ascx");
        var placeh = e.Item.FindControl("templatePlaceholder") as PlaceHolder;
        p1.Controls.Add(ucSimpleControl);
    }
}
  