### Spotify Lyrics Grabber From Genius Lyrics or Happi Api

This application Reads current playing song from spotify Api and Grab the Lyrics from Happi api or Genius Lyrics. My Example will work for Console. you can easily develope a GUI Interface but i prefer the terminal so i won't add GUI implementation.

#### How To Use


-  Create an account from  [spotify Developer Page](https://developer.spotify.com/dashboard/login)

- add the given client Id and Client secret to appsetting.json file.(you can change the file name in config.json)

- If you want use happi api (If you want use Genius Lyrics just skip this one )
   - Create a Happi Account from [this link](https://happi.dev/ "this link")
   - Add The Api Key to appsetting.json (you can change the file name in config.json)
- for using Genius
  - remove HappiApi Section from config File and that will do it.

-via terminal navigate to SpotifyLyrics.Console.Example Folder and type dotnet run. you should see the lyrics in your terminal

### Config File 

Just Be sure set configFile in configFile.json before start

in your config file you should set your api keys and if you need you can also set proxy 

thanx to JohnnyCrazy for increadable Api : https://github.com/JohnnyCrazy/SpotifyAPI-NET
