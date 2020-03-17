using Core.ApiCaller;
using Core.ApiCaller.Models;
using Core.Lyrics;
using Core.Lyrics.LyricsModel;
using GeniusLyrics.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeniusLyrics
{
    public class GeniusWebApi : BaseWebAPI
    {
        public override IWebBuilder _builder => new GeniusApiBuilder();
        private GeniusApiBuilder _geniusApiBuilder => (GeniusApiBuilder)_builder;

        public Task<Response<string>> GetLyric(string lyricUrl)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Get Spotify catalog information about artists, albums, tracks or playlists that match a keyword string.
        /// </summary>
        /// <param name="q">The search query's keywords (and optional field filters and operators), for example q=roadhouse+blues.</param>
        /// <param name="type">A list of item types to search across.</param>
        /// <param name="limit">The maximum number of items to return. Default: 5. Minimum: 1. Maximum: 50.</param>
        /// <returns></returns>
        public async Task<Response<GeniusResult>> SearchItems(string q, int limit = 5)
        {
            var result= await DownloadDataAsync<GeniusResult>(_geniusApiBuilder.SearchItems(q, limit));
            return new Response<GeniusResult>() {Success = result.Meta.Status==200,Error =new Error() { Message = result.Response.Error, Status = result.Meta.Status }, Length=0,Result=result };
        }

        
        public override void SetAuthenticationParams(ref Dictionary<string, string> headers, ref string url)
        {
            //Do nothing
        }


    }  




}

