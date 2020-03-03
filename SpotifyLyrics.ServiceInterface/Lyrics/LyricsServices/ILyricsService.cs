using Core.Lyrics.LyricsModel;
using SpotifyLyrics.ServiceInterface.Common;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices
{
    public abstract class LyricsService
    {
        protected ConfigModel ConfigModel { get; }
        public abstract  Task<ServiceResult<IEnumerable<BaseLyricsSearchModel>>> SearchItem(string q, int limit = 20);
        public LyricsService(ConfigModel configModel)
        {
            ConfigModel = configModel;
        }
    }
}
