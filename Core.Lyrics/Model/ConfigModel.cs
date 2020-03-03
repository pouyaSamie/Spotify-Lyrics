using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.ServiceInterface.Lyrics.Model
{
    public class ConfigModel
    {
        public ConfigModel(IConfigurationSection configSection)
        {
            ConfigSection = configSection;
        }

        public IConfigurationSection ConfigSection { get; set; }
    }
}
