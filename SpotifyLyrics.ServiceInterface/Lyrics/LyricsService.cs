using Core.Lyrics;
using Core.Lyrics.LyricsModel;
using SpotifyLyrics.ServiceInterface.Common;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SpotifyLyrics.ServiceInterface.Lyrics
{
    public class LyricsService<T>
    {
        public  ServiceResult<Response<List<T>>> SearchForLyrics(ILyricsFinder<List<T>> api ,string songInfo)  {
            var currentsong = api.SearchItems(songInfo).GetAwaiter().GetResult();
            
            if (currentsong.Error != null)
                return ServiceResult<Response<List<T>>>.Failed($"no lyrics found - {currentsong.Error.Message}");

            if (!currentsong.Result.Any())
                return ServiceResult<Response<List<T>>>.Failed($"no lyrics found");

            return ServiceResult<Response<List<T>>>.Success(currentsong);

        }
    }
}
