using Core.ApiCaller.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyAPI.Web.Models
{
    public class SimpleCurrentsong:BasicModel
    {
        [JsonProperty("timestamp")]
        public long timestamp { get; set; }

        [JsonProperty("context")]
        public Context context { get; set; }

        [JsonProperty("progress_ms")]
        public int progress_ms { get; set; }

        [JsonProperty("item")]
        public CurrentSongPlayingItem Item { get; set; }

        [JsonProperty("currently_playing_type")]
        public string currently_playing_type { get; set; }

        //[JsonProperty("actions")]
        //public Actions actions { get; set; }

        [JsonProperty("is_playing")]
        public bool is_playing { get; set; }

    }
}
