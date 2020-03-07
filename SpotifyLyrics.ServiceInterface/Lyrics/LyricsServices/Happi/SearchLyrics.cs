using Core.Lyrics.LyricsModel;
using HappiLyricsApi.Web;
using SpotifyLyrics.ServiceInterface.Common;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.Swan;

namespace SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Happi
{

    /// <summary>
    /// Happi Concrete class  
    /// </summary>
    public class SearchLyrics : LyricsService
    {
        private readonly string _ApiKey;
        HappiWebApi api;
        public SearchLyrics(ConfigModel ConfigModel):base(ConfigModel)
        {
        
            if (string.IsNullOrEmpty(_ApiKey))
                _ApiKey = GetApiKey();

            api = new HappiWebApi(_ApiKey);
        }

        public async override Task<ServiceResult<string>> DownloadLyrics(string url)
        {
            var lyrics = await api.GetLyric(url);
            if (string.IsNullOrEmpty(lyrics?.Result?.Lyrics))
                return ServiceResult<string>.Failed("no lyrics found");
            return ServiceResult<string>.Success(lyrics.Result.Lyrics);
            
        }

        public async override Task<ServiceResult<IEnumerable<BaseLyricsSearchModel>>> SearchItem(string q, int limit = 20)
        {
            
            var result = await api.SearchItems(q, limit);
            if (!result.Success || result.Error != null)
                return ServiceResult<IEnumerable<BaseLyricsSearchModel>>.Failed(result.Error?.Message);
            return ServiceResult<IEnumerable<BaseLyricsSearchModel>>.Success(result.Result);



        }

        private string GetApiKey()
        {
            return this.ConfigModel.ConfigSection["HappiApiKey"];
        }

        
    }
}
