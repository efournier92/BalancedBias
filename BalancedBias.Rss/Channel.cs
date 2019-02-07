using System.Collections.Generic;

namespace BalancedBias.Rss
{
    public class Channel
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<Article> Articles { get; set; }

        public Channel()
        {
            Articles = new List<Article>();
        }
    }
}
