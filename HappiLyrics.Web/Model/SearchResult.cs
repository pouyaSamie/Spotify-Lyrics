using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappiLyricsApi.Web.Model
{
    public class SearchResult
    {
        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("id_track")]
        public long IdTrack { get; set; }

        [JsonProperty("haslyrics")]
        public bool Haslyrics { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("id_artist")]
        public long IdArtist { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("id_album")]
        public long IdAlbum { get; set; }

        [JsonProperty("cover")]
        public Uri Cover { get; set; }

        [JsonProperty("api_artist")]
        public Uri ApiArtist { get; set; }

        [JsonProperty("api_albums")]
        public Uri ApiAlbums { get; set; }

        [JsonProperty("api_album")]
        public Uri ApiAlbum { get; set; }

        [JsonProperty("api_tracks")]
        public Uri ApiTracks { get; set; }

        [JsonProperty("api_track")]
        public Uri ApiTrack { get; set; }

        [JsonProperty("api_lyrics")]
        public Uri ApiLyrics { get; set; }
    }
}
