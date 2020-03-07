using Core.Lyrics.LyricsModel;
using GeniusLyrics;
using SpotifyLyrics.ServiceInterface.Common;
using SpotifyLyrics.ServiceInterface.Lyrics.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Genius
{

    /// <summary>
    /// Genius Concrete class  
    /// </summary>
    public class SearchLyrics : LyricsService
    {

        private readonly GeniusWebApi _Api;
        public SearchLyrics(ConfigModel configModel):base(configModel)
        {
             _Api = new GeniusWebApi();
        }

        public override Task<ServiceResult<string>> DownloadLyrics(string url)
        {
            throw new NotImplementedException();
        }

        public async override Task<ServiceResult<IEnumerable<BaseLyricsSearchModel>>> SearchItem(string q, int limit = 5)
        {
            //Genius accepts maximum 5 hits
            if (limit > 5)
                limit = 5;
            var result =await _Api.SearchItems(q, limit);

            
            if (result == null || !result.Success || result.Result.Meta.Status != 200)
                return ServiceResult<IEnumerable<BaseLyricsSearchModel>>.Failed(result.Error?.Message);

            var topHit = result.Result.Response.Sections.Where(x => x.Hits.Any(c => c.Type == GeniusLyrics.Model.TypeEnum.TopHit)).FirstOrDefault();
            if (topHit is null)
                return ServiceResult<IEnumerable<BaseLyricsSearchModel>>.Failed("No Result");

            return ServiceResult<IEnumerable<BaseLyricsSearchModel>>.Success(topHit.Hits.Select(x => new BaseLyricsSearchModel() { LyricUrl = x.Result.Url.OriginalString }).ToList());
            
        }
    }
}
