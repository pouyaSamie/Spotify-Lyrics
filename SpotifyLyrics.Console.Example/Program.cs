using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HappiLyricsApi.Web;
using HappiLyricsApi.Web.Model;
using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyLyrics.Console.Example;

namespace SpotifyAPI.Web.Example
{
    internal static class Program
    {
        private static string _clientId = "";
        private static string _secretId = "";
        private static string _HappiapiKey = "";

        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            SetApiKeys();
                        
            AuthorizationCodeAuth auth =
                new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4002", "http://localhost:4002",
                    Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.UserReadCurrentlyPlaying);
            auth.AuthReceived += AuthOnAuthReceived;
            auth.Start();
            auth.OpenBrowser();
            Timer t = new Timer(TimerCallbackAsync, null, 0, 5000);
            Console.ReadLine();
            auth.Stop(0);
        }

        private static void SetApiKeys()
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("config.json");
                           

            var configuration = builder.Build();

            var configFileName = configuration["configFile"];
            
            builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile(configFileName);


            configuration = builder.Build();
            _clientId = configuration["SpotifyClientId"];
            _secretId = configuration.GetSection("SpotifySecretId").Value;
            _HappiapiKey = configuration.GetSection("HappiApiKey").Value;
        }

        private static void TimerCallbackAsync(Object o)
        {
            
            if (api == null)
                return;

            var newsongInfo = CurrentPlayingsong(api).Result;
            if (songinfo == newsongInfo || newsongInfo == "")
                return;

            songinfo = newsongInfo;

            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine("");
            Console.WriteLine(songinfo);
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.White;
            //Read Lyrics
            HappiWebApi happiapi = new HappiWebApi(_HappiapiKey);
            GetLyrics(happiapi, songinfo);



        }

        private static string songinfo;
        private static SpotifyWebAPI api;
        private static async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
        {
            AuthorizationCodeAuth auth = (AuthorizationCodeAuth)sender;
            auth.Stop();

            Token token = await auth.ExchangeCode(payload.Code);
            api = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };
            
            songinfo = await CurrentPlayingsong(api);
            Console.WriteLine(songinfo);

            if (songinfo == "")
                return;

            Console.WriteLine("");
            HappiWebApi happiapi = new HappiWebApi(_HappiapiKey);
            GetLyrics(happiapi, songinfo);




        }


        private static async Task<string> CurrentPlayingsong(SpotifyWebAPI api)
        {
          
            SimpleCurrentsong currentsong = await api.GetUserCurrentSong();
            var songInfo = "";

            if (currentsong.Item == null)
            {
                Console.WriteLine("no playing song found");
                return "";
            }


            //If the ad was playing we will do nothing
            if (currentsong.currently_playing_type == "ad")
                return songInfo;

            
            //for finding lyrics the first Artist is enough
            songInfo += currentsong.Item.Artists.First().Name;


            //if song has something like 'Remasterd' or anything else at the end of it names the lyrics api can not find the actual Lyrics so we eliminate that part
            songInfo += $"- {currentsong.Item.Name.Split('-')[0].Trim()}";
            return songInfo;




        }

        private static async void GetLyrics(HappiWebApi api, string songInfo)

        {
            Response<List<SearchResult>> currentsong = await api.SearchItems(songInfo);
            if (currentsong.Error !=null)
            {
                Console.WriteLine($"no lyrics found - {currentsong.Error.Message}");
                return;
            }
            if (!currentsong.Result.Any())
            {
                Console.WriteLine("no lyrics found");
                return;
            }
            var lyricUrl = currentsong.Result.FirstOrDefault().ApiLyrics;

            var lyrics = await api.GetLyric(lyricUrl.OriginalString);
            if (lyrics.Result == null)
            {
                Console.WriteLine($"no lyrics found - {lyrics.Error.Message}");
                return;
            }
            Console.WriteLine(lyrics.Result.Lyrics);
        }

    }
}