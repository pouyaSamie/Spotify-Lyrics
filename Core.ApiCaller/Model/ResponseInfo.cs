using System.Net;

namespace Core.ApiCaller.Models
{
    public class ResponseInfo
    {
        public WebHeaderCollection Headers { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public static readonly ResponseInfo Empty = new ResponseInfo();
    }
}