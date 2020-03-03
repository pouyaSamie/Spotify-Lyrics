using Core.Lyrics.LyricsModel;
using SpotifyLyrics.ServiceInterface.Common;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Genius
{

    /// <summary>
    /// Genius Concrete class  
    /// </summary>
    public class SearchLyrics : LyricsService
    {
        public SearchLyrics(ConfigModel configModel):base(configModel)
        {

        }

        public override Task<ServiceResult<string>> DownloadLyrics(string url)
        {
            throw new NotImplementedException();
        }

        public override Task<ServiceResult<IEnumerable<BaseLyricsSearchModel>>> SearchItem(string q, int limit = 20)
        {
            throw new NotImplementedException();
        }
    }
}
