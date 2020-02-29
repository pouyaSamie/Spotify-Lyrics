using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Lyrics
{
    public interface ILyricsFinder<T>
    {
        Task<T> SearchItems(string q, int limit = 20);
        

    }
}
