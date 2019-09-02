using Core.ApiCaller.Models;
using Newtonsoft.Json;
using SpotifyAPI.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
