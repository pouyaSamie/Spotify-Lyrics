using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Models
{
    public class CurrentSongPlayingItem
    {

        [JsonProperty("album")]
        public SimpleAlbum Album { get; set; }

        [JsonProperty("artists")]
        public List<SimpleArtist> Artists { get; set; }

        [JsonProperty("available_markets")]
        public List<string> available_markets { get; set; }

        [JsonProperty("disc_number")]
        public int disc_number { get; set; }

        [JsonProperty("duration_ms")]
        public int duration_ms { get; set; }



        [JsonProperty("href")]
        public string href { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("is_local")]
        public bool is_local { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("popularity")]
        public int popularity { get; set; }

        [JsonProperty("preview_url")]
        public string preview_url { get; set; }

        [JsonProperty("track_number")]
        public int track_number { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("uri")]
        public string uri { get; set; }

    }
}
