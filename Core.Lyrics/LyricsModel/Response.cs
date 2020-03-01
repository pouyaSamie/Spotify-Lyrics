using Core.ApiCaller.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Lyrics.LyricsModel
{
    public class Response<T>:BasicModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("result")]
        public T Result { get; set; }
    }
}
