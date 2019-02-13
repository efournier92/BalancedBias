namespace BalancedBias.Rss
{
    public interface IChannelsDbService
    {
        //void AddNewArticle(string channel, string title, string url, string publishDate, string description);
        NewsCollection GetChannelsFromDbByDate(string date);

    }
}