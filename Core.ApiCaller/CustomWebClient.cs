using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Core.ApiCaller.Models;

namespace SpotifyAPI.Web
{
    public class CustomWebClient : IClient<ResponseInfo>
    {
        public JsonSerializerSettings JsonSettings { get; set; }
        private readonly Encoding _encoding = Encoding.UTF8;
        private readonly HttpClient _client;

        protected virtual string UnknownErrorJson
        {
            get
            {
                return "{\"error\": { \"status\": 0, \"message\": \"SpotifyAPI.Web - Unkown Spotify Error\" }}";
            }
        }

        public CustomWebClient(ProxyConfig proxyConfig = null)
        {
            HttpClientHandler clientHandler = CreateClientHandler(proxyConfig);
            _client = new HttpClient(clientHandler);
        }

        public Tuple<ResponseInfo, string> Download(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = DownloadRaw(url, headers);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }

        public async Task<Tuple<ResponseInfo, string>> DownloadAsync(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> raw = await DownloadRawAsync(url, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(raw.Item1, raw.Item2.Length > 0 ? _encoding.GetString(raw.Item2) : "{}");
        }

        public Tuple<ResponseInfo, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }
            using (HttpResponseMessage response = Task.Run(() => _client.GetAsync(url)).Result)
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, Task.Run(() => response.Content.ReadAsByteArrayAsync()).Result);
            }
        }

        public async Task<Tuple<ResponseInfo, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null)
        {
            try
            {

                Uri uriResult;
                if(!Uri.TryCreate(url, UriKind.Absolute, out uriResult))
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = HttpStatusCode.InternalServerError,
                        Headers = null,
                    }, Encoding.UTF8.GetBytes($"{url} is not valid url"));




                if (headers != null)
                    AddHeaders(headers);

                using (HttpResponseMessage response = await _client.GetAsync(url).ConfigureAwait(false))
                {
                    return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                    {
                        StatusCode = response.StatusCode,
                        Headers = ConvertHeaders(response.Headers)
                    }, await response.Content.ReadAsByteArrayAsync());
                }
            }
            catch (Exception ex)
            {

                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Headers = null,
                }, Encoding.UTF8.GetBytes(ex.Message));
            }
        }

        public Tuple<ResponseInfo, U> DownloadJson<U>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = Download(url, headers);
            try
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(response.Item2, JsonSettings));
            }
            catch (JsonException)
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(UnknownErrorJson, JsonSettings));
            }
        }

        public async Task<Tuple<ResponseInfo, U>> DownloadJsonAsync<U>(string url, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await DownloadAsync(url, headers).ConfigureAwait(false); try
            {

                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(response.Item2, JsonSettings));
            }
            catch (JsonException ex)
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(UnknownErrorJson, JsonSettings));
            }
        }

        public Tuple<ResponseInfo, string> Upload(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> data = UploadRaw(url, body, method, headers);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
        }

        public async Task<Tuple<ResponseInfo, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, byte[]> data = await UploadRawAsync(url, body, method, headers).ConfigureAwait(false);
            return new Tuple<ResponseInfo, string>(data.Item1, data.Item2.Length > 0 ? _encoding.GetString(data.Item2) : "{}");
        }

        public Tuple<ResponseInfo, byte[]> UploadRaw(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url)
            {
                Content = new StringContent(body, _encoding)
            };
            using (HttpResponseMessage response = Task.Run(() => _client.SendAsync(message)).Result)
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, Task.Run(() => response.Content.ReadAsByteArrayAsync()).Result);
            }
        }

        public async Task<Tuple<ResponseInfo, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                AddHeaders(headers);
            }

            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), url)
            {
                Content = new StringContent(body, _encoding)
            };
            using (HttpResponseMessage response = await _client.SendAsync(message))
            {
                return new Tuple<ResponseInfo, byte[]>(new ResponseInfo
                {
                    StatusCode = response.StatusCode,
                    Headers = ConvertHeaders(response.Headers)
                }, await response.Content.ReadAsByteArrayAsync());
            }
        }

        public Tuple<ResponseInfo, U> UploadJson<U>(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = Upload(url, body, method, headers);
            try
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(response.Item2, JsonSettings));
            }
            catch (JsonException)
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(UnknownErrorJson, JsonSettings));
            }
        }

        public async Task<Tuple<ResponseInfo, U>> UploadJsonAsync<U>(string url, string body, string method, Dictionary<string, string> headers = null)
        {
            Tuple<ResponseInfo, string> response = await UploadAsync(url, body, method, headers).ConfigureAwait(false);
            try
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(response.Item2, JsonSettings));
            }
            catch (JsonException)
            {
                return new Tuple<ResponseInfo, U>(response.Item1, JsonConvert.DeserializeObject<U>(UnknownErrorJson, JsonSettings));
            }
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }

        private static WebHeaderCollection ConvertHeaders(HttpResponseHeaders headers)
        {
            WebHeaderCollection newHeaders = new WebHeaderCollection();
            foreach (KeyValuePair<string, IEnumerable<string>> headerPair in headers)
            {
                foreach (string headerValue in headerPair.Value)
                {
                    newHeaders.Add(headerPair.Key, headerValue);
                }
            }
            return newHeaders;
        }

        private void AddHeaders(Dictionary<string, string> headers)
        {
            _client.DefaultRequestHeaders.Clear();
            foreach (KeyValuePair<string, string> headerPair in headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(headerPair.Key, headerPair.Value);
            }
        }

        private static HttpClientHandler CreateClientHandler(ProxyConfig proxyConfig = null)
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                PreAuthenticate = false,
                UseDefaultCredentials = true,
                UseProxy = false
            };

            if (string.IsNullOrWhiteSpace(proxyConfig?.Host)) return clientHandler;
            WebProxy proxy = proxyConfig.CreateWebProxy();
            clientHandler.UseProxy = true;
            clientHandler.Proxy = proxy;
            clientHandler.UseDefaultCredentials = proxy.UseDefaultCredentials;
            clientHandler.PreAuthenticate = proxy.UseDefaultCredentials;

            return clientHandler;
        }


    }
}