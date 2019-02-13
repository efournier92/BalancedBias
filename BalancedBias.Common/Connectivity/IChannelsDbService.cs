using System.Collections.Generic;
using BalancedBias.Common.Config;
using BalancedBias.Common.Rss;

namespace BalancedBias.Common.Connectivity
{
    public interface IChannelsDbService
    {
        /// <summary>
        /// Writes a new article to the Channels database table
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="publishDate"></param>
        /// <param name="description"></param>
        void AddNewArticle(string channel, string title, string url, string publishDate, string description);

        /// <summary>
        /// Reads channels from database by inputted date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Collection of channels</returns>
        NewsCollection GetChannelsFromDbByDate(string date);

        /// <summary>
        /// Reads all unique article dates by string
        /// </summary>
        /// <returns>List of unique article dates as strings</returns>
        List<string> GetUniqueArticleDates();

        /// <summary>
        /// Gets all articles from database according to inputted channel and date published 
        /// </summary>
        /// <param name="channelElement"></param>
        /// <param name="publishDate"></param>
        /// <returns>Channel containing all articles from inputted date</returns>
        Channel GetArticlesByDateAndChannel(ChannelElement channelElement, string publishDate);

        /// <summary>
        /// Checks if inputted article title is already written to the database
        /// </summary>
        /// <param name="title"></param>
        /// <returns>Bool reflecting if inputted article is unique in database</returns>
        bool IsArticleUnique(string title);
    }
}