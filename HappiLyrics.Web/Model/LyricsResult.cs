using Core.Lyrics.LyricsModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HappiLyricsApi.Web.Model
{
    public class LyricsResult
    {
        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("id_artist")]
        public long IdArtist { get; set; }

        [JsonProperty("track")]
        public string Track { get; set; }

        [JsonProperty("id_track")]
        public long IdTrack { get; set; }

        [JsonProperty("id_album")]
        public long IdAlbum { get; set; }

        [JsonProperty("album")]
        public string Album { get; set; }

        [JsonProperty("lyrics")]
        public string Lyrics { get; set; }

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

        [JsonProperty("copyright_label")]
        public string CopyrightLabel { get; set; }

        [JsonProperty("copyright_notice")]
        public string CopyrightNotice { get; set; }

        [JsonProperty("copyright_text")]
        public string CopyrightText { get; set; }

        
    }
}
