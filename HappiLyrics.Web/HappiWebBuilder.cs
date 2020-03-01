using Core.ApiCaller;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappiLyricsApi.Web
{
    public class HappiWebBuilder: IWebBuilder
    {
        public const string APIBase = "https://api.happi.dev/v1/music";
        public string SearchItems(string q, int limit = 5)
        {
            limit = Math.Min(10, limit);
            StringBuilder builder = new StringBuilder(APIBase);
            builder.Append("?q=" + q);
            builder.Append("&limit=" + limit);
            return builder.ToString();
        }
    }
}
