using Microsoft.Extensions.Configuration;
using SpotifyLyrics.ServiceInterface.Lyrics.Factory;
using SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Genius;
using SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Happi;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.Console.Example.Helper
{
    public class LyricsServiceSelector
    {
        public static LyricsServiceFactory GetFactory(IConfigurationSection configSection) {

           if (configSection.GetSection("HappiApiKey").Exists())
                return new HappiServiceCreator();
           else
                return new GeniusServiceCreator();
            
        }
    }
}
