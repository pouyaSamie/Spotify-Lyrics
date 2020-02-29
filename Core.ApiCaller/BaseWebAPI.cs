using Core.ApiCaller.Models;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.ApiCaller
{
    public abstract class BaseWebAPI : IDisposable
    {
        public abstract IWebBuilder _builder { get;  }
        public BaseWebAPI() : this(new ProxyConfig())
        {
        }

        public BaseWebAPI(ProxyConfig proxyConfig)
        {
            
            UseAuth = true;
            WebClient = new CustomWebClient(proxyConfig)
            {
                JsonSettings =
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    }
            };
        }

        public abstract void SetAuthenticationParams(ref Dictionary<string, string> headers, ref string url);

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
        protected Tuple<ResponseInfo, T> DownloadDataAlt<T>(string url)
        {
            Dictionary<string, string> headers = GetHeaders();

            if (UseAuth)
                SetAuthenticationParams(ref headers, ref url);

            return WebClient.DownloadJson<T>(url, headers);
        }

        protected Task<Tuple<ResponseInfo, T>> DownloadDataAltAsync<T>(string url)
        {
            var queryStringsign = url.Contains("?") ? "&" : "?";
            Dictionary<string, string> headers = GetHeaders();
            url = $"{url}{queryStringsign}";
            if (UseAuth)
                SetAuthenticationParams(ref headers, ref url);

            return WebClient.DownloadJsonAsync<T>(url, headers);
        }

        private Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string>();
        }


        /// <summary>
        ///     The type of the <see cref="AccessToken"/>
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        ///     A valid token issued by spotify. Used only when <see cref="UseAuth"/> is true
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        ///     If true, an authorization header based on <see cref="TokenType"/> and <see cref="AccessToken"/> will be used
        /// </summary>
        public bool UseAuth { get; set; }

        /// <summary>
        ///     A custom WebClient, used for Unit-Testing
        /// </summary>
        public IClient<ResponseInfo> WebClient { get; set; }


        /// <summary>
        ///     Specifies after how many miliseconds should a failed request be retried.
        /// </summary>
        public int RetryAfter { get; set; } = 50;

        /// <summary>
        ///     Should a failed request (specified by <see cref="RetryErrorCodes"/> be automatically retried or not.
        /// </summary>
        public bool UseAutoRetry { get; set; } = false;

        /// <summary>
        ///     Maximum number of tries for one failed request.
        /// </summary>
        public int RetryTimes { get; set; } = 10;

        /// <summary>
        ///     Whether a failure of type "Too Many Requests" should use up one of the allocated retry attempts.
        /// </summary>
        public bool TooManyRequestsConsumesARetry { get; set; } = false;

        /// <summary>
        ///     Error codes that will trigger auto-retry if <see cref="UseAutoRetry"/> is enabled.
        /// </summary>
        public IEnumerable<int> RetryErrorCodes { get; set; } = new[] { 500, 502, 503 };
        public void Dispose()
        {
            WebClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
