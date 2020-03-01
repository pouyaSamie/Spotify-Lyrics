using Core.Lyrics.LyricsModel;
using System.Threading.Tasks;

namespace Core.Lyrics
{
    public interface ILyricsFinder<T>
    {
        Task<Response<T>> SearchItems(string q, int limit = 20);
        

    }
}
