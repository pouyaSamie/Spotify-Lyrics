using System.Collections.Generic;
using Core.ApiCaller.Models;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class RecommendationSeedGenres : BasicModel
    {
         [JsonProperty("genres")]
         public List<string> Genres { get; set; }
    }
}