using Core.ApiCaller;
using System;
using System.Text;

namespace GeniusLyrics
{
    public class GeniusApiBuilder : IWebBuilder
    {
        public const string BaseApi = "https://genius.com/api/search/multi/";
        public string SearchItems(string q, int limit = 5)
        {
            limit = Math.Min(10, limit);
            StringBuilder builder = new StringBuilder(BaseApi);
            builder.Append("?per_page=" + limit);
            builder.Append("&q=" + q);
            return builder.ToString();
        }
    }
}
