using System.Collections.Generic;
using Core.ApiCaller.Models;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class SeveralTracks : BasicModel
    {
        [JsonProperty("tracks")]
        public List<FullTrack> Tracks { get; set; }
    }
}