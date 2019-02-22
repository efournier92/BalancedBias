using System.Threading.Tasks;

namespace BalancedBias.Common.Rss
{
    public interface IRssChannelsService
    {
        Task<bool> PersistNewArticles();
    }
}