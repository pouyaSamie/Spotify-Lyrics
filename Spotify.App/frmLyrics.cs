using HappiLyricsApi.Web;
using HappiLyricsApi.Web.Model;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpotifyLyrics.App
{
    public partial class frmLyrics : Form
    {

        private static string _clientId = "";
        private static string _secretId = "";
        private static string _HappiapiKey = "";
        private static SpotifyWebAPI api;
        private static string songInfo;
        public frmLyrics()
        {
            InitializeComponent();
            SetPoistion();
            SetApiKeys();


            AuthorizationCodeAuth auth =
                new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4102", "http://localhost:4102",
                    Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative | Scope.UserReadCurrentlyPlaying);
            auth.AuthReceived += AuthOnAuthReceived;
            auth.Start();
            auth.OpenBrowser();
            Timer MyTimer = new Timer();
            MyTimer.Interval = (5 * 1000); // 5 Seccond
            MyTimer.Tick += new EventHandler(CheckLyricsTick);
            MyTimer.Start();

            //Console.ReadLine();
            auth.Stop(0);

        }


        private void CheckLyricsTick(object sender, EventArgs e)
        {

            if (api == null)
                return;

            var newsongInfo = CurrentPlayingsong(api).Result;
            if (songInfo == newsongInfo || newsongInfo == "")
                return;

            songInfo = newsongInfo;
            txtLyrics.Text = "";
            this.Text = songInfo;
           
            HappiWebApi happiapi = new HappiWebApi(_HappiapiKey);
            GetLyrics(happiapi, songInfo);



        }


        private async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
        {
            AuthorizationCodeAuth auth = (AuthorizationCodeAuth)sender;
            auth.Stop();

            Token token = await auth.ExchangeCode(payload.Code);
            api = new SpotifyWebAPI
            {
                AccessToken = token.AccessToken,
                TokenType = token.TokenType
            };

            songInfo = await CurrentPlayingsong(api);


            if (songInfo == "")
                return;

            HappiWebApi happiapi = new HappiWebApi(_HappiapiKey);
            GetLyrics(happiapi, songInfo);

        }
        private  async Task<string> CurrentPlayingsong(SpotifyWebAPI api)
        {

            SimpleCurrentsong currentsong = await api.GetUserCurrentSong();
            var songInfo = "";

            if (currentsong.Item == null)
            {
                txtLyrics.Text = "no playing song found";
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
        private  async void GetLyrics(HappiWebApi api, string songInfo)

        {
            Response<List<SearchResult>> currentsong = await api.SearchItems(songInfo);
            if (currentsong.Error != null)
            {
                txtLyrics.Text = $"no lyrics found - {currentsong.Error.Message}";
                return;
            }
            if (!currentsong.Result.Any())
            {
                txtLyrics.Text = "no lyrics found";
                return;
            }
            var lyricUrl = currentsong.Result.FirstOrDefault().ApiLyrics;

            var lyrics = await api.GetLyric(lyricUrl.OriginalString);
            if (lyrics.Result == null)
            {
                txtLyrics.Text = $"no lyrics found - {lyrics.Error.Message}";
                return;
            }
            txtLyrics.Text = lyrics.Result.Lyrics;
        }


        private  void SetApiKeys()
        {

            _clientId = System.Configuration.ConfigurationManager.AppSettings["SpotifyClientId"];
            _secretId = System.Configuration.ConfigurationManager.AppSettings["SpotifySecretId"];
            _HappiapiKey = System.Configuration.ConfigurationManager.AppSettings["HappiApiKey"];

        }
        private void SetPoistion()
        {
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }
    }

}

