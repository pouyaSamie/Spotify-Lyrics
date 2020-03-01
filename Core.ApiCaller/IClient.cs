using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SpotifyAPI.Web
{
    public interface IClient<T> : IDisposable
    {
        JsonSerializerSettings JsonSettings { get; set; }

        /// <summary>
        ///     Downloads data from an URL and returns it
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T, string> Download(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, string>> DownloadAsync(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data from an URL and returns it
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T, byte[]> DownloadRaw(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and returns it
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, byte[]>> DownloadRawAsync(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data from an URL and converts it to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T, U> DownloadJson<U>(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Downloads data async from an URL and converts it to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, U>> DownloadJsonAsync<U>(string url, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T, string> Upload(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, string>> UploadAsync(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T, byte[]> UploadRaw(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and returns the response
        /// </summary>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, byte[]>> UploadRawAsync(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data from an URL and converts the response to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Tuple<T,U> UploadJson<U>(string url, string body, string method, Dictionary<string, string> headers = null);

        /// <summary>
        ///     Uploads data async from an URL and converts the response to an object
        /// </summary>
        /// <typeparam name="T">The Type which the object gets converted to</typeparam>
        /// <param name="url">An URL</param>
        /// <param name="body">The Body-Data (most likely a JSON String)</param>
        /// <param name="method">The Upload-method (POST,DELETE,PUT)</param>
        /// <param name="headers"></param>
        /// <returns></returns>
        Task<Tuple<T, U>> UploadJsonAsync<U>(string url, string body, string method, Dictionary<string, string> headers = null);
    }
}