using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace SpotifyAPI.Web
{
    public class ProxyConfig
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Whether to bypass the proxy server for local addresses.
        /// </summary>
        /// <summary>
        /// Whether to bypass the proxy server for local addresses.
        /// </summary>
        public bool BypassProxyOnLocal { get; set; }

        public void Set(ProxyConfig proxyConfig)
        {
            Host = proxyConfig?.Host;
            Port = proxyConfig?.Port ?? 80;
            Username = proxyConfig?.Username;
            Password = proxyConfig?.Password;
            BypassProxyOnLocal = proxyConfig?.BypassProxyOnLocal ?? false;
        }

        public ProxyConfig()
        {
            SetProxyFromConfig();
        }

        private void SetProxyFromConfig()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("config.json");


            var configuration = builder.Build();

            var configFileName = configuration["configFile"];

            builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(configFileName);

            Host = configuration["proxy:host"]?? "";
            Port =int.Parse(configuration["proxy:port"]??"80");
            Username = configuration["proxy:user"]??"";
            Password = configuration["proxy:password"]??"";
        }

        /// <summary>
        /// Whether both <see cref="Host"/> and <see cref="Port"/> have valid values.
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Host) && Port > 0;
        }

        /// <summary>
        /// Create a <see cref="Uri"/> from the host and port number
        /// </summary>
        /// <returns>A URI</returns>
        public Uri GetUri()
        {
            UriBuilder uriBuilder = new UriBuilder(Host)
            {
                Port = Port
            };
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Creates a <see cref="WebProxy"/> from the proxy details of this object.
        /// </summary>
        /// <returns>A <see cref="WebProxy"/> or <code>null</code> if the proxy details are invalid.</returns>
        public WebProxy CreateWebProxy()
        {
            if (!IsValid())
                return null;

            WebProxy proxy = new WebProxy
            {
                Address = GetUri(),
                UseDefaultCredentials = true,
                BypassProxyOnLocal = BypassProxyOnLocal
            };

            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                return proxy;

            proxy.UseDefaultCredentials = false;
            proxy.Credentials = new NetworkCredential(Username, Password);

            return proxy;
        }

        public static HttpClientHandler CreateClientHandler(ProxyConfig proxyConfig = null)
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