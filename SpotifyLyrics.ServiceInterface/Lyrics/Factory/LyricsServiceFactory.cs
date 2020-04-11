using SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.ServiceInterface.Lyrics.Factory
{
    /// <summary>
    /// Lyrics Service Creator Class
    /// </summary>
    public abstract class LyricsServiceFactory
    {
        public abstract LyricsService CreateLyricsService(ConfigModel configModel);
    }
}
