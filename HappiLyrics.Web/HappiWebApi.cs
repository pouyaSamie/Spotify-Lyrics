using Core.ApiCaller;
using Core.ApiCaller.Models;
using Core.Lyrics;
using HappiLyricsApi.Web.Model;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HappiLyricsApi.Web
{
    public class HappiWebApi : BaseWebAPI,ILyricsFinder<Response<List<SearchResult>>>,ILyricsGrabber<Response<LyricsResult>>
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
        public Task<Response<List<SearchResult>>> SearchItems(string q, int limit = 20)
        {
            return DownloadDataAsync<Response<List<SearchResult>>>(_happiWebBuilder.SearchItems(q, limit));
        }

        public Task<Response<LyricsResult>> GetLyric(string lyricUrl)
        {
            return DownloadDataAsync<Response<LyricsResult>>(lyricUrl);
        }

        public override void SetAuthenticationParams(ref Dictionary<string, string> headers,ref string url) {
            url = $"{url}apikey={happyApiKey}";
        }

        
    }
}
