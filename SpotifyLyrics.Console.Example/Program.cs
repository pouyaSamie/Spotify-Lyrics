using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Lyrics.LyricsModel;
using HappiLyricsApi.Web;
using HappiLyricsApi.Web.Model;
using Microsoft.Extensions.Configuration;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using SpotifyLyrics.Console.Example.Helper;
using SpotifyLyrics.ServiceInterface.Common;
using SpotifyLyrics.ServiceInterface.Lyrics.Factory;
using SpotifyLyrics.ServiceInterface.Lyrics.LyricsServices.Happi;
using SpotifyLyrics.ServiceInterface.Spotify;

namespace SpotifyAPI.Web.Example
{
    internal static class Program
    {
        private static string _clientId = "";
        private static string _secretId = "";
        private static IConfigurationSection LyricsSectionconfig;

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
            LyricsSectionconfig = configuration.GetSection("LyricsConfig");
        }

        private static void TimerCallbackAsync(Object o)
        {


            var result = GetsongInfo();
            if (!result.IsSuccess)
                return;
            


            //Read Lyrics
            GetLyrics(result.Date);



        }

        private static ServiceResult<string> GetsongInfo()
        {

            if (api == null)
                return ServiceResult<string>.Failed("");


            var result = CurrentPlayingsong(api).Result;
            if (songinfo == result.Date || result.Date == "")
                return ServiceResult<string>.Failed("");

            songinfo = result.Date;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n\r{songinfo}\n\r");


            Console.ForegroundColor = ConsoleColor.White;


            return result;

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

            var result = GetsongInfo();
            if (!result.IsSuccess)
            {
                Console.WriteLine("Song Not found.");
                return;
            }
                

            songinfo = result.Date;
            GetLyrics(songinfo);




        }


        private async static void GetLyrics(string songInfo) {


            
            LyricsServiceFactory factory = LyricsServiceSelector.GetFactory(LyricsSectionconfig);
            var service = factory.CreateLyricsService(new SpotifyLyrics.ServiceInterface.Lyrics.Model.ConfigModel(LyricsSectionconfig));
            var lyricsSearchResult =await service.SearchItem(songInfo);

            
            // we return the first result of searched items
            var url =  lyricsSearchResult.IsSuccess ? lyricsSearchResult.Date.First().LyricUrl : "";
            if (!lyricsSearchResult.IsSuccess)
            {
                Console.WriteLine($"Lyrics Error {lyricsSearchResult.Message}");
                return;
            }
            
            var lyicsResult  = await service.DownloadLyrics(url);
            if (!lyicsResult.IsSuccess)
            {
                Console.WriteLine($"Lyrics Error {lyricsSearchResult.Message}");
                return;
            }

            Console.WriteLine(lyicsResult.Date);
        }

        private static async Task<ServiceResult<string>> CurrentPlayingsong(SpotifyWebAPI api) => 
            await SpotifyServices.CurrentPlayingsong(api);

        

    }
}