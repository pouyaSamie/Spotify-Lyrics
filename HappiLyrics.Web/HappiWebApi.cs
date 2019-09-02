using Core.ApiCaller;
using Core.ApiCaller.Models;
using HappiLyricsApi.Web.Model;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public Task<Response<List<SearchResult>>> SearchItems(string q, int limit = 20)
        {
            return DownloadDataAsync<Response<List<SearchResult>>>(_happiWebBuilder.SearchItems(q, limit));
        }

        public Task<Response<LyricsResult>> GetLyric(string lyricApiUrl)
        {
            return DownloadDataAsync<Response<LyricsResult>>(lyricApiUrl);
        }

        public T DownloadData<T>(string url) where T : BasicModel
        {
            int triesLeft = RetryTimes + 1;
            Error lastError;

            Tuple<ResponseInfo, T> response = null;
            do
            {
                if (response != null) { Thread.Sleep(RetryAfter); }
                response = DownloadDataAlt<T>(url);

                response.Item2.AddResponseInfo(response.Item1);
                lastError = response.Item2.Error;

                triesLeft -= 1;

            } while (UseAutoRetry && triesLeft > 0 && lastError != null && RetryErrorCodes.Contains(lastError.Status));


            return response.Item2;
        }

        public async Task<T> DownloadDataAsync<T>(string url) where T : BasicModel
        {
            int triesLeft = RetryTimes + 1;
            Error lastError;

            Tuple<ResponseInfo, T> response = null;
            do
            {
                if (response != null)
                {
                    int msToWait = RetryAfter;
                    int secondsToWait = GetTooManyRequests(response.Item1);
                    if (secondsToWait > 0)
                    {
                        msToWait = secondsToWait * 1000;
                    }
                    await Task.Delay(msToWait).ConfigureAwait(false);
                }
                response = await DownloadDataAltAsync<T>(url).ConfigureAwait(false);

                response.Item2.AddResponseInfo(response.Item1);
                lastError = response.Item2.Error;

                if (TooManyRequestsConsumesARetry || GetTooManyRequests(response.Item1) == -1)
                {
                    triesLeft -= 1;
                }

            } while (UseAutoRetry
                && triesLeft > 0
                && (GetTooManyRequests(response.Item1) != -1
                    || lastError != null && RetryErrorCodes.Contains(lastError.Status)));


            return response.Item2;
        }

        private int GetTooManyRequests(ResponseInfo info)
        {
            // 429 is "TooManyRequests" value specified in Spotify API
            if (429 != (int)info.StatusCode)
            {
                return -1;
            }
            if (!int.TryParse(info.Headers.Get("Retry-After"), out int secondsToWait))
            {
                return -1;
            }
            return secondsToWait;
        }
        private Tuple<ResponseInfo, T> DownloadDataAlt<T>(string url)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (UseAuth)
                url += $"{url}&apikey={happyApiKey}";
                //headers.Add("Authorization", TokenType + " " + AccessToken);

            return WebClient.DownloadJson<T>(url, headers);
        }

        private Task<Tuple<ResponseInfo, T>> DownloadDataAltAsync<T>(string url)
        {
            var queryStringsign = url.Contains("?") ? "&" : "?";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (UseAuth)
                url = $"{url}{queryStringsign}apikey={happyApiKey}";
            return WebClient.DownloadJsonAsync<T>(url, headers);
        }



    }
}
