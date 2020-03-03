using Core.ApiCaller;
using Core.Lyrics;
using Core.Lyrics.LyricsModel;
using HappiLyricsApi.Web.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HappiLyricsApi.Web
{
    public class HappiWebApi : BaseWebAPI
    {
        private string happyApiKey = "";
        public override IWebBuilder _builder => new HappiWebBuilder();
        private HappiWebBuilder _happiWebBuilder=> (HappiWebBuilder)_builder ;

        public HappiWebApi(string apiKey)
        {
            happyApiKey = apiKey;
        }
        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 20. Minimum: 1. Maximum: 50.</param>
        /// <returns></returns>
        public Task<Response<IEnumerable<SearchResult>>> SearchItems(string q, int limit = 20)
        {
            return DownloadDataAsync<Response<IEnumerable<SearchResult>>>(_happiWebBuilder.SearchItems(q, limit));
        }


        public async Task<Response<LyricsResult>> GetLyric(string lyricUrl)
        {
            var result = await DownloadDataAsync<Response<LyricsResult>>(lyricUrl);
            return result;
        }

        public override void SetAuthenticationParams(ref Dictionary<string, string> headers,ref string url) {
            url = $"{url}apikey={happyApiKey}";
        }

      
    }
}
