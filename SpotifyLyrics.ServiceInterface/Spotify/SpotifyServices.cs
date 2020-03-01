using SpotifyAPI.Web;
using SpotifyAPI.Web.Models;
using SpotifyLyrics.ServiceInterface.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyLyrics.ServiceInterface.Spotify
{
    public class SpotifyServices
    {
        public static async Task<ServiceResult<string>> CurrentPlayingsong(SpotifyWebAPI api)
        {

            SimpleCurrentsong currentsong = await api.GetUserCurrentSong();
            var songInfo = "";

            if (currentsong.Item == null)
            {
                return ServiceResult<string>.Failed("no playing song found");
            }


            //If the ad was playing we will do nothing
            if (currentsong.currently_playing_type == "ad")
                return ServiceResult<string>.Failed(songInfo);


            //for finding lyrics the first Artist is enough
            songInfo += currentsong.Item.Artists.First().Name;


            //if song has something like 'Remasterd' or anything else at the end of it names the lyrics api can not find the actual Lyrics so we eliminate that part
            songInfo += $"- {currentsong.Item.Name.Split('-')[0].Trim()}";
            return ServiceResult<string>.Success(songInfo);




        }
    }
}
