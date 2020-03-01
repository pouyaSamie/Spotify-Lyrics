using System.Collections.Generic;
using Core.ApiCaller.Models;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralAlbums : BasicModel
    {
        [JsonProperty("albums")]
        public List<FullAlbum> Albums { get; set; }
    }
}