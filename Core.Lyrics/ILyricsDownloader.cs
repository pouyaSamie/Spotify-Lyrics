using Core.Lyrics.LyricsModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Lyrics
{
    public interface ILyricsDownloader<T>
    {
        Task<Response<T>> GetLyric(string lyricUrl);
    }
}
