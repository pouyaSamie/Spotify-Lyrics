using System.Collections.Generic;
using Core.ApiCaller.Models;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralArtists : BasicModel
    {
        [JsonProperty("artists")]
        public List<FullArtist> Artists { get; set; }
    }
}