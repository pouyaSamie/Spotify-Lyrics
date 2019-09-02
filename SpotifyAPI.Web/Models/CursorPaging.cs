﻿using Core.ApiCaller.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SpotifyAPI.Web.Models
{
    public class CursorPaging<T> : BasicModel
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("items")]
        public List<T> Items { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("cursors")]
        public Cursor Cursors { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        public bool HasNext()
        {
            return !string.IsNullOrEmpty(Next);
        }
    }
}
