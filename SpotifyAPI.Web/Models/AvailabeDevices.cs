using System.Collections.Generic;
using Core.ApiCaller.Models;
using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
    public class AvailabeDevices : BasicModel
    {
        [JsonProperty("devices")]
        public List<Device> Devices { get; set; }
    }
}