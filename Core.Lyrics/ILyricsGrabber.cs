using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Lyrics
{
    public interface ILyricsGrabber<T>
    {
        Task<T> GetLyric(string lyricUrl);
    }

}
