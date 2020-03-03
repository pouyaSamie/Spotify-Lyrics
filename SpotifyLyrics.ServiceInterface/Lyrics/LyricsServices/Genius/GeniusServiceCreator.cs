using SpotifyLyrics.ServiceInterface.Lyrics.Factory;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Genius
{
    public class GeniusServiceCreator : LyricsServiceFactory
    {
        public override LyricsService CreateLyricsService(ConfigModel configModel)
        {
            return new SearchLyrics(configModel);
        }
    }
}
