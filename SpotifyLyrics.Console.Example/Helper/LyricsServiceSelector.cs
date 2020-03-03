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
        public static LyricsServiceFactory GetFactory(LyricsServices lyricsServices) {

            switch (lyricsServices)
            {
                case LyricsServices.Happi:
                    return new HappiServiceCreator();
                    
                case LyricsServices.Genius:
                    return new GeniusServiceCreator();
                default:
                    return new HappiServiceCreator();
                    
            }
        }
    }
}
